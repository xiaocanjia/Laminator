using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using JSystem.Perform;
using BoardSys;
using JSystem.Param;
using MeasResult;

namespace JSystem.Station
{
    public class StationManager
    {
        private bool _isInit = false;

        private bool _isReseted = false;    //是否已经复位

        private bool _isRunning = false;

        public ReadCodeStation ReadCode;

        public VisionStation Vision;

        [XmlIgnore]
        public List<StationBase> StationList
        {
            get
            {
                return new List<StationBase>()
                {
                    ReadCode,
                    Vision
                };
            }
        }

        [XmlIgnore]
        public Action<string> OnSetUserRight;

        [XmlIgnore]
        public Action<string, List<MesResult>> OnSendRets;

        [XmlIgnore]
        public Func<bool> OnAlarm;

        [XmlIgnore]
        public Func<bool, bool> OnStop;

        private Dictionary<string, List<MesResult>> _retsDict;

        public StationManager()
        {
            ReadCode = new ReadCodeStation();
            Vision = new VisionStation();
            _retsDict = new Dictionary<string, List<MesResult>>();
        }

        public void SetUserRight(string right)
        {
            foreach (StationBase station in StationList)
                station.View.SetEnable(right != "操作员");
            Vision.Meas3DMgr.OnSetUserRight(right);
        }

        public void RegisterEvents()
        {
            ReadCode.OnAddSN = Vision.AddSN;
            ReadCode.OnGetScanOver = Vision.GetScanOver;
            foreach (StationBase station in StationList)
                station.OnSendRets += AddResults;
        }

        public bool Run()
        {
            try
            {
                _isInit = false;
                if (StationList.Count == 0)
                    return true;
                new Task(AxisStateMonitor).Start();
                foreach (StationBase station in StationList)
                {
                    Task task = new Task(station.Run);
                    task.Start();
                }
                _isInit = true;
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站线程初始化异常：{ex.Message}");
                return false;
            }
        }

        public bool Reset()
        {
            try
            {
                if (!_isInit)
                {
                    LogManager.Instance.AddLog($"工站未初始化");
                    return false;
                }
                if (StationList == null || StationList.Count == 0)
                    return false;
                LogManager.Instance.AddLog($"开始复位");
                _isReseted = true;
                foreach (StationBase station in StationList)
                    _isReseted &= station.Reset();
                while (!CheckIsAllStationStop())
                    Thread.Sleep(100);
                if (!_isReseted || !BoardSysIF.Instance.GetIn("急停"))
                {
                    LogManager.Instance.AddLog($"复位失败");
                    return false;
                }
                _isReseted = true;
                _isRunning = false;
                LogManager.Instance.AddLog($"复位完成");
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站复位异常：{ex.Message}");
                return false;
            }
        }

        public bool Start()
        {
            try
            {
                if (!_isReseted)
                {
                    LogManager.Instance.AddLog($"机台未复位");
                    return false;
                }
                if (StationList == null || StationList.Count == 0)
                    return false;
                foreach (StationBase station in StationList)
                    station.Start();
                LogManager.Instance.AddLog($"设备已启动");
                _isRunning = true;
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站启动异常：{ex.Message}");
                return false;
            }
        }

        public bool Pause()
        {
            try
            {
                if (!_isRunning)
                {
                    LogManager.Instance.AddLog($"工站未启动");
                    return false;
                }
                if (StationList == null || StationList.Count == 0)
                    return false;
                foreach (StationBase station in StationList)
                    station.Pause();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站暂停异常：{ex.Message}");
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                if (!_isRunning)
                    return true;
                _isReseted = false;
                _isRunning = false;
                if (StationList == null || StationList.Count == 0)
                    return true;
                foreach (StationBase station in StationList)
                    new Task(station.EndAllMove).Start();
                LogManager.Instance.AddLog($"已停止运行");
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站停止异常：{ex.Message}");
                return false;
            }
        }

        public bool End()
        {
            if (!_isInit)
                return false;
            foreach (StationBase station in StationList)
                station.End();
            return true;
        }

        private bool CheckIsAllStationStop()
        {
            bool ret = true;
            foreach (StationBase station in StationList)
                ret &= station.CheckIsAllStop();
            return ret;
        }

        private void AxisStateMonitor()
        {
            while (true)
            {
                Thread.Sleep(100);
                foreach (StationBase station in StationList)
                {
                    foreach (AxisInfo axis in station.AxesInfo)
                    {
                        axis.UpdateState();
                        if (!_isRunning || !axis.IsAlarm) continue;
                        OnStop?.Invoke(false);
                        LogManager.Instance.AddLog($"{station.Name}工站{axis.Name}轴驱动器报警，已停止");
                    }
                }
            }
        }

        private void AddResults(string sn, List<MesResult> rets)
        {
            if (!_retsDict.ContainsKey(sn))
                _retsDict.Add(sn, new List<MesResult>());
            _retsDict[sn].AddRange(rets);
        }

        private void SendResults(string sn)
        {
            OnSendRets?.Invoke(sn, _retsDict[sn]);
            ResultsLogger.SaveResult(ParamManager.GetStringParam("数据保存路径"), sn, _retsDict[sn]);
            _retsDict.Remove(sn);
        }
    }
}

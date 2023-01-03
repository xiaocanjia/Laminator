using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using BoardSys;
using JSystem.Perform;
using MeasResult;

namespace JSystem.Station
{
    public class StationBase
    {
        protected bool IsPause = true;

        protected bool IsEnd = false;

        protected bool IsRunning = false;

        protected bool HasReset = false;

        protected Queue<string> _SNQueue;
        
        public string Name;

        [XmlIgnore]
        public AxisInfo[] AxesInfo;

        protected PointInfo[] _pointsInfo;

        public PointInfo[] PointsInfo
        {
            get
            {
                return _pointsInfo;
            }
            set
            {
                for (int i = 0; i < _pointsInfo.Length; i++)
                {
                    if (value[i] == null) continue;
                    _pointsInfo[i].Pos = value[i].Pos;
                }
            }
        }

        [XmlIgnore]
        public StationView View;

        [XmlIgnore]
        public Form DebugForm;

        [XmlIgnore]
        public Action OnStartClock;

        [XmlIgnore]
        public Action OnStopClock;

        [XmlIgnore]
        public Action<string, List<MesResult>> OnSendRets;

        [XmlIgnore]
        public Action<string> OnFinish;

        public virtual void Run() { }

        public virtual void End() { IsEnd = true; }

        public virtual bool Reset()
        {
            try
            {
                foreach (AxisInfo axis in AxesInfo)
                {
                    if (axis.IsAlarm)
                    {
                        LogManager.Instance.AddLog($"{Name}{axis.Name}轴驱动器报警，无法复位", true);
                        return false;
                    }
                    BoardSysIF.Instance.StopMove(axis.BoardID, axis.AxisIndex);
                }
                foreach (AxisInfo axis in AxesInfo)
                {
                    if (!axis.IsBelt)
                        BoardSysIF.Instance.GoHome(axis.BoardID, axis.AxisIndex);
                    else
                        BoardSysIF.Instance.StopMove(axis.BoardID, axis.AxisIndex);
                    axis.IsMoving = false;
                }
                IsPause = true;
                HasReset = true;
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"{Name}复位失败：{ex.Message}");
                return false;
            }
        }

        public virtual void Start()
        {
            if (!HasReset)
                return;
            IsPause = false;
            IsRunning = true;
            for (int i = 0; i < AxesInfo.Length; i++)
            {
                if (AxesInfo[i].IsBelt && AxesInfo[i].IsMoving)
                    BoardSysIF.Instance.JogMove(AxesInfo[i].BoardID, AxesInfo[i].AxisIndex, AxesInfo[i].IsPositive, -1);
            }
        }

        public virtual void Pause()
        {
            IsPause = true;
            for (int i = 0; i < AxesInfo.Length; i++)
                BoardSysIF.Instance.StopMove(AxesInfo[i].BoardID, AxesInfo[i].AxisIndex);
        }

        public virtual void EndAllMove()
        {
            if (!IsRunning) return;
            HasReset = false;
            IsRunning = false;
            IsPause = true;
            for (int i = 0; i < AxesInfo.Length; i++)
                BoardSysIF.Instance.StopMove(AxesInfo[i].BoardID, AxesInfo[i].AxisIndex);
            AddLog($"所有轴停止运动");
        }

        protected double[] GetPos(string posName)
        {
            double[] pos = new double[AxesInfo.Length];
            var list = PointsInfo.Where(posInfo => posInfo.Name == posName).ToList();
            if (list == null || list.Count == 0)
            {
                AddLog($"列表中没有{posName}");
                return null;
            }
            return list[0].Pos;
        }

        /// <summary>
        /// 移动到固定点位（默认同步）
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="speed"></param>
        /// <param name="isAsyn">false：同步，true：异步</param>
        /// <returns></returns>
        protected bool MoveToPos(double[] pos, double speed = -1,  bool isAsyn = false)
        {
            try
            {
                int idx = 0;
                for (int i = 0; i < AxesInfo.Length; i++)
                {
                    if (AxesInfo[i].IsBelt)
                        continue;
                    BoardSysIF.Instance.AbsMove(AxesInfo[i].BoardID, AxesInfo[i].AxisIndex, pos[idx], speed);
                    idx++;
                }
                while (!CheckIsAllStop() && !isAsyn)
                    Thread.Sleep(100);
                if (IsRunning && IsPause)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                AddLog($"移动到固定点位失败：{ex.Message}");
                return false;
            }
        }

        protected bool MoveToPos(string axisName, double pos, double speed = -1, bool isAsyn = false)
        {
            try
            {
                AxisInfo axis = GetAxisByName(axisName);
                if (axis == null) return false;
                AddLog($"{axisName}轴移动到{pos}");
                BoardSysIF.Instance.AbsMove(axis.BoardID, axis.AxisIndex, pos, speed);
                while (!CheckIsStop(axisName) && !isAsyn)
                    Thread.Sleep(100);
                if (IsRunning && IsPause)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                AddLog($"移动到固定点位失败：{ex.Message}");
                return false;
            }
        }

        public bool CheckIsAllStop()
        {
            bool ret = true;
            foreach (AxisInfo axis in AxesInfo)
                ret &= BoardSysIF.Instance.CheckIsStop(axis.BoardID, axis.AxisIndex);
            return ret;
        }

        protected bool CheckIsStop(string axisName)
        {
            AxisInfo axis = GetAxisByName(axisName);
            if (axis == null) return false;
            return BoardSysIF.Instance.CheckIsStop(axis.BoardID, axis.AxisIndex);
        }

        protected bool EndMove(string axisName)
        {
            try
            {
                AxisInfo axis = GetAxisByName(axisName);
                if (axis == null) return false;
                AddLog($"{axisName}停止运动");
                BoardSysIF.Instance.StopMove(axis.BoardID, axis.AxisIndex);
                axis.IsMoving = false;
                return true;
            }
            catch (Exception ex)
            {
                AddLog($"{axisName}轴停止运动失败：{ex.Message}");
                return false;
            }
        }
        
        protected bool JogMove(string axisName, bool isPositive, double speed = -1)
        {
            try
            {
                AxisInfo axis = GetAxisByName(axisName);
                if (axis == null) return false;
                axis.IsPositive = isPositive;
                axis.IsMoving = true;
                BoardSysIF.Instance.JogMove(axis.BoardID, axis.AxisIndex, isPositive, speed);
                AddLog($"移动{axisName}");
                return true;
            }
            catch (Exception ex)
            {
                AddLog($"{axisName}轴连续移动失败：{ex.Message}");
                return false;
            }
        }

        private AxisInfo GetAxisByName(string name)
        {
            var list = AxesInfo.Where(axis => axis.Name == name).ToList();
            if (list == null || list.Count == 0)
            {
                AddLog($"{Name}没有{name}轴");
                return null;
            }
            return list[0];
        }

        protected bool GetIn(string name)
        {
            try
            {
                return BoardSysIF.Instance.GetIn(name);
            }
            catch (Exception ex)
            {
                AddLog($"读取“{name}”信号失败，请确认是否有该IO：{ex.Message}");
                return false;
            }
        }

        protected void SetOut(string name, bool value)
        {
            try
            {
                BoardSysIF.Instance.SetOut(name, value);
                LogManager.Instance.AddLog($"{Name} 信号{name}设置为{value}");
            }
            catch (Exception ex)
            {
                AddLog($"设置“{name}”信号失败，请确认是否有该IO：{ex.Message}");
            }
        }

        protected void AddLog(string log, bool isError = false)
        {
            LogManager.Instance.AddLog(Name + " " + log, isError);
        }

        public void AddSN(string sn)
        {
            if (!IsRunning)
                return;
            if (_SNQueue == null)
                _SNQueue = new Queue<string>();
            _SNQueue.Enqueue(sn);
        }
    }
}

using System;
using System.Threading.Tasks;
using BoardSys;
using JSystem.Param;
using JSystem.Perform;

namespace JSystem.IO
{
    public class IOManager
    {
        public Action<string> OnSetUserRight;

        private bool _isStart = false;

        public Func<bool> OnInit;

        public Func<bool> OnStart;

        public Func<bool, bool> OnStop;

        public Func<bool> OnPause;

        public Func<bool> OnAlarm;

        public Action OnClearAlarm;

        private DateTime _start;

        private bool _isPress;

        public IOManager()
        {
        }

        public void Init()
        {
            BoardSysIF.Instance.SetOut("电源指示灯", true);
            BoardSysIF.Instance.SetOut("黄灯", true);
            BoardSysIF.Instance.SetOut("Z轴刹车", true);
            BoardSysIF.Instance.SetOut("相机光源", true);
            new Task(MonitorIO).Start();
        }

        public void StartMonitor()
        {
            _isStart = true;
        }

        public void StopMonitor()
        {
            _isStart = false;
        }

        public void SetUserRight(string right)
        {
            OnSetUserRight(right);
        }

        private void MonitorIO()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(10);
                if (BoardSysIF.Instance.GetIn("复位"))
                {
                    _isPress = true;
                    _start = DateTime.Now;
                }
                if (_isPress && !BoardSysIF.Instance.GetIn("复位"))
                {
                    if (DateTime.Now.Subtract(_start).TotalSeconds < 5)
                        OnClearAlarm?.Invoke();
                    else
                        OnInit?.Invoke();
                    _isPress = false;
                }
                if (BoardSysIF.Instance.GetIn("启动"))
                    OnStart?.Invoke();
                if (BoardSysIF.Instance.GetIn("停止"))
                    OnPause?.Invoke();
                if (!_isStart) continue;
                if (CheckDoorIsOn("前") || CheckDoorIsOn("后") ||
                    CheckDoorIsOn("左") || CheckDoorIsOn("右") ||
                    CheckPressureLack())
                    OnAlarm?.Invoke();
                if (CheckEmgStop())
                    OnStop?.Invoke(false);
            }
        }

        public bool CheckDoorIsOn(string door)
        {
            if (ParamManager.GetBoolParam("禁用安全门"))
                return false;
            if (BoardSysIF.Instance.GetIn($"{door}门禁"))
                return false;
            LogManager.Instance.AddLog($"{door}门被打开");
            return true;
        }

        public bool CheckHasPdt(int stationIdx)
        {
            if (!BoardSysIF.Instance.GetIn($"皮带线{stationIdx}感应有料"))
                return false;
            LogManager.Instance.AddLog($"工位{stationIdx}感应有料");
            return true;
        }

        public bool CheckEmgStop()
        {
            if (BoardSysIF.Instance.GetIn("急停"))
                return false;
            LogManager.Instance.AddLog($"急停被按下");
            return true;
        }

        public bool CheckPressureLack()
        {
            if (BoardSysIF.Instance.GetIn("气压数显表"))
                return false;
            LogManager.Instance.AddLog($"气压不足");
            return true;
        }
    }
}

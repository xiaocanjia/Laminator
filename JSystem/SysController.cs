using System;
using System.IO;
using JSystem.Perform;
using JSystem.Station;
using JSystem.Device;
using JSystem.IO;
using JSystem.User;
using JSystem.Param;
using JSystem.Project;
using BoardSys;
using Serilizer;
using JSystem.JEnum;

namespace JSystem
{
    public class SysController
    {
        public SysManagers SysMgrs;

        public ProjectManager ProjectMgr;

        public PerformManager PerformMgr;

        public LoginManager LoginMgr;

        public StationManager StationMgr;

        public DeviceManager DeviceMgr;

        public IOManager IOMgr;

        public ParamManager ParamMgr;

        public Action OnInitUI;

        public Action<bool> OnSetEnable;

        public SysController()
        {
            IOMgr = new IOManager();
            SysMgrs = new SysManagers();
            LoginMgr = new LoginManager();
            ProjectMgr = new ProjectManager();
            PerformMgr = new PerformManager();
            LoadProject(ProjectMgr.ProjectPath);
        }

        public bool Init()
        {
            if (DeviceMgr.CurrState == EDeviceState.INITING)
                return false;
            DeviceMgr.UpdateState(EDeviceState.INITING);
            LogManager.Instance.AddLog("开始初始化");
            bool ret = true;
            ret &= BoardSysIF.Instance.Init(out string msg);
            LogManager.Instance.AddLog(msg);
            ret &= DeviceMgr.Init(out msg);
            LogManager.Instance.AddLog(msg);
            if (!ret)
            {
                DeviceMgr.UpdateState(EDeviceState.ALARM);
                LogManager.Instance.AddLog("初始化失败");
                return false;
            }
            IOMgr.Init();
            if (IOMgr.CheckDoorIsOn("前") || IOMgr.CheckDoorIsOn("后") ||
                IOMgr.CheckDoorIsOn("左") || IOMgr.CheckDoorIsOn("右") ||
                IOMgr.CheckEmgStop() || IOMgr.CheckPressureLack())
            {
                DeviceMgr.UpdateState(EDeviceState.ALARM);
                LogManager.Instance.AddLog("初始化失败");
                return false;
            }
            if (IOMgr.CheckHasPdt(1) || IOMgr.CheckHasPdt(2) ||
                IOMgr.CheckHasPdt(3) || IOMgr.CheckHasPdt(4))
            {
                BoardSysIF.Instance.SetOut("顶升缸", false);
                BoardSysIF.Instance.SetOut("阻挡缸2", false);
                LogManager.Instance.AddLog("初始化失败，请取料");
                return false;
            }
            System.Threading.Thread.Sleep(1000);
            if (!StationMgr.Reset())
            {
                DeviceMgr.UpdateState(EDeviceState.ALARM);
                LogManager.Instance.AddLog("初始化失败");
                return false;
            }
            DeviceMgr.UpdateState(EDeviceState.INITED);
            LogManager.Instance.AddLog("初始化完成");
            return true;
        }

        public bool Start()
        {
            if (DeviceMgr.CurrState == EDeviceState.UNINIT)
            {
                LogManager.Instance.AddLog("请先初始化");
                return false;
            }
            if (DeviceMgr.CurrState == EDeviceState.ALARM)
            {
                LogManager.Instance.AddLog("请先清除报警");
                return false;
            }
            if (DeviceMgr.CurrState == EDeviceState.RUN)
            {
                LogManager.Instance.AddLog("请先清除报警");
                return false;
            }
            if (!StationMgr.Start())
                return false;
            IOMgr.StartMonitor();
            OnSetEnable?.Invoke(false);
            PerformMgr.SetButtonState(true);
            DeviceMgr.UpdateState(EDeviceState.RUN);
            return true;
        }

        public bool Pause()
        {
            if (DeviceMgr.CurrState != EDeviceState.RUN)
                return false;
            if (!StationMgr.Pause())
                return false;
            IOMgr.StopMonitor();
            PerformMgr.SetButtonState(false);
            DeviceMgr.UpdateState(EDeviceState.PAUSE);
            return true;
        }

        public bool Stop(bool isNormal)
        {
            if (StationMgr == null || !StationMgr.Stop())
                return false;
            IOMgr.StopMonitor();
            OnSetEnable?.Invoke(true);
            PerformMgr.SetButtonState(false);
            if (isNormal)
                DeviceMgr.UpdateState(EDeviceState.INITED);
            else
                DeviceMgr.UpdateState(EDeviceState.ALARM);
            return true;
        }

        public bool Alarm()
        {
            if (!StationMgr.Pause())
                return false;
            IOMgr.StopMonitor();
            PerformMgr.SetButtonState(false);
            DeviceMgr.UpdateState(EDeviceState.ALARM);
            return true;
        }

        public void ClearAlarm()
        {
            if (IOMgr.CheckDoorIsOn("前") || IOMgr.CheckDoorIsOn("后") ||
                IOMgr.CheckDoorIsOn("左") || IOMgr.CheckDoorIsOn("右") ||
                IOMgr.CheckEmgStop() || IOMgr.CheckPressureLack())
            {
                LogManager.Instance.AddLog("无法清除报警");
                return;
            }
            DeviceMgr.UpdateState(EDeviceState.PAUSE);
        }

        public void UnInit()
        {
            IOMgr.StopMonitor();
            StationMgr?.End();
            //BoardSysIF.Instance.SetOut("Z轴刹车", false);  
            Stop(true);
        }

        private bool SaveProject(string filePath)
        {
            try
            {
                SysMgrs.StationMgr = StationMgr;
                SysMgrs.ParamMgr = ParamMgr;
                SysMgrs.DeviceMgr = DeviceMgr;
                XMLSerializer.Serialize(SysMgrs, filePath);
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"项目文件保存失败：{ex.Message}", true);
                return false;
            }
        }

        private bool LoadProject(string filePath)
        {
            try
            {
                StationMgr?.End();
                if (!File.Exists(filePath))
                {
                    StationMgr = new StationManager();
                    DeviceMgr = new DeviceManager();
                    ParamMgr = new ParamManager();
                }
                else
                {
                    SysMgrs = XMLSerializer.Deserialize<SysManagers>(filePath);
                    DeviceMgr = SysMgrs.DeviceMgr ?? new DeviceManager();
                    StationMgr = SysMgrs.StationMgr ?? new StationManager();
                    ParamMgr = SysMgrs.ParamMgr ?? new ParamManager();
                }
                StationMgr.Run();
                RegisterEvents();
                OnInitUI?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"项目文件加载失败：{ex.Message}");
                return false;
            }
        }

        private void RegisterEvents()
        {
            ProjectMgr.OnLoadProject = LoadProject;
            ProjectMgr.OnSaveProject = SaveProject;
            PerformMgr.OnInit = Init;
            PerformMgr.OnStart = Start;
            PerformMgr.OnPause = Pause;
            PerformMgr.OnStop = Stop;
            PerformMgr.OnClearAlarm = ClearAlarm;
            IOMgr.OnInit = Init;
            IOMgr.OnStart = Start;
            IOMgr.OnStop = Stop;
            IOMgr.OnPause = Pause;
            IOMgr.OnAlarm = Alarm;
            IOMgr.OnClearAlarm = ClearAlarm;
            StationMgr.OnStop = Stop;
            StationMgr.OnAlarm = Alarm;
            StationMgr.OnSendRets = PerformMgr.UpdateRusults;
            StationMgr.ReadCode.OnStartClock = PerformMgr.StatisticsMgr.StartClock;
            StationMgr.Vision.OnStopClock = PerformMgr.StatisticsMgr.StopClock;
            StationMgr.Vision.RegisterEvents(DeviceMgr.Cam3D1, DeviceMgr.Cam3D2);
            StationMgr.ReadCode.RegisterEvents(DeviceMgr.Cam2D);
            LoginMgr.OnSetUserRight += IOMgr.SetUserRight;
            LoginMgr.OnSetUserRight += StationMgr.SetUserRight;
            LoginMgr.OnSetUserRight += DeviceMgr.SetUserRight;
            LoginMgr.OnSetUserRight += ProjectMgr.SetUserRight;
            StationMgr.RegisterEvents();
        }
    }
}

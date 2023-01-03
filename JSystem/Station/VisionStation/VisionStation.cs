using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BSLib;
using Meas3D;
using Serilizer;
using JSystem.Param;
using JSystem.Device;

namespace JSystem.Station
{
    public class VisionStation : StationBase
    {
        enum EStationStep
        {
            ARRIVAL,    //进站
            CHECKINPOS, //检查是否到位
            JACK,       //顶升气缸上升
            MEAS,       //测试
            DEPARTURE   //出站
        }
        
        private EStationStep _step;

        private int _measStep = 0;  //测量步骤，在大节点MEAS中

        private Camera3D _cam3D1;

        private Camera3D _cam3D2;

        public Meas3DManager Meas3DMgr;

        [XmlIgnore]
        public Func<bool> OnGetHasTaken;

        [XmlIgnore]
        public Action OnSetHasTaken;

        private int _pdtIdx = 0;    //当前产品序号 pdt-product

        private bool _isEndScan = false;

        private string _currSN = "";

        private bool _isScanOver1 = true;

        private bool _isScanOver2 = true;

        public double ScanSpeed = 50.0;

        public double PCLLength = 50.0;

        public int JointCount = 1;

        public int GrabCount = 1;

        public VisionStation()
        {
            try
            {
                Name = "视觉工站";
                AxesInfo = XMLSerializer.Deserialize<AxisInfo[]>($"{AppDomain.CurrentDomain.BaseDirectory}Config/VisionStation.xml");
                _pointsInfo = new PointInfo[1] { new PointInfo("扫描起始位") };
                Meas3DMgr = new Meas3DManager("P1");
                DebugForm = new VisionStationForm(this);
                View = new StationView(this);
                _step = EStationStep.ARRIVAL;
            }
            catch (Exception ex)
            {
                AddLog($"视觉工站初始化异常：{ex.Message}");
            }
        }

        public void RegisterEvents(Camera3D cam3D1, Camera3D cam3D2)
        {
            _cam3D1 = cam3D1;
            _cam3D2 = cam3D2;
            Meas3DMgr.OnStartGrab = StartGrab;
            Meas3DMgr.OnEndScan = EndGrab;
            Meas3DMgr.RegisterEvents();
        }

        public override void Run()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(10);
                    if (IsEnd) return;
                    if (IsPause) continue;
                    switch (_step)
                    {
                        case EStationStep.ARRIVAL:
                            if (GetIn("阻挡缸2右下到位") && GetIn("阻挡缸2左下到位") &&
                                GetIn("阻挡缸3右上到位") && GetIn("阻挡缸3左上到位") &&
                               (GetIn("皮带线2感应有料") || ParamManager.GetBoolParam("空跑模式")) &&
                                CheckIsStop("皮带线3"))
                            {
                                MoveToPos(GetPos("扫描起始位"), -1, true);
                                JogMove("皮带线3", false);
                                AddLog("等待产品移动到皮带线3");
                                _step = EStationStep.CHECKINPOS;
                            }
                            break;
                        case EStationStep.CHECKINPOS:
                            if (GetIn("皮带线3感应有料") || ParamManager.GetBoolParam("空跑模式"))
                            {
                                if (ParamManager.GetBoolParam("空跑模式"))
                                    Thread.Sleep(3000);
                                EndMove("皮带线3");
                                AddLog("产品已到达阻挡位");
                                _step = EStationStep.JACK;
                            }
                            break;
                        case EStationStep.JACK:
                            if (CheckIsStop("皮带线3"))
                            {
                                Thread.Sleep(100);
                                SetOut("顶升缸", true);
                                if (!ParamManager.GetBoolParam("空跑模式"))
                                    SetOut("真空", true);
                                _step = EStationStep.MEAS;
                                AddLog("开始检测");
                            }
                            break;
                        case EStationStep.MEAS:
                            if (GetIn("顶升缸升到位")/* && (GetIn("真空表") || (bool)OnGetParam("空跑模式"))*/)
                            {
                                StartGrab();
                                OnStopClock?.Invoke();
                                MoveToPos(GetPos("扫码位"), -1, true);
                                if (!ParamManager.GetBoolParam("空跑模式"))
                                    SetOut("真空", false);
                                SetOut("顶升缸", false);
                                AddLog("等待顶升气缸下降");
                                _step = EStationStep.DEPARTURE;
                            }
                            break;
                        case EStationStep.DEPARTURE:
                            if (GetIn("顶升缸降到位") && !GetIn("皮带线4感应有料"))
                            {
                                SetOut("阻挡缸3", false);
                                JogMove("皮带线3", false);
                                Thread.Sleep(4000);
                                EndMove("皮带线3");
                                SetOut("阻挡缸3", true);
                                AddLog($"移料完成");
                                _step = EStationStep.ARRIVAL;
                            }
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"视觉工站发生异常：{ex.Message}", true);
            }
        }

        public bool StartGrab()
        {
            try
            {
                if (!_cam3D1.CheckConnection())
                    return false;
                double sidesway = _cam3D1.ValidWidth;
                Meas3DMgr.CalibMgr.SetValidWidth(sidesway);
                double extDist = 1;
                double[] pos = GetPos("扫描起始位");
                _isEndScan = false;

                JMatrix3D matrix3D1 = null;
                JMatrix3D matrix3D2 = null;
                double[] startPos = { pos[0], pos[1], pos[2] };
                bool scanFinished = false;
                while (!scanFinished)
                {
                    if (_isEndScan)
                    {
                        _measStep = 0;
                        return true;
                    }
                    if (IsRunning && IsPause)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    switch (_measStep)
                    {
                        case 0:
                            if (_isScanOver1 && _isScanOver2)
                            {
                                new Task(() =>
                                {
                                    _isScanOver1 = false;
                                    matrix3D1 = _cam3D1.GrabImage(PCLLength, JointCount);
                                    _isScanOver1 = true;
                                }).Start();
                                new Task(() =>
                                {
                                    _isScanOver2 = false;
                                    matrix3D2 = _cam3D2.GrabImage(PCLLength, JointCount);
                                    _isScanOver2 = true;
                                }).Start();
                                _measStep = 1;
                            }
                            break;
                        case 1:
                            if (_cam3D1.GetIsScanning() && _cam3D2.GetIsScanning())
                            {
                                double[] currPos = { startPos[0] - _pdtIdx * 0.1, startPos[1], startPos[2] };
                                if (!MoveToPos(currPos))
                                    break;
                                AddLog($"移动到产品{_pdtIdx + 1}检测位置1");
                                _cam3D1.ReceiveTrigger();
                                _cam3D2.ReceiveTrigger();
                                _measStep = 2;
                            }
                            break;
                        case 2:
                            if (_cam3D1.GetIsOn() && _cam3D2.GetIsOn())
                            {
                                double[] currPos = { startPos[0] + PCLLength + extDist + _pdtIdx * 0.1, startPos[1], startPos[2] };
                                if (!MoveToPos(currPos, ScanSpeed))
                                    break;
                                AddLog($"移动到产品{_pdtIdx + 1}检测位置{2}");
                                _measStep = 3;
                            }
                            break;
                        case 3:
                            if (_isScanOver1 && _isScanOver2)
                            {
                                if (matrix3D1 == null || matrix3D2 == null)
                                {
                                    AddLog($"点云数据采集失败，请检查是否开启批处理模式");
                                    break;
                                }
                                else
                                {
                                    JMatrix3D matrix3D = matrix3D1.Combine(matrix3D2);
                                    Meas3DMgr.UpdateResult(matrix3D);
                                    OnSendRets?.Invoke(_currSN, Meas3DMgr.ToolMgr.GetResults());
                                    _measStep = 0;
                                    scanFinished = true;
                                }
                            }
                            break;
                    }
                }
                if (Meas3DMgr.CurrDecision == "FAIL" && IsRunning)
                    SetOut("NG红色指示灯", true);
                else if (IsRunning)
                    SetOut("OK绿色指示灯", true);
                _pdtIdx = 0;
                _isScanOver1 = true;
                _isScanOver2 = true;
                return true;
            }
            catch (Exception ex)
            {
                AddLog($"开始扫描发生异常：{ex.Message}", true);
                return false;
            }
        }

        public override void EndAllMove()
        {
            base.EndAllMove();
            _isScanOver1 = true;
            _isScanOver2 = true;
            _SNQueue.Clear();
            _isEndScan = true;
            _cam3D1.EndGrab();
            _pdtIdx = 0;
        }

        public override bool Reset()
        {
            _step = EStationStep.ARRIVAL;
            SetOut("阻挡缸3", true);
            return base.Reset();
        }

        public void EndGrab()
        {
            EndMove("X");
            EndMove("Y");
            EndMove("Z");
            _pdtIdx = 0;
            _isScanOver1 = true;
            _isScanOver2 = true;
            _isEndScan = true;
        }

        public bool GetScanOver()
        {
            return true;
        }
    }
}

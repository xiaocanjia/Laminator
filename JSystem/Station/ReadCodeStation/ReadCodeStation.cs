using System;
using System.Threading;
using System.Xml.Serialization;
using Serilizer;
using JSystem.Device;
using Meas2D;
using HalconDotNet;
using JSystem.Param;

namespace JSystem.Station
{
    public class ReadCodeStation : StationBase
    {
        enum EStationStep
        {
            ARRIVAL,    //进站
            CHECKINPOS, //检查是否到位
            SCANCODE,   //扫码
            DEPARTURE,  //出站
            FINISH      //出站结束
        }

        private Camera2D _cam2D;
        
        public Meas2DManager Meas2DMgr;

        [XmlIgnore]
        public Action<string> OnAddSN;

        [XmlIgnore]
        public Func<bool> OnGetScanOver;

        private EStationStep _step;

        private int _pdtIdx = 0;            //当前产品序号 pdt-product
        
        private int _scanStep = 0;  //扫码步骤，在大节点SCANCODE中

        public ReadCodeStation()
        {
            try
            {
                Name = "扫码工站";
                AxesInfo = XMLSerializer.Deserialize<AxisInfo[]>($"{AppDomain.CurrentDomain.BaseDirectory}Config/ReadCodeStation.xml");
                _pointsInfo = new PointInfo[1] { new PointInfo("扫码位") };
                Meas2DMgr = new Meas2DManager();
                DebugForm = new ReadCodeStationFrom(this);
                View = new StationView(this);
                _step = EStationStep.ARRIVAL;
                _pdtIdx = 0;
            }
            catch (Exception ex)
            {
                AddLog($"上料工站初始化异常：{ex.Message}", true);
            }
        }

        public void RegisterEvents(Camera2D cam2D)
        {
            _cam2D = cam2D;
            Meas2DMgr.OnStartGrab = StartGrab;
            Meas2DMgr.RegisterEvents();
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
                            if (GetIn("阻挡缸1右下到位") && !GetIn("阻挡缸1右上到位") &&
                               GetIn("阻挡缸2右上到位") && CheckIsStop("皮带线2"))
                            {
                                JogMove("皮带线2", false);
                                _step = EStationStep.CHECKINPOS;
                                AddLog($"等待产品移动到皮带线2");
                            }
                            break;
                        case EStationStep.CHECKINPOS:
                            if (GetIn("皮带线2感应有料") || ParamManager.GetBoolParam("空跑模式"))
                            {
                                EndMove("皮带线2");
                                AddLog($"等待扫码");
                                OnStartClock?.Invoke();
                                _step = EStationStep.SCANCODE;
                            }
                            break;
                        case EStationStep.SCANCODE:
                            if (CheckIsStop("皮带线2") && OnGetScanOver())
                            {
                                StartGrab();
                                AddLog($"扫码完成，等待移料");
                                _step = EStationStep.DEPARTURE;
                            }
                            break;
                        case EStationStep.DEPARTURE:
                            if (!GetIn("皮带线3感应有料") && GetIn("阻挡缸3左上到位") && GetIn("阻挡缸3右上到位"))
                            {
                                SetOut("阻挡缸2", false);
                                JogMove("皮带线2", false);
                                AddLog($"开始移料");
                                _step = EStationStep.FINISH;
                            }
                            break;
                        case EStationStep.FINISH:
                            if ((GetIn("皮带线3感应有料") || ParamManager.GetBoolParam("空跑模式")))
                            {
                                if (ParamManager.GetBoolParam("空跑模式"))
                                    Thread.Sleep(3000);
                                EndMove("皮带线2");
                                AddLog($"移料完成");
                                SetOut("阻挡缸2", true);
                                Thread.Sleep(500);
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
                AddLog($"扫码工站发生异常：{ex.Message}", true);
            }
        }

        public void StartGrab()
        {
            try
            {
                double[] pos = GetPos("扫码位");
                int count = ParamManager.GetIntParam("产品个数");
                double interval = ParamManager.GetDoubleParam("产品间距");
                SetOut("相机光源", false);
                _cam2D.Open();
                Thread.Sleep(100);
                for (;_pdtIdx < count; _pdtIdx++)
                {
                    bool scanFinished = false;
                    while (!scanFinished)
                    {
                        if (IsRunning && IsPause)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        switch (_scanStep)
                        {
                            case 0:
                                double[] currPos = { pos[0] - _pdtIdx * interval, pos[1], pos[2] };
                                MoveToPos(currPos, -1, false);
                                if (!MoveToPos(currPos))
                                    break;
                                AddLog($"移动到扫码位{_pdtIdx + 1}");
                                _scanStep = 1;
                                break;
                            case 1:
                                _cam2D.GrabImage(out HImage image);
                                Meas2DMgr.UpdateImage(image);
                                string code = Meas2DMgr.ToolMgr.GetCode();
                                OnAddSN?.Invoke($"{code}-{DateTime.Now.ToString("HHmmssffff")}");
                                if (code == "")
                                    AddLog($"检测不到二维码，将不进行检测");
                                else
                                    AddLog($"当前SN码：{code}");
                                _scanStep = 0;
                                break;
                        }
                    }
                }
                _cam2D.Close();
                SetOut("相机光源", true);
                _pdtIdx = 0;
            }
            catch (Exception ex)
            {
                AddLog($"扫码发生异常：{ex.Message}", true);
            }
        }

        public override bool Reset()
        {
            try
            {
                SetOut("阻挡缸2", true);
                SetOut("相机光源", true);
                EndMove("皮带线2");
                IsPause = true;
                HasReset = true;
                _step = EStationStep.ARRIVAL;
                return true;
            }
            catch  (Exception ex)
            {
                AddLog($"皮带线2停止异常{ex.Message}", true);
                return false;
            }
        }
    }
}

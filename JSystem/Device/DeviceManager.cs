using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoardSys;
using JSystem.JEnum;
using JSystem.Param;
using System.Drawing;
using System.Xml.Serialization;

namespace JSystem.Device
{
    public class DeviceManager
    {
        public Camera2D Cam2D;

        public Camera3D Cam3D1;

        public Camera3D Cam3D2;

        public ScanningGun Gun;

        [XmlIgnore]
        public List<DeviceBase> DeviceList
        {
            get
            {
                return new List<DeviceBase>()
                {
                    Cam2D,
                    Cam3D1,
                    Cam3D2,
                    Gun
                };
            }
        }

        [XmlIgnore]
        public Action<string> OnSetUserRight;

        [XmlIgnore]
        public Action<string, Color> OnUpdateView;

        private bool _isTwinkle = false;

        [XmlIgnore]
        public EDeviceState CurrState = EDeviceState.UNINIT;

        public DeviceManager()
        {
            Cam2D = new Camera2D("扫码相机");
            Cam3D1 = new Camera3D("3D线扫1");
            Cam3D2 = new Camera3D("3D线扫2");
            Gun = new ScanningGun("扫码枪");
        }

        public bool Init(out string msg)
        {
            bool ret = true;
            msg = "";
            foreach (DeviceBase device in DeviceList)
            {
                if (device.CheckConnection())
                {
                    msg += $"{device.Name}初始化成功；";
                    continue;
                }
                if (!device.Connect())
                {
                    ret &= false;
                    msg += $"{device.Name}初始化失败；";
                    continue;
                }
                msg += $"{device.Name}初始化成功；";
            }
            return ret;
        }

        public void UpdateState(EDeviceState state)
        {
            CurrState = state;
            BoardSysIF.Instance.SetOut("蜂鸣器", false);
            if (_isTwinkle == true)
            {
                Thread.Sleep(500);
                _isTwinkle = false;
            }
            switch (state)
            {
                case EDeviceState.UNINIT:
                    Close("红灯");
                    Close("绿灯");
                    Open("黄灯");
                    Close("启动指示灯");
                    Close("停止指示灯");
                    OnUpdateView?.Invoke("未初始化", Color.Orange);
                    break;
                case EDeviceState.INITING:
                    Close("黄灯");
                    Twinkle("绿灯");
                    Close("红灯");
                    Open("复位指示灯");
                    Close("启动指示灯");
                    Close("停止指示灯");
                    Close("报警指示灯");
                    OnUpdateView?.Invoke("初始化中", Color.Green);
                    break;
                case EDeviceState.INITED:
                    Open("黄灯");
                    Close("绿灯");
                    Close("红灯");
                    Open("停止指示灯");
                    Close("启动指示灯");
                    Close("复位指示灯");
                    Close("报警指示灯");
                    Close("测试指示灯");
                    OnUpdateView?.Invoke("初始化完成", Color.Orange);
                    break;
                case EDeviceState.RUN:
                    Close("黄灯");
                    Open("绿灯");
                    Close("红灯");
                    Open("测试指示灯");
                    Open("启动指示灯");
                    Close("停止指示灯");
                    OnUpdateView?.Invoke("运行中", Color.Green);
                    break;
                case EDeviceState.PAUSE:
                    Open("黄灯");
                    Twinkle("绿灯");
                    Close("红灯");
                    Close("启动指示灯");
                    Open("停止指示灯");
                    Close("报警指示灯");
                    OnUpdateView?.Invoke("暂停中", Color.Green);
                    break;
                case EDeviceState.ALARM:
                    Close("黄灯");
                    Close("绿灯");
                    Open("红灯");
                    Close("测试指示灯");
                    Close("启动指示灯");
                    Open("报警指示灯");
                    if (!ParamManager.GetBoolParam("禁用蜂鸣器"))
                        BoardSysIF.Instance.SetOut("蜂鸣器", true);
                    OnUpdateView?.Invoke("报警", Color.Red);
                    break;
                default:
                    OnUpdateView?.Invoke("错误状态", Color.Red);
                    break;
            }
        }

        private void Twinkle(string led)
        {
            _isTwinkle = true;
            new Task(() =>
            {
                if (!_isTwinkle)
                    return;
                Open(led);
                Thread.Sleep(300);
                Close(led);
                Thread.Sleep(300);
            }).Start();
        }

        private void Open(string led)
        {
            BoardSysIF.Instance.SetOut(led, true);
        }

        private void Close(string led)
        {
            BoardSysIF.Instance.SetOut(led, false);
        }

        public void SetUserRight(string right)
        {
            foreach (DeviceBase device in DeviceList)
                device.SetUserRight(right);
        }
    }
}

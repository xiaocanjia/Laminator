using System;
using System.Runtime.InteropServices;
using MvCamCtrl.NET;

namespace Camera2DSDK
{
    public class MVDevice : I2DCamera
    {
        private MyCamera _camera = new MyCamera();

        private MyCamera.MV_CC_DEVICE_INFO device;

        public bool Connect(string name)
        {
            MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            int ret = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
            for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
            {
                device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                string deviceName = "";
                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    deviceName = gigeInfo.chUserDefinedName;
                }
                else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                {
                    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                    MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    deviceName = usbInfo.chUserDefinedName;
                }
                if (deviceName == name)
                {
                    ret += _camera.MV_CC_CreateDevice_NET(ref device);
                    ret += _camera.MV_CC_OpenDevice_NET();
                    ret += _camera.MV_CC_SetTriggerSource_NET((uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                    ret += _camera.MV_CC_SetAcquisitionMode_NET((uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
                    ret += _camera.MV_CC_SetTriggerMode_NET((uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                    if (ret != 0)
                        return false;
                    return true;
                }
            }
            return false;
        }

        public void Disconnect()
        {
            _camera?.MV_CC_CloseDevice_NET();
            _camera?.MV_CC_DestroyDevice_NET();
        }

        public bool CheckConnection()
        {
            return _camera?.MV_CC_GetDeviceInfo_NET(ref device) == 0 ? true : false;
        }

        public void GrabImage(out IntPtr pData, out int width, out int height)
        {
            GetIntValue("PayloadSize", out uint nPayloadSize);
            byte[] buffer = new byte[nPayloadSize + 2048];
            pData = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
            MyCamera.MV_FRAME_OUT_INFO_EX info = new MyCamera.MV_FRAME_OUT_INFO_EX();
            int ret = _camera.MV_CC_GetOneFrameTimeout_NET(pData, nPayloadSize, ref info, 1000);
            width = info.nWidth;
            height = info.nHeight;
        }

        private int GetIntValue(string strKey, out uint value)
        {
            var strParam = new MyCamera.MVCC_INTVALUE();
            int ret = _camera.MV_CC_GetIntValue_NET(strKey, ref strParam);
            value = ret == 0 ? strParam.nCurValue : 0;
            return ret;
        }

        public void SwitchSoftTrigger(bool isOn)
        {
            //if (isOn)
            //    _camera.MV_CC_SetTriggerMode_NET((uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            //else
            //    _camera.MV_CC_SetTriggerMode_NET((uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
        }

        public void Open()
        {
            _camera?.MV_CC_StartGrabbing_NET();
        }

        public void Close()
        {
            _camera?.MV_CC_StopGrabbing_NET();
        }

        public void TriggerOnce()
        {
            _camera?.MV_CC_TriggerSoftwareExecute_NET();
        }

        public object GetParams(EParamNames name)
        {
            throw new NotImplementedException();
        }

        public void SetParams(EParamNames name, object val)
        {
            throw new NotImplementedException();
        }
    }
}

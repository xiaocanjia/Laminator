using System;
using System.Xml.Serialization;
using HalconDotNet;
using Camera2DSDK;

namespace JSystem.Device
{
    public class Camera2D : DeviceBase
    {
        public int CamType = 0;
        
        [XmlIgnore]
        private I2DCamera _camera;

        public Camera2D()
        {
            View = new Cam2DView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public Camera2D(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            _camera = Cam2DFactory.Create2DCamera((ECam2DType)CamType);
            return _camera.Connect(Name);
        }

        public override void DisConnect()
        {
            _camera.Disconnect();
        }

        public override bool CheckConnection()
        {
            bool isConnected = _camera == null ? false : _camera.CheckConnection();
            OnUpdateStatus?.Invoke(isConnected);
            return isConnected;
        }

        public void Open()
        {
            _camera?.Open();
        }

        public void Close()
        {
            _camera?.Close();
        }

        public int GrabImage(out HImage image)
        {
            image = null;
            _camera.GrabImage(out IntPtr pData, out int width, out int height);
            if (width == 0 || height == 0)
                return -1;
            image = new HImage("byte", width, height, pData);
            return 0;
        }
    }
}

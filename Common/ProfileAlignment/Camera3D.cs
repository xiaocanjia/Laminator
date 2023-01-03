using System;
using System.Drawing;
using Camera3DSDK;

namespace ProfileCalib
{
    public class Camera3D
    {
        public int CamType = 0;

        public string IP = "192.168.0.10";

        public string Port = "8080";

        public float XOffset = 0.0f;

        public float ZOffset = 0.0f;

        public float Angle = 0;

        public float[] Points;

        private I3DCamera _camera;

        public Cam3DView View;

        public Color Color;

        private float _interval = 0.012f;
        
        public Camera3D()
        {
            View = new Cam3DView(this);
        }

        public bool Connect()
        {
            _camera = Cam3DFactory.Create3DCamera((ECamera3DType)CamType);
            if (!_camera.Connect(IP, Port))
                return false;
            _interval = (float)_camera.GetParams(EParamNames.PointInterval);
            return true;
        }

        public void DisConnect()
        {
            _camera?.Disconnect();
        }

        public void SetCameraType(int type)
        {
            CamType = type;
        }

        public float[] GrabProfile()
        {
            if (_camera == null || _camera.CheckConnection() == false)
                return null;
            _camera.ReadSingleProfile(out float[] heightData, out byte[] intensityData);
            for (int i = 0; i < heightData.Length; i++)
            {
                float cos = (float)Math.Cos(Angle * Math.PI / 180);
                float sin = (float)Math.Sin(Angle * Math.PI / 180);

                var tx = cos * i * _interval - sin * heightData[i] + XOffset;
                heightData[i] = sin * i * _interval + cos * heightData[i] + ZOffset;
            }
            return heightData;
        }
    }
}

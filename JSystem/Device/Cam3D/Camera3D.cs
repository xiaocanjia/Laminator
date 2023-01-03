using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using BSLib;
using Camera3DSDK;
using JSystem.Perform;
using HalconDotNet;
using System.Runtime.InteropServices;

namespace JSystem.Device
{
    public class Camera3D : DeviceBase
    {
        private JMatrix3D _matrix3D;

        public int CamType = 0;

        public string IP = "192.168.0.10";

        public string Port = "8080";

        private float _pointsInterval = 0.02f;

        public float TriggerInterval = 0.02f;

        private int _rows = 0;

        private int _columns = 0;

        public int TimeOut = 20000;

        public bool _isScanning = false;

        public bool _getTrigger = false;

        public bool _isOn = false;

        public float ValidWidth = 30.0f;

        public float XOffset = 0.0f;

        public float YOffset = 0.0f;

        public float ZOffset = 0.0f;

        public float ZAngle = 0.0f;

        public string CfgPath = "";

        public bool IsSaveImage = false;

        public bool IsSaveFailOnly = false;

        [XmlIgnore]
        private I3DCamera _camera;

        public Camera3D()
        {
            View = new Cam3DView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public Camera3D(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                _camera = Cam3DFactory.Create3DCamera((ECamera3DType)CamType);
                if (!_camera.Connect(IP, Port))
                    return false;
                _camera.SetParams(EParamNames.TimeOut, TimeOut);
                _pointsInterval = (float)_camera.GetParams(EParamNames.PointInterval);
                if (ValidWidth > (int)_camera.GetParams(EParamNames.ProfileSize) * _pointsInterval)
                    ValidWidth = (int)_camera.GetParams(EParamNames.ProfileSize) * _pointsInterval;
                _columns = (int)(ValidWidth / _pointsInterval);
                if (CfgPath != "" && File.Exists(CfgPath))
                    _camera.LoadJob(CfgPath);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void DisConnect()
        {
            _camera?.Disconnect();
        }

        public override bool CheckConnection()
        {
            bool isConnect = _camera == null ? false : _camera.CheckConnection();
            OnUpdateStatus?.Invoke(isConnect);
            return isConnect;
        }

        public JMatrix3D GrabImage(double PCLLength, int jointCount)
        {
            try
            {
                if (CheckConnection() == false) return null;
                _rows = (int)(PCLLength / TriggerInterval);
                _camera.SetParams(EParamNames.ProfileCount, _rows);
                _isScanning = true;
                int cols = (_columns + (int)(XOffset / _pointsInterval)) * jointCount;
                int rows = _rows + (int)(YOffset / TriggerInterval);
                float[] hBuffer = new float[rows * cols];
                byte[] lBuffer = new byte[rows * cols];
                for (int i = 0; i < jointCount; i++)
                {
                    while (!_getTrigger)
                    { 
                        if (_isScanning == false)
                            return null;
                        Thread.Sleep(10);
                    }
                    SwitchLaser(true);
                    LogManager.Instance.AddLog("开始读取一次");
                    _camera.ReadBatchProfiles(out float[] hData, out byte[] lData);
                    if (hData == null || lData == null)
                        return null;
                    int initCols = (int)_camera.GetParams(EParamNames.ProfileSize);
                    int startCols = (initCols - _columns) / 2;
                    for (int rowIndex = 0; rowIndex < _rows; rowIndex++)
                    {
                        int startIdx = rowIndex * initCols + startCols;
                        for (int j = 0; j < _columns; j++)
                        {
                            if (float.IsNaN(hData[startIdx + j]))
                                continue;
                            float cos = (float)Math.Cos(ZAngle * Math.PI / 180);
                            float sin = (float)Math.Sin(ZAngle * Math.PI / 180);
                            hData[startIdx + j] = sin * (startCols + j) * _pointsInterval + cos * hData[startIdx + j] + ZOffset;
                        }
                        Array.Copy(hData, startIdx, hBuffer, (rowIndex + (int)(YOffset / TriggerInterval)) * cols + _columns * i + (int)(XOffset / _pointsInterval), _columns);
                        Array.Copy(lData, startIdx, lBuffer, (rowIndex + (int)(YOffset / TriggerInterval)) * cols + _columns * i + (int)(XOffset / _pointsInterval), _columns);
                    }
                    SwitchLaser(false);
                    _getTrigger = false;
                    LogManager.Instance.AddLog("读取一次完成");
                }
                _isScanning = false;
                _matrix3D = new JMatrix3D();
                HImage imageZ = new HImage();
                HImage imageL = new HImage();
                unsafe
                {
                    fixed (float* zp = &hBuffer[0])
                        imageZ.GenImage1("real", cols, rows, new IntPtr(zp));
                    fixed (byte* lp = &lBuffer[0])
                        imageL.GenImage1("byte", cols, rows, new IntPtr(lp));
                }
                _matrix3D.Row = rows;
                _matrix3D.Column = cols;
                _matrix3D.Pitch = _pointsInterval;
                if (_pointsInterval < TriggerInterval)
                {
                    _matrix3D.Column = (int)(cols * _pointsInterval / TriggerInterval);
                    _matrix3D.Row = rows;
                    _matrix3D.Pitch = TriggerInterval;
                    imageZ = imageZ.ZoomImageSize(_matrix3D.Column, _matrix3D.Row, "constant");
                    imageL = imageL.ZoomImageSize(_matrix3D.Column, _matrix3D.Row, "constant");
                }
                else if (_pointsInterval > TriggerInterval)
                {
                    _matrix3D.Column = cols;
                    _matrix3D.Row = (int)(rows * TriggerInterval / _pointsInterval);
                    imageZ = imageZ.ZoomImageSize(_matrix3D.Column, _matrix3D.Row, "constant");
                    imageL = imageL.ZoomImageSize(_matrix3D.Column, _matrix3D.Row, "constant");
                }
                IntPtr pZ = imageZ.GetImagePointer1(out HTuple tz, out HTuple wz, out HTuple hz);
                _matrix3D.HeightData = new float[_matrix3D.Row * _matrix3D.Column];
                Marshal.Copy(pZ, _matrix3D.HeightData, 0, _matrix3D.Row * _matrix3D.Column);
                _matrix3D.SetImageZ(imageZ);
                IntPtr pL = imageL.GetImagePointer1(out HTuple tl, out HTuple wl, out HTuple hl);
                _matrix3D.LuminaceData = new byte[_matrix3D.Row * _matrix3D.Column];
                Marshal.Copy(pL, _matrix3D.LuminaceData, 0, _matrix3D.Row * _matrix3D.Column);
                _matrix3D.SetImageL(imageL);
                return _matrix3D;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"读取数据失败，请检测参数是否设置正确：{ex.Message}", true);
                return null;
            }
        }

        public void EndGrab()
        {
            if (_camera == null)
                return;
            _camera.ClearBuffer();
            SwitchLaser(false);
            _isScanning = false;
            _getTrigger = false;
        }

        public void ReceiveTrigger()
        {
            if (CheckConnection() == false) return;
            if (!_isScanning || _getTrigger)
            {
                LogManager.Instance.AddLog($"{Name}未启动扫描");
                return;
            }
            _getTrigger = true;
            LogManager.Instance.AddLog($"{Name}接受到触发信号");
        }

        public float GetValidWidth()
        {
            return _pointsInterval * _columns;
        }

        public void SwitchLaser(bool isOn)
        {
            _camera?.SwitchLaser(isOn);
            _isOn = isOn;
        }

        public void SaveJob(string filePath)
        {
            _camera?.SaveJob(filePath);
        }

        public void LoadJob(string filePath)
        {
            _camera?.LoadJob(filePath);
        }

        public bool GetIsScanning()
        {
            return _isScanning;
        }

        public bool GetIsOn()
        {
            return _isOn;
        }
    }
}

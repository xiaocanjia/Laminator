﻿using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace Camera3DSDK
{
    public class VoNetLP3000 : I3DCamera
    {
        private bool _isConnect = false;

        private float _triggerInterval = 0;

        private readonly float _pointInterval = 0;

        private int _profileSize = 0;

        private int _profileCount = 1000;

        private int _timeOut = 20000;

        private bool _isOn = false;

        public VoNetLP3000(ECamera3DType type)
        {
            switch (type)
            {
                case ECamera3DType.LP3030M:
                    _pointInterval = 0.01f;
                    break;
                case ECamera3DType.LP3060M:
                    _pointInterval = 0.02f;
                    break;
            }
        }

        public bool Connect(string IP, string port)
        {
            int reo = VONetLinkFunc.VONET_EthernetOpen("0.0.0.0", IP);
            if (reo < 0)
            {
                _isConnect = false;
                return false;
            }
            else
            {
                _isConnect = true;
                //_profileCount = VONetLinkFunc.VONET_ProfilePointGetCount(); //自动获取scan设置的批处理行数
                _profileSize = VONetLinkFunc.VONET_ProfileDataWidth();      //X方向点数
                return true;
            }
        }

        public void Disconnect()
        {
            //关闭设备
            int rcc = VONetLinkFunc.VONET_CommClose();
            if (rcc < 0)
                return;
            _isConnect = false;
        }

        public bool CheckConnection()
        {
            return _isConnect;
        }

        public void SwitchLaser(bool isOn)
        {
            _isOn = isOn;
            if (isOn)
                VONetLinkFunc.VONET_StartMeasure(_timeOut);
            else
                VONetLinkFunc.VONET_StopMeasure();
        }

        public void ClearBuffer()
        {
            throw new  NotImplementedException();
        }

        public void SetParams(EParamNames name, object val)
        {
            switch (name)
            {
                case EParamNames.TriggerInterval:
                    _triggerInterval = Convert.ToSingle(val);
                    break;
                case EParamNames.TimeOut:
                    _timeOut = Convert.ToInt32(val);
                    break;
                case EParamNames.ProfileCount:
                    _profileCount = Convert.ToInt32(val);
                    break;
                default:
                    break;
            }
        }

        public object GetParams(EParamNames name)
        {
            switch (name)
            {
                case EParamNames.TriggerInterval:
                    return _triggerInterval;
                case EParamNames.ProfileSize:
                    return _profileSize;
                case EParamNames.PointInterval:
                    return _pointInterval;
                default:
                    return null;
            }
        }

        public int ReadBatchProfiles(out float[] heightData, out byte[] intensityData)
        {
            int size = _profileCount * _profileSize;
            heightData = new float[size];
            intensityData = new byte[size];
            byte[] tIntensityData = new byte[size]; //当前批次亮度数据缓存  
            float[] tHeightData = new float[size];  //当前批次高度数据缓存
            int currCount = 0;
            while (true)
            { 
                int num = VONetLinkFunc.VONET_GetBatchRollData((uint)_profileCount, tHeightData, tIntensityData, null);
                if (num == 0)
                {
                    if (_isOn == false)
                        return -1;
                    Thread.Sleep(50);
                    continue;
                }
                else if (num < 0)
                {
                    VONetLinkFunc.VONET_StopMeasure();
                    return -1;
                }
                else
                {
                    int currSize = (currCount + num <= _profileCount ? num : (_profileCount - currCount)) * _profileSize;
                    int bufferSize = currCount * _profileSize;  //已经扫描的点数
                    for (int i = 0; i < currSize; i++)
                    {
                        if (tHeightData[i] == -100)
                        {
                            heightData[i + bufferSize] = float.NaN;
                            intensityData[i + bufferSize] = 0;
                        }
                        else
                        {
                            heightData[i + bufferSize] = tHeightData[i];
                            intensityData[i + bufferSize] = tIntensityData[i];
                        }
                    }
                    currCount += num;
                    if (currCount >= _profileCount)
                    {
                        Thread.Sleep(100);
                        tHeightData = null;
                        tIntensityData = null;
                        GC.Collect();
                        return 0;
                    }
                }
            }
        }

        public int ReadSingleProfile(out float[] heightData, out byte[] intensityData)
        {
            heightData = new float[_profileSize];
            intensityData = new byte[_profileSize];
            int num = VONetLinkFunc.VONET_GetBatchRollData(1, heightData, intensityData, null);
            if (num < 0 || num == 0)
                return -1;
            return 0;
        }

        public void SaveJob(string filePath)
        {
            uint[] size = new uint[1];
            IntPtr ptr = VONetLinkFunc.VONET_ExportParameters(size);
            byte[] param = new byte[size[0]];
            Marshal.Copy(ptr, param, 0, param.Length);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            fs.Write(param, 0, param.Length);
            fs.Close();
        }

        public void LoadJob(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            long size = fs.Length;
            byte[] param = new byte[size];
            fs.Read(param, 0, param.Length);
            fs.Close();
            VONetLinkFunc.VONET_LoadParameters(param, (uint)size);
        }
    }
}

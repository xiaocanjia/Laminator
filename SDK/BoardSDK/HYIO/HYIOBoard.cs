using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using Modbus.Device;
using FileHelper;

namespace BoardSDK
{
    public class HYIOBoard : IBoard
    {
        private ModbusSerialMaster _master;
        
        private SerialPort _serialPort = new SerialPort();

        private int _axexCount = 0;

        private bool[][] DIs;

        private bool[][] DOs;

        public bool Connect(string filePath)
        {
            try
            {
                _serialPort.PortName = IniHelper.INIGetStringValue(filePath, "串口设置", "PortName", "");
                _serialPort.BaudRate = Convert.ToInt32(IniHelper.INIGetStringValue(filePath, "串口设置", "BaudRate", ""));
                _serialPort.Parity = (Parity)Convert.ToInt32(IniHelper.INIGetStringValue(filePath, "串口设置", "Parity", ""));
                _serialPort.DataBits = Convert.ToInt32(IniHelper.INIGetStringValue(filePath, "串口设置", "DataBits", ""));
                _serialPort.StopBits = (StopBits)Convert.ToInt32(IniHelper.INIGetStringValue(filePath, "串口设置", "StopBits", ""));
                _serialPort.ReadTimeout = Convert.ToInt32(IniHelper.INIGetStringValue(filePath, "串口设置", "ReadTimeout", ""));
                _axexCount = Convert.ToInt32(IniHelper.INIGetStringValue(filePath, "板卡数量", "AxesCount", ""));
                _serialPort.Open();
                if (!_serialPort.IsOpen)
                    return false;
                _master = ModbusSerialMaster.CreateRtu(_serialPort);
                DIs = new bool[_axexCount][];
                DOs = new bool[_axexCount][];
                for (int i = 0; i < _axexCount; i++)
                {
                    DIs[i] = new bool[16];
                    DOs[i] = new bool[16];
                }
                new Task(RefreshIO).Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void RefreshIO()
        {
            while (true)
            {
                Thread.Sleep(10);
                for (int i = 0; i < _axexCount; i++)
                {
                    try
                    {
                        _master.WriteMultipleCoils((byte)(i + 1), 80, DOs[i]);
                        DIs[i] = _master.ReadCoils((byte)(i + 1), 16, 16);
                    }
                    catch { }
                }
            }
        }

        public bool Disconnect()
        {
            try
            {
                _serialPort.Close();
                _master.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckConnect()
        {
            return _serialPort.IsOpen;
        }

        public bool GetIn(int axisIdx, int IOIdx)
        {
            return DIs[axisIdx - 1][IOIdx];
        }

        public bool GetOut(int axisIdx, int IOIdx)
        {
            return DOs[axisIdx - 1][IOIdx];
        }

        public bool SetOut(int axisIdx, int IOIdx, bool value)
        {
            try
            {
                DOs[axisIdx - 1][IOIdx] = value;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AbsMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double pos)
        {
            throw new NotImplementedException();
        }

        public bool CheckIsStop(int axis)
        {
            throw new NotImplementedException();
        }

        public bool ClearAlarm(int axis)
        {
            throw new NotImplementedException();
        }
        
        public bool GetAxisServoEnabled(int axis)
        {
            throw new NotImplementedException();
        }

        public byte GetAxisState(int axis)
        {
            throw new NotImplementedException();
        }

        public int GetNegativeLS(int axis)
        {
            throw new NotImplementedException();
        }

        public int GetPositiveLS(int axis)
        {
            throw new NotImplementedException();
        }

        public bool GoHome(int axis, double homeVelL, double homeVelH, double homeAcc, double homeDcc, uint homeMode, uint homeDir)
        {
            throw new NotImplementedException();
        }

        public bool InstancyStop(int axis)
        {
            throw new NotImplementedException();
        }

        public bool JogMove(int axis, bool isPositive, double moveVelL, double moveVelH, double moveAcc, double moveDcc)
        {
            throw new NotImplementedException();
        }

        public bool LoadConfig(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool RelMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double dist)
        {
            throw new NotImplementedException();
        }

        public bool SetAxisServoEnabled(int axis, bool isOn)
        {
            throw new NotImplementedException();
        }

        public bool Stop(int axis)
        {
            throw new NotImplementedException();
        }

        public double GetActPos(int axis)
        {
            throw new NotImplementedException();
        }

        public double GetCmdPos(int axis)
        {
            throw new NotImplementedException();
        }
    }
}

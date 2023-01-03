using System.IO.Ports;

namespace JSystem.Device
{
    public class ScanningGun : DeviceBase
    {
        private SerialPort _port;

        public string PortName = "COM1";

        public int BaudRate = 9600;

        public int DataBits = 8;

        public StopBits StopBits = StopBits.One;

        public Parity Parity = Parity.None;

        public string Command = "K";

        public ScanningGun()
        {
            View = new ScanningGunView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public ScanningGun(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                _port = new SerialPort
                {
                    PortName = PortName,
                    BaudRate = BaudRate,
                    DataBits = DataBits,
                    StopBits = StopBits,
                    Parity = Parity
                };
                _port.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void DisConnect()
        {
            _port?.Close();
        }

        public override bool CheckConnection()
        {
            bool isConnect = _port == null ? false : _port.IsOpen;
            OnUpdateStatus?.Invoke(isConnect);
            return isConnect;
        }

        public string ReadSN()
        {
            _port.Write(Command);
            System.Threading.Thread.Sleep(500);
            return _port.ReadExisting();
        }
    }
}


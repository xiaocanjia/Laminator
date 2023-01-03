using System;
using System.Drawing;
using System.Windows.Forms;

namespace JSystem.Device
{
    public partial class DevStatusPanel : UserControl
    {
        private DeviceBase _device;

        public DevStatusPanel(DeviceBase device)
        {
            _device = device;
            InitializeComponent();
            Lbl_Name.Text = device.Name;
            device.OnUpdateStatus += UpdateStatus;
        }

        public void UpdateStatus(bool isConnected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateStatus(isConnected); }));
            }
            else
            {
                Lbl_Name.Text = _device.Name;
                if (isConnected)
                {
                    Lbl_Status.Text = "已连接";
                    Lbl_Status.ForeColor = Color.Green;
                }
                else
                {
                    Lbl_Status.Text = "未连接";
                    Lbl_Status.ForeColor = Color.Red;
                }
            }
        }
    }
}

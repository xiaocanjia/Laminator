using System;
using System.Windows.Forms;
using Sunny.UI;
using System.IO.Ports;

namespace JSystem.Device
{
    public partial class ScanningGunView : UserControl
    {
        private ScanningGun _device;

        public ScanningGunView()
        {
            InitializeComponent();
        }

        public ScanningGunView(ScanningGun device) : this()
        {
            _device = device;
            device.OnSetEnable = SetEnable;
            device.OnUpdateStatus += UpdateStatus;
        }

        private void SetEnable(bool isEnable)
        {
            foreach (Control control in Controls)
            {
                if (control is UIComboBox || control is UIButton | control is UITextBox)
                    control.Enabled = isEnable;
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            CbB_Port_Name.Items.Clear();
            CbB_Port_Name.Items.AddRange(SerialPort.GetPortNames());
            CbB_Port_Name.SelectedItem = _device.PortName;
            CbB_BaudRate.SelectedItem = _device.BaudRate.ToString();
            CbB_DataBits.SelectedItem = _device.DataBits.ToString();
            CbB_StopBits.SelectedIndex = (int)_device.StopBits;
            CbB_Parity.SelectedIndex = (int)_device.Parity;
            TB_Command.Text = _device.Command;
            Btn_Connect.Selected = _device.CheckConnection();
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Btn_Connect.Selected)
            {
                _device.PortName = CbB_Port_Name.Text;
                _device.BaudRate = Convert.ToInt32(CbB_BaudRate.SelectedItem);
                _device.DataBits = Convert.ToInt32(CbB_DataBits.SelectedItem);
                _device.StopBits = (StopBits)CbB_StopBits.SelectedIndex;
                _device.Parity = (Parity)CbB_Parity.SelectedIndex;
                _device.Command = TB_Command.Text;
                if (!_device.Connect())
                    UIMessageBox.Show("相机连接失败，可能被占用或者相机信息填写错误");
                Btn_Connect.Selected = true;
                foreach (Control control in Controls)
                {
                    if (control is UIComboBox || control is UITextBox)
                        control.Enabled = false;
                }
            }
            else
            {
                _device.DisConnect();
                Btn_Connect.Selected = false;
                foreach (Control control in Controls)
                {
                    if (control is UIComboBox || control is UITextBox)
                        control.Enabled = true;
                }
            }
        }

        public void UpdateStatus(bool isConnected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateStatus(isConnected); }));
            }
            else
            {
                if (Btn_Connect.Selected == isConnected)
                    return;
                if (isConnected)
                {
                    Btn_Connect.Selected = true;
                    foreach (Control control in Controls)
                    {
                        if (control is UIComboBox || control is UITextBox)
                            control.Enabled = false;
                    }
                }
                else
                {
                    Btn_Connect.Selected = false;
                    foreach (Control control in Controls)
                    {
                        if (control is UIComboBox || control is UITextBox)
                            control.Enabled = true;
                    }
                }
            }
        }
    }
}

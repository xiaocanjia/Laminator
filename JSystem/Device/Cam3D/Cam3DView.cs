using System;
using System.Windows.Forms;
using Sunny.UI;
using Camera3DSDK;

namespace JSystem.Device
{
    public partial class Cam3DView : UserControl
    {
        private Camera3D _device;

        public Cam3DView()
        {
            InitializeComponent();
        }

        public Cam3DView(Camera3D device) : this()
        {
            _device = device;
            device.OnSetEnable = SetEnable;
            device.OnUpdateStatus += UpdateStatus;
        }

        private void SetEnable(bool isEnable)
        {
            foreach (Control control in Controls)
            {
                if (control is UIComboBox || control is UITextBox)
                {
                    if (control.Enabled)
                        control.Enabled = isEnable;
                }
            }
            Btn_Connect.Enabled = isEnable;
        }

        public override void Refresh()
        {
            base.Refresh();
            CbB_Cam_Name.Items.Clear();
            foreach (ECamera3DType type in Enum.GetValues(typeof(ECamera3DType)))
                CbB_Cam_Name.Items.Add(type.ToString());
            CbB_Cam_Name.SelectedIndex = _device.CamType;
            TB_IP.Text = _device.IP;
            TB_Port.Text = _device.Port;
            TB_Trigger_Interval.Text = _device.TriggerInterval.ToString();
            TB_Valiad_Width.Text = _device.ValidWidth.ToString();
            TB_XOffset.Text = _device.XOffset.ToString();
            TB_YOffset.Text = _device.YOffset.ToString();
            TB_ZOffset.Text = _device.ZOffset.ToString();
            TB_ZAngle.Text = _device.ZAngle.ToString();
            TB_Config_Path.Text = _device.CfgPath;
            Btn_Connect.Selected = _device.CheckConnection();
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Btn_Connect.Selected)
            {
                try
                {
                    _device.CamType = CbB_Cam_Name.SelectedIndex;
                    _device.IP = TB_IP.Text;
                    _device.Port = TB_Port.Text;
                    _device.ValidWidth = Convert.ToSingle(TB_Valiad_Width.Text);
                    _device.XOffset = Convert.ToSingle(TB_XOffset.Text);
                    _device.YOffset = Convert.ToSingle(TB_YOffset.Text);
                    _device.ZOffset = Convert.ToSingle(TB_ZOffset.Text);
                    _device.ZAngle = Convert.ToSingle(TB_ZAngle.Text);
                    _device.TriggerInterval = Convert.ToSingle(TB_Trigger_Interval.Text);
                    _device.CfgPath = TB_Config_Path.Text;
                }
                catch
                {
                    UIMessageBox.Show("参数格式填写错误，请检查！");
                    return;
                }
                if (!_device.Connect())
                {
                    UIMessageBox.Show("相机连接失败，可能被占用或者相机信息填写错误");
                    return;
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

        private void CbB_Cam_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _device.CamType = CbB_Cam_Name.SelectedIndex;
        }

        private void Btn_Export_Config_Click(object sender, EventArgs e)
        {
            if (_device.CheckConnection() == false)
            {
                UIMessageTip.ShowWarning("请先连接相机");
                return;
            }
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "配置文件|*.cfg";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                _device.SaveJob(dialog.FileName);
            }
        }

        private void TB_Config_Path_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "配置文件|*.cfg";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                TB_Config_Path.Text = dialog.FileName;
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

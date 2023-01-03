using System;
using System.Windows.Forms;
using Sunny.UI;
using Camera2DSDK;

namespace JSystem.Device
{
    public partial class Cam2DView : UserControl
    {
        private Camera2D _device;

        public Cam2DView()
        {
            InitializeComponent();
        }

        public Cam2DView(Camera2D device) : this()
        {
            _device = device;
            _device.OnSetEnable = SetEnable;
            device.OnUpdateStatus += UpdateStatus;
        }

        private void SetEnable(bool isEnable)
        {
            foreach (Control control in Controls)
            {
                if (control is UIComboBox || control is UIButton)
                    control.Enabled = isEnable;
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            CbB_Cam_Type.Items.Clear();
            foreach (ECam2DType type in Enum.GetValues(typeof(ECam2DType)))
                CbB_Cam_Type.Items.Add(type.ToString());
            CbB_Cam_Type.SelectedIndex = _device.CamType;
            Btn_Connect.Selected = _device.CheckConnection();
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Btn_Connect.Selected)
            {
                if (_device.Connect())
                    Btn_Connect.Selected = true;
                else
                    UIMessageBox.Show("相机连接失败，可能被占用或者相机信息填写错误");
            }
            else
            {
                _device.DisConnect();
                Btn_Connect.Selected = false;
            }
        }

        private void CbB_Cam_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _device.CamType = CbB_Cam_Type.SelectedIndex;
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

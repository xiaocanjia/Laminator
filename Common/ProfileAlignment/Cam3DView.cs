using System;
using System.Windows.Forms;

namespace ProfileCalib
{
    public partial class Cam3DView : UserControl
    {
        private Camera3D _camera;

        public Cam3DView(Camera3D camera)
        {
            InitializeComponent();
            _camera = camera;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue();
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            try
            {
                _camera.XOffset = Convert.ToSingle(TB_XOffset.Text);
                _camera.ZOffset = Convert.ToSingle(TB_ZOffset.Text);
                _camera.Angle = Convert.ToSingle(TB_Angle.Text);
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Btn_Connect.Selected)
            {
                _camera.IP = TB_IP.Text;
                _camera.Port = TB_Port.Text;
                _camera.XOffset = Convert.ToSingle(TB_XOffset.Text);
                _camera.ZOffset = Convert.ToSingle(TB_ZOffset.Text);
                _camera.Angle = Convert.ToSingle(TB_Angle.Text);
                if (_camera.Connect())
                {
                    Btn_Connect.Selected = true;
                }
            }
            else
            {
                _camera.DisConnect();
                Btn_Connect.Selected = false;
            }
        }
    }
}

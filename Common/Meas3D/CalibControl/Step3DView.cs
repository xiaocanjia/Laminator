using System;
using System.Windows.Forms;
using Sunny.UI;

namespace Meas3D.Calib
{
    public partial class Step3DView : UserControl
    {
        private Step3DModel _step;

        public Step3DView()
        {
            InitializeComponent();
        }

        public Step3DView(Step3DModel step) : this()
        {
            _step = step;
        }

        public override void Refresh()
        {
            base.Refresh();
            for (int i = 0; i < _step.RefPoints.Length; i++)
            {
                (Controls.Find($"TB_Point{i + 1}X", true)[0] as UITextBox).Text = _step.RefPoints[i][0].ToString();
                (Controls.Find($"TB_Point{i + 1}Y", true)[0] as UITextBox).Text = _step.RefPoints[i][1].ToString();
                (Controls.Find($"TB_Point{i + 1}Z", true)[0] as UITextBox).Text = _step.RefPoints[i][2].ToString();
            }
            for (int i = 0; i < 6; i++)
            {
                (Controls.Find($"Btn_Add_ROI{i + 1}", true)[0] as UIButton).Enabled = false;
                (Controls.Find($"Btn_Remove_ROI{i + 1}", true)[0] as UIButton).Enabled = false;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue(sender);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UpdateValue(sender);
        }

        private void UpdateValue(object sender)
        {
            try
            {
                UITextBox tb = sender as UITextBox;
                int pointIdx = Convert.ToInt32(tb.Name.Substring(tb.Name.IndexOf('t') + 1, tb.Name.Length - tb.Name.IndexOf('t') - 2)) - 1;
                float value = Convert.ToSingle(tb.Text);
                if (tb.Name[tb.Name.Length - 1] == 'X')
                    _step.RefPoints[pointIdx][0] = value;
                else if (tb.Name[tb.Name.Length - 1] == 'Y')
                    _step.RefPoints[pointIdx][1] = value;
                else if (tb.Name[tb.Name.Length - 1] == 'Z')
                    _step.RefPoints[pointIdx][2] = value;
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            _step.CloseSetupPanel();
        }

        private void Btn_Add_ROI_Click(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            _step.AddROI(Convert.ToInt32(btn.Name.Substring(11)) - 1);
        }

        private void Btn_Remove_ROI_Click(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            _step.RemoveROI(Convert.ToInt32(btn.Name.Substring(14)) - 1);
        }

        private void Btn_Setup_Click(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            int idx = Convert.ToInt32(btn.Name.Substring(9)) - 1;
            btn.Selected = !btn.Selected;
            (Controls.Find($"Btn_Add_ROI{idx + 1}", true)[0] as UIButton).Enabled = btn.Selected;
            (Controls.Find($"Btn_Remove_ROI{idx + 1}", true)[0] as UIButton).Enabled = btn.Selected;
            _step.SetupROI(idx, btn.Selected);
        }
    }
}

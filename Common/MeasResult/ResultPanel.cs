using System;
using System.Drawing;
using System.Windows.Forms;

namespace MeasResult
{
    public partial class ResultPanel : UserControl
    {
        private MesResult _result;

        public ResultPanel()
        {
            InitializeComponent();
        }

        public ResultPanel(MesResult result) : this()
        {
            _result = result;
            Panel_Limit.Visible = result.HasLimit;
            Label_Name.Text = _result.Name;
            Label_Value.Location = new Point(Label_Name.Location.X + Label_Name.Width, Label_Name.Location.Y);
            Label_Value.Text = _result.Result;
            TB_ID.Text = _result.ID;
            TB_Upper_Limit.Text = _result.UpperLimit.ToString();
            TB_Lower_Limit.Text = _result.LowerLimit.ToString();
            TB_Offset.Text = _result.Offset.ToString();
            CB_IsAbs.Checked = _result.IsAbs;
            CB_IsOutput.Checked = _result.IsOutput;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue();
                Label_Value.Focus();
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UpdateValue();
        }

        public void UpdateValue()
        {
            try
            {
                _result.LowerLimit = Convert.ToDouble(TB_Lower_Limit.Text);
                _result.UpperLimit = Convert.ToDouble(TB_Upper_Limit.Text);
                _result.Offset = Convert.ToDouble(TB_Offset.Text);
                _result.ID = TB_ID.Text;
            }
            catch
            {
                MessageBox.Show("格式错误，请重新输入");
            }
        }

        public void UpdateLabelValue()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateLabelValue(); }));
            }
            else
            {
                Label_Value.Text = _result.Result;
            }
        }

        private void CB_IsAbs_CheckedChanged(object sender, EventArgs e)
        {
            _result.IsAbs = CB_IsAbs.Checked;
            UpdateLabelValue();
        }

        private void CB_Output_CheckedChanged(object sender, EventArgs e)
        {
            _result.IsOutput = CB_IsOutput.Checked;
        }
    }
}

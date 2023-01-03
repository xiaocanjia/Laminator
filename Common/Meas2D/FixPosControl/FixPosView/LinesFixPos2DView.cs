using System;
using System.Windows.Forms;

namespace Meas2D.FixPos
{
    public partial class LinesFixPos2DView : UserControl
    {
        private LinesFixPos2DModel _fixPos;

        public LinesFixPos2DView(LinesFixPos2DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_Min_Gray1.Text = _fixPos.MinGray1.ToString();
            TB_Max_Gray1.Text = _fixPos.MaxGray1.ToString();
            CbB_Direction1.SelectedIndex = _fixPos.Direction1 - 2;
            TB_Min_Gray2.Text = _fixPos.MinGray2.ToString();
            TB_Max_Gray2.Text = _fixPos.MaxGray2.ToString();
            CbB_Direction2.SelectedIndex = _fixPos.Direction2;
            CB_IsRising1.Checked = _fixPos.IsRising1;
            CB_IsRising2.Checked = _fixPos.IsRising2;
            CB_IsRising1.ValueChanged += (object sender, bool value) => { UpdateValue(); };
            CB_IsRising2.ValueChanged += (object sender, bool value) => { UpdateValue(); };
            CbB_Direction1.SelectedIndexChanged += (object sender, EventArgs value) => { UpdateValue(); };
            CbB_Direction2.SelectedIndexChanged += (object sender, EventArgs value) => { UpdateValue(); };
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
                _fixPos.MaxGray1 = Convert.ToDouble(TB_Max_Gray1.Text);
                _fixPos.MinGray1 = Convert.ToDouble(TB_Min_Gray1.Text);
                _fixPos.IsRising1 = CB_IsRising1.Checked;
                _fixPos.Direction1 = CbB_Direction1.SelectedIndex + 2;
                _fixPos.MaxGray2 = Convert.ToDouble(TB_Max_Gray2.Text);
                _fixPos.MinGray2 = Convert.ToDouble(TB_Min_Gray2.Text);
                _fixPos.IsRising2 = CB_IsRising2.Checked;
                _fixPos.Direction2 = CbB_Direction2.SelectedIndex;
                _fixPos.UpdatePos();
                _fixPos.UpdateShape();
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        private void CB_Disp_Loc_CheckedChanged(object sender, bool value)
        {

        }

        private void Button_Add_ROI1_Click(object sender, EventArgs e)
        {
            _fixPos.AddROI1();
        }

        private void Button_Remove_ROI1_Click(object sender, EventArgs e)
        {
            _fixPos.RemoveROI1();
        }

        private void Button_Add_ROI2_Click(object sender, EventArgs e)
        {
            _fixPos.AddROI2();
        }

        private void Button_Remove_ROI2_Click(object sender, EventArgs e)
        {
            _fixPos.RemoveROI2();
        }
    }
}

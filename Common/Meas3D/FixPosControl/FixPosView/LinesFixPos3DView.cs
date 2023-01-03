using System;
using System.Windows.Forms;

namespace Meas3D.FixPos
{
    public partial class LinesFixPos3DView : UserControl
    {
        private LinesFixPos3DModel _fixPos;

        public LinesFixPos3DView(LinesFixPos3DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_Min_Height1.Text = _fixPos.MinHeight1.ToString();
            TB_Max_Height1.Text = _fixPos.MaxHeight1.ToString();
            TB_Min_Luminace1.Text = _fixPos.MinLuminace1.ToString();
            TB_Max_Luminace1.Text = _fixPos.MaxLuminace1.ToString();
            CbB_Direction1.SelectedIndex = _fixPos.Direction1 - 2;
            CB_Disp_Loc1.Checked = _fixPos.IsDispLoc1;
            TB_Min_Height2.Text = _fixPos.MinHeight2.ToString();
            TB_Max_Height2.Text = _fixPos.MaxHeight2.ToString();
            TB_Min_Luminace2.Text = _fixPos.MinLuminace2.ToString();
            TB_Max_Luminace2.Text = _fixPos.MaxLuminace2.ToString();
            CbB_Direction2.SelectedIndex = _fixPos.Direction2;
            CB_Disp_Loc2.Checked = _fixPos.IsDispLoc2;
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
                _fixPos.MaxHeight1 = Convert.ToDouble(TB_Max_Height1.Text);
                _fixPos.MinHeight1 = Convert.ToDouble(TB_Min_Height1.Text);
                _fixPos.MaxLuminace1 = Convert.ToDouble(TB_Max_Luminace1.Text);
                _fixPos.MinLuminace1 = Convert.ToDouble(TB_Min_Luminace1.Text);
                _fixPos.IsRising1 = CB_IsRising1.Checked;
                _fixPos.Direction1 = CbB_Direction1.SelectedIndex + 2;
                _fixPos.MaxHeight2 = Convert.ToDouble(TB_Max_Height2.Text);
                _fixPos.MinHeight2 = Convert.ToDouble(TB_Min_Height2.Text);
                _fixPos.MaxLuminace2 = Convert.ToDouble(TB_Max_Luminace2.Text);
                _fixPos.MinLuminace2 = Convert.ToDouble(TB_Min_Luminace2.Text);
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

        private void Button_Enable_FixPos_Click(object sender, EventArgs e)
        {
            _fixPos.EnableFixPos();
        }

        private void Button_Disable_FixPos_Click(object sender, EventArgs e)
        {
            _fixPos.DisableFixPos();
        }

        private void Button_Delete_FixPos_Click(object sender, EventArgs e)
        {
            _fixPos.DeleteFixPos();
        }

        private void CB_Disp_Loc_CheckedChanged(object sender, bool value)
        {
            _fixPos.IsDispLoc1 = CB_Disp_Loc1.Checked;
            _fixPos.IsDispLoc2 = CB_Disp_Loc2.Checked;
            _fixPos.UpdateShape();
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

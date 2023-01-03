using System;
using System.Windows.Forms;

namespace Meas2D.FixPos
{
    public partial class CircleLineFixPos2DView : UserControl
    {
        private CircleLineFixPos2DModel _fixPos;

        public CircleLineFixPos2DView(CircleLineFixPos2DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_Min_Gray1.Text = _fixPos.MinGray1.ToString();
            TB_Max_Gray1.Text = _fixPos.MaxGray1.ToString();
            TB_Min_Area.Text = _fixPos.MinArea.ToString();
            TB_Max_Area.Text = _fixPos.MaxArea.ToString();
            TB_Min_Gray2.Text = _fixPos.MinGray2.ToString();
            TB_Max_Gray2.Text = _fixPos.MaxGray2.ToString();
            CB_IsRising2.Checked = _fixPos.IsRising2;
            CbB_Direction2.SelectedIndex = _fixPos.Direction2;
            CB_IsRising2.ValueChanged += ComboBox_ValueChanged;
            CbB_Direction2.SelectedIndexChanged += CbB_Direction_SelectedIndexChanged;
        }

        private void ComboBox_ValueChanged(object sender, bool value)
        {
            UpdateValue();
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
                _fixPos.MaxArea = Convert.ToDouble(TB_Max_Area.Text);
                _fixPos.MinArea = Convert.ToDouble(TB_Min_Area.Text);
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

        private void Button_Add_ROI2_Click(object sender, EventArgs e)
        {
            _fixPos.AddROI2();
        }

        private void Button_Remove_ROI2_Click(object sender, EventArgs e)
        {
            _fixPos.RemoveROI2();
        }

        private void CB_Disp_Loc_ValueChanged(object sender, bool value)
        {

        }

        private void CbB_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }
    }
}

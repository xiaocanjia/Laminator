using System;
using System.Windows.Forms;

namespace Meas3D.FixPos
{
    public partial class CirclesFixPos3DView : UserControl
    {
        private CirclesFixPos3DModel _fixPos;

        public CirclesFixPos3DView(CirclesFixPos3DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_Min_Height1.Text = _fixPos.MinHeight1.ToString();
            TB_Max_Height1.Text = _fixPos.MaxHeight1.ToString();
            TB_MinDiameter1.Text = _fixPos.MinDiameter1.ToString();
            TB_MaxDiameter1.Text = _fixPos.MaxDiameter1.ToString();
            TB_Min_Luminace1.Text = _fixPos.MinLuminace1.ToString();
            TB_Max_Luminace1.Text = _fixPos.MaxLuminace1.ToString();
            TB_Start_Angle1.Text = _fixPos.StartAngle1.ToString();
            TB_End_Angle1.Text = _fixPos.EndAngle1.ToString();
            CB_Disp_Loc1.Checked = _fixPos.IsDispLoc1;
            CB_IsRising1.Checked = _fixPos.IsRising1;
            CbB_Direction1.SelectedIndex = _fixPos.Dir1;
            CB_IsFilterAgain1.Checked = _fixPos.IsFilterAgain1;
            TB_Min_Height2.Text = _fixPos.MinHeight2.ToString();
            TB_Max_Height2.Text = _fixPos.MaxHeight2.ToString();
            TB_MinDiameter2.Text = _fixPos.MinDiameter2.ToString();
            TB_MaxDiameter2.Text = _fixPos.MaxDiameter2.ToString();
            TB_Min_Luminace2.Text = _fixPos.MinLuminace2.ToString();
            TB_Max_Luminace2.Text = _fixPos.MaxLuminace2.ToString();
            TB_Start_Angle2.Text = _fixPos.StartAngle2.ToString();
            TB_End_Angle2.Text = _fixPos.EndAngle2.ToString();
            CB_Disp_Loc2.Checked = _fixPos.IsDispLoc2;
            CB_IsRising2.Checked = _fixPos.IsRising2;
            CbB_Direction2.SelectedIndex = _fixPos.Dir2;
            CB_IsFilterAgain2.Checked = _fixPos.IsFilterAgain2;
            CB_IsRising1.ValueChanged += ComboBox_ValueChanged;
            CB_IsFilterAgain1.ValueChanged += ComboBox_ValueChanged;
            CB_IsRising2.ValueChanged += ComboBox_ValueChanged;
            CB_IsFilterAgain2.ValueChanged += ComboBox_ValueChanged;
            CbB_Direction1.SelectedIndexChanged += CbB_Direction_SelectedIndexChanged;
            CbB_Direction2.SelectedIndexChanged += CbB_Direction_SelectedIndexChanged;
        }

        private void CbB_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
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
                _fixPos.MaxHeight1 = Convert.ToDouble(TB_Max_Height1.Text);
                _fixPos.MinHeight1 = Convert.ToDouble(TB_Min_Height1.Text);
                _fixPos.MaxLuminace1 = Convert.ToDouble(TB_Max_Luminace1.Text);
                _fixPos.MinLuminace1 = Convert.ToDouble(TB_Min_Luminace1.Text);
                _fixPos.MaxDiameter1 = Convert.ToDouble(TB_MaxDiameter1.Text);
                _fixPos.MinDiameter1 = Convert.ToDouble(TB_MinDiameter1.Text);
                _fixPos.StartAngle1 = Convert.ToDouble(TB_Start_Angle1.Text);
                _fixPos.EndAngle1 = Convert.ToDouble(TB_End_Angle1.Text);
                _fixPos.IsDispLoc1 = CB_Disp_Loc1.Checked;
                _fixPos.IsRising1 = CB_IsRising1.Checked;
                _fixPos.IsFilterAgain1 = CB_IsFilterAgain1.Checked;
                _fixPos.Dir1 = CbB_Direction1.SelectedIndex;
                _fixPos.MaxHeight2 = Convert.ToDouble(TB_Max_Height2.Text);
                _fixPos.MinHeight2 = Convert.ToDouble(TB_Min_Height2.Text);
                _fixPos.MaxLuminace2 = Convert.ToDouble(TB_Max_Luminace2.Text);
                _fixPos.MinLuminace2 = Convert.ToDouble(TB_Min_Luminace2.Text);
                _fixPos.MaxDiameter2 = Convert.ToDouble(TB_MaxDiameter2.Text);
                _fixPos.MinDiameter2 = Convert.ToDouble(TB_MinDiameter2.Text);
                _fixPos.StartAngle2 = Convert.ToDouble(TB_Start_Angle2.Text);
                _fixPos.EndAngle2 = Convert.ToDouble(TB_End_Angle2.Text);
                _fixPos.IsDispLoc2 = CB_Disp_Loc2.Checked;
                _fixPos.IsRising2 = CB_IsRising2.Checked;
                _fixPos.IsFilterAgain2 = CB_IsFilterAgain2.Checked;
                _fixPos.Dir2 = CbB_Direction2.SelectedIndex;
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

        private void CB_Disp_Loc_ValueChanged(object sender, bool value)
        {
            _fixPos.IsDispLoc1 = CB_Disp_Loc1.Checked;
            _fixPos.IsDispLoc2 = CB_Disp_Loc2.Checked;
            _fixPos.UpdateShape();
        }

        private void Button_Add_ROI2_Click(object sender, EventArgs e)
        {

        }
    }
}

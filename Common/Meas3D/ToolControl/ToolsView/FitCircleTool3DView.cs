using System;
using System.Windows.Forms;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class FitCircleTool3DView : UserControl
    {
        FitCircleTool3DModel _tool;

        public FitCircleTool3DView()
        {
            InitializeComponent();
        }

        public FitCircleTool3DView(FitCircleTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            TB_Min_Height.Text = _tool.MinHeight.ToString();
            TB_Max_Height.Text = _tool.MaxHeight.ToString();
            TB_MinDiameter.Text = _tool.MinDiameter.ToString();
            TB_MaxDiameter.Text = _tool.MaxDiameter.ToString();
            TB_Min_Luminace.Text = _tool.MinLuminace.ToString();
            TB_Max_Luminace.Text = _tool.MaxLuminace.ToString();
            TB_Start_Angle.Text = _tool.StartAngle.ToString();
            TB_End_Angle.Text = _tool.EndAngle.ToString();
            CbB_Direction.SelectedIndex = _tool.Dir;
            CB_Disp_Loc.Checked = _tool.IsDispLoc;
            CB_IsRising.Checked = _tool.IsRising;
            CB_IsFilterAgain.Checked = tool.IsFilterAgain;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
            CB_IsRising.ValueChanged += ComboBox_ValueChanged;
            CB_IsFilterAgain.ValueChanged += ComboBox_ValueChanged;
            CbB_Direction.SelectedIndexChanged += CbB_Direction_SelectedIndexChanged;
        }

        private void CbB_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void ComboBox_ValueChanged(object sender, bool value)
        {
            UpdateValue();
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue();
                //Button_Confirm.Focus();
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
                _tool.MaxHeight = Convert.ToDouble(TB_Max_Height.Text);
                _tool.MinHeight = Convert.ToDouble(TB_Min_Height.Text);
                _tool.MaxLuminace = Convert.ToDouble(TB_Max_Luminace.Text);
                _tool.MinLuminace = Convert.ToDouble(TB_Min_Luminace.Text);
                _tool.MaxDiameter = Convert.ToDouble(TB_MaxDiameter.Text);
                _tool.MinDiameter = Convert.ToDouble(TB_MinDiameter.Text);
                _tool.StartAngle = Convert.ToDouble(TB_Start_Angle.Text);
                _tool.EndAngle = Convert.ToDouble(TB_End_Angle.Text);
                _tool.IsRising = CB_IsRising.Checked;
                _tool.Dir = CbB_Direction.SelectedIndex;
                _tool.IsFilterAgain = CB_IsFilterAgain.Checked;
                _tool.UpdateResult();
                _tool.UpdateShape();
                _tool.UpdateCombinedTool();
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        private void CB_Disp_Loc_ValueChanged(object sender, bool value)
        {
            _tool.IsDispLoc = CB_Disp_Loc.Checked;
            _tool.UpdateShape();
        }
    }
}

using System;
using System.Windows.Forms;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class FitLineTool3DView : UserControl
    {
        FitLineTool3DModel _tool;

        public FitLineTool3DView()
        {
            InitializeComponent();
        }

        public FitLineTool3DView(FitLineTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            TB_Min_Height.Text = _tool.MinHeight.ToString();
            TB_Max_Height.Text = _tool.MaxHeight.ToString();
            TB_Min_Luminace.Text = _tool.MinLuminace.ToString();
            TB_Max_Luminace.Text = _tool.MaxLuminace.ToString();
            CB_IsRising.Checked = _tool.IsRising;
            CbB_Direction.SelectedIndex = _tool.Direction;
            CB_Disp_Loc.Checked = _tool.IsDispLoc;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            CB_IsRising.ValueChanged += ComboBox_ValueChanged;
            ResultsContainer.AddResult(_tool.Results);
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
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UITextBox tb = sender as UITextBox;
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
                _tool.FilterRatio = Convert.ToDouble(TB_Hot_Pixcel_Filter.Text);
                _tool.IsRising = CB_IsRising.Checked;
                _tool.Direction = CbB_Direction.SelectedIndex;
                _tool.UpdateResult();
                _tool.UpdateShape();
                _tool.UpdateCombinedTool();
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        private void CB_Disp_Loc_CheckedChanged(object sender, EventArgs e)
        {
            _tool.IsDispLoc = CB_Disp_Loc.Checked;
            _tool.UpdateShape();
        }

        private void CbB_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void Button_Add_ROI_Click(object sender, EventArgs e)
        {
            _tool.AddROI();
        }

        private void Button_Remove_ROI_Click(object sender, EventArgs e)
        {
            _tool.RemoveROI();
        }
    }
}

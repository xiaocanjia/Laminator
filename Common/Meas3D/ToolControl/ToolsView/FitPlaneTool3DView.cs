using System;
using System.Windows.Forms;

namespace Meas3D.Tool
{
    public partial class FitPlaneTool3DView : UserControl
    {
        FitPlaneTool3DModel _tool;

        public FitPlaneTool3DView()
        {
            InitializeComponent();
        }

        public FitPlaneTool3DView(FitPlaneTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {

        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void Button_Add_Region_Click(object sender, EventArgs e)
        {
            _tool.AddROI();
        }

        private void Button_Remove_Region_Click(object sender, EventArgs e)
        {
            _tool.RemoveROI();
        }
    }
}

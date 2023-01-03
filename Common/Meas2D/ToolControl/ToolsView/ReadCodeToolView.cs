using System;
using System.Windows.Forms;

namespace Meas2D
{
    public partial class ReadCodeToolView : UserControl
    {
        private ReadCodeToolModel _tool;

        public ReadCodeToolView()
        {
            InitializeComponent();
        }
        
        public ReadCodeToolView(ReadCodeToolModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            CbB_Code_Type.SelectedItem = _tool.CodeType;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
        }

        private void CbB_Code_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tool.CodeType = CbB_Code_Type.Text;
            _tool.CreateModel();
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }
    }
}

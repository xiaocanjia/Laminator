using System.Windows.Forms;

namespace Meas2D
{
    public partial class MinimizedView : UserControl
    {
        private Tool2DBaseModel _tool;

        private string _name = "";
        public string ToolName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Label_Name.Text = _name;
            }
        }

        public MinimizedView()
        {
            InitializeComponent();
            ToolTip toolTipSetup = new ToolTip();
            toolTipSetup.ShowAlways = true;
            toolTipSetup.SetToolTip(Button_Setup, "编辑");
            ToolTip toolTipCopy = new ToolTip();
            toolTipCopy.ShowAlways = true;
            toolTipCopy.SetToolTip(Button_Copy, "复制");
            ToolTip toolTipDelete = new ToolTip();
            toolTipDelete.ShowAlways = true;
            toolTipDelete.SetToolTip(Button_Delete, "删除");
        }

        public MinimizedView(Tool2DBaseModel tool) : this()
        {
            _tool = tool;
        }

        private void Button_Setup_Click(object sender, System.EventArgs e)
        {
            _tool.OpenSetupView();
        }

        private void Button_Delete_Click(object sender, System.EventArgs e)
        {
            _tool.DeleteTool();
        }

        private void Button_Copy_Click(object sender, System.EventArgs e)
        {
            _tool.CopyTool();
        }
    }
}

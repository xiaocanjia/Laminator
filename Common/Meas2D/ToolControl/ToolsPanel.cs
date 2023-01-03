using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Meas2D
{
    public partial class ToolsPanel : UserControl
    {
        private Tools2DManager _manager;

        public Action<ETool2DType> OnAddTool;

        public ToolsPanel()
        {
            InitializeComponent();
            Panel_Setup.BringToFront();
            Panel_Setup.Visible = false;
        }

        public void Init(Tools2DManager manager)
        {
            _manager = manager;
            _manager.OnAddTool = AddTool;
            _manager.OnRemoveTool = RemoveTool;
            _manager.OnOpenSetupPanel = OpenSetupPanel;
            _manager.OnCloseSetupPanel = CloseSetupPanel;
            CbB_Tools_List.Items.Clear();
            foreach (string key in _manager.ToolsName.Values)
                CbB_Tools_List.Items.Add(key);
            Panel_Tool_List.Controls.Clear();
            Panel_Setup.Visible = false;
            //不清除的话会一直保留着，下次打开的时候依旧打开之前删除的工具的界面
            Panel_Setup.Controls.Clear();
            foreach (Tool2DBaseModel tool in _manager.ToolsList)
            {
                AddTool(tool);
                _manager.InitTool(tool);
            }
        }

        private void Button_Add_Tool_Click(object sender, EventArgs e)
        {
            _manager.AddTool(_manager.ToolsName.FirstOrDefault(q => q.Value == CbB_Tools_List.Text).Key);
        }

        private void OpenSetupPanel(Tool2DBaseModel tool)
        {
            Panel_Setup.Visible = true;
            tool.SetupView.Dock = DockStyle.Fill;
            Panel_Setup.Controls.Add(tool.SetupView);
        }

        private void CloseSetupPanel(Tool2DBaseModel tool)
        {
            Panel_Setup.Visible = false;
            Panel_Setup.Controls.Clear();
            tool.SetupView.Dispose();
        }

        private void AddTool(Tool2DBaseModel tool)
        {
            //注意控件的Button_Copy,Button_Setup,Button_Delete的Anchor要设置成left，否则显示大小不对
            tool.NormalView.Size = new Size(Panel_Tool_List.Width - 5, tool.NormalView.Height);
            Panel_Tool_List.Controls.Add(tool.NormalView);
        }

        private void RemoveTool(Tool2DBaseModel tool)
        {
            Panel_Tool_List.Controls.Remove(tool.NormalView);
        }
    }
}

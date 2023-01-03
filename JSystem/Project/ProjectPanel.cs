using System;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.Project
{
    public partial class ProjectPanel : UserControl
    {
        ProjectManager _manager;

        public ProjectPanel()
        {
            InitializeComponent();
            ToolTip toolTipSave = new ToolTip();
            toolTipSave.ShowAlways = true;
            toolTipSave.SetToolTip(Button_SavePro, "保存");
            ToolTip toolTipDelete = new ToolTip();
            toolTipDelete.ShowAlways = true;
            toolTipDelete.SetToolTip(Button_DeletePro, "删除");
        }

        public void Init(ProjectManager manager)
        {
            if (manager == null)
                return;
            _manager = manager;
            _manager.OnSetUserRight = SetUserRight;
            CbB_Project_List.Items.Clear();
            foreach (string item in manager.Projects.ProjectsName)
                CbB_Project_List.Items.Add(item);
            CbB_Project_List.SelectedItem = manager.Projects.CurrProject;
            CbB_Project_List.SelectedIndexChanged += CbB_Project_List_SelectedIndexChanged;
        }

        private void SetUserRight(string right)
        {
            CbB_Project_List.Enabled = right == "操作员" ? false : true;
            Button_DeletePro.Enabled = right == "操作员" ? false : true;
            Button_SavePro.Enabled = right == "操作员" ? false : true;
        }

        private void Button_Save_Project_Click(object sender, EventArgs e)
        {
            if (CbB_Project_List.Text == "")
                return;
            if (!_manager.Projects.ProjectsName.Contains(CbB_Project_List.Text))
            {
                _manager.Projects.ProjectsName.Add(CbB_Project_List.Text);
                CbB_Project_List.Items.Add(CbB_Project_List.Text);
                CbB_Project_List.SelectedIndex = CbB_Project_List.Items.Count - 1;
            }
            if (_manager.SaveProject(CbB_Project_List.Text))
                UIMessageTip.ShowOk("保存成功");
            else
                UIMessageTip.ShowError("保存失败");
        }

        private void Button_Delete_Pro_Click(object sender, EventArgs e)
        {
            if (CbB_Project_List.Text == "")
                return;
            _manager.DeleteProject(CbB_Project_List.Text);
            CbB_Project_List.Items.Remove(CbB_Project_List.Text);
            CbB_Project_List.SelectedIndex = -1;
        }

        private void CbB_Project_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbB_Project_List.Text == "")
                return;
            _manager.LoadProject(CbB_Project_List.Text);
        }
    }
}

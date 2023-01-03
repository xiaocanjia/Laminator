using System;
using System.ComponentModel;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.Param
{
    public partial class ParamPage : UIPage
    {
        private ParamManager _manager;

        public ParamPage()
        {
            InitializeComponent();
            Shown += ParamPage_Shown;
        }

        private void ParamPage_Shown(object sender, EventArgs e)
        {
            SetRight(_manager.CurrRight);
        }

        public void Init(ParamManager manager)
        {
            if (manager == null)
                return;
            _manager = manager;
            _manager.OnSetUserRight = SetRight;
            DGV_Param.Columns[0].DataPropertyName = "Name";
            DGV_Param.Columns[0].ReadOnly = true;
            DGV_Param.Columns[1].DataPropertyName = "Type";
            DGV_Param.Columns[1].Visible = false;
            DGV_Param.Columns[2].DataPropertyName = "Value";
            DGV_Param.Columns[3].DataPropertyName = "Right";
            DGV_Param.DataSource = new BindingList<BasicParam>(_manager.ParamsArray);
            DGV_Param.AllowUserToAddRows = false;
        }

        public void SetRight(string right)
        {
            for (int i = 0; i < _manager.ParamsArray.Length; i++)
            {
                if (right == "操作员")
                {
                    if (_manager.ParamsArray[i].Right == "操作员")
                        DGV_Param.Rows[i].ReadOnly = false;
                    else
                        DGV_Param.Rows[i].ReadOnly = true;
                    DGV_Param.Columns[3].ReadOnly = true;
                }
                else if (right == "工程师")
                {
                    if (_manager.ParamsArray[i].Right == "操作员" || _manager.ParamsArray[i].Right == "工程师")
                        DGV_Param.Rows[i].ReadOnly = false;
                    else
                        DGV_Param.Rows[i].ReadOnly = true;
                    DGV_Param.Columns[3].ReadOnly = true;
                }
                else if (right == "管理员")
                {
                    DGV_Param.Rows[i].ReadOnly = false;
                    DGV_Param.Columns[3].ReadOnly = false;
                }
            }
        }

        private void DGV_Param_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= _manager.ParamsArray.Length)
                return;
            BasicParam param = _manager.ParamsArray[e.RowIndex];
            if (param.Type == "BOOL" && param.Value != "是" && param.Value != "否")
            {
                param.Value = "是";
                if (e.ColumnIndex == 1)
                    return;
                MessageBox.Show($"参数 {param.Name} 输入格式错误");
            }
            else if (param.Type == "DOUBLE" && !double.TryParse(param.Value, out double dResult))
            {
                param.Value = "0.0";
                if (e.ColumnIndex == 1)
                    return;
                MessageBox.Show($"参数 {param.Name} 输入格式不是double型");
            }
            else if (param.Type == "INT" && !int.TryParse(param.Value, out int iResult))
            {
                param.Value = "0";
                if (e.ColumnIndex == 1)
                    return;
                MessageBox.Show($"参数 {param.Name} 输入格式不是int型");
            }
        }

        private void DGV_Param_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex >= _manager.ParamsArray.Length || !DGV_Param.Enabled)
                return;
            BasicParam param = _manager.ParamsArray[e.RowIndex];
            if (e.ColumnIndex != 2) return;
            if (param.Type == "BOOL")
            {
                param.Value = param.Value == "是" ? "否" : "是";
                DGV_Param.Rows[e.RowIndex].Cells[2].ReadOnly = true;
            }
            else if (param.Name == "数据保存路径")
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() != DialogResult.OK) return;
                    DGV_Param.Rows[e.RowIndex].Cells[2].Value = dialog.SelectedPath;
                }
            }
        }
    }
}

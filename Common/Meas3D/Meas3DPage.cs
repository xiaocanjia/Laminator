using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace Meas3D
{
    public partial class Meas3DPage : UIPage
    {
        Meas3DManager _manager;

        public Meas3DPage()
        {
            InitializeComponent();
        }

        public Meas3DPage(Meas3DManager manager) : this()
        {
            _manager = manager;
            CB_Save_Data.Checked = manager.IsSaveImage;
            CB_Save_Fail_Image.Checked = manager.IsSaveFailOnly;
            CB_Save_Fail_Image.Visible = manager.IsSaveImage;
            TB_Image_Dir.Text = _manager.ImageDir;
            TB_Data_Dir.Text = _manager.DataDir;
            _manager.OnSetUserRight = SetUserRight;
            ToolTip toolTipScan = new ToolTip();
            toolTipScan.ShowAlways = true;
            ToolTip toolTipDownload = new ToolTip();
            toolTipDownload.ShowAlways = true;
            toolTipDownload.SetToolTip(Btn_Load_Matrix, "加载点云");
        }

        public override void Refresh()
        {
            base.Refresh();
            Win3D.Init(_manager.Win3DMgr);
            calib3DPanel.Init(_manager.CalibMgr);
            fixPosPanel.Init(_manager.FixPosMgr);
            toolsPanel.Init(_manager.ToolMgr);
        }

        private void SetUserRight(string right)
        {
            calib3DPanel.Enabled = right == "管理员" ? true : false;
            fixPosPanel.Enabled = right == "操作员" ? false : true;
            toolsPanel.Enabled = right == "操作员" ? false : true;
        }

        private void Btn_Load_Matrix_Click(object sender, EventArgs e)
        {
            if (Btn_Load_Matrix.Selected)
                return;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = "3D|*.tif";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                Btn_Load_Matrix.Selected = true;
                new Task(() =>
                {
                    foreach (string fileName in dialog.FileNames)
                        _manager.LoadMatrix3D(fileName);
                    Invoke(new Action(() => { Btn_Load_Matrix.Selected = false; }));
                }).Start();
            }
        }

        private void CB_Save_Image_CheckedChanged(object sender, EventArgs e)
        {
            _manager.IsSaveImage = CB_Save_Image.Checked;
            CB_Save_Fail_Image.Visible = _manager.IsSaveImage;
        }

        private void CB_Save_Fail_Image_CheckedChanged(object sender, EventArgs e)
        {
            _manager.IsSaveFailOnly = CB_Save_Fail_Image.Checked;
        }

        private void CB_Save_Data_CheckedChanged(object sender, EventArgs e)
        {
            _manager.IsSaveData = CB_Save_Data.Checked;
        }

        private void Btn_Image_Save_Dir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TB_Image_Dir.Text = dialog.SelectedPath;
                    _manager.ImageDir = dialog.SelectedPath;
                }
            }
        }

        private void Btn_Data_Save_Dir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TB_Data_Dir.Text = dialog.SelectedPath;
                    _manager.DataDir = dialog.SelectedPath;
                }
            }
        }

        private void Btn_Calib_Click(object sender, EventArgs e)
        {

        }
    }
}

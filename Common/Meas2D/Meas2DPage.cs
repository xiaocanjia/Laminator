using System;
using System.Windows.Forms;
using Sunny.UI;

namespace Meas2D
{
    public partial class Meas2DPage : UIPage
    {
        Meas2DManager _manager;

        public Meas2DPage()
        {
            InitializeComponent();
        }

        public Meas2DPage(Meas2DManager manager) : this()
        {
            _manager = manager;
        }

        public override void Refresh()
        {
            base.Refresh();
            Win2D.Init(_manager.Win2DMgr);
            fixPosPanel.Init(_manager.FixPosMgr);
            toolsPanel.Init(_manager.ToolMgr);
        }

        private void Btn_Start_Grab_Click(object sender, EventArgs e)
        {
            _manager.OnStartGrab?.Invoke();
        }

        private void Btn_Load_Image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image(*.jpg;*.bmp)|*.jpg;*.bmp";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                _manager.LoadImage(dialog.FileName);
            }
        }

        private void Btn_Save_Image_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Image(*.jpg)|*.jpg";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                _manager.SaveImage(dialog.FileName);
            }
        }
    }
}

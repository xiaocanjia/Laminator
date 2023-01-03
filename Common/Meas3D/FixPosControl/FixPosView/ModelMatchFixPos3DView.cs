using System;
using System.Windows.Forms;

namespace Meas3D.FixPos
{
    public partial class ModelMatchFixPos3DView : UserControl
    {
        private ModelMatchFixPos3DModel _fixPos;

        public ModelMatchFixPos3DView(ModelMatchFixPos3DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
        }

        private void Button_Enable_FixPos_Click(object sender, EventArgs e)
        {
            _fixPos.EnableFixPos();
        }

        private void Button_Disable_FixPos_Click(object sender, EventArgs e)
        {
            _fixPos.DisableFixPos();
        }

        private void Button_Delete_FixPos_Click(object sender, EventArgs e)
        {
            _fixPos.DeleteFixPos();
        }

        private void Btn_Create_Model_Click(object sender, EventArgs e)
        {
            _fixPos.CreateModel();
        }

        private void Button_Add_ROI_Click(object sender, EventArgs e)
        {
            _fixPos.AddROI();
        }

        private void Button_Remove_ROI_Click(object sender, EventArgs e)
        {
            _fixPos.RemoveROI();
        }
    }
}

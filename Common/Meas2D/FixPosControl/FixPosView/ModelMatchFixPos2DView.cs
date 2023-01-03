using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meas2D.FixPos
{
    public partial class ModelMatchFixPos2DView : UserControl
    {
        private ModelMatchFixPos2DModel _fixPos;

        public ModelMatchFixPos2DView(ModelMatchFixPos2DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
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

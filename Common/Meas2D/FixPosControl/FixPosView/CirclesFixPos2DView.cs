using System;
using System.Windows.Forms;

namespace Meas2D.FixPos
{
    public partial class CirclesFixPos2DView : UserControl
    {
        private CirclesFixPos2DModel _fixPos;

        public CirclesFixPos2DView(CirclesFixPos2DModel fixPos)
        {
            InitializeComponent();
            _fixPos = fixPos;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_Min_Gray1.Text = _fixPos.MinGray1.ToString();
            TB_Max_Gray1.Text = _fixPos.MaxGray1.ToString();
            TB_Min_Area1.Text = _fixPos.MinArea1.ToString();
            TB_Max_Area1.Text = _fixPos.MaxArea1.ToString();
            TB_Min_Gray2.Text = _fixPos.MinGray2.ToString();
            TB_Max_Gray2.Text = _fixPos.MaxGray2.ToString();
            TB_Min_Area2.Text = _fixPos.MinArea2.ToString();
            TB_Max_Area2.Text = _fixPos.MaxArea2.ToString();
        }

        private void CbB_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void ComboBox_ValueChanged(object sender, bool value)
        {
            UpdateValue();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue();
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            try
            {
                _fixPos.MaxGray1 = Convert.ToDouble(TB_Max_Gray1.Text);
                _fixPos.MinGray1 = Convert.ToDouble(TB_Min_Gray1.Text);
                _fixPos.MaxArea1 = Convert.ToDouble(TB_Max_Area1.Text);
                _fixPos.MinArea1 = Convert.ToDouble(TB_Min_Area1.Text);
                _fixPos.MaxGray2 = Convert.ToDouble(TB_Max_Gray2.Text);
                _fixPos.MinGray2 = Convert.ToDouble(TB_Min_Gray2.Text);
                _fixPos.MaxArea2 = Convert.ToDouble(TB_Max_Area2.Text);
                _fixPos.MinArea2 = Convert.ToDouble(TB_Min_Area2.Text);
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
            _fixPos.UpdatePos();
            _fixPos.UpdateShape();
        }
    }
}

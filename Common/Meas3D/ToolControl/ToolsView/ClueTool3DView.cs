using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Meas3D.Tool
{
    public partial class ClueTool3DView : UserControl
    {
        ClueTool3DModel _tool;

        private List<Tool3DBaseModel> _planes;

        public ClueTool3DView()
        {
            InitializeComponent();
        }

        public ClueTool3DView(ClueTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            TB_Min_Height.Text = _tool.MinHeight.ToString();
            TB_Max_Height.Text = _tool.MaxHeight.ToString();
            TB_Min_Luminace.Text = _tool.MinLuminace.ToString();
            TB_Max_Luminace.Text = _tool.MaxLuminace.ToString();
            TB_Line_Width.Text = _tool.LineWidth.ToString();
            TB_Density.Text = _tool.Density.ToString();
            _planes = _tool.OnGetToolsList().FindAll(t => (t is FitPlaneTool3DModel));
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            if (Btn_Add_Begin.Text == "删除")
                _tool.AddFinished();
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
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
            TextBox tb = sender as TextBox;
            if (tb.Name == "TB_Name")
            {
                _tool.Name = TB_Name.Text;
                return;
            }
            UpdateValue();
        }

        private void UpdateValue()
        {
            try
            {
                _tool.MaxHeight = Convert.ToDouble(TB_Max_Height.Text);
                _tool.MinHeight = Convert.ToDouble(TB_Min_Height.Text);
                _tool.MaxLuminace = Convert.ToByte(TB_Max_Luminace.Text);
                _tool.MinLuminace = Convert.ToByte(TB_Min_Luminace.Text);
                _tool.UpdateResult();
                _tool.UpdateShape();
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }

        private void TB_Density_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            int density = Convert.ToInt32(TB_Density.Text);
            if (_tool.Density == density)
                return;
            _tool.Density = density;
            _tool.InitShape();
            _tool.ResetResults();
            ResultsContainer.AddResult(_tool.Results);
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void TB_Density_Leave(object sender, EventArgs e)
        {
            int density = Convert.ToInt32(TB_Density.Text);
            if (_tool.Density == density)
                return;
            _tool.Density = density;
            _tool.InitShape();
            _tool.ResetResults();
            ResultsContainer.AddResult(_tool.Results);
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void Btn_Add_Begin_Click(object sender, EventArgs e)
        {
            if (Btn_Add_Begin.Text == "开始添加")
            {
                _tool.AddPoints();
                Btn_Add_Begin.Text = "删除";
            }
            else if (Btn_Add_Begin.Text == "删除")
            {
                _tool.DeletePoint();
            }
        }

        private void Btn_Add_Finished_Click(object sender, EventArgs e)
        {
            _tool.AddFinished();
            Btn_Add_Begin.Text = "开始添加";
            ResultsContainer.AddResult(_tool.Results);
        }

        private void Btn_Delete_Points_Click(object sender, EventArgs e)
        {
            _tool.DeleteAllPoints();
            ResultsContainer.AddResult(_tool.Results);
        }

        private void TB_Line_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;
            double lineWidth = Convert.ToDouble(TB_Line_Width.Text);
            if (_tool.LineWidth == lineWidth)
                return;
            _tool.LineWidth = lineWidth;
            _tool.InitShape();
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void TB_Line_Width_Leave(object sender, EventArgs e)
        {
            double lineWidth = Convert.ToDouble(TB_Line_Width.Text);
            if (_tool.LineWidth == lineWidth)
                return;
            _tool.LineWidth = lineWidth;
            _tool.InitShape();
            _tool.UpdateResult();
            _tool.UpdateShape();
        }
    }

}

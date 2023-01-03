using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vision3D;

namespace Meas3D.Tool
{
    public partial class VertexLocTool3DView : UserControl
    {
        VertexLocTool3DModel _tool;

        private List<Tool3DBaseModel> _planes;

        public VertexLocTool3DView()
        {
            InitializeComponent();
        }

        public VertexLocTool3DView(VertexLocTool3DModel tool) : this()
        {
            _tool = tool;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            TB_Name.Text = _tool.Name;
            TB_Max_Luminace.Text = _tool.MaxLuminace.ToString();
            TB_Min_Luminace.Text = _tool.MinLuminace.ToString();
            TB_Max_Height.Text = _tool.MaxHeight.ToString();
            TB_Min_Height.Text = _tool.MinHeight.ToString();
            _planes = _tool.OnGetToolsList().FindAll(t => (t is FitPlaneTool3DModel));
            List<string> planesNames = new List<string>();
            planesNames.Add("无");
            foreach (var plane in _planes)
                planesNames.Add(plane.Name);
            CbB_Planes.Items.AddRange(planesNames.ToArray());
            CbB_Planes.SelectedItem = _tool.Plane != null ? _tool.Plane.Name : "无";
            CbB_Point_Type.SelectedIndex = _tool.PointType;
            switch (_tool.ShapeType)
            {
                case EShape3DType.RECT:
                    CbB_ROI_Type.SelectedIndex = 0;
                    break;
                case EShape3DType.CIRCLE:
                    CbB_ROI_Type.SelectedIndex = 1;
                    break;
                case EShape3DType.LINE:
                    CbB_ROI_Type.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            ResultsContainer.AddResult(_tool.Results);
            CbB_Planes.SelectedIndexChanged += CbB_Plane_SelectedIndexChanged;
            CbB_ROI_Type.SelectedIndexChanged += CbB_ROI_Type_SelectedIndexChanged;
            CbB_Point_Type.SelectedIndexChanged += CbB_Point_Type_SelectedIndexChanged;
        }

        private void CbB_Plane_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tool.Plane = _planes.Find(plane => (plane.Name == CbB_Planes.SelectedItem.ToString())) as FitPlaneTool3DModel;
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void CbB_Point_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tool.PointType = CbB_Point_Type.SelectedIndex;
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void CbB_ROI_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbB_ROI_Type.SelectedIndex)
            {
                case 0:
                    _tool.ShapeType = EShape3DType.RECT;
                    break;
                case 1:
                    _tool.ShapeType = EShape3DType.CIRCLE;
                    break;
                case 2:
                    _tool.ShapeType = EShape3DType.LINE;
                    break;
                default:
                    break;
            }
            _tool.ChangeShape();
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                UpdateValue();
                _tool.UpdateResult();
                _tool.UpdateShape();
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            UpdateValue();
            _tool.UpdateResult();
            _tool.UpdateShape();
        }

        private void UpdateValue()
        {
            try
            {
                _tool.MaxLuminace = Convert.ToByte(TB_Max_Luminace.Text);
                _tool.MinLuminace = Convert.ToByte(TB_Min_Luminace.Text);
                _tool.MaxHeight = Convert.ToSingle(TB_Max_Height.Text);
                _tool.MinHeight = Convert.ToSingle(TB_Min_Height.Text);
            }
            catch
            {
                MessageBox.Show("输入字符串格式不正确！");
            }
        }
    }
}

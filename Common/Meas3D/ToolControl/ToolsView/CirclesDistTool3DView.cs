using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class CirclesDistTool3DView : UserControl
    {
        private CirclesDistTool3DModel _tool;

        private List<Tool3DBaseModel> _circles;

        public CirclesDistTool3DView()
        {
            InitializeComponent();
        }

        public CirclesDistTool3DView(CirclesDistTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            _circles = _tool.OnGetToolsList().FindAll(t => (t is FitCircleTool3DModel));
            List<string> names = new List<string>();
            foreach (var circle in _circles)
                names.Add(circle.Name);
            CbB_Circles_List1.Items.AddRange(names.ToArray());
            CbB_Circles_List2.Items.AddRange(names.ToArray());
            if (_tool.Circle1 != null)
                CbB_Circles_List1.SelectedItem = _tool.Circle1.Name;
            if (_tool.Circle2 != null)
                CbB_Circles_List2.SelectedItem = _tool.Circle2.Name;
            CbB_Dist_Type.SelectedIndex = _tool.DistType;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
            CbB_Circles_List1.SelectedIndexChanged += ComboBox_Circles_List_SelectedIndexChanged;
            CbB_Circles_List2.SelectedIndexChanged += ComboBox_Circles_List_SelectedIndexChanged;
            CbB_Dist_Type.SelectedIndexChanged += CbB_Dist_Type_SelectedIndexChanged;
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void ComboBox_Circles_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIComboBox combobox = sender as UIComboBox;
            if (combobox.Name.Contains("List1"))
                _tool.Circle1 = _circles.Find(circle => (circle.Name == combobox.SelectedItem.ToString())) as FitCircleTool3DModel;
            else if (combobox.Name.Contains("List2"))
                _tool.Circle2 = _circles.Find(circle => (circle.Name == combobox.SelectedItem.ToString())) as FitCircleTool3DModel;
            _tool.UpdateResult();
        }

        private void CbB_Dist_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tool.DistType = CbB_Dist_Type.SelectedIndex;
            _tool.UpdateResult();
            _tool.UpdateShape();
        }
    }
}

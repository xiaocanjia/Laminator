using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class PlanesIntersectionTool3DView : UserControl
    {
        private PlanesIntersectionTool3DModel _tool;

        private List<Tool3DBaseModel> _planes;

        public PlanesIntersectionTool3DView()
        {
            InitializeComponent();
        }

        public PlanesIntersectionTool3DView(PlanesIntersectionTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            _planes = _tool.OnGetToolsList().FindAll(t => (t is FitPlaneTool3DModel));
            List<string> planesNames = new List<string>();
            foreach (var plane in _planes)
                planesNames.Add(plane.Name);
            CbB_Plane1_List.Items.AddRange(planesNames.ToArray());
            CbB_Plane2_List.Items.AddRange(planesNames.ToArray());
            CbB_Plane3_List.Items.AddRange(planesNames.ToArray());
            if (_tool.Plane1 != null)
                CbB_Plane1_List.SelectedItem = _tool.Plane1.Name;
            if (_tool.Plane2 != null)
                CbB_Plane2_List.SelectedItem = _tool.Plane2.Name;
            if (_tool.Plane2 != null)
                CbB_Plane3_List.SelectedItem = _tool.Plane3.Name;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void ComboBox_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIComboBox combobox = sender as UIComboBox;
            if (combobox.Name.Contains("Plane1"))
                _tool.Plane1 = _planes.Find(plane => (plane.Name == combobox.SelectedItem.ToString())) as FitPlaneTool3DModel;
            else if (combobox.Name.Contains("Plane2"))
                _tool.Plane2 = _planes.Find(plane => (plane.Name == combobox.SelectedItem.ToString())) as FitPlaneTool3DModel;
            else if (combobox.Name.Contains("Plane3"))
                _tool.Plane3 = _planes.Find(plane => (plane.Name == combobox.SelectedItem.ToString())) as FitPlaneTool3DModel;
            _tool.UpdateResult();
        }
    }
}

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class PointsDistTool3DView : UserControl
    {
        private PointsDistTool3DModel _tool;

        private List<Tool3DBaseModel> _points;

        public PointsDistTool3DView()
        {
            InitializeComponent();
        }

        public PointsDistTool3DView(PointsDistTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            _points = _tool.OnGetToolsList().FindAll(t => (t is PointToolModel));
            List<string> names = new List<string>();
            foreach (var circle in _points)
                names.Add(circle.Name);
            CbB_Points_List1.Items.AddRange(names.ToArray());
            CbB_Points_List2.Items.AddRange(names.ToArray());
            if (_tool.Point1 != null)
                CbB_Points_List1.SelectedItem = _tool.Point1.Name;
            if (_tool.Point2 != null)
                CbB_Points_List2.SelectedItem = _tool.Point2.Name;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
            CbB_Points_List1.SelectedIndexChanged += ComboBox_Points_List_SelectedIndexChanged;
            CbB_Points_List2.SelectedIndexChanged += ComboBox_Points_List_SelectedIndexChanged;
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void ComboBox_Points_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIComboBox combobox = sender as UIComboBox;
            if (combobox.Name.Contains("List1"))
                _tool.Point1 = _points.Find(circle => (circle.Name == combobox.SelectedItem.ToString())) as PointToolModel;
            else if (combobox.Name.Contains("List2"))
                _tool.Point2 = _points.Find(circle => (circle.Name == combobox.SelectedItem.ToString())) as PointToolModel;
            _tool.UpdateResult();
        }
    }
}

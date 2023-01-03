using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class CTLDistTool3DView : UserControl
    {
        private CTLDistTool3DModel _tool;

        private List<Tool3DBaseModel> _circles;

        private List<Tool3DBaseModel> _lines;

        public CTLDistTool3DView()
        {
            InitializeComponent();
        }

        public CTLDistTool3DView(CTLDistTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            _circles = _tool.OnGetToolsList().FindAll(t => (t is FitCircleTool3DModel));
            List<string> circlesNames = new List<string>();
            foreach (var circle in _circles)
                circlesNames.Add(circle.Name);
            CbB_Circles_List.Items.AddRange(circlesNames.ToArray());
            _lines = _tool.OnGetToolsList().FindAll(t => (t is FitLineTool3DModel));
            List<string> linesNames = new List<string>();
            foreach (var line in _lines)
                linesNames.Add(line.Name);
            CbB_Lines_List.Items.AddRange(linesNames.ToArray());
            if (_tool.Circle != null)
                CbB_Circles_List.SelectedItem = _tool.Circle.Name;
            if (_tool.Line != null)
                CbB_Lines_List.SelectedItem = _tool.Line.Name;
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
            if (combobox.Name.Contains("Circles"))
                _tool.Circle = _circles.Find(circle => (circle.Name == combobox.SelectedItem.ToString())) as FitCircleTool3DModel;
            else if (combobox.Name.Contains("Lines"))
                _tool.Line = _lines.Find(line => (line.Name == combobox.SelectedItem.ToString())) as FitLineTool3DModel;
            _tool.UpdateResult();
        }
    }
}

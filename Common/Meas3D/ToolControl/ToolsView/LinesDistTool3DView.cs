using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sunny.UI;

namespace Meas3D.Tool
{
    public partial class LinesDistTool3DView : UserControl
    {
        private LinesDistTool3DModel _tool;

        private List<Tool3DBaseModel> _lines;

        public LinesDistTool3DView()
        {
            InitializeComponent();
        }

        public LinesDistTool3DView(LinesDistTool3DModel tool) : this()
        {
            _tool = tool;
            TB_Name.Text = _tool.Name;
            _lines = _tool.OnGetToolsList().FindAll(t => (t is FitLineTool3DModel));
            List<string> names = new List<string>();
            foreach (var circle in _lines)
                names.Add(circle.Name);
            CbB_Lines_List1.Items.AddRange(names.ToArray());
            CbB_Lines_List2.Items.AddRange(names.ToArray());
            if (_tool.Line1 != null)
                CbB_Lines_List1.SelectedItem = _tool.Line1.Name;
            if (_tool.Line2 != null)
                CbB_Lines_List2.SelectedItem = _tool.Line2.Name;
            _tool.OnUpdateValue += ResultsContainer.UpdateValues;
            ResultsContainer.AddResult(_tool.Results);
            CbB_Lines_List1.SelectedIndexChanged += ComboBox_Lines_List_SelectedIndexChanged;
            CbB_Lines_List2.SelectedIndexChanged += ComboBox_Lines_List_SelectedIndexChanged;
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            _tool.Name = TB_Name.Text;
            _tool.CloseSetupView();
        }

        private void ComboBox_Lines_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIComboBox combobox = sender as UIComboBox;
            if (combobox.Name.Contains("List1"))
                _tool.Line1 = _lines.Find(line => (line.Name == combobox.SelectedItem.ToString())) as FitLineTool3DModel;
            else if (combobox.Name.Contains("List2"))
                _tool.Line2 = _lines.Find(line => (line.Name == combobox.SelectedItem.ToString())) as FitLineTool3DModel;
            _tool.UpdateResult();
        }
    }
}

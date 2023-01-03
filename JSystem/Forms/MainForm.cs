using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunny.UI;

namespace JSystem
{
    public partial class MainForm : UIHeaderMainFrame
    {
        private AutoForm _autoForm;

        private DebugForm _debugForm;

        private DevicesForm _devicesForm;

        private ParamsForm _paramsForm;

        private SystemForm _systemForm;

        public MainForm()
        {
            InitializeComponent();
            _autoForm = new AutoForm();
            Header.TabControl = MainTabControl;
            AddPage(_autoForm, 1001);
            Header.SetNodePageIndex(Header.Nodes[0], 1001);
            Header.SetNodeSymbol(Header.Nodes[0], 61461, 40);
            _debugForm = new DebugForm();
            Header.TabControl = MainTabControl;
            AddPage(_debugForm, 1002);
            Header.SetNodePageIndex(Header.Nodes[1], 1002);
            Header.SetNodeSymbol(Header.Nodes[1], 61613, 40);
            _devicesForm = new DevicesForm();
            AddPage(_devicesForm, 1003);
            Header.SetNodePageIndex(Header.Nodes[2], 1003);
            Header.SetNodeSymbol(Header.Nodes[2], 61643, 40);
            _paramsForm = new ParamsForm();
            AddPage(_paramsForm, 1004);
            Header.SetNodePageIndex(Header.Nodes[3], 1004);
            Header.SetNodeSymbol(Header.Nodes[3], 61742, 40);
            _systemForm = new SystemForm();
            AddPage(_systemForm, 1005);
            Header.SetNodePageIndex(Header.Nodes[4], 1005);
            Header.SetNodeSymbol(Header.Nodes[4], 61459, 40);
            Header.SelectedIndex = 4;
            Icon = Icon.ExtractAssociatedIcon("Logo.ico");
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;
using JSystem.Perform;
using JSystem.Station;
using JSystem.Device;
using JSystem.IO;
using JSystem.User;
using JSystem.Param;
using Vision3D;

namespace JSystem
{
    public partial class MainWindow : UIHeaderMainFrame
    {
        private SysController _controller;

        private PerformPage _performPage;

        private IOPage _IOPage;

        private StationsPage _stationPage;

        private DevicePage _devicePage;

        private ParamPage _paramsPage;

        private LoginForm _loginForm;

        private JWindow3D _win3D;

        public MainWindow()
        {
            InitializeComponent();
            Load += MainWindow_Load;
            Shown += MainWindow_Shown;
            FormClosing += MainWindow_FormClosing;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            TopMost = false;
            //_loginForm.Display();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.UnInit();
        }

        public MainWindow(SysController controller) : this()
        {
            _controller = controller;
            _controller.OnInitUI = InitUI;
            _controller.OnSetEnable = SetEnable;
            _loginForm = new LoginForm();
            Application.AddMessageFilter(_loginForm);
            Header.TabControl = MainTabControl;
            _performPage = new PerformPage();
            _IOPage = new IOPage();
            _stationPage = new StationsPage();
            _devicePage = new DevicePage();
            _paramsPage = new ParamPage();
            AddPage(_performPage, 1001, 0, 61461);
            AddPage(_IOPage, 1002, 1, 61729);
            AddPage(_stationPage, 1003, 2, 61613);
            AddPage(_devicePage, 1004, 3, 61573);
            AddPage(_paramsPage, 1005, 4, 61643);
            Icon = Icon.ExtractAssociatedIcon("Logo.ico");
            projectPanel.Init(_controller.ProjectMgr);
            InitUI();
        }

        private void AddPage(UIPage page, int pageIdx, int nodeIdx, int symbol)
        {
            AddPage(page, pageIdx);
            Header.SetNodePageIndex(Header.Nodes[nodeIdx], pageIdx);
            Header.SetNodeSymbol(Header.Nodes[nodeIdx], symbol, 40);
        }

        private void InitUI()
        {
            try
            {
                if (_controller == null) return;
                _loginForm.Init(_controller.LoginMgr);
                _performPage.Init(_controller.PerformMgr);
                _performPage.StatusPanel.Init(_controller.DeviceMgr);
                _IOPage.Init(_controller.IOMgr);
                _stationPage.Init(_controller.StationMgr);
                _devicePage.Init(_controller.DeviceMgr);
                _paramsPage.Init(_controller.ParamMgr);
                _win3D = _controller.StationMgr.Vision.Meas3DMgr.Page.Win3D;
                Header_MenuItemClick(Header.Text, 0, 0);
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog(ex.Message, true);
            }
        }

        private void SetEnable(bool isEnable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { SetEnable(isEnable); }));
            }
            else
            {
                projectPanel.Enabled = isEnable;
                _IOPage.Enabled = isEnable;
                _stationPage.Enabled = isEnable;
                _devicePage.Enabled = isEnable;
                _paramsPage.Enabled = isEnable;
            }
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            _loginForm.Display();
        }

        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            if (menuIndex == 0)
            {
                _controller.StationMgr?.Vision.Meas3DMgr.Page?.Panel_Vision.Controls.Clear();
                _performPage.Panel_Vision.Controls.Clear();
                _performPage.Panel_Vision.Controls.Add(_win3D);
            }
            if (menuIndex == 1)
            {
                _IOPage.StartMonitor();
            }
            else
            {
                _IOPage.StopMonitor();
            }
        }
    }
}

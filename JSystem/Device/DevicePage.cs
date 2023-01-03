using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.Device
{
    public partial class DevicePage : UIPage
    {
        private DeviceManager _manager;
        
        public DevicePage()
        {
            InitializeComponent();
        }

        public void Init(DeviceManager manager)
        {
            _manager = manager;
            _manager.OnSetUserRight = SetUserRight;
            Tab_Devices.TabPages.Clear();
            foreach (DeviceBase device in manager.DeviceList)
            {
                TabPage page = new TabPage(device.Name);
                Tab_Devices.TabPages.Add(page);
                page.Controls.Add(device.View);
                device.View.Refresh();
                device.View.Dock = DockStyle.Fill;
                device.View.Show();
            }
        }

        public void SetUserRight(string right)
        {
            foreach (DeviceBase device in _manager.DeviceList)
            {
                if (right == "操作员")
                    device.View.Enabled = false;
                else
                    device.View.Enabled = true;
            }
        }
    }
}

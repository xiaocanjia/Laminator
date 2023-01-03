using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSystem.Device;
using JSystem.Param;

namespace JSystem.Perform
{
    public partial class StatusPanel : UserControl
    {
        private DeviceManager _manager;

        private bool _isDisableDoor = false;

        public StatusPanel()
        {
            InitializeComponent();
        }

        public void Init(DeviceManager manager)
        {
            _manager = manager;
            _manager.OnUpdateView = UpdateState;
            for (int i = 0; i < manager.DeviceList.Count; i++)
            {
                DevStatusPanel panel = manager.DeviceList[i].StatusPanel;
                Panel_State.Controls.Add(panel);
            }
            Timer_Monitor.Enabled = true;
        }

        public void UpdateState(string state, Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateState(state, color); }));
            }
            else
            {
                Lb_State.Text = state;
                Lb_State.ForeColor = color;
            }
        }

        private void Timer_Monitor_Tick(object sender, EventArgs e)
        {
            new Task(() =>
            {
                foreach (DeviceBase device in _manager.DeviceList)
                    device.CheckConnection();
                if (_isDisableDoor != ParamManager.GetBoolParam("禁用安全门"))
                {
                    _isDisableDoor = !_isDisableDoor;
                    UpdateDoorState();
                }
            }).Start();
        }

        private void UpdateDoorState()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateDoorState(); }));
            }
            else
            {
                Lb_Door.Text = _isDisableDoor ? "已禁用" : "已启用";
                Lb_Door.ForeColor = _isDisableDoor ? Color.Red : Color.Green;
            }
        }
    }
}

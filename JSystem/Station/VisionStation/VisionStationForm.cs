using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.Station
{
    public partial class VisionStationForm : UIForm
    {
        private VisionStation _station;

        public VisionStationForm()
        {
            InitializeComponent();
            FormClosed += VisionStationForm_FormClosed;
            Shown += VisionStationForm_Shown;
        }

        private void VisionStationForm_Shown(object sender, System.EventArgs e)
        {
            _station.Meas3DMgr.Page.Panel_Vision.Controls.Add(_station.Meas3DMgr.Page.Win3D);
        }

        private void VisionStationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _station.Meas3DMgr.Page.Panel_Vision.Controls.Clear();
            Hide();
        }

        public VisionStationForm(VisionStation station) : this()
        {
            _station = station;
        }

        public override void Refresh()
        {
            base.Refresh();
            TB_PCL_Length.Text = _station.PCLLength.ToString();
            TB_Joint_Count.Text = _station.JointCount.ToString();
            TB_Scan_Speed.Text = _station.ScanSpeed.ToString();
            Panel_Meas.Controls.Add(_station.Meas3DMgr.Page);
            _station.Meas3DMgr.Page.TopLevel = false;
            _station.Meas3DMgr.Page.Dock = DockStyle.Fill;
            _station.Meas3DMgr.Page.Show();
            _station.Meas3DMgr.Page.Refresh();
        }

        private void Btn_Start_Grab_Click(object sender, System.EventArgs e)
        {
            try
            {
                _station.PCLLength = Convert.ToDouble(TB_PCL_Length.Text);
                _station.ScanSpeed = Convert.ToDouble(TB_Scan_Speed.Text);
                _station.JointCount = Convert.ToInt32(TB_Joint_Count.Text);
                _station.GrabCount = Convert.ToInt32(TB_Grab_Count.Text);
            }
            catch
            {
                UIMessageBox.Show("输入字符串格式不正确！");
                return;
            }
            if (Btn_Start_Grab.Selected == false)
            {
                new Task(() =>
                {
                    Invoke(new Action(() => { Btn_Start_Grab.Selected = true; }));
                    if (!_station.StartGrab())
                        UIMessageTip.ShowWarning("请检查机台是否复位和相机是否连接");
                    Invoke(new Action(() => { Btn_Start_Grab.Selected = false; }));
                }).Start();
            }
            else
            {
                _station.EndGrab();
                Btn_Start_Grab.Selected = false;
            }
        }
    }
}

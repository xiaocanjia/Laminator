using System;
using System.Windows.Forms;
using Sunny.UI;

namespace JSystem.Station
{
    public partial class ReadCodeStationFrom : UIForm
    {
        private ReadCodeStation _station;

        public ReadCodeStationFrom()
        {
            InitializeComponent();
            Shown += ReadCodeStationFrom_Shown;
            FormClosed += ReadCodeStationFrom_FormClosed;
        }

        private void ReadCodeStationFrom_Shown(object sender, EventArgs e)
        {
            _station.Meas2DMgr.Page.Panel_Vision.Controls.Add(_station.Meas2DMgr.Page.Win2D);
            _station.Meas2DMgr.Page.Win2D.RePaint();
        }

        private void ReadCodeStationFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            _station.Meas2DMgr.Page.Panel_Vision.Controls.Clear();
            Hide();
        }

        public ReadCodeStationFrom(ReadCodeStation station) : this()
        {
            _station = station;
        }

        public override void Refresh()
        {
            base.Refresh();
            Controls.Add(_station.Meas2DMgr.Page);
            _station.Meas2DMgr.Page.TopLevel = false;
            _station.Meas2DMgr.Page.Dock = DockStyle.Fill;
            _station.Meas2DMgr.Page.Show();
            _station.Meas2DMgr.Page.Refresh();
        }

        private void Btn_Start_Grab_Click(object sender, EventArgs e)
        {

        }
    }
}

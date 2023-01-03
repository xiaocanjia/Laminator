using JSystem.Param;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JSystem.Perform
{
    public partial class StatisticsPanel : UserControl
    {
        StatisticsManager _manager;

        private int _pdtIdx = 0;

        public StatisticsPanel()
        {
            InitializeComponent();
        }

        public void Init(StatisticsManager manager)
        {
            _manager = manager;
            _manager.OnUpdateDispaly = UpdateDisplay;
        }

        public void UpdateDisplay()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateDisplay(); }));
            }
            else
            {
                Lb_Curr_Decision.Text = _manager.CurrDecision;
                Lb_Curr_Decision.ForeColor = _manager.CurrDecision == "PASS" ? Color.Green : Color.Red;
                Lb_OK_Pct.Text = ((_manager.Pass / Convert.ToDouble(_manager.Total)) * 100).ToString("F1") + "%";
                Lb_Total.Text = _manager.Total.ToString();
                Lb_Pass.Text = _manager.Pass.ToString();
                Lb_Fail.Text = _manager.Fail.ToString();
                Lb_CT.Text = _manager.CT.ToString();
                Lb_UPH.Text = _manager.UPH.ToString();
                _pdtIdx++;
            }
        }
    }
}

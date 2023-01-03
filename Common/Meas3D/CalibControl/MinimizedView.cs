using System;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;

namespace Meas3D.Calib
{
    public partial class MinimizedView : UserControl
    {
        Calib3DPointsModel _model;

        public MinimizedView()
        {
            InitializeComponent();
        }

        public MinimizedView(Calib3DPointsModel model) : this()
        {
            _model = model;
        }

        public override void Refresh()
        {
            base.Refresh();
            foreach (Step3DModel step in _model.Steps)
            {
                UIButton btn = new UIButton();
                btn.StyleCustomMode = true;
                btn.FillColor = Color.SteelBlue;
                btn.Size = new Size(65, 30);
                btn.Text = $"台阶{Panel_Steps.Controls.Count + 1}";
                btn.Click += Btn_Click;
                Panel_Steps.Controls.Add(btn);
            }
        }

        private void Btn_Add_Step_Click(object sender, EventArgs e)
        {
            UIButton btn = new UIButton();
            btn.StyleCustomMode = true;
            btn.FillColor = Color.SteelBlue;
            btn.Size = new Size(65, 30);
            btn.Text = $"台阶{Panel_Steps.Controls.Count + 1}";
            btn.Click += Btn_Click;
            _model.AddStep();
            Panel_Steps.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            int idx = Convert.ToInt32(btn.Text.Substring(2)) - 1;
            _model.OpenStepPanel(idx);
        }

        private void Btn_Remove_Step_Click(object sender, EventArgs e)
        {
            if (Panel_Steps.Controls.Count == 0)
                return;
            Panel_Steps.Controls.RemoveAt(Panel_Steps.Controls.Count - 1);
            _model.RemoveStep();
        }
    }
}

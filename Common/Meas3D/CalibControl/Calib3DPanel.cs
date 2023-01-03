using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Serilizer;
using Sunny.UI;

namespace Meas3D.Calib
{
    public partial class Calib3DPanel : UserControl
    {
        private Calib3DManager _manager;

        public Calib3DPanel()
        {
            InitializeComponent();
        }

        public void Init(Calib3DManager manager)
        {
            _manager = manager;
            Panel_Calibs.Controls.Clear();
            _manager.OnOpenStepPanel = OpenStepPanel;
            _manager.OnClseStepPanel = CloseSetupPanel;
            foreach (Calib3DPointsModel model in manager.ModelList)
            {
                Panel_Calibs.Controls.Add(model.NormalView);
                model.NormalView.Enabled = !_manager.IsCalib;
                model.NormalView.Refresh();
                _manager.InitCalib(model);
            }
            Btn_Enable_Calib.Selected = _manager.IsCalib;
        }

        private void Btn_Add_Calib_Click(object sender, EventArgs e)
        {
            if (_manager.IsCalib)
                return;
            Calib3DPointsModel model = new Calib3DPointsModel();
            _manager.AddCliab(model);
            Panel_Calibs.Controls.Add(model.NormalView);
            //model.View.Refresh();
        }

        private void Btn_Remove_Calib_Click(object sender, EventArgs e)
        {
            if (_manager.IsCalib || _manager.ModelList.Count == 0)
                return;
            Panel_Calibs.Controls.Remove(_manager.ModelList[_manager.ModelList.Count - 1].NormalView);
            _manager.RemoveCliab();
        }

        private void Btn_EnableCalib_Click(object sender, EventArgs e)
        {
            if (!Btn_Enable_Calib.Selected)
            {
                _manager.EnalbleCalib();
                Btn_Enable_Calib.Selected = true;
            }
            else
            {
                _manager.DisableCalib();
                Btn_Enable_Calib.Selected = false;
            }
        }

        private void Button_Fast_Calib_Click(object sender, EventArgs e)
        {
            if (Btn_Enable_Calib.Selected)
            {
                UIMessageTip.Show("请先关闭校准");
                return;
            }
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "cfg|*.xml";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                try
                {
                    Panel_Calibs.Controls.Clear();
                    _manager.ModelList = XMLSerializer.Deserialize<List<Calib3DPointsModel>>(dialog.FileName);
                    _manager.IsCalib = true;
                    Btn_Enable_Calib.Selected = true;
                    foreach (Calib3DPointsModel model in _manager.ModelList)
                    {
                        Panel_Calibs.Controls.Add(model.NormalView);
                        model.NormalView.Enabled = false;
                    }
                    _manager.OnUpdateTools?.Invoke();
                    _manager.OnRepaint?.Invoke();
                }
                catch (Exception ex)
                {
                    UIMessageBox.ShowError(ex.Message);
                }
            }
        }

        private void OpenStepPanel(Step3DModel step)
        {
            Panel_Step.BringToFront();
            step.StepView = new Step3DView(step);
            step.StepView.Dock = DockStyle.Fill;
            step.StepView.Refresh();
            Panel_Step.Controls.Add(step.StepView);
        }

        private void CloseSetupPanel(Step3DModel step)
        {
            Panel_Step.SendToBack();
            Panel_Step.Controls.Clear();
            step.StepView.Dispose();
        }
    }
}

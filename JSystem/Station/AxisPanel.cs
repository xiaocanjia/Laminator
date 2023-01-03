using System;
using System.Windows.Forms;
using BoardSys;
using Sunny.UI;

namespace JSystem.Station
{
    public partial class AxisPanel : UserControl
    {
        private AxisInfo _axis;

        private string _moveType = "Jog";

        public AxisPanel() { }

        public AxisPanel(AxisInfo axis)
        {
            InitializeComponent();
            _axis = axis;
            _axis.OnUpdateView = UpdateStatus;
        }

        public override void Refresh()
        {
            base.Refresh();
            Lbl_Axis_Name.Text = _axis.Name;
            if (_axis.IsBelt)
                Btn_Home.Enabled = false;
        }

        public void SetEnable(bool isEnable)
        {
            Switch_Enable.Enabled = isEnable;
            foreach (Control control in Panel_Axis.Controls)
            {
                if (control is UIButton button)
                {
                    button.Enabled = isEnable;
                }
            }
        }

        public void SetMoveType(string type)
        {
            _moveType = type;
        }

        private void Switch_Enable_ValueChanged(object sender, bool value)
        {
            BoardSysIF.Instance.SetAxisServoEnabled(_axis.BoardID, _axis.AxisIndex, value);
        }

        private void Btn_Home_Click(object sender, EventArgs e)
        {
            BoardSysIF.Instance.GoHome(_axis.BoardID, _axis.AxisIndex);
        }

        private void Btn_Move_Click(object sender, EventArgs e)
        {
            UISymbolButton btn = sender as UISymbolButton;
            if (_moveType == "Jog" || btn == null)
                return;
            if (btn.Symbol == 61544)
                BoardSysIF.Instance.RelMove(_axis.BoardID, _axis.AxisIndex, -Convert.ToDouble(_moveType));
            else if (btn.Symbol == 61543)
                BoardSysIF.Instance.RelMove(_axis.BoardID, _axis.AxisIndex, Convert.ToDouble(_moveType));
        }

        private void Btn_Move_MouseDown(object sender, MouseEventArgs e)
        {
            UISymbolButton btn = sender as UISymbolButton;
            if (_moveType != "Jog" || btn == null)
                return;
            BoardSysIF.Instance.JogMove(_axis.BoardID, _axis.AxisIndex, btn.Symbol == 61543);
        }

        private void Btn_Move_MouseUp(object sender, MouseEventArgs e)
        {
            UISymbolButton btn = sender as UISymbolButton;
            if (_moveType != "Jog" || btn == null)
                return;
            BoardSysIF.Instance.StopMove(_axis.BoardID, _axis.AxisIndex);
        }

        private void Btn_Setup_Click(object sender, EventArgs e)
        {
            AxisParamForm form = new AxisParamForm(BoardSysIF.Instance.GetAxisParam(_axis.BoardID, _axis.AxisIndex));
            form.ShowDialog();
        }

        public void UpdateStatus(double cmdPos, double actPos, byte state, bool isEnable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { UpdateStatus(cmdPos, actPos, state, isEnable); }));
            }
            else
            {
                try
                {
                    Tb_CmdPos.Text = cmdPos.ToString();
                    Tb_ActPos.Text = actPos.ToString();
                    Switch_Enable.Active = isEnable;
                    Light_Alarm.State = (state & (0x01 << 0)) > 0 ? UILightState.On : UILightState.Off;
                    Light_PL.State = (state & (0x01 << 1)) > 0 ? UILightState.On : UILightState.Off;
                    Light_NL.State = (state & (0x01 << 2)) > 0 ? UILightState.On : UILightState.Off;
                    Light_Origin.State = (state & (0x01 << 3)) > 0 ? UILightState.On : UILightState.Off;
                    Light_Emg.State = (state & (0x01 << 4)) > 0 ? UILightState.On : UILightState.Off;
                }
                catch { }
            }
        }
    }
}

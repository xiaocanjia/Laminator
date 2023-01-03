using System;
using System.Linq;
using System.Windows.Forms;

namespace Meas3D.FixPos
{
    public partial class FixPos3DPanel : UserControl
    {
        private FixPos3DManager _manager;

        public FixPos3DPanel()
        {
            InitializeComponent();
        }

        public void Init(FixPos3DManager manager)
        {
            _manager = manager;
            _manager.OnOpenSetupPanel = OpenSetupPanel;
            _manager.OnCloseSetupPanel = CloseSetupPanel;
            CbB_Tools_List.Items.Clear();
            foreach (string key in _manager.FixPosName.Values)
                CbB_Tools_List.Items.Add(key);
            Panel_Setup.Visible = false;
            Panel_Setup.Controls.Clear();
            _manager.InitFixPos(_manager.CurrFixPos);
            _manager.CurrFixPos?.OpenSetupView();
            if (_manager.CurrFixPos != null)
                Button_Enable_FixPos.Selected = _manager.CurrFixPos.IsEnable;
        }

        private void Button_Add_FixPos_Click(object sender, EventArgs e)
        {
            _manager.AddFixPos(_manager.FixPosName.FirstOrDefault(q => q.Value == CbB_Tools_List.Text).Key);
        }

        private void OpenSetupPanel(FixPos3DBaseModel fixPos)
        {
            if (fixPos == null) return;
            Panel_Setup.Visible = true;
            fixPos.SetupView.Dock = DockStyle.Fill;
            Panel_Setup.Controls.Add(fixPos.SetupView);
            fixPos.SetupView.Refresh();
        }

        private void CloseSetupPanel(FixPos3DBaseModel fixPos)
        {
            Panel_Setup.Visible = false;
            Panel_Setup.Controls.Clear();
            fixPos.SetupView.Dispose();
        }

        private void Button_Enable_FixPos_Click(object sender, EventArgs e)
        {
            if (!Button_Enable_FixPos.Selected)
            {
                if (_manager.EnableFixPos())
                    Button_Enable_FixPos.Selected = true;
            }
            else
            {
                _manager.DisableFixPos();
                Button_Enable_FixPos.Selected = false;
            }
        }

        private void Button_Delete_FixPos_Click(object sender, EventArgs e)
        {
            _manager.DeleteFixPos();
            Button_Enable_FixPos.Selected = false;
        }
    }
}

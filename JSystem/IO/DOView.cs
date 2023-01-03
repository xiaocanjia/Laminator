using System;
using System.Windows.Forms;
using BoardSys;

namespace JSystem.IO
{
    public partial class DOView : UserControl
    {
        public string DOName;

        public DOView(string name)
        {
            InitializeComponent();
            DOName = name;
            Lbl_Name.Text = name;
            Switch_IsOn.ValueChanged += Switch_IsOn_ValueChanged;
        }

        private void Switch_IsOn_ValueChanged(object sender, bool value)
        {
            if (value != BoardSysIF.Instance.GetOut(DOName))
                BoardSysIF.Instance.SetOut(DOName, value);
        }

        public void SetUserRight(string right)
        {
            Switch_IsOn.Enabled = right == "操作员" ? false : true;
        }

        public void UpdateState()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateState()));
            }
            else
            {
                Switch_IsOn.Active = BoardSysIF.Instance.GetOut(DOName);
            }
        }
    }
}

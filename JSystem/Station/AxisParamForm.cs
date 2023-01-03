using System;
using Sunny.UI;
using BoardSys;

namespace JSystem.Station
{
    public partial class AxisParamForm : UIForm
    {
        private AxisParam _param;

        public AxisParamForm()
        {
            InitializeComponent();
        }

        public AxisParamForm(AxisParam param) : this()
        {
            _param = param;
            TB_MoveVelH.Text = param?.MoveVelH.ToString();
            TB_MoveVelL.Text = param?.MoveVelL.ToString();
            TB_MoveAcc.Text = param?.MoveAcc.ToString();
            TB_MoveDcc.Text = param?.MoveDcc.ToString();
            TB_MoveDir.Text = param?.MoveDir.ToString();
            TB_HomeVelH.Text = param?.HomeVelH.ToString();
            TB_HomeVelL.Text = param?.HomeVelL.ToString();
            TB_HomeAcc.Text = param?.HomeAcc.ToString();
            TB_HomeDcc.Text = param?.HomeDcc.ToString();
            TB_HomeMode.Text = param?.HomeMode.ToString();
            TB_HomeOffset.Text = param?.HomeOffset.ToString();
            TB_HomeDir.Text = param?.HomeDir.ToString();
            TB_PlusePerMM.Text = param?.PlusePerMM.ToString();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (_param == null)
                return;
            try
            {
                _param.MoveVelH = Convert.ToDouble(TB_MoveVelH.Text);
                _param.MoveVelL = Convert.ToDouble(TB_MoveVelL.Text);
                _param.MoveAcc = Convert.ToDouble(TB_MoveAcc.Text);
                _param.MoveDcc = Convert.ToDouble(TB_MoveDcc.Text);
                _param.MoveDir = Convert.ToUInt32(TB_MoveDir.Text);
                _param.HomeVelH = Convert.ToDouble(TB_HomeVelH.Text);
                _param.HomeVelL = Convert.ToDouble(TB_HomeVelL.Text);
                _param.HomeAcc = Convert.ToDouble(TB_HomeAcc.Text);
                _param.HomeDcc = Convert.ToDouble(TB_HomeDcc.Text);
                _param.HomeMode = Convert.ToUInt32(TB_HomeMode.Text);
                _param.HomeDir = Convert.ToUInt32(TB_HomeDir.Text);
                _param.HomeOffset = Convert.ToDouble(TB_HomeOffset.Text);
                _param.PlusePerMM = Convert.ToUInt32(TB_PlusePerMM.Text);
                Close();
            }
            catch
            {
                UIMessageBox.Show("输入格式错误");
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

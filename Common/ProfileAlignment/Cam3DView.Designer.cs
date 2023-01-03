namespace ProfileCalib
{
    partial class Cam3DView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TB_Angle = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.TB_XOffset = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.TB_Port = new Sunny.UI.UITextBox();
            this.TB_IP = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Btn_Connect = new Sunny.UI.UIButton();
            this.TB_ZOffset = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TB_ZOffset);
            this.panel1.Controls.Add(this.uiLabel5);
            this.panel1.Controls.Add(this.TB_Angle);
            this.panel1.Controls.Add(this.uiLabel4);
            this.panel1.Controls.Add(this.TB_XOffset);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Controls.Add(this.TB_Port);
            this.panel1.Controls.Add(this.TB_IP);
            this.panel1.Controls.Add(this.uiLabel9);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.Btn_Connect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 239);
            this.panel1.TabIndex = 0;
            // 
            // TB_Angle
            // 
            this.TB_Angle.ButtonSymbol = 61761;
            this.TB_Angle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Angle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Angle.Location = new System.Drawing.Point(112, 154);
            this.TB_Angle.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Angle.Maximum = 2147483647D;
            this.TB_Angle.Minimum = -2147483648D;
            this.TB_Angle.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Angle.Name = "TB_Angle";
            this.TB_Angle.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Angle.Size = new System.Drawing.Size(165, 29);
            this.TB_Angle.TabIndex = 197;
            this.TB_Angle.Text = "0";
            this.TB_Angle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Angle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Angle.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(17, 158);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(85, 25);
            this.uiLabel4.TabIndex = 196;
            this.uiLabel4.Text = "旋转角度";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_XOffset
            // 
            this.TB_XOffset.ButtonSymbol = 61761;
            this.TB_XOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_XOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_XOffset.Location = new System.Drawing.Point(112, 82);
            this.TB_XOffset.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_XOffset.Maximum = 2147483647D;
            this.TB_XOffset.Minimum = -2147483648D;
            this.TB_XOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_XOffset.Name = "TB_XOffset";
            this.TB_XOffset.Padding = new System.Windows.Forms.Padding(7);
            this.TB_XOffset.Size = new System.Drawing.Size(165, 29);
            this.TB_XOffset.TabIndex = 195;
            this.TB_XOffset.Text = "0";
            this.TB_XOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_XOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_XOffset.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(17, 86);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(85, 25);
            this.uiLabel3.TabIndex = 194;
            this.uiLabel3.Text = "X方向偏移";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Port
            // 
            this.TB_Port.ButtonSymbol = 61761;
            this.TB_Port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Port.Location = new System.Drawing.Point(112, 46);
            this.TB_Port.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Port.Maximum = 2147483647D;
            this.TB_Port.Minimum = -2147483648D;
            this.TB_Port.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Port.Size = new System.Drawing.Size(165, 29);
            this.TB_Port.TabIndex = 193;
            this.TB_Port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_IP
            // 
            this.TB_IP.ButtonSymbol = 61761;
            this.TB_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_IP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_IP.Location = new System.Drawing.Point(112, 10);
            this.TB_IP.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_IP.Maximum = 2147483647D;
            this.TB_IP.Minimum = -2147483648D;
            this.TB_IP.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Padding = new System.Windows.Forms.Padding(7);
            this.TB_IP.Size = new System.Drawing.Size(165, 29);
            this.TB_IP.TabIndex = 192;
            this.TB_IP.Text = "192.168.0.10";
            this.TB_IP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(17, 50);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(85, 25);
            this.uiLabel9.TabIndex = 191;
            this.uiLabel9.Text = "端口号";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(17, 14);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(85, 25);
            this.uiLabel1.TabIndex = 190;
            this.uiLabel1.Text = "IP地址";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Connect.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Connect.Location = new System.Drawing.Point(97, 194);
            this.Btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Connect.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(88, 33);
            this.Btn_Connect.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Connect.StyleCustomMode = true;
            this.Btn_Connect.TabIndex = 189;
            this.Btn_Connect.Text = "连接";
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // TB_ZOffset
            // 
            this.TB_ZOffset.ButtonSymbol = 61761;
            this.TB_ZOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_ZOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_ZOffset.Location = new System.Drawing.Point(112, 118);
            this.TB_ZOffset.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_ZOffset.Maximum = 2147483647D;
            this.TB_ZOffset.Minimum = -2147483648D;
            this.TB_ZOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_ZOffset.Name = "TB_ZOffset";
            this.TB_ZOffset.Padding = new System.Windows.Forms.Padding(7);
            this.TB_ZOffset.Size = new System.Drawing.Size(165, 29);
            this.TB_ZOffset.TabIndex = 197;
            this.TB_ZOffset.Text = "0";
            this.TB_ZOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_ZOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_ZOffset.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(17, 122);
            this.uiLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(85, 25);
            this.uiLabel5.TabIndex = 196;
            this.uiLabel5.Text = "Z方向偏移";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cam3DView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Cam3DView";
            this.Size = new System.Drawing.Size(292, 239);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UITextBox TB_Port;
        private Sunny.UI.UITextBox TB_IP;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton Btn_Connect;
        private Sunny.UI.UITextBox TB_Angle;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox TB_XOffset;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TB_ZOffset;
        private Sunny.UI.UILabel uiLabel5;
    }
}

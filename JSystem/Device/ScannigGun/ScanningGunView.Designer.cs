namespace JSystem.Device
{
    partial class ScanningGunView
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
            this.Btn_Connect = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CbB_Port_Name = new Sunny.UI.UIComboBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.CbB_StopBits = new Sunny.UI.UIComboBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.CbB_Parity = new Sunny.UI.UIComboBox();
            this.CbB_BaudRate = new Sunny.UI.UIComboBox();
            this.CbB_DataBits = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.TB_Command = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Connect.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Connect.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Connect.Location = new System.Drawing.Point(159, 287);
            this.Btn_Connect.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.Size = new System.Drawing.Size(100, 40);
            this.Btn_Connect.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Connect.StyleCustomMode = true;
            this.Btn_Connect.TabIndex = 186;
            this.Btn_Connect.Text = "连接";
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(23, 24);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(85, 25);
            this.uiLabel2.TabIndex = 185;
            this.uiLabel2.Text = "串口号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Port_Name
            // 
            this.CbB_Port_Name.DataSource = null;
            this.CbB_Port_Name.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Port_Name.FillColor = System.Drawing.Color.White;
            this.CbB_Port_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Port_Name.Location = new System.Drawing.Point(118, 18);
            this.CbB_Port_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Port_Name.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Port_Name.Name = "CbB_Port_Name";
            this.CbB_Port_Name.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_Port_Name.Size = new System.Drawing.Size(266, 29);
            this.CbB_Port_Name.TabIndex = 184;
            this.CbB_Port_Name.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(23, 96);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(85, 25);
            this.uiLabel9.TabIndex = 180;
            this.uiLabel9.Text = "数据位";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(23, 60);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(85, 25);
            this.uiLabel1.TabIndex = 178;
            this.uiLabel1.Text = "波特率";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(23, 132);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(85, 25);
            this.uiLabel3.TabIndex = 189;
            this.uiLabel3.Text = "停止位";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_StopBits
            // 
            this.CbB_StopBits.DataSource = null;
            this.CbB_StopBits.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_StopBits.FillColor = System.Drawing.Color.White;
            this.CbB_StopBits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_StopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.CbB_StopBits.Location = new System.Drawing.Point(118, 126);
            this.CbB_StopBits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_StopBits.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_StopBits.Name = "CbB_StopBits";
            this.CbB_StopBits.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_StopBits.Size = new System.Drawing.Size(266, 29);
            this.CbB_StopBits.TabIndex = 188;
            this.CbB_StopBits.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(23, 168);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(85, 25);
            this.uiLabel4.TabIndex = 191;
            this.uiLabel4.Text = "校验位";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Parity
            // 
            this.CbB_Parity.DataSource = null;
            this.CbB_Parity.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Parity.FillColor = System.Drawing.Color.White;
            this.CbB_Parity.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Parity.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.CbB_Parity.Location = new System.Drawing.Point(118, 162);
            this.CbB_Parity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Parity.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Parity.Name = "CbB_Parity";
            this.CbB_Parity.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_Parity.Size = new System.Drawing.Size(266, 29);
            this.CbB_Parity.TabIndex = 190;
            this.CbB_Parity.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CbB_BaudRate
            // 
            this.CbB_BaudRate.DataSource = null;
            this.CbB_BaudRate.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_BaudRate.FillColor = System.Drawing.Color.White;
            this.CbB_BaudRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "115200"});
            this.CbB_BaudRate.Location = new System.Drawing.Point(118, 54);
            this.CbB_BaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_BaudRate.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_BaudRate.Name = "CbB_BaudRate";
            this.CbB_BaudRate.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_BaudRate.Size = new System.Drawing.Size(266, 29);
            this.CbB_BaudRate.TabIndex = 185;
            this.CbB_BaudRate.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CbB_DataBits
            // 
            this.CbB_DataBits.DataSource = null;
            this.CbB_DataBits.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_DataBits.FillColor = System.Drawing.Color.White;
            this.CbB_DataBits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_DataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.CbB_DataBits.Location = new System.Drawing.Point(118, 90);
            this.CbB_DataBits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_DataBits.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_DataBits.Name = "CbB_DataBits";
            this.CbB_DataBits.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_DataBits.Size = new System.Drawing.Size(266, 29);
            this.CbB_DataBits.TabIndex = 185;
            this.CbB_DataBits.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(23, 203);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(85, 25);
            this.uiLabel5.TabIndex = 193;
            this.uiLabel5.Text = "指令";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Command
            // 
            this.TB_Command.ButtonSymbol = 61761;
            this.TB_Command.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Command.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Command.Location = new System.Drawing.Point(118, 197);
            this.TB_Command.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Command.Maximum = 2147483647D;
            this.TB_Command.Minimum = -2147483648D;
            this.TB_Command.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Command.Name = "TB_Command";
            this.TB_Command.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Command.Size = new System.Drawing.Size(266, 29);
            this.TB_Command.TabIndex = 194;
            this.TB_Command.Text = "K";
            this.TB_Command.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScanningGunView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.TB_Command);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.CbB_DataBits);
            this.Controls.Add(this.CbB_BaudRate);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.CbB_Parity);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.CbB_StopBits);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.CbB_Port_Name);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScanningGunView";
            this.Size = new System.Drawing.Size(400, 700);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton Btn_Connect;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox CbB_Port_Name;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox CbB_StopBits;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox CbB_Parity;
        private Sunny.UI.UIComboBox CbB_BaudRate;
        private Sunny.UI.UIComboBox CbB_DataBits;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox TB_Command;
    }
}

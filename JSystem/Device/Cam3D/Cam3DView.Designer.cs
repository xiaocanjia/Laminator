namespace JSystem.Device
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
            this.Btn_Connect = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CbB_Cam_Name = new Sunny.UI.UIComboBox();
            this.TB_Trigger_Interval = new Sunny.UI.UITextBox();
            this.TB_Port = new Sunny.UI.UITextBox();
            this.TB_IP = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_Valiad_Width = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.TB_Config_Path = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.Btn_Export_Config = new Sunny.UI.UIButton();
            this.TB_XOffset = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.TB_YOffset = new Sunny.UI.UITextBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.TB_ZOffset = new Sunny.UI.UITextBox();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.TB_ZAngle = new Sunny.UI.UITextBox();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Connect.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Connect.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Connect.Location = new System.Drawing.Point(65, 425);
            this.Btn_Connect.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Connect.Size = new System.Drawing.Size(100, 40);
            this.Btn_Connect.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Connect.StyleCustomMode = true;
            this.Btn_Connect.TabIndex = 176;
            this.Btn_Connect.Text = "连接";
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(18, 27);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(78, 23);
            this.uiLabel2.TabIndex = 175;
            this.uiLabel2.Text = "相机类型";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Cam_Name
            // 
            this.CbB_Cam_Name.DataSource = null;
            this.CbB_Cam_Name.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Cam_Name.FillColor = System.Drawing.Color.White;
            this.CbB_Cam_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Cam_Name.Location = new System.Drawing.Point(113, 21);
            this.CbB_Cam_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Cam_Name.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Cam_Name.Name = "CbB_Cam_Name";
            this.CbB_Cam_Name.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_Cam_Name.Size = new System.Drawing.Size(266, 29);
            this.CbB_Cam_Name.Style = Sunny.UI.UIStyle.Custom;
            this.CbB_Cam_Name.StyleCustomMode = true;
            this.CbB_Cam_Name.TabIndex = 174;
            this.CbB_Cam_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Cam_Name.SelectedIndexChanged += new System.EventHandler(this.CbB_Cam_Type_SelectedIndexChanged);
            // 
            // TB_Trigger_Interval
            // 
            this.TB_Trigger_Interval.ButtonSymbol = 61761;
            this.TB_Trigger_Interval.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Trigger_Interval.DoubleValue = 0.01D;
            this.TB_Trigger_Interval.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Trigger_Interval.Location = new System.Drawing.Point(113, 123);
            this.TB_Trigger_Interval.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Trigger_Interval.Maximum = 2147483647D;
            this.TB_Trigger_Interval.Minimum = -2147483648D;
            this.TB_Trigger_Interval.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Trigger_Interval.Name = "TB_Trigger_Interval";
            this.TB_Trigger_Interval.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Trigger_Interval.Size = new System.Drawing.Size(266, 29);
            this.TB_Trigger_Interval.TabIndex = 173;
            this.TB_Trigger_Interval.Text = "0.01";
            this.TB_Trigger_Interval.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Port
            // 
            this.TB_Port.ButtonSymbol = 61761;
            this.TB_Port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Port.DoubleValue = 8898D;
            this.TB_Port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Port.IntValue = 8898;
            this.TB_Port.Location = new System.Drawing.Point(113, 89);
            this.TB_Port.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Port.Maximum = 2147483647D;
            this.TB_Port.Minimum = -2147483648D;
            this.TB_Port.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Port.Size = new System.Drawing.Size(266, 29);
            this.TB_Port.TabIndex = 172;
            this.TB_Port.Text = "8898";
            this.TB_Port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_IP
            // 
            this.TB_IP.ButtonSymbol = 61761;
            this.TB_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_IP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_IP.Location = new System.Drawing.Point(113, 55);
            this.TB_IP.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_IP.Maximum = 2147483647D;
            this.TB_IP.Minimum = -2147483648D;
            this.TB_IP.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Padding = new System.Windows.Forms.Padding(7);
            this.TB_IP.Size = new System.Drawing.Size(266, 29);
            this.TB_IP.TabIndex = 171;
            this.TB_IP.Text = "127.0.0.1";
            this.TB_IP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(18, 93);
            this.uiLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(85, 25);
            this.uiLabel9.TabIndex = 170;
            this.uiLabel9.Text = "端口号";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(18, 127);
            this.uiLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(85, 25);
            this.uiLabel6.TabIndex = 169;
            this.uiLabel6.Text = "触发间隔";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(18, 59);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(85, 25);
            this.uiLabel1.TabIndex = 168;
            this.uiLabel1.Text = "IP地址";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Valiad_Width
            // 
            this.TB_Valiad_Width.ButtonSymbol = 61761;
            this.TB_Valiad_Width.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Valiad_Width.DoubleValue = 30D;
            this.TB_Valiad_Width.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Valiad_Width.IntValue = 30;
            this.TB_Valiad_Width.Location = new System.Drawing.Point(113, 157);
            this.TB_Valiad_Width.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Valiad_Width.Maximum = 2147483647D;
            this.TB_Valiad_Width.Minimum = -2147483648D;
            this.TB_Valiad_Width.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Valiad_Width.Name = "TB_Valiad_Width";
            this.TB_Valiad_Width.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Valiad_Width.Size = new System.Drawing.Size(266, 29);
            this.TB_Valiad_Width.TabIndex = 175;
            this.TB_Valiad_Width.Text = "30";
            this.TB_Valiad_Width.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(18, 161);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(85, 25);
            this.uiLabel3.TabIndex = 174;
            this.uiLabel3.Text = "有效线宽";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Config_Path
            // 
            this.TB_Config_Path.ButtonSymbol = 61761;
            this.TB_Config_Path.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Config_Path.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Config_Path.Location = new System.Drawing.Point(113, 333);
            this.TB_Config_Path.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Config_Path.Maximum = 2147483647D;
            this.TB_Config_Path.Minimum = -2147483648D;
            this.TB_Config_Path.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Config_Path.Name = "TB_Config_Path";
            this.TB_Config_Path.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Config_Path.Size = new System.Drawing.Size(266, 29);
            this.TB_Config_Path.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Config_Path.TabIndex = 209;
            this.TB_Config_Path.Text = "0";
            this.TB_Config_Path.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Config_Path.DoubleClick += new System.EventHandler(this.TB_Config_Path_DoubleClick);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(18, 337);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(78, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 208;
            this.uiLabel7.Text = "配置文件";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Export_Config
            // 
            this.Btn_Export_Config.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Export_Config.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Export_Config.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Export_Config.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Export_Config.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Export_Config.Location = new System.Drawing.Point(206, 425);
            this.Btn_Export_Config.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Export_Config.Name = "Btn_Export_Config";
            this.Btn_Export_Config.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Export_Config.Size = new System.Drawing.Size(100, 40);
            this.Btn_Export_Config.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Export_Config.StyleCustomMode = true;
            this.Btn_Export_Config.TabIndex = 210;
            this.Btn_Export_Config.Text = "导出配置";
            this.Btn_Export_Config.Click += new System.EventHandler(this.Btn_Export_Config_Click);
            // 
            // TB_XOffset
            // 
            this.TB_XOffset.ButtonSymbol = 61761;
            this.TB_XOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_XOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_XOffset.Location = new System.Drawing.Point(113, 194);
            this.TB_XOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_XOffset.Maximum = 2147483647D;
            this.TB_XOffset.Minimum = -2147483648D;
            this.TB_XOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_XOffset.Name = "TB_XOffset";
            this.TB_XOffset.Padding = new System.Windows.Forms.Padding(5);
            this.TB_XOffset.Size = new System.Drawing.Size(266, 29);
            this.TB_XOffset.Style = Sunny.UI.UIStyle.Custom;
            this.TB_XOffset.TabIndex = 209;
            this.TB_XOffset.Text = "0";
            this.TB_XOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(18, 198);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(88, 23);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 208;
            this.uiLabel8.Text = "X方向偏移";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_YOffset
            // 
            this.TB_YOffset.ButtonSymbol = 61761;
            this.TB_YOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_YOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_YOffset.Location = new System.Drawing.Point(113, 229);
            this.TB_YOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_YOffset.Maximum = 2147483647D;
            this.TB_YOffset.Minimum = -2147483648D;
            this.TB_YOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_YOffset.Name = "TB_YOffset";
            this.TB_YOffset.Padding = new System.Windows.Forms.Padding(5);
            this.TB_YOffset.Size = new System.Drawing.Size(266, 29);
            this.TB_YOffset.Style = Sunny.UI.UIStyle.Custom;
            this.TB_YOffset.TabIndex = 209;
            this.TB_YOffset.Text = "0";
            this.TB_YOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel10.Location = new System.Drawing.Point(18, 233);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(85, 23);
            this.uiLabel10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel10.TabIndex = 208;
            this.uiLabel10.Text = "Y方向偏移";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_ZOffset
            // 
            this.TB_ZOffset.ButtonSymbol = 61761;
            this.TB_ZOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_ZOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_ZOffset.Location = new System.Drawing.Point(113, 264);
            this.TB_ZOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_ZOffset.Maximum = 2147483647D;
            this.TB_ZOffset.Minimum = -2147483648D;
            this.TB_ZOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_ZOffset.Name = "TB_ZOffset";
            this.TB_ZOffset.Padding = new System.Windows.Forms.Padding(5);
            this.TB_ZOffset.Size = new System.Drawing.Size(266, 29);
            this.TB_ZOffset.Style = Sunny.UI.UIStyle.Custom;
            this.TB_ZOffset.TabIndex = 211;
            this.TB_ZOffset.Text = "0";
            this.TB_ZOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel11.Location = new System.Drawing.Point(18, 268);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(88, 23);
            this.uiLabel11.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel11.TabIndex = 210;
            this.uiLabel11.Text = "Z方向偏移";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_ZAngle
            // 
            this.TB_ZAngle.ButtonSymbol = 61761;
            this.TB_ZAngle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_ZAngle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_ZAngle.Location = new System.Drawing.Point(113, 299);
            this.TB_ZAngle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_ZAngle.Maximum = 2147483647D;
            this.TB_ZAngle.Minimum = -2147483648D;
            this.TB_ZAngle.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_ZAngle.Name = "TB_ZAngle";
            this.TB_ZAngle.Padding = new System.Windows.Forms.Padding(5);
            this.TB_ZAngle.Size = new System.Drawing.Size(266, 29);
            this.TB_ZAngle.Style = Sunny.UI.UIStyle.Custom;
            this.TB_ZAngle.TabIndex = 213;
            this.TB_ZAngle.Text = "0";
            this.TB_ZAngle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel12.Location = new System.Drawing.Point(18, 303);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(88, 23);
            this.uiLabel12.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel12.TabIndex = 212;
            this.uiLabel12.Text = "Z方向角度";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cam3DView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.TB_ZAngle);
            this.Controls.Add(this.uiLabel12);
            this.Controls.Add(this.TB_ZOffset);
            this.Controls.Add(this.uiLabel11);
            this.Controls.Add(this.TB_YOffset);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.TB_XOffset);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.Btn_Export_Config);
            this.Controls.Add(this.TB_Config_Path);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.TB_Valiad_Width);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.CbB_Cam_Name);
            this.Controls.Add(this.TB_Trigger_Interval);
            this.Controls.Add(this.TB_Port);
            this.Controls.Add(this.TB_IP);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Cam3DView";
            this.Size = new System.Drawing.Size(400, 700);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton Btn_Connect;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox CbB_Cam_Name;
        private Sunny.UI.UITextBox TB_Trigger_Interval;
        private Sunny.UI.UITextBox TB_Port;
        private Sunny.UI.UITextBox TB_IP;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_Valiad_Width;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TB_Config_Path;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIButton Btn_Export_Config;
        private Sunny.UI.UITextBox TB_XOffset;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox TB_YOffset;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITextBox TB_ZOffset;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox TB_ZAngle;
        private Sunny.UI.UILabel uiLabel12;
    }
}

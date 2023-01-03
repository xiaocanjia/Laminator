namespace JSystem.Station
{
    partial class VisionStationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TB_Grab_Count = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.Btn_Start_Grab = new Sunny.UI.UIButton();
            this.TB_Scan_Speed = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TB_Joint_Count = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_PCL_Length = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.Panel_Meas = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TB_Grab_Count);
            this.panel1.Controls.Add(this.uiLabel4);
            this.panel1.Controls.Add(this.Btn_Start_Grab);
            this.panel1.Controls.Add(this.TB_Scan_Speed);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Controls.Add(this.TB_Joint_Count);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.TB_PCL_Length);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 859);
            this.panel1.TabIndex = 0;
            // 
            // TB_Grab_Count
            // 
            this.TB_Grab_Count.ButtonSymbol = 61761;
            this.TB_Grab_Count.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Grab_Count.DoubleValue = 1D;
            this.TB_Grab_Count.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Grab_Count.IntValue = 1;
            this.TB_Grab_Count.Location = new System.Drawing.Point(93, 144);
            this.TB_Grab_Count.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Grab_Count.Maximum = 2147483647D;
            this.TB_Grab_Count.Minimum = -2147483648D;
            this.TB_Grab_Count.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Grab_Count.Name = "TB_Grab_Count";
            this.TB_Grab_Count.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Grab_Count.Size = new System.Drawing.Size(81, 29);
            this.TB_Grab_Count.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Grab_Count.TabIndex = 181;
            this.TB_Grab_Count.Text = "1";
            this.TB_Grab_Count.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(9, 148);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(79, 25);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 182;
            this.uiLabel4.Text = "采集次数";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Start_Grab
            // 
            this.Btn_Start_Grab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Start_Grab.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Start_Grab.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Start_Grab.Location = new System.Drawing.Point(85, 201);
            this.Btn_Start_Grab.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Start_Grab.Name = "Btn_Start_Grab";
            this.Btn_Start_Grab.Size = new System.Drawing.Size(89, 33);
            this.Btn_Start_Grab.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Start_Grab.StyleCustomMode = true;
            this.Btn_Start_Grab.TabIndex = 233;
            this.Btn_Start_Grab.Text = "开始采集";
            this.Btn_Start_Grab.Click += new System.EventHandler(this.Btn_Start_Grab_Click);
            // 
            // TB_Scan_Speed
            // 
            this.TB_Scan_Speed.ButtonSymbol = 61761;
            this.TB_Scan_Speed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Scan_Speed.DoubleValue = 1D;
            this.TB_Scan_Speed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Scan_Speed.IntValue = 1;
            this.TB_Scan_Speed.Location = new System.Drawing.Point(93, 101);
            this.TB_Scan_Speed.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Scan_Speed.Maximum = 2147483647D;
            this.TB_Scan_Speed.Minimum = -2147483648D;
            this.TB_Scan_Speed.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Scan_Speed.Name = "TB_Scan_Speed";
            this.TB_Scan_Speed.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Scan_Speed.Size = new System.Drawing.Size(81, 29);
            this.TB_Scan_Speed.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Scan_Speed.TabIndex = 179;
            this.TB_Scan_Speed.Text = "1";
            this.TB_Scan_Speed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(9, 105);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(79, 25);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 180;
            this.uiLabel2.Text = "扫描速度";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Joint_Count
            // 
            this.TB_Joint_Count.ButtonSymbol = 61761;
            this.TB_Joint_Count.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Joint_Count.DoubleValue = 1D;
            this.TB_Joint_Count.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Joint_Count.IntValue = 1;
            this.TB_Joint_Count.Location = new System.Drawing.Point(93, 58);
            this.TB_Joint_Count.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Joint_Count.Maximum = 2147483647D;
            this.TB_Joint_Count.Minimum = -2147483648D;
            this.TB_Joint_Count.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Joint_Count.Name = "TB_Joint_Count";
            this.TB_Joint_Count.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Joint_Count.Size = new System.Drawing.Size(81, 29);
            this.TB_Joint_Count.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Joint_Count.TabIndex = 178;
            this.TB_Joint_Count.Text = "1";
            this.TB_Joint_Count.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(9, 62);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(79, 25);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 178;
            this.uiLabel1.Text = "拼接次数";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_PCL_Length
            // 
            this.TB_PCL_Length.ButtonSymbol = 61761;
            this.TB_PCL_Length.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_PCL_Length.DoubleValue = 100D;
            this.TB_PCL_Length.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_PCL_Length.IntValue = 100;
            this.TB_PCL_Length.Location = new System.Drawing.Point(93, 17);
            this.TB_PCL_Length.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_PCL_Length.Maximum = 2147483647D;
            this.TB_PCL_Length.Minimum = -2147483648D;
            this.TB_PCL_Length.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_PCL_Length.Name = "TB_PCL_Length";
            this.TB_PCL_Length.Padding = new System.Windows.Forms.Padding(7);
            this.TB_PCL_Length.Size = new System.Drawing.Size(81, 29);
            this.TB_PCL_Length.Style = Sunny.UI.UIStyle.Custom;
            this.TB_PCL_Length.TabIndex = 177;
            this.TB_PCL_Length.Text = "100";
            this.TB_PCL_Length.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(9, 21);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(79, 25);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 176;
            this.uiLabel3.Text = "点云长度";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_Meas
            // 
            this.Panel_Meas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Meas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Meas.Location = new System.Drawing.Point(195, 38);
            this.Panel_Meas.Name = "Panel_Meas";
            this.Panel_Meas.Size = new System.Drawing.Size(1102, 859);
            this.Panel_Meas.TabIndex = 1;
            // 
            // VisionStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 900);
            this.Controls.Add(this.Panel_Meas);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "VisionStationForm";
            this.RectColor = System.Drawing.Color.SteelBlue;
            this.ShowInTaskbar = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "视觉工站调试";
            this.TitleColor = System.Drawing.Color.SteelBlue;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel_Meas;
        private Sunny.UI.UITextBox TB_Joint_Count;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_PCL_Length;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TB_Scan_Speed;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton Btn_Start_Grab;
        private Sunny.UI.UITextBox TB_Grab_Count;
        private Sunny.UI.UILabel uiLabel4;
    }
}
namespace JSystem.Station
{
    partial class ReadCodeStationFrom
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
            this.Panel_Meas = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Start_Grab = new Sunny.UI.UIButton();
            this.TB_Joint_Count = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_PCL_Length = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.Panel_Meas.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Btn_Start_Grab);
            this.panel1.Controls.Add(this.TB_Joint_Count);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.TB_PCL_Length);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 859);
            this.panel1.TabIndex = 1;
            // 
            // Btn_Start_Grab
            // 
            this.Btn_Start_Grab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Start_Grab.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Start_Grab.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Start_Grab.Location = new System.Drawing.Point(85, 116);
            this.Btn_Start_Grab.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Start_Grab.Name = "Btn_Start_Grab";
            this.Btn_Start_Grab.Size = new System.Drawing.Size(89, 33);
            this.Btn_Start_Grab.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Start_Grab.StyleCustomMode = true;
            this.Btn_Start_Grab.TabIndex = 233;
            this.Btn_Start_Grab.Text = "开始采集";
            this.Btn_Start_Grab.Click += new System.EventHandler(this.Btn_Start_Grab_Click);
            // 
            // TB_Joint_Count
            // 
            this.TB_Joint_Count.ButtonSymbol = 61761;
            this.TB_Joint_Count.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Joint_Count.DoubleValue = 122.5D;
            this.TB_Joint_Count.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Joint_Count.Location = new System.Drawing.Point(99, 58);
            this.TB_Joint_Count.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_Joint_Count.Maximum = 2147483647D;
            this.TB_Joint_Count.Minimum = -2147483648D;
            this.TB_Joint_Count.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Joint_Count.Name = "TB_Joint_Count";
            this.TB_Joint_Count.Padding = new System.Windows.Forms.Padding(7);
            this.TB_Joint_Count.Size = new System.Drawing.Size(81, 29);
            this.TB_Joint_Count.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Joint_Count.TabIndex = 178;
            this.TB_Joint_Count.Text = "122.5";
            this.TB_Joint_Count.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(5, 61);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(85, 25);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 178;
            this.uiLabel1.Text = "Y方向偏移";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_PCL_Length
            // 
            this.TB_PCL_Length.ButtonSymbol = 61761;
            this.TB_PCL_Length.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_PCL_Length.DoubleValue = 122D;
            this.TB_PCL_Length.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_PCL_Length.IntValue = 122;
            this.TB_PCL_Length.Location = new System.Drawing.Point(99, 17);
            this.TB_PCL_Length.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TB_PCL_Length.Maximum = 2147483647D;
            this.TB_PCL_Length.Minimum = -2147483648D;
            this.TB_PCL_Length.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_PCL_Length.Name = "TB_PCL_Length";
            this.TB_PCL_Length.Padding = new System.Windows.Forms.Padding(7);
            this.TB_PCL_Length.Size = new System.Drawing.Size(81, 29);
            this.TB_PCL_Length.Style = Sunny.UI.UIStyle.Custom;
            this.TB_PCL_Length.TabIndex = 177;
            this.TB_PCL_Length.Text = "122";
            this.TB_PCL_Length.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(5, 21);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(85, 25);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 176;
            this.uiLabel3.Text = "X方向偏移";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReadCodeStationFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 900);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Meas);
            this.Name = "ReadCodeStationFrom";
            this.RectColor = System.Drawing.Color.SteelBlue;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "扫码工站调试";
            this.TitleColor = System.Drawing.Color.SteelBlue;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Meas;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIButton Btn_Start_Grab;
        private Sunny.UI.UITextBox TB_Joint_Count;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_PCL_Length;
        private Sunny.UI.UILabel uiLabel3;
    }
}
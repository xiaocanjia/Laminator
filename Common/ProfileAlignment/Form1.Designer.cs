namespace ProfileCalib
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_StartGrab = new Sunny.UI.UIButton();
            this.Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.ProfileChart = new Sunny.UI.UILineChart();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CbB_Cam_Name = new Sunny.UI.UIComboBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // Btn_StartGrab
            // 
            this.Btn_StartGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_StartGrab.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_StartGrab.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_StartGrab.Location = new System.Drawing.Point(42, 367);
            this.Btn_StartGrab.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_StartGrab.Name = "Btn_StartGrab";
            this.Btn_StartGrab.Size = new System.Drawing.Size(100, 35);
            this.Btn_StartGrab.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_StartGrab.StyleCustomMode = true;
            this.Btn_StartGrab.TabIndex = 2;
            this.Btn_StartGrab.Text = "开始采集";
            this.Btn_StartGrab.Click += new System.EventHandler(this.Btn_StartGrab_Click);
            // 
            // Panel
            // 
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel.Location = new System.Drawing.Point(21, 82);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(935, 249);
            this.Panel.TabIndex = 3;
            // 
            // ProfileChart
            // 
            this.ProfileChart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ProfileChart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProfileChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ProfileChart.LegendFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProfileChart.Location = new System.Drawing.Point(174, 347);
            this.ProfileChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.ProfileChart.Name = "ProfileChart";
            this.ProfileChart.Size = new System.Drawing.Size(782, 254);
            this.ProfileChart.Style = Sunny.UI.UIStyle.Custom;
            this.ProfileChart.SubFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProfileChart.TabIndex = 4;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(22, 46);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(78, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 197;
            this.uiLabel2.Text = "相机类型";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Cam_Name
            // 
            this.CbB_Cam_Name.DataSource = null;
            this.CbB_Cam_Name.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Cam_Name.FillColor = System.Drawing.Color.White;
            this.CbB_Cam_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Cam_Name.Location = new System.Drawing.Point(117, 43);
            this.CbB_Cam_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Cam_Name.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Cam_Name.Name = "CbB_Cam_Name";
            this.CbB_Cam_Name.Padding = new System.Windows.Forms.Padding(8, 0, 30, 2);
            this.CbB_Cam_Name.Size = new System.Drawing.Size(225, 29);
            this.CbB_Cam_Name.Style = Sunny.UI.UIStyle.Custom;
            this.CbB_Cam_Name.StyleCustomMode = true;
            this.CbB_Cam_Name.TabIndex = 196;
            this.CbB_Cam_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Cam_Name.SelectedIndexChanged += new System.EventHandler(this.CbB_Cam_Name_SelectedIndexChanged);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.SteelBlue;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(362, 41);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(71, 35);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.StyleCustomMode = true;
            this.uiButton1.TabIndex = 198;
            this.uiButton1.Text = "添加";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 624);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.CbB_Cam_Name);
            this.Controls.Add(this.ProfileChart);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Btn_StartGrab);
            this.Name = "Form1";
            this.RectColor = System.Drawing.Color.SteelBlue;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Form1";
            this.TitleColor = System.Drawing.Color.SteelBlue;
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton Btn_StartGrab;
        private System.Windows.Forms.FlowLayoutPanel Panel;
        private Sunny.UI.UILineChart ProfileChart;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox CbB_Cam_Name;
        private Sunny.UI.UIButton uiButton1;
    }
}


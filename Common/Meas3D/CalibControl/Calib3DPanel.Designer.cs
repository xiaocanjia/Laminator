namespace Meas3D.Calib
{
    partial class Calib3DPanel
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
            this.Btn_Enable_Calib = new Sunny.UI.UIButton();
            this.Panel_Calibs = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Load_Data = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Btn_Add_Calib = new Sunny.UI.UIButton();
            this.Btn_Remove_Calib = new Sunny.UI.UIButton();
            this.Panel_Step = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Btn_Enable_Calib
            // 
            this.Btn_Enable_Calib.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Enable_Calib.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Enable_Calib.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Enable_Calib.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Enable_Calib.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Enable_Calib.Location = new System.Drawing.Point(221, 644);
            this.Btn_Enable_Calib.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Enable_Calib.Name = "Btn_Enable_Calib";
            this.Btn_Enable_Calib.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Enable_Calib.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Enable_Calib.Size = new System.Drawing.Size(106, 43);
            this.Btn_Enable_Calib.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Enable_Calib.TabIndex = 144;
            this.Btn_Enable_Calib.Text = "开启校准";
            this.Btn_Enable_Calib.Click += new System.EventHandler(this.Btn_EnableCalib_Click);
            // 
            // Panel_Calibs
            // 
            this.Panel_Calibs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Calibs.AutoScroll = true;
            this.Panel_Calibs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Calibs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Calibs.Location = new System.Drawing.Point(1, 49);
            this.Panel_Calibs.Name = "Panel_Calibs";
            this.Panel_Calibs.Size = new System.Drawing.Size(416, 589);
            this.Panel_Calibs.TabIndex = 145;
            // 
            // Btn_Load_Data
            // 
            this.Btn_Load_Data.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Load_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Load_Data.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Load_Data.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Load_Data.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Load_Data.Location = new System.Drawing.Point(81, 644);
            this.Btn_Load_Data.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Load_Data.Name = "Btn_Load_Data";
            this.Btn_Load_Data.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Load_Data.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Load_Data.Size = new System.Drawing.Size(106, 43);
            this.Btn_Load_Data.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Load_Data.TabIndex = 146;
            this.Btn_Load_Data.Text = "一键校准";
            this.Btn_Load_Data.Click += new System.EventHandler(this.Button_Fast_Calib_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(17, 20);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "拼接次数";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Add_Calib
            // 
            this.Btn_Add_Calib.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Add_Calib.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Add_Calib.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Add_Calib.Location = new System.Drawing.Point(112, 14);
            this.Btn_Add_Calib.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Add_Calib.Name = "Btn_Add_Calib";
            this.Btn_Add_Calib.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Add_Calib.Size = new System.Drawing.Size(29, 29);
            this.Btn_Add_Calib.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Add_Calib.TabIndex = 142;
            this.Btn_Add_Calib.Text = "+";
            this.Btn_Add_Calib.Click += new System.EventHandler(this.Btn_Add_Calib_Click);
            // 
            // Btn_Remove_Calib
            // 
            this.Btn_Remove_Calib.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Remove_Calib.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Remove_Calib.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Remove_Calib.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Remove_Calib.Location = new System.Drawing.Point(147, 14);
            this.Btn_Remove_Calib.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Remove_Calib.Name = "Btn_Remove_Calib";
            this.Btn_Remove_Calib.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Remove_Calib.Size = new System.Drawing.Size(29, 29);
            this.Btn_Remove_Calib.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Remove_Calib.TabIndex = 143;
            this.Btn_Remove_Calib.Text = "-";
            this.Btn_Remove_Calib.Click += new System.EventHandler(this.Btn_Remove_Calib_Click);
            // 
            // Panel_Step
            // 
            this.Panel_Step.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Step.Location = new System.Drawing.Point(0, 0);
            this.Panel_Step.Name = "Panel_Step";
            this.Panel_Step.Size = new System.Drawing.Size(420, 700);
            this.Panel_Step.TabIndex = 147;
            // 
            // Calib3DPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.Btn_Load_Data);
            this.Controls.Add(this.Panel_Calibs);
            this.Controls.Add(this.Btn_Enable_Calib);
            this.Controls.Add(this.Btn_Remove_Calib);
            this.Controls.Add(this.Btn_Add_Calib);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.Panel_Step);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Calib3DPanel";
            this.Size = new System.Drawing.Size(420, 700);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton Btn_Enable_Calib;
        private System.Windows.Forms.FlowLayoutPanel Panel_Calibs;
        private Sunny.UI.UIButton Btn_Load_Data;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton Btn_Add_Calib;
        private Sunny.UI.UIButton Btn_Remove_Calib;
        private System.Windows.Forms.Panel Panel_Step;
    }
}

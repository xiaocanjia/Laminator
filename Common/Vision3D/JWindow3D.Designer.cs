namespace Vision3D
{
    partial class JWindow3D
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
            this.Label_Pos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HWindowControl = new HalconDotNet.HWindowControl();
            this.CbB_Mode = new Sunny.UI.UIComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Pos
            // 
            this.Label_Pos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_Pos.AutoSize = true;
            this.Label_Pos.BackColor = System.Drawing.Color.Black;
            this.Label_Pos.ForeColor = System.Drawing.Color.White;
            this.Label_Pos.Location = new System.Drawing.Point(5, 550);
            this.Label_Pos.Name = "Label_Pos";
            this.Label_Pos.Size = new System.Drawing.Size(0, 16);
            this.Label_Pos.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Label_Pos);
            this.panel1.Controls.Add(this.HWindowControl);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 573);
            this.panel1.TabIndex = 13;
            // 
            // HWindowControl
            // 
            this.HWindowControl.BackColor = System.Drawing.Color.Black;
            this.HWindowControl.BorderColor = System.Drawing.Color.Black;
            this.HWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.HWindowControl.Location = new System.Drawing.Point(0, 0);
            this.HWindowControl.Name = "HWindowControl";
            this.HWindowControl.Size = new System.Drawing.Size(635, 573);
            this.HWindowControl.TabIndex = 0;
            this.HWindowControl.WindowSize = new System.Drawing.Size(635, 573);
            // 
            // CbB_Mode
            // 
            this.CbB_Mode.DataSource = null;
            this.CbB_Mode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Mode.FillColor = System.Drawing.Color.White;
            this.CbB_Mode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbB_Mode.Items.AddRange(new object[] {
            "高度图",
            "亮度图"});
            this.CbB_Mode.Location = new System.Drawing.Point(5, 4);
            this.CbB_Mode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Mode.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Mode.Name = "CbB_Mode";
            this.CbB_Mode.Padding = new System.Windows.Forms.Padding(5, 0, 30, 2);
            this.CbB_Mode.Size = new System.Drawing.Size(95, 25);
            this.CbB_Mode.TabIndex = 14;
            this.CbB_Mode.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.CbB_Mode.SelectedIndexChanged += new System.EventHandler(this.CbB_Mode_SelectedIndexChanged);
            // 
            // JWindow3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.CbB_Mode);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JWindow3D";
            this.Size = new System.Drawing.Size(635, 605);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_Pos;
        private System.Windows.Forms.Panel panel1;
        private HalconDotNet.HWindowControl HWindowControl;
        private Sunny.UI.UIComboBox CbB_Mode;
    }
}

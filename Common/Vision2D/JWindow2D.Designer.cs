namespace Vision2D
{
    partial class JWindow2D
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
            this.HWindowControl = new HalconDotNet.HWindowControl();
            this.Label_Pos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HWindowControl
            // 
            this.HWindowControl.BackColor = System.Drawing.Color.Black;
            this.HWindowControl.BorderColor = System.Drawing.Color.Black;
            this.HWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.HWindowControl.Location = new System.Drawing.Point(0, 0);
            this.HWindowControl.Name = "HWindowControl";
            this.HWindowControl.Size = new System.Drawing.Size(526, 492);
            this.HWindowControl.TabIndex = 9;
            this.HWindowControl.WindowSize = new System.Drawing.Size(526, 492);
            // 
            // Label_Pos
            // 
            this.Label_Pos.AutoSize = true;
            this.Label_Pos.BackColor = System.Drawing.Color.Transparent;
            this.Label_Pos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Pos.Location = new System.Drawing.Point(12, 468);
            this.Label_Pos.Name = "Label_Pos";
            this.Label_Pos.Size = new System.Drawing.Size(16, 16);
            this.Label_Pos.TabIndex = 10;
            this.Label_Pos.Text = "1";
            // 
            // JWindow2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label_Pos);
            this.Controls.Add(this.HWindowControl);
            this.Name = "JWindow2D";
            this.Size = new System.Drawing.Size(526, 492);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl HWindowControl;
        private System.Windows.Forms.Label Label_Pos;
    }
}

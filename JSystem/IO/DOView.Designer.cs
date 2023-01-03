namespace JSystem.IO
{
    partial class DOView
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
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.Switch_IsOn = new Sunny.UI.UISwitch();
            this.Lbl_Name = new Sunny.UI.UILabel();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.Switch_IsOn);
            this.uiPanel1.Controls.Add(this.Lbl_Name);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Radius = 10;
            this.uiPanel1.RectColor = System.Drawing.Color.SteelBlue;
            this.uiPanel1.Size = new System.Drawing.Size(254, 40);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.StyleCustomMode = true;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Switch_IsOn
            // 
            this.Switch_IsOn.ActiveColor = System.Drawing.Color.SteelBlue;
            this.Switch_IsOn.BackColor = System.Drawing.Color.Transparent;
            this.Switch_IsOn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Switch_IsOn.Location = new System.Drawing.Point(173, 7);
            this.Switch_IsOn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Switch_IsOn.Name = "Switch_IsOn";
            this.Switch_IsOn.Size = new System.Drawing.Size(75, 29);
            this.Switch_IsOn.Style = Sunny.UI.UIStyle.Custom;
            this.Switch_IsOn.StyleCustomMode = true;
            this.Switch_IsOn.TabIndex = 169;
            this.Switch_IsOn.Text = "uiSwitch1";
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_Name.Location = new System.Drawing.Point(7, 5);
            this.Lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(153, 31);
            this.Lbl_Name.Style = Sunny.UI.UIStyle.Custom;
            this.Lbl_Name.TabIndex = 168;
            this.Lbl_Name.Text = "名称";
            this.Lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DOView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.uiPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 15, 4);
            this.Name = "DOView";
            this.Size = new System.Drawing.Size(254, 40);
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISwitch Switch_IsOn;
        private Sunny.UI.UILabel Lbl_Name;
    }
}

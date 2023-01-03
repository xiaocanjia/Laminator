namespace Meas3D.Calib
{
    partial class MinimizedView
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
            this.Btn_Remove_Step = new Sunny.UI.UIButton();
            this.Btn_Add_Step = new Sunny.UI.UIButton();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.Panel_Steps = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Panel_Steps);
            this.panel1.Controls.Add(this.Btn_Remove_Step);
            this.panel1.Controls.Add(this.Btn_Add_Step);
            this.panel1.Controls.Add(this.uiLabel14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 84);
            this.panel1.TabIndex = 0;
            // 
            // Btn_Remove_Step
            // 
            this.Btn_Remove_Step.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Remove_Step.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Remove_Step.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Remove_Step.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Remove_Step.Location = new System.Drawing.Point(98, 3);
            this.Btn_Remove_Step.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Remove_Step.Name = "Btn_Remove_Step";
            this.Btn_Remove_Step.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Remove_Step.Size = new System.Drawing.Size(29, 29);
            this.Btn_Remove_Step.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Remove_Step.TabIndex = 243;
            this.Btn_Remove_Step.Text = "-";
            this.Btn_Remove_Step.Click += new System.EventHandler(this.Btn_Remove_Step_Click);
            // 
            // Btn_Add_Step
            // 
            this.Btn_Add_Step.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Add_Step.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Add_Step.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Add_Step.Location = new System.Drawing.Point(63, 3);
            this.Btn_Add_Step.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Add_Step.Name = "Btn_Add_Step";
            this.Btn_Add_Step.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Add_Step.Size = new System.Drawing.Size(29, 29);
            this.Btn_Add_Step.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Add_Step.TabIndex = 242;
            this.Btn_Add_Step.Text = "+";
            this.Btn_Add_Step.Click += new System.EventHandler(this.Btn_Add_Step_Click);
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel14.Location = new System.Drawing.Point(5, 9);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(52, 23);
            this.uiLabel14.TabIndex = 241;
            this.uiLabel14.Text = "台阶";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_Steps
            // 
            this.Panel_Steps.AutoScroll = true;
            this.Panel_Steps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Steps.Location = new System.Drawing.Point(6, 38);
            this.Panel_Steps.Name = "Panel_Steps";
            this.Panel_Steps.Size = new System.Drawing.Size(386, 40);
            this.Panel_Steps.TabIndex = 244;
            // 
            // MinimizedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MinimizedView";
            this.Size = new System.Drawing.Size(400, 84);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel Panel_Steps;
        private Sunny.UI.UIButton Btn_Remove_Step;
        private Sunny.UI.UIButton Btn_Add_Step;
        private Sunny.UI.UILabel uiLabel14;
    }
}

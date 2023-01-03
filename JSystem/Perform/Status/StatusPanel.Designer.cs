namespace JSystem.Perform
{
    partial class StatusPanel
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
            this.components = new System.ComponentModel.Container();
            this.Timer_Monitor = new System.Windows.Forms.Timer(this.components);
            this.Btn_Title = new Sunny.UI.UIButton();
            this.Panel_State = new Sunny.UI.UIFlowLayoutPanel();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.Lb_State = new Sunny.UI.UILabel();
            this.Lbl_Name = new Sunny.UI.UILabel();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.Lb_Raster = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.Lb_Door = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.Panel_State.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_Monitor
            // 
            this.Timer_Monitor.Interval = 2000;
            this.Timer_Monitor.Tick += new System.EventHandler(this.Timer_Monitor_Tick);
            // 
            // Btn_Title
            // 
            this.Btn_Title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Title.Enabled = false;
            this.Btn_Title.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Title.FillDisableColor = System.Drawing.Color.SteelBlue;
            this.Btn_Title.FillHoverColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Title.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Title.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Title.ForeDisableColor = System.Drawing.Color.White;
            this.Btn_Title.Location = new System.Drawing.Point(0, 0);
            this.Btn_Title.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Title.Name = "Btn_Title";
            this.Btn_Title.RectColor = System.Drawing.Color.SteelBlue;
            this.Btn_Title.Size = new System.Drawing.Size(542, 35);
            this.Btn_Title.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Title.StyleCustomMode = true;
            this.Btn_Title.TabIndex = 177;
            this.Btn_Title.Text = "设备状态";
            // 
            // Panel_State
            // 
            this.Panel_State.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_State.Controls.Add(this.uiPanel2);
            this.Panel_State.Controls.Add(this.uiPanel3);
            this.Panel_State.Controls.Add(this.uiPanel1);
            this.Panel_State.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_State.Location = new System.Drawing.Point(0, 33);
            this.Panel_State.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_State.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_State.Name = "Panel_State";
            this.Panel_State.Padding = new System.Windows.Forms.Padding(2);
            this.Panel_State.Size = new System.Drawing.Size(542, 189);
            this.Panel_State.TabIndex = 178;
            this.Panel_State.Text = "uiFlowLayoutPanel1";
            this.Panel_State.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.Lb_State);
            this.uiPanel2.Controls.Add(this.Lbl_Name);
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(6, 6);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(260, 40);
            this.uiPanel2.TabIndex = 12;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_State
            // 
            this.Lb_State.BackColor = System.Drawing.Color.Transparent;
            this.Lb_State.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_State.ForeColor = System.Drawing.Color.Orange;
            this.Lb_State.Location = new System.Drawing.Point(121, 9);
            this.Lb_State.Name = "Lb_State";
            this.Lb_State.Size = new System.Drawing.Size(120, 23);
            this.Lb_State.TabIndex = 1;
            this.Lb_State.Text = "未初始化";
            this.Lb_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_Name.Location = new System.Drawing.Point(3, 9);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(100, 23);
            this.Lbl_Name.TabIndex = 0;
            this.Lbl_Name.Text = "当前状态";
            this.Lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.Lb_Raster);
            this.uiPanel3.Controls.Add(this.uiLabel3);
            this.uiPanel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel3.Location = new System.Drawing.Point(274, 6);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(260, 40);
            this.uiPanel3.TabIndex = 14;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_Raster
            // 
            this.Lb_Raster.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Raster.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_Raster.ForeColor = System.Drawing.Color.Green;
            this.Lb_Raster.Location = new System.Drawing.Point(121, 9);
            this.Lb_Raster.Name = "Lb_Raster";
            this.Lb_Raster.Size = new System.Drawing.Size(120, 23);
            this.Lb_Raster.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_Raster.StyleCustomMode = true;
            this.Lb_Raster.TabIndex = 1;
            this.Lb_Raster.Text = "已启用";
            this.Lb_Raster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(3, 9);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "安全光栅";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.Lb_Door);
            this.uiPanel1.Controls.Add(this.uiLabel2);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(6, 53);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(260, 40);
            this.uiPanel1.TabIndex = 13;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_Door
            // 
            this.Lb_Door.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Door.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_Door.ForeColor = System.Drawing.Color.Green;
            this.Lb_Door.Location = new System.Drawing.Point(121, 9);
            this.Lb_Door.Name = "Lb_Door";
            this.Lb_Door.Size = new System.Drawing.Size(120, 23);
            this.Lb_Door.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_Door.StyleCustomMode = true;
            this.Lb_Door.TabIndex = 1;
            this.Lb_Door.Text = "已启用";
            this.Lb_Door.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 9);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "安全门";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Panel_State);
            this.Controls.Add(this.Btn_Title);
            this.Name = "StatusPanel";
            this.Size = new System.Drawing.Size(542, 222);
            this.Panel_State.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Timer_Monitor;
        private Sunny.UI.UIButton Btn_Title;
        private Sunny.UI.UIFlowLayoutPanel Panel_State;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UILabel Lb_State;
        private Sunny.UI.UILabel Lbl_Name;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UILabel Lb_Raster;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel Lb_Door;
        private Sunny.UI.UILabel uiLabel2;
    }
}

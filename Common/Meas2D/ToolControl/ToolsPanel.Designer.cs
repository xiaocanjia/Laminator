namespace Meas2D
{
    partial class ToolsPanel
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
            this.Panel_Tool_List = new System.Windows.Forms.FlowLayoutPanel();
            this.CbB_Tools_List = new Sunny.UI.UIComboBox();
            this.Button_Add_Tool = new Sunny.UI.UIButton();
            this.Panel_Setup = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Panel_Tool_List
            // 
            this.Panel_Tool_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Tool_List.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Tool_List.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_Tool_List.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_Tool_List.Location = new System.Drawing.Point(3, 45);
            this.Panel_Tool_List.Name = "Panel_Tool_List";
            this.Panel_Tool_List.Size = new System.Drawing.Size(394, 652);
            this.Panel_Tool_List.TabIndex = 98;
            // 
            // CbB_Tools_List
            // 
            this.CbB_Tools_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbB_Tools_List.DataSource = null;
            this.CbB_Tools_List.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Tools_List.FillColor = System.Drawing.Color.White;
            this.CbB_Tools_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Tools_List.Items.AddRange(new object[] {
            "2"});
            this.CbB_Tools_List.Location = new System.Drawing.Point(4, 10);
            this.CbB_Tools_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Tools_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Tools_List.Name = "CbB_Tools_List";
            this.CbB_Tools_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Tools_List.Size = new System.Drawing.Size(305, 29);
            this.CbB_Tools_List.TabIndex = 97;
            this.CbB_Tools_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_Add_Tool
            // 
            this.Button_Add_Tool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add_Tool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Add_Tool.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Add_Tool.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Add_Tool.Location = new System.Drawing.Point(320, 9);
            this.Button_Add_Tool.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Add_Tool.Name = "Button_Add_Tool";
            this.Button_Add_Tool.Radius = 20;
            this.Button_Add_Tool.Size = new System.Drawing.Size(72, 30);
            this.Button_Add_Tool.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Add_Tool.TabIndex = 96;
            this.Button_Add_Tool.Text = "添加";
            this.Button_Add_Tool.Click += new System.EventHandler(this.Button_Add_Tool_Click);
            // 
            // Panel_Setup
            // 
            this.Panel_Setup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Setup.Location = new System.Drawing.Point(0, 0);
            this.Panel_Setup.Name = "Panel_Setup";
            this.Panel_Setup.Size = new System.Drawing.Size(400, 700);
            this.Panel_Setup.TabIndex = 99;
            // 
            // ToolsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Panel_Tool_List);
            this.Controls.Add(this.CbB_Tools_List);
            this.Controls.Add(this.Button_Add_Tool);
            this.Controls.Add(this.Panel_Setup);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ToolsPanel";
            this.Size = new System.Drawing.Size(400, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Panel_Tool_List;
        private Sunny.UI.UIComboBox CbB_Tools_List;
        private Sunny.UI.UIButton Button_Add_Tool;
        private System.Windows.Forms.Panel Panel_Setup;
    }
}

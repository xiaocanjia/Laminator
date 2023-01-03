namespace JSystem
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("主页");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("调试");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("参数");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("设备");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("系统");
            this.Avatar = new Sunny.UI.UIAvatar();
            this.Button_Delete_Pro = new Sunny.UI.UISymbolButton();
            this.Button_Save_Project = new Sunny.UI.UISymbolButton();
            this.CbB_Project_List = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Controls.Add(this.uiLabel1);
            this.Header.Controls.Add(this.Button_Delete_Pro);
            this.Header.Controls.Add(this.Button_Save_Project);
            this.Header.Controls.Add(this.CbB_Project_List);
            this.Header.Controls.Add(this.Avatar);
            this.Header.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.Header.MenuSelectedColor = System.Drawing.SystemColors.ActiveBorder;
            this.Header.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Header.NodeAlignment = System.Drawing.StringAlignment.Near;
            treeNode6.Name = "节点0";
            treeNode6.Text = "主页";
            treeNode7.Name = "节点1";
            treeNode7.Text = "调试";
            treeNode8.Name = "节点2";
            treeNode8.Text = "参数";
            treeNode9.Name = "节点3";
            treeNode9.Text = "设备";
            treeNode10.Name = "节点4";
            treeNode10.Text = "系统";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.Header.SelectedForeColor = System.Drawing.Color.SteelBlue;
            this.Header.Size = new System.Drawing.Size(1382, 90);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
            // 
            // Avatar
            // 
            this.Avatar.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Avatar.ForeColor = System.Drawing.Color.SteelBlue;
            this.Avatar.Location = new System.Drawing.Point(3, 17);
            this.Avatar.MinimumSize = new System.Drawing.Size(1, 1);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(85, 67);
            this.Avatar.Style = Sunny.UI.UIStyle.Custom;
            this.Avatar.TabIndex = 3;
            this.Avatar.Text = "uiAvatar1";
            // 
            // Button_Delete_Pro
            // 
            this.Button_Delete_Pro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Delete_Pro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Delete_Pro.FillColor = System.Drawing.Color.Transparent;
            this.Button_Delete_Pro.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Delete_Pro.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete_Pro.Location = new System.Drawing.Point(1339, 54);
            this.Button_Delete_Pro.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Delete_Pro.Name = "Button_Delete_Pro";
            this.Button_Delete_Pro.RectColor = System.Drawing.Color.Transparent;
            this.Button_Delete_Pro.Size = new System.Drawing.Size(30, 30);
            this.Button_Delete_Pro.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Delete_Pro.Symbol = 61944;
            this.Button_Delete_Pro.SymbolSize = 30;
            this.Button_Delete_Pro.TabIndex = 151;
            // 
            // Button_Save_Project
            // 
            this.Button_Save_Project.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Save_Project.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Save_Project.FillColor = System.Drawing.Color.Transparent;
            this.Button_Save_Project.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Save_Project.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Save_Project.Location = new System.Drawing.Point(1307, 54);
            this.Button_Save_Project.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Save_Project.Name = "Button_Save_Project";
            this.Button_Save_Project.RectColor = System.Drawing.Color.Transparent;
            this.Button_Save_Project.Size = new System.Drawing.Size(30, 30);
            this.Button_Save_Project.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Save_Project.Symbol = 61639;
            this.Button_Save_Project.SymbolSize = 30;
            this.Button_Save_Project.TabIndex = 150;
            // 
            // CbB_Project_List
            // 
            this.CbB_Project_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbB_Project_List.DataSource = null;
            this.CbB_Project_List.FillColor = System.Drawing.Color.White;
            this.CbB_Project_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Project_List.Location = new System.Drawing.Point(1026, 53);
            this.CbB_Project_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Project_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Project_List.Name = "CbB_Project_List";
            this.CbB_Project_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Project_List.Size = new System.Drawing.Size(274, 29);
            this.CbB_Project_List.Style = Sunny.UI.UIStyle.Custom;
            this.CbB_Project_List.TabIndex = 149;
            this.CbB_Project_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(939, 56);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(80, 23);
            this.uiLabel1.TabIndex = 152;
            this.uiLabel1.Text = "当前项目";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 849);
            this.Name = "MainForm";
            this.RectColor = System.Drawing.Color.SteelBlue;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "JSystem";
            this.TitleColor = System.Drawing.Color.SteelBlue;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIAvatar Avatar;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton Button_Delete_Pro;
        private Sunny.UI.UISymbolButton Button_Save_Project;
        private Sunny.UI.UIComboBox CbB_Project_List;
    }
}
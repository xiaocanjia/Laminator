namespace JSystem
{
    partial class MainWindow
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("主页");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("IO");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("工站");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("设备");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("参数");
            this.Avatar = new Sunny.UI.UIAvatar();
            this.projectPanel = new JSystem.Project.ProjectPanel();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.AliceBlue;
            this.Header.Controls.Add(this.projectPanel);
            this.Header.Controls.Add(this.Avatar);
            this.Header.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.Header.MenuSelectedColor = System.Drawing.SystemColors.ActiveBorder;
            this.Header.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Header.NodeAlignment = System.Drawing.StringAlignment.Near;
            treeNode1.Name = "节点0";
            treeNode1.Text = "主页";
            treeNode2.Name = "节点0";
            treeNode2.Text = "IO";
            treeNode3.Name = "节点1";
            treeNode3.Text = "工站";
            treeNode4.Name = "节点2";
            treeNode4.Text = "设备";
            treeNode5.Name = "节点3";
            treeNode5.Text = "参数";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.Header.NodeSize = new System.Drawing.Size(120, 45);
            this.Header.SelectedForeColor = System.Drawing.Color.SteelBlue;
            this.Header.Size = new System.Drawing.Size(1221, 90);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
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
            this.Avatar.Click += new System.EventHandler(this.Avatar_Click);
            // 
            // projectPanel
            // 
            this.projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.projectPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.projectPanel.Location = new System.Drawing.Point(858, 45);
            this.projectPanel.Margin = new System.Windows.Forms.Padding(4);
            this.projectPanel.Name = "projectPanel";
            this.projectPanel.Size = new System.Drawing.Size(359, 39);
            this.projectPanel.TabIndex = 4;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1221, 900);
            this.CloseAskString = "";
            this.Name = "MainWindow";
            this.RectColor = System.Drawing.Color.SteelBlue;
            this.ShowIcon = true;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "JSystem V1.0";
            this.TitleColor = System.Drawing.Color.SteelBlue;
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIAvatar Avatar;
        private Project.ProjectPanel projectPanel;
    }
}
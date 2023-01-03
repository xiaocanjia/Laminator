namespace Meas2D
{
    partial class Meas2DPage
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
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolsPanel = new Meas2D.ToolsPanel();
            this.Panel_Vision = new Sunny.UI.UIPanel();
            this.Win2D = new Vision2D.JWindow2D();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Btn_Load_Image = new Sunny.UI.UISymbolButton();
            this.fixPosPanel = new Meas2D.FixPos.FixPos2DPanel();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Panel_Vision.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(130, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(775, 5);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(422, 788);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.StyleCustomMode = true;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.SteelBlue;
            this.uiTabControl1.TabIndex = 33;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.AliceBlue;
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.Black;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(422, 748);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "标定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fixPosPanel);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(422, 748);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "定位";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolsPanel);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(422, 748);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "测量";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolsPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(422, 748);
            this.toolsPanel.TabIndex = 0;
            // 
            // Panel_Vision
            // 
            this.Panel_Vision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Vision.Controls.Add(this.Win2D);
            this.Panel_Vision.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Panel_Vision.Location = new System.Drawing.Point(13, 45);
            this.Panel_Vision.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Vision.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Vision.Name = "Panel_Vision";
            this.Panel_Vision.Size = new System.Drawing.Size(755, 748);
            this.Panel_Vision.Style = Sunny.UI.UIStyle.Custom;
            this.Panel_Vision.TabIndex = 34;
            this.Panel_Vision.Text = null;
            this.Panel_Vision.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Win2D
            // 
            this.Win2D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Win2D.Location = new System.Drawing.Point(0, 0);
            this.Win2D.Margin = new System.Windows.Forms.Padding(17075, 40330, 17075, 40330);
            this.Win2D.Name = "Win2D";
            this.Win2D.Size = new System.Drawing.Size(755, 748);
            this.Win2D.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.Btn_Load_Image);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 39);
            this.panel1.TabIndex = 151;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(7, 8);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 150;
            this.uiLabel1.Text = "显示";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Load_Image
            // 
            this.Btn_Load_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Load_Image.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_Load_Image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Load_Image.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Load_Image.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Load_Image.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Load_Image.Location = new System.Drawing.Point(714, 5);
            this.Btn_Load_Image.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Load_Image.Name = "Btn_Load_Image";
            this.Btn_Load_Image.RectColor = System.Drawing.Color.Transparent;
            this.Btn_Load_Image.Size = new System.Drawing.Size(30, 30);
            this.Btn_Load_Image.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Load_Image.StyleCustomMode = true;
            this.Btn_Load_Image.Symbol = 57457;
            this.Btn_Load_Image.SymbolSize = 30;
            this.Btn_Load_Image.TabIndex = 149;
            this.Btn_Load_Image.TipsText = "aaa";
            this.Btn_Load_Image.Click += new System.EventHandler(this.Btn_Load_Image_Click);
            // 
            // fixPosPanel
            // 
            this.fixPosPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.fixPosPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixPosPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fixPosPanel.Location = new System.Drawing.Point(0, 0);
            this.fixPosPanel.Margin = new System.Windows.Forms.Padding(4);
            this.fixPosPanel.Name = "fixPosPanel";
            this.fixPosPanel.Size = new System.Drawing.Size(422, 748);
            this.fixPosPanel.TabIndex = 0;
            // 
            // Meas2DPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Vision);
            this.Controls.Add(this.uiTabControl1);
            this.Name = "Meas2DPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Vison2DPage";
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.Panel_Vision.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Meas2D.ToolsPanel toolsPanel;
        public Sunny.UI.UIPanel Panel_Vision;
        public Vision2D.JWindow2D Win2D;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton Btn_Load_Image;
        private FixPos.FixPos2DPanel fixPosPanel;
    }
}
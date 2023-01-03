namespace Meas3D
{
    partial class Meas3DPage
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
            this.Btn_Load_Matrix = new Sunny.UI.UISymbolButton();
            this.Tab_3D = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.calib3DPanel = new Meas3D.Calib.Calib3DPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.fixPosPanel = new Meas3D.FixPos.FixPos3DPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.toolsPanel = new Meas3D.Tool.ToolsPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CB_Save_Data = new Sunny.UI.UICheckBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TB_Data_Dir = new Sunny.UI.UITextBox();
            this.Btn_Data_Save_Dir = new Sunny.UI.UISymbolButton();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.Btn_Image_Save_Dir = new Sunny.UI.UISymbolButton();
            this.TB_Image_Dir = new Sunny.UI.UITextBox();
            this.CB_Save_Fail_Image = new Sunny.UI.UICheckBox();
            this.CB_Save_Image = new Sunny.UI.UICheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Panel_Vision = new Sunny.UI.UIPanel();
            this.Win3D = new Vision3D.JWindow3D();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Tab_3D.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_Vision.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Load_Matrix
            // 
            this.Btn_Load_Matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Load_Matrix.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_Load_Matrix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Load_Matrix.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Load_Matrix.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Load_Matrix.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Load_Matrix.Location = new System.Drawing.Point(721, 5);
            this.Btn_Load_Matrix.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Load_Matrix.Name = "Btn_Load_Matrix";
            this.Btn_Load_Matrix.RectColor = System.Drawing.Color.Transparent;
            this.Btn_Load_Matrix.Size = new System.Drawing.Size(30, 30);
            this.Btn_Load_Matrix.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Load_Matrix.StyleCustomMode = true;
            this.Btn_Load_Matrix.Symbol = 57457;
            this.Btn_Load_Matrix.SymbolSize = 30;
            this.Btn_Load_Matrix.TabIndex = 149;
            this.Btn_Load_Matrix.TipsText = "aaa";
            this.Btn_Load_Matrix.Click += new System.EventHandler(this.Btn_Load_Matrix_Click);
            // 
            // Tab_3D
            // 
            this.Tab_3D.Controls.Add(this.tabPage1);
            this.Tab_3D.Controls.Add(this.tabPage4);
            this.Tab_3D.Controls.Add(this.tabPage5);
            this.Tab_3D.Controls.Add(this.tabPage2);
            this.Tab_3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_3D.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Tab_3D.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tab_3D.ItemSize = new System.Drawing.Size(100, 40);
            this.Tab_3D.Location = new System.Drawing.Point(0, 0);
            this.Tab_3D.MainPage = "";
            this.Tab_3D.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Tab_3D.Name = "Tab_3D";
            this.Tab_3D.SelectedIndex = 0;
            this.Tab_3D.Size = new System.Drawing.Size(420, 786);
            this.Tab_3D.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tab_3D.Style = Sunny.UI.UIStyle.Custom;
            this.Tab_3D.StyleCustomMode = true;
            this.Tab_3D.TabBackColor = System.Drawing.Color.SteelBlue;
            this.Tab_3D.TabIndex = 34;
            this.Tab_3D.TabSelectedColor = System.Drawing.Color.AliceBlue;
            this.Tab_3D.TabSelectedForeColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.calib3DPanel);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(420, 746);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "校准";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // calib3DPanel
            // 
            this.calib3DPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.calib3DPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calib3DPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.calib3DPanel.Location = new System.Drawing.Point(0, 0);
            this.calib3DPanel.Name = "calib3DPanel";
            this.calib3DPanel.Size = new System.Drawing.Size(420, 746);
            this.calib3DPanel.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.fixPosPanel);
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(420, 746);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "定位";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // fixPosPanel
            // 
            this.fixPosPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.fixPosPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixPosPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fixPosPanel.Location = new System.Drawing.Point(0, 0);
            this.fixPosPanel.Margin = new System.Windows.Forms.Padding(5);
            this.fixPosPanel.Name = "fixPosPanel";
            this.fixPosPanel.Size = new System.Drawing.Size(420, 746);
            this.fixPosPanel.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.toolsPanel);
            this.tabPage5.Location = new System.Drawing.Point(0, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(420, 746);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "测量";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolsPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(420, 746);
            this.toolsPanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.CB_Save_Data);
            this.tabPage2.Controls.Add(this.uiLabel2);
            this.tabPage2.Controls.Add(this.TB_Data_Dir);
            this.tabPage2.Controls.Add(this.Btn_Data_Save_Dir);
            this.tabPage2.Controls.Add(this.uiLabel10);
            this.tabPage2.Controls.Add(this.Btn_Image_Save_Dir);
            this.tabPage2.Controls.Add(this.TB_Image_Dir);
            this.tabPage2.Controls.Add(this.CB_Save_Fail_Image);
            this.tabPage2.Controls.Add(this.CB_Save_Image);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(420, 746);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "保存";
            // 
            // CB_Save_Data
            // 
            this.CB_Save_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_Save_Data.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Save_Data.Location = new System.Drawing.Point(11, 199);
            this.CB_Save_Data.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_Save_Data.Name = "CB_Save_Data";
            this.CB_Save_Data.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_Save_Data.Size = new System.Drawing.Size(133, 29);
            this.CB_Save_Data.Style = Sunny.UI.UIStyle.Custom;
            this.CB_Save_Data.TabIndex = 221;
            this.CB_Save_Data.Text = "是否保存数据";
            this.CB_Save_Data.CheckedChanged += new System.EventHandler(this.CB_Save_Data_CheckedChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(10, 150);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(106, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 220;
            this.uiLabel2.Text = "数据保存路径";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Data_Dir
            // 
            this.TB_Data_Dir.ButtonSymbol = 61761;
            this.TB_Data_Dir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Data_Dir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Data_Dir.Location = new System.Drawing.Point(127, 146);
            this.TB_Data_Dir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Data_Dir.Maximum = 2147483647D;
            this.TB_Data_Dir.Minimum = -2147483648D;
            this.TB_Data_Dir.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Data_Dir.Name = "TB_Data_Dir";
            this.TB_Data_Dir.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Data_Dir.Size = new System.Drawing.Size(246, 29);
            this.TB_Data_Dir.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Data_Dir.TabIndex = 219;
            this.TB_Data_Dir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Data_Save_Dir
            // 
            this.Btn_Data_Save_Dir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Data_Save_Dir.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Data_Save_Dir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Data_Save_Dir.Location = new System.Drawing.Point(380, 146);
            this.Btn_Data_Save_Dir.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Data_Save_Dir.Name = "Btn_Data_Save_Dir";
            this.Btn_Data_Save_Dir.Size = new System.Drawing.Size(30, 28);
            this.Btn_Data_Save_Dir.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Data_Save_Dir.StyleCustomMode = true;
            this.Btn_Data_Save_Dir.Symbol = 61761;
            this.Btn_Data_Save_Dir.TabIndex = 218;
            this.Btn_Data_Save_Dir.Click += new System.EventHandler(this.Btn_Data_Save_Dir_Click);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel10.Location = new System.Drawing.Point(10, 37);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(106, 23);
            this.uiLabel10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel10.TabIndex = 217;
            this.uiLabel10.Text = "图片保存路径";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Image_Save_Dir
            // 
            this.Btn_Image_Save_Dir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Image_Save_Dir.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Image_Save_Dir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Image_Save_Dir.Location = new System.Drawing.Point(380, 34);
            this.Btn_Image_Save_Dir.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Image_Save_Dir.Name = "Btn_Image_Save_Dir";
            this.Btn_Image_Save_Dir.Size = new System.Drawing.Size(30, 28);
            this.Btn_Image_Save_Dir.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Image_Save_Dir.StyleCustomMode = true;
            this.Btn_Image_Save_Dir.Symbol = 61761;
            this.Btn_Image_Save_Dir.TabIndex = 216;
            this.Btn_Image_Save_Dir.Click += new System.EventHandler(this.Btn_Image_Save_Dir_Click);
            // 
            // TB_Image_Dir
            // 
            this.TB_Image_Dir.ButtonSymbol = 61761;
            this.TB_Image_Dir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Image_Dir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Image_Dir.Location = new System.Drawing.Point(127, 34);
            this.TB_Image_Dir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Image_Dir.Maximum = 2147483647D;
            this.TB_Image_Dir.Minimum = -2147483648D;
            this.TB_Image_Dir.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Image_Dir.Name = "TB_Image_Dir";
            this.TB_Image_Dir.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Image_Dir.Size = new System.Drawing.Size(246, 29);
            this.TB_Image_Dir.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Image_Dir.TabIndex = 215;
            this.TB_Image_Dir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_Save_Fail_Image
            // 
            this.CB_Save_Fail_Image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_Save_Fail_Image.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Save_Fail_Image.Location = new System.Drawing.Point(185, 80);
            this.CB_Save_Fail_Image.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_Save_Fail_Image.Name = "CB_Save_Fail_Image";
            this.CB_Save_Fail_Image.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_Save_Fail_Image.Size = new System.Drawing.Size(142, 29);
            this.CB_Save_Fail_Image.Style = Sunny.UI.UIStyle.Custom;
            this.CB_Save_Fail_Image.TabIndex = 214;
            this.CB_Save_Fail_Image.Text = "只保存FAIL图片";
            this.CB_Save_Fail_Image.CheckedChanged += new System.EventHandler(this.CB_Save_Fail_Image_CheckedChanged);
            // 
            // CB_Save_Image
            // 
            this.CB_Save_Image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_Save_Image.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Save_Image.Location = new System.Drawing.Point(11, 80);
            this.CB_Save_Image.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_Save_Image.Name = "CB_Save_Image";
            this.CB_Save_Image.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_Save_Image.Size = new System.Drawing.Size(105, 29);
            this.CB_Save_Image.Style = Sunny.UI.UIStyle.Custom;
            this.CB_Save_Image.TabIndex = 213;
            this.CB_Save_Image.Text = "保存图片";
            this.CB_Save_Image.CheckedChanged += new System.EventHandler(this.CB_Save_Image_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.Btn_Load_Matrix);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 39);
            this.panel1.TabIndex = 150;
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
            // Panel_Vision
            // 
            this.Panel_Vision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Vision.Controls.Add(this.Win3D);
            this.Panel_Vision.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Panel_Vision.Location = new System.Drawing.Point(5, 46);
            this.Panel_Vision.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Vision.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Vision.Name = "Panel_Vision";
            this.Panel_Vision.Size = new System.Drawing.Size(763, 747);
            this.Panel_Vision.Style = Sunny.UI.UIStyle.Custom;
            this.Panel_Vision.TabIndex = 151;
            this.Panel_Vision.Text = null;
            this.Panel_Vision.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Win3D
            // 
            this.Win3D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Win3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Win3D.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Win3D.Location = new System.Drawing.Point(0, 0);
            this.Win3D.Margin = new System.Windows.Forms.Padding(4);
            this.Win3D.Name = "Win3D";
            this.Win3D.Size = new System.Drawing.Size(763, 747);
            this.Win3D.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Tab_3D);
            this.panel2.Location = new System.Drawing.Point(775, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 788);
            this.panel2.TabIndex = 152;
            // 
            // Meas3DPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel_Vision);
            this.Controls.Add(this.panel1);
            this.Name = "Meas3DPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Vision3DPage";
            this.Tab_3D.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Panel_Vision.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITabControl Tab_3D;
        private System.Windows.Forms.TabPage tabPage4;
        private FixPos.FixPos3DPanel fixPosPanel;
        private System.Windows.Forms.TabPage tabPage5;
        private Tool.ToolsPanel toolsPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private Calib.Calib3DPanel calib3DPanel;
        private Sunny.UI.UISymbolButton Btn_Load_Matrix;
        private System.Windows.Forms.Panel panel1;
        public Sunny.UI.UIPanel Panel_Vision;
        public Vision3D.JWindow3D Win3D;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UISymbolButton Btn_Image_Save_Dir;
        private Sunny.UI.UITextBox TB_Image_Dir;
        private Sunny.UI.UICheckBox CB_Save_Fail_Image;
        private Sunny.UI.UICheckBox CB_Save_Image;
        private Sunny.UI.UICheckBox CB_Save_Data;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox TB_Data_Dir;
        private Sunny.UI.UISymbolButton Btn_Data_Save_Dir;
        private Sunny.UI.UILabel uiLabel10;
        private System.Windows.Forms.Panel panel2;
    }
}
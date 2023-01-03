namespace JSystem.Perform
{
    partial class PerformPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.Btn_Stop = new Sunny.UI.UISymbolButton();
            this.Btn_Start = new Sunny.UI.UISymbolButton();
            this.Btn_Reset = new Sunny.UI.UISymbolButton();
            this.Btn_ClearAlarm = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Panel_Vision = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGV_Results = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGV_Tray = new Sunny.UI.UIDataGridView();
            this.statisticsPanel = new JSystem.Perform.StatisticsPanel();
            this.StatusPanel = new JSystem.Perform.StatusPanel();
            this.runningMsgPanel = new JSystem.Perform.LogPanel();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tray)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel2, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiPanel1, 0, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 2;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1217, 788);
            this.uiTableLayoutPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTableLayoutPanel1.TabIndex = 33;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 4;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_Stop, 2, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_Start, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_Reset, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.Btn_ClearAlarm, 3, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.statisticsPanel, 0, 1);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(870, 3);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 2;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(344, 545);
            this.uiTableLayoutPanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTableLayoutPanel2.TabIndex = 31;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Stop.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Stop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Stop.Location = new System.Drawing.Point(177, 5);
            this.Btn_Stop.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(69, 54);
            this.Btn_Stop.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Stop.StyleCustomMode = true;
            this.Btn_Stop.Symbol = 61517;
            this.Btn_Stop.SymbolSize = 48;
            this.Btn_Stop.TabIndex = 7;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_End_Click);
            // 
            // Btn_Start
            // 
            this.Btn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Start.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Start.Location = new System.Drawing.Point(91, 5);
            this.Btn_Start.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Start.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(69, 54);
            this.Btn_Start.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Start.StyleCustomMode = true;
            this.Btn_Start.Symbol = 61515;
            this.Btn_Start.SymbolSize = 48;
            this.Btn_Start.TabIndex = 6;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Reset
            // 
            this.Btn_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Reset.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Reset.FillDisableColor = System.Drawing.Color.AliceBlue;
            this.Btn_Reset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Reset.Location = new System.Drawing.Point(5, 5);
            this.Btn_Reset.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_Reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Reset.Name = "Btn_Reset";
            this.Btn_Reset.Size = new System.Drawing.Size(69, 54);
            this.Btn_Reset.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Reset.StyleCustomMode = true;
            this.Btn_Reset.Symbol = 61470;
            this.Btn_Reset.SymbolSize = 48;
            this.Btn_Reset.TabIndex = 5;
            this.Btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // Btn_ClearAlarm
            // 
            this.Btn_ClearAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ClearAlarm.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_ClearAlarm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_ClearAlarm.Location = new System.Drawing.Point(263, 5);
            this.Btn_ClearAlarm.Margin = new System.Windows.Forms.Padding(5, 5, 3, 3);
            this.Btn_ClearAlarm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_ClearAlarm.Name = "Btn_ClearAlarm";
            this.Btn_ClearAlarm.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Btn_ClearAlarm.Size = new System.Drawing.Size(73, 54);
            this.Btn_ClearAlarm.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_ClearAlarm.StyleCustomMode = true;
            this.Btn_ClearAlarm.Symbol = 61942;
            this.Btn_ClearAlarm.SymbolSize = 48;
            this.Btn_ClearAlarm.TabIndex = 4;
            this.Btn_ClearAlarm.Click += new System.EventHandler(this.Btn_ClearAlarm_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StatusPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.runningMsgPanel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 554);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1211, 231);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiTabControl1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(9, 5);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(9, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(854, 541);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 34;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(2, 2);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(850, 537);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.StyleCustomMode = true;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.LightSteelBlue;
            this.uiTabControl1.TabIndex = 35;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.SteelBlue;
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.White;
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.SteelBlue;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Panel_Vision);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(850, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图像";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Panel_Vision
            // 
            this.Panel_Vision.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Vision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Vision.Location = new System.Drawing.Point(0, 0);
            this.Panel_Vision.Name = "Panel_Vision";
            this.Panel_Vision.Size = new System.Drawing.Size(850, 497);
            this.Panel_Vision.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGV_Results);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(850, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGV_Results
            // 
            this.DGV_Results.AllowUserToAddRows = false;
            this.DGV_Results.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.DGV_Results.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Results.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Results.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Results.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Results.ColumnHeadersHeight = 32;
            this.DGV_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Results.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Results.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Results.EnableHeadersVisualStyles = false;
            this.DGV_Results.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.DGV_Results.GridColor = System.Drawing.Color.LightSkyBlue;
            this.DGV_Results.Location = new System.Drawing.Point(0, 0);
            this.DGV_Results.Name = "DGV_Results";
            this.DGV_Results.RectColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Results.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Results.RowHeadersVisible = false;
            this.DGV_Results.RowHeadersWidth = 51;
            this.DGV_Results.RowHeight = 30;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DGV_Results.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Results.RowTemplate.Height = 30;
            this.DGV_Results.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_Results.ScrollMode = Sunny.UI.UIDataGridView.UIDataGridViewScrollMode.Page;
            this.DGV_Results.SelectedIndex = -1;
            this.DGV_Results.ShowGridLine = true;
            this.DGV_Results.Size = new System.Drawing.Size(850, 497);
            this.DGV_Results.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.DGV_Results.Style = Sunny.UI.UIStyle.Custom;
            this.DGV_Results.StyleCustomMode = true;
            this.DGV_Results.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "工具名称";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "结果名称";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "测量值";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "公差上限";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "公差下限";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "结果";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGV_Tray);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(850, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "料盘";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGV_Tray
            // 
            this.DGV_Tray.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DGV_Tray.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_Tray.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Tray.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Tray.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_Tray.ColumnHeadersHeight = 32;
            this.DGV_Tray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Tray.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_Tray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Tray.EnableHeadersVisualStyles = false;
            this.DGV_Tray.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DGV_Tray.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DGV_Tray.Location = new System.Drawing.Point(0, 0);
            this.DGV_Tray.Name = "DGV_Tray";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Tray.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV_Tray.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.DGV_Tray.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_Tray.RowTemplate.Height = 23;
            this.DGV_Tray.SelectedIndex = -1;
            this.DGV_Tray.ShowGridLine = true;
            this.DGV_Tray.Size = new System.Drawing.Size(850, 497);
            this.DGV_Tray.StyleCustomMode = true;
            this.DGV_Tray.TabIndex = 29;
            this.DGV_Tray.SizeChanged += new System.EventHandler(this.DGV_Tray_SizeChanged);
            // 
            // statisticsPanel
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.statisticsPanel, 4);
            this.statisticsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticsPanel.Location = new System.Drawing.Point(3, 70);
            this.statisticsPanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.statisticsPanel.Name = "statisticsPanel";
            this.statisticsPanel.Size = new System.Drawing.Size(338, 475);
            this.statisticsPanel.TabIndex = 9;
            // 
            // StatusPanel
            // 
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusPanel.Location = new System.Drawing.Point(5, 0);
            this.StatusPanel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(595, 226);
            this.StatusPanel.TabIndex = 0;
            // 
            // runningMsgPanel
            // 
            this.runningMsgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runningMsgPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runningMsgPanel.Location = new System.Drawing.Point(609, 0);
            this.runningMsgPanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.runningMsgPanel.Name = "runningMsgPanel";
            this.runningMsgPanel.Size = new System.Drawing.Size(598, 226);
            this.runningMsgPanel.TabIndex = 1;
            // 
            // PerformPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1217, 788);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Name = "PerformPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "PerformWindow";
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tray)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UISymbolButton Btn_ClearAlarm;
        public Sunny.UI.UISymbolButton Btn_Stop;
        public Sunny.UI.UISymbolButton Btn_Start;
        private Sunny.UI.UISymbolButton Btn_Reset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LogPanel runningMsgPanel;
        public StatusPanel StatusPanel;
        public StatisticsPanel statisticsPanel;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Panel Panel_Vision;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIDataGridView DGV_Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UIDataGridView DGV_Tray;
    }
}
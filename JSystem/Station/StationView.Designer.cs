namespace JSystem.Station
{
    partial class StationView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.Panel2 = new Sunny.UI.UIPanel();
            this.Panel_PointInfo = new System.Windows.Forms.Panel();
            this.Btn_Debug = new Sunny.UI.UISymbolButton();
            this.Btn_AllAxisMove = new Sunny.UI.UISymbolButton();
            this.Btn_SingleAxisMove = new Sunny.UI.UISymbolButton();
            this.Btn_Stop = new Sunny.UI.UISymbolButton();
            this.Btn_Record = new Sunny.UI.UISymbolButton();
            this.Btn_Apply = new Sunny.UI.UISymbolButton();
            this.DGV_PointInfo = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel_Axes = new Sunny.UI.UIFlowLayoutPanel();
            this.panel1 = new Sunny.UI.UIPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lblAxName = new Sunny.UI.UILabel();
            this.lblEnabled = new Sunny.UI.UILabel();
            this.lblPM = new Sunny.UI.UILabel();
            this.lblOrg = new Sunny.UI.UILabel();
            this.lblNM = new Sunny.UI.UILabel();
            this.lblHome = new Sunny.UI.UILabel();
            this.lblAlarm = new Sunny.UI.UILabel();
            this.lblEMG = new Sunny.UI.UILabel();
            this.CbB_MoveType = new Sunny.UI.UIComboBox();
            this.lblActPos = new Sunny.UI.UILabel();
            this.uiTitlePanel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel_PointInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PointInfo)).BeginInit();
            this.Panel_Axes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiTitlePanel1.Controls.Add(this.Panel2);
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.Size = new System.Drawing.Size(955, 788);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.StyleCustomMode = true;
            this.uiTitlePanel1.TabIndex = 0;
            this.uiTitlePanel1.Text = "点位";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.SteelBlue;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Panel_PointInfo);
            this.Panel2.Controls.Add(this.Panel_Axes);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel2.Location = new System.Drawing.Point(0, 35);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(955, 753);
            this.Panel2.Style = Sunny.UI.UIStyle.Custom;
            this.Panel2.TabIndex = 0;
            this.Panel2.Text = null;
            this.Panel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_PointInfo
            // 
            this.Panel_PointInfo.AllowDrop = true;
            this.Panel_PointInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_PointInfo.AutoScroll = true;
            this.Panel_PointInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Panel_PointInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_PointInfo.Controls.Add(this.Btn_Debug);
            this.Panel_PointInfo.Controls.Add(this.Btn_AllAxisMove);
            this.Panel_PointInfo.Controls.Add(this.Btn_SingleAxisMove);
            this.Panel_PointInfo.Controls.Add(this.Btn_Stop);
            this.Panel_PointInfo.Controls.Add(this.Btn_Record);
            this.Panel_PointInfo.Controls.Add(this.Btn_Apply);
            this.Panel_PointInfo.Controls.Add(this.DGV_PointInfo);
            this.Panel_PointInfo.Location = new System.Drawing.Point(7, 58);
            this.Panel_PointInfo.Name = "Panel_PointInfo";
            this.Panel_PointInfo.Size = new System.Drawing.Size(941, 692);
            this.Panel_PointInfo.TabIndex = 105;
            // 
            // Btn_Debug
            // 
            this.Btn_Debug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Debug.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Debug.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Debug.Location = new System.Drawing.Point(783, 259);
            this.Btn_Debug.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Debug.Name = "Btn_Debug";
            this.Btn_Debug.Size = new System.Drawing.Size(132, 45);
            this.Btn_Debug.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Debug.StyleCustomMode = true;
            this.Btn_Debug.Symbol = 61819;
            this.Btn_Debug.SymbolSize = 32;
            this.Btn_Debug.TabIndex = 106;
            this.Btn_Debug.Text = "工站调试";
            this.Btn_Debug.Click += new System.EventHandler(this.Btn_Debug_Click);
            // 
            // Btn_AllAxisMove
            // 
            this.Btn_AllAxisMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_AllAxisMove.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_AllAxisMove.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_AllAxisMove.Location = new System.Drawing.Point(783, 157);
            this.Btn_AllAxisMove.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_AllAxisMove.Name = "Btn_AllAxisMove";
            this.Btn_AllAxisMove.Size = new System.Drawing.Size(132, 45);
            this.Btn_AllAxisMove.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_AllAxisMove.StyleCustomMode = true;
            this.Btn_AllAxisMove.Symbol = 57418;
            this.Btn_AllAxisMove.SymbolSize = 32;
            this.Btn_AllAxisMove.TabIndex = 103;
            this.Btn_AllAxisMove.Text = "多轴联动";
            this.Btn_AllAxisMove.Click += new System.EventHandler(this.Btn_AllAxisMove_Click);
            // 
            // Btn_SingleAxisMove
            // 
            this.Btn_SingleAxisMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_SingleAxisMove.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_SingleAxisMove.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_SingleAxisMove.Location = new System.Drawing.Point(783, 106);
            this.Btn_SingleAxisMove.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_SingleAxisMove.Name = "Btn_SingleAxisMove";
            this.Btn_SingleAxisMove.Size = new System.Drawing.Size(132, 45);
            this.Btn_SingleAxisMove.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_SingleAxisMove.StyleCustomMode = true;
            this.Btn_SingleAxisMove.Symbol = 57414;
            this.Btn_SingleAxisMove.SymbolSize = 32;
            this.Btn_SingleAxisMove.TabIndex = 99;
            this.Btn_SingleAxisMove.Text = "单轴点动";
            this.Btn_SingleAxisMove.Click += new System.EventHandler(this.Btn_SingleAxisMove_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Stop.FillColor = System.Drawing.Color.Brown;
            this.Btn_Stop.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.Btn_Stop.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.Btn_Stop.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.Btn_Stop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Stop.Location = new System.Drawing.Point(783, 208);
            this.Btn_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Btn_Stop.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.Btn_Stop.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.Btn_Stop.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.Btn_Stop.Size = new System.Drawing.Size(132, 45);
            this.Btn_Stop.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Stop.StyleCustomMode = true;
            this.Btn_Stop.Symbol = 61517;
            this.Btn_Stop.SymbolSize = 32;
            this.Btn_Stop.TabIndex = 100;
            this.Btn_Stop.Text = "停止";
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Record
            // 
            this.Btn_Record.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Record.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Record.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Record.Location = new System.Drawing.Point(783, 55);
            this.Btn_Record.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Record.Name = "Btn_Record";
            this.Btn_Record.Size = new System.Drawing.Size(132, 45);
            this.Btn_Record.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Record.StyleCustomMode = true;
            this.Btn_Record.Symbol = 61713;
            this.Btn_Record.SymbolSize = 32;
            this.Btn_Record.TabIndex = 101;
            this.Btn_Record.Text = "记录点位";
            this.Btn_Record.Click += new System.EventHandler(this.Btn_Record_Click);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Apply.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Apply.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Apply.Location = new System.Drawing.Point(783, 4);
            this.Btn_Apply.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(132, 45);
            this.Btn_Apply.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Apply.StyleCustomMode = true;
            this.Btn_Apply.Symbol = 82;
            this.Btn_Apply.SymbolSize = 32;
            this.Btn_Apply.TabIndex = 102;
            this.Btn_Apply.Text = "应用点位";
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // DGV_PointInfo
            // 
            this.DGV_PointInfo.AllowUserToAddRows = false;
            this.DGV_PointInfo.AllowUserToDeleteRows = false;
            this.DGV_PointInfo.AllowUserToResizeColumns = false;
            this.DGV_PointInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DGV_PointInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_PointInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_PointInfo.BackgroundColor = System.Drawing.Color.White;
            this.DGV_PointInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PointInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_PointInfo.ColumnHeadersHeight = 32;
            this.DGV_PointInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_PointInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_PointInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_PointInfo.EnableHeadersVisualStyles = false;
            this.DGV_PointInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.DGV_PointInfo.GridColor = System.Drawing.Color.LightSkyBlue;
            this.DGV_PointInfo.Location = new System.Drawing.Point(4, 4);
            this.DGV_PointInfo.Name = "DGV_PointInfo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PointInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_PointInfo.RowHeadersVisible = false;
            this.DGV_PointInfo.RowHeadersWidth = 51;
            this.DGV_PointInfo.RowHeight = 29;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.DGV_PointInfo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_PointInfo.RowTemplate.Height = 29;
            this.DGV_PointInfo.SelectedIndex = -1;
            this.DGV_PointInfo.ShowGridLine = true;
            this.DGV_PointInfo.Size = new System.Drawing.Size(764, 683);
            this.DGV_PointInfo.Style = Sunny.UI.UIStyle.Custom;
            this.DGV_PointInfo.StyleCustomMode = true;
            this.DGV_PointInfo.TabIndex = 98;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "点位名称";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 120;
            // 
            // Panel_Axes
            // 
            this.Panel_Axes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Axes.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_Axes.Controls.Add(this.panel1);
            this.Panel_Axes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_Axes.Location = new System.Drawing.Point(7, 5);
            this.Panel_Axes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel_Axes.MinimumSize = new System.Drawing.Size(1, 1);
            this.Panel_Axes.Name = "Panel_Axes";
            this.Panel_Axes.Padding = new System.Windows.Forms.Padding(2);
            this.Panel_Axes.Size = new System.Drawing.Size(941, 45);
            this.Panel_Axes.Style = Sunny.UI.UIStyle.Custom;
            this.Panel_Axes.TabIndex = 104;
            this.Panel_Axes.Text = "uiFlowLayoutPanel2";
            this.Panel_Axes.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.lblAxName);
            this.panel1.Controls.Add(this.lblEnabled);
            this.panel1.Controls.Add(this.lblPM);
            this.panel1.Controls.Add(this.lblOrg);
            this.panel1.Controls.Add(this.lblNM);
            this.panel1.Controls.Add(this.lblHome);
            this.panel1.Controls.Add(this.lblAlarm);
            this.panel1.Controls.Add(this.lblEMG);
            this.panel1.Controls.Add(this.CbB_MoveType);
            this.panel1.Controls.Add(this.lblActPos);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.RectColor = System.Drawing.Color.Transparent;
            this.panel1.Size = new System.Drawing.Size(913, 39);
            this.panel1.Style = Sunny.UI.UIStyle.Custom;
            this.panel1.StyleCustomMode = true;
            this.panel1.TabIndex = 100;
            this.panel1.Text = null;
            this.panel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(266, 9);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(74, 21);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.TabIndex = 103;
            this.uiLabel1.Text = "命令位置";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAxName
            // 
            this.lblAxName.AutoSize = true;
            this.lblAxName.BackColor = System.Drawing.Color.Transparent;
            this.lblAxName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblAxName.Location = new System.Drawing.Point(6, 9);
            this.lblAxName.Name = "lblAxName";
            this.lblAxName.Size = new System.Drawing.Size(42, 21);
            this.lblAxName.Style = Sunny.UI.UIStyle.Custom;
            this.lblAxName.TabIndex = 93;
            this.lblAxName.Text = "轴名";
            this.lblAxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoSize = true;
            this.lblEnabled.BackColor = System.Drawing.Color.Transparent;
            this.lblEnabled.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblEnabled.Location = new System.Drawing.Point(114, 9);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(58, 21);
            this.lblEnabled.Style = Sunny.UI.UIStyle.Custom;
            this.lblEnabled.StyleCustomMode = true;
            this.lblEnabled.TabIndex = 94;
            this.lblEnabled.Text = "轴使能";
            this.lblEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPM
            // 
            this.lblPM.AutoSize = true;
            this.lblPM.BackColor = System.Drawing.Color.Transparent;
            this.lblPM.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblPM.Location = new System.Drawing.Point(500, 9);
            this.lblPM.Name = "lblPM";
            this.lblPM.Size = new System.Drawing.Size(42, 21);
            this.lblPM.Style = Sunny.UI.UIStyle.Custom;
            this.lblPM.StyleCustomMode = true;
            this.lblPM.TabIndex = 98;
            this.lblPM.Text = "正限";
            this.lblPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.BackColor = System.Drawing.Color.Transparent;
            this.lblOrg.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblOrg.Location = new System.Drawing.Point(553, 9);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(42, 21);
            this.lblOrg.Style = Sunny.UI.UIStyle.Custom;
            this.lblOrg.StyleCustomMode = true;
            this.lblOrg.TabIndex = 97;
            this.lblOrg.Text = "原点";
            this.lblOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNM
            // 
            this.lblNM.AutoSize = true;
            this.lblNM.BackColor = System.Drawing.Color.Transparent;
            this.lblNM.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblNM.Location = new System.Drawing.Point(606, 9);
            this.lblNM.Name = "lblNM";
            this.lblNM.Size = new System.Drawing.Size(42, 21);
            this.lblNM.Style = Sunny.UI.UIStyle.Custom;
            this.lblNM.StyleCustomMode = true;
            this.lblNM.TabIndex = 101;
            this.lblNM.Text = "负限";
            this.lblNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.BackColor = System.Drawing.Color.Transparent;
            this.lblHome.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblHome.Location = new System.Drawing.Point(195, 9);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(58, 21);
            this.lblHome.Style = Sunny.UI.UIStyle.Custom;
            this.lblHome.StyleCustomMode = true;
            this.lblHome.TabIndex = 95;
            this.lblHome.Text = "轴回原";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.BackColor = System.Drawing.Color.Transparent;
            this.lblAlarm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblAlarm.Location = new System.Drawing.Point(447, 9);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(42, 21);
            this.lblAlarm.Style = Sunny.UI.UIStyle.Custom;
            this.lblAlarm.StyleCustomMode = true;
            this.lblAlarm.TabIndex = 99;
            this.lblAlarm.Text = "报警";
            this.lblAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEMG
            // 
            this.lblEMG.AutoSize = true;
            this.lblEMG.BackColor = System.Drawing.Color.Transparent;
            this.lblEMG.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblEMG.Location = new System.Drawing.Point(659, 9);
            this.lblEMG.Name = "lblEMG";
            this.lblEMG.Size = new System.Drawing.Size(42, 21);
            this.lblEMG.Style = Sunny.UI.UIStyle.Custom;
            this.lblEMG.StyleCustomMode = true;
            this.lblEMG.TabIndex = 100;
            this.lblEMG.Text = "急停";
            this.lblEMG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_MoveType
            // 
            this.CbB_MoveType.DataSource = null;
            this.CbB_MoveType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_MoveType.FillColor = System.Drawing.Color.White;
            this.CbB_MoveType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_MoveType.Items.AddRange(new object[] {
            "Jog",
            "0.01",
            "0.05",
            "0.1",
            "1",
            "5",
            "10",
            "50",
            "100",
            "200"});
            this.CbB_MoveType.Location = new System.Drawing.Point(724, 5);
            this.CbB_MoveType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_MoveType.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_MoveType.Name = "CbB_MoveType";
            this.CbB_MoveType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_MoveType.Size = new System.Drawing.Size(120, 29);
            this.CbB_MoveType.Style = Sunny.UI.UIStyle.Custom;
            this.CbB_MoveType.TabIndex = 102;
            this.CbB_MoveType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_MoveType.SelectedIndexChanged += new System.EventHandler(this.CbB_MoveType_SelectedIndexChanged);
            // 
            // lblActPos
            // 
            this.lblActPos.AutoSize = true;
            this.lblActPos.BackColor = System.Drawing.Color.Transparent;
            this.lblActPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblActPos.Location = new System.Drawing.Point(355, 9);
            this.lblActPos.Name = "lblActPos";
            this.lblActPos.Size = new System.Drawing.Size(74, 21);
            this.lblActPos.Style = Sunny.UI.UIStyle.Custom;
            this.lblActPos.StyleCustomMode = true;
            this.lblActPos.TabIndex = 96;
            this.lblActPos.Text = "实际位置";
            this.lblActPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1300, 788);
            this.Controls.Add(this.uiTitlePanel1);
            this.Name = "StationView";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel_PointInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PointInfo)).EndInit();
            this.Panel_Axes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UIPanel Panel2;
        private Sunny.UI.UIFlowLayoutPanel Panel_Axes;
        private Sunny.UI.UIPanel panel1;
        private Sunny.UI.UILabel lblAxName;
        private Sunny.UI.UILabel lblEnabled;
        private Sunny.UI.UILabel lblPM;
        private Sunny.UI.UILabel lblOrg;
        private Sunny.UI.UILabel lblNM;
        private Sunny.UI.UILabel lblHome;
        private Sunny.UI.UILabel lblAlarm;
        private Sunny.UI.UILabel lblEMG;
        private Sunny.UI.UIComboBox CbB_MoveType;
        private Sunny.UI.UILabel lblActPos;
        private System.Windows.Forms.Panel Panel_PointInfo;
        private Sunny.UI.UISymbolButton Btn_Debug;
        private Sunny.UI.UISymbolButton Btn_AllAxisMove;
        private Sunny.UI.UISymbolButton Btn_SingleAxisMove;
        private Sunny.UI.UISymbolButton Btn_Stop;
        private Sunny.UI.UISymbolButton Btn_Record;
        private Sunny.UI.UISymbolButton Btn_Apply;
        private Sunny.UI.UIDataGridView DGV_PointInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Sunny.UI.UILabel uiLabel1;
    }
}

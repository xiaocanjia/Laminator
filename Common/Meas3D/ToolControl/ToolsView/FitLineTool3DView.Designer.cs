namespace Meas3D.Tool
{
    partial class FitLineTool3DView
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
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.TB_Name = new Sunny.UI.UITextBox();
            this.TB_Max_Luminace = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.TB_Min_Luminace = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.TB_Max_Height = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TB_Min_Height = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.CB_IsRising = new Sunny.UI.UICheckBox();
            this.Button_Add_ROI = new Sunny.UI.UIButton();
            this.CB_Disp_Loc = new Sunny.UI.UICheckBox();
            this.Button_Remove_ROI = new Sunny.UI.UIButton();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.CbB_Direction = new Sunny.UI.UIComboBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.Button_Confirm = new Sunny.UI.UIButton();
            this.TB_Hot_Pixcel_Filter = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.ResultsContainer = new MeasResult.ResultsContainer();
            this.SuspendLayout();
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(19, 20);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(78, 23);
            this.uiLabel9.TabIndex = 189;
            this.uiLabel9.Text = "名称";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(116, 17);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Name.Maximum = 2147483647D;
            this.TB_Name.Minimum = -2147483648D;
            this.TB_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Name.Size = new System.Drawing.Size(241, 29);
            this.TB_Name.TabIndex = 182;
            this.TB_Name.Text = "0";
            this.TB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Max_Luminace
            // 
            this.TB_Max_Luminace.ButtonSymbol = 61761;
            this.TB_Max_Luminace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Max_Luminace.DoubleValue = 1000D;
            this.TB_Max_Luminace.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Max_Luminace.IntValue = 1000;
            this.TB_Max_Luminace.Location = new System.Drawing.Point(253, 95);
            this.TB_Max_Luminace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Luminace.Maximum = 2147483647D;
            this.TB_Max_Luminace.Minimum = -2147483648D;
            this.TB_Max_Luminace.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Luminace.Name = "TB_Max_Luminace";
            this.TB_Max_Luminace.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Luminace.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Luminace.TabIndex = 187;
            this.TB_Max_Luminace.Text = "1000";
            this.TB_Max_Luminace.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Luminace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Luminace.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(227, 98);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(19, 23);
            this.uiLabel3.TabIndex = 188;
            this.uiLabel3.Text = "-";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Min_Luminace
            // 
            this.TB_Min_Luminace.ButtonSymbol = 61761;
            this.TB_Min_Luminace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Luminace.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Luminace.Location = new System.Drawing.Point(116, 95);
            this.TB_Min_Luminace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Luminace.Maximum = 2147483647D;
            this.TB_Min_Luminace.Minimum = -2147483648D;
            this.TB_Min_Luminace.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Luminace.Name = "TB_Min_Luminace";
            this.TB_Min_Luminace.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Luminace.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Luminace.TabIndex = 186;
            this.TB_Min_Luminace.Text = "0";
            this.TB_Min_Luminace.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Luminace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Luminace.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(19, 98);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(78, 23);
            this.uiLabel4.TabIndex = 185;
            this.uiLabel4.Text = "亮度范围";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Max_Height
            // 
            this.TB_Max_Height.ButtonSymbol = 61761;
            this.TB_Max_Height.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Max_Height.DoubleValue = 1000D;
            this.TB_Max_Height.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Max_Height.IntValue = 1000;
            this.TB_Max_Height.Location = new System.Drawing.Point(253, 56);
            this.TB_Max_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Height.Maximum = 2147483647D;
            this.TB_Max_Height.Minimum = -2147483648D;
            this.TB_Max_Height.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Height.Name = "TB_Max_Height";
            this.TB_Max_Height.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Height.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Height.TabIndex = 184;
            this.TB_Max_Height.Text = "1000";
            this.TB_Max_Height.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Height.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(227, 59);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(19, 23);
            this.uiLabel2.TabIndex = 183;
            this.uiLabel2.Text = "-";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Min_Height
            // 
            this.TB_Min_Height.ButtonSymbol = 61761;
            this.TB_Min_Height.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Height.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Height.Location = new System.Drawing.Point(116, 56);
            this.TB_Min_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Height.Maximum = 2147483647D;
            this.TB_Min_Height.Minimum = -2147483648D;
            this.TB_Min_Height.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Height.Name = "TB_Min_Height";
            this.TB_Min_Height.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Height.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Height.TabIndex = 181;
            this.TB_Min_Height.Text = "0";
            this.TB_Min_Height.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Height.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(19, 59);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 180;
            this.uiLabel1.Text = "高度范围";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_IsRising
            // 
            this.CB_IsRising.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_IsRising.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CB_IsRising.Location = new System.Drawing.Point(148, 260);
            this.CB_IsRising.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_IsRising.Name = "CB_IsRising";
            this.CB_IsRising.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_IsRising.Size = new System.Drawing.Size(89, 29);
            this.CB_IsRising.TabIndex = 191;
            this.CB_IsRising.Text = "上升沿";
            // 
            // Button_Add_ROI
            // 
            this.Button_Add_ROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Add_ROI.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Add_ROI.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Add_ROI.Location = new System.Drawing.Point(117, 220);
            this.Button_Add_ROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Add_ROI.Name = "Button_Add_ROI";
            this.Button_Add_ROI.Size = new System.Drawing.Size(89, 29);
            this.Button_Add_ROI.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Add_ROI.TabIndex = 196;
            this.Button_Add_ROI.Text = "添加";
            this.Button_Add_ROI.Click += new System.EventHandler(this.Button_Add_ROI_Click);
            // 
            // CB_Disp_Loc
            // 
            this.CB_Disp_Loc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_Disp_Loc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CB_Disp_Loc.Location = new System.Drawing.Point(20, 260);
            this.CB_Disp_Loc.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_Disp_Loc.Name = "CB_Disp_Loc";
            this.CB_Disp_Loc.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_Disp_Loc.Size = new System.Drawing.Size(114, 29);
            this.CB_Disp_Loc.TabIndex = 190;
            this.CB_Disp_Loc.Text = "显示边沿点";
            this.CB_Disp_Loc.Click += new System.EventHandler(this.CB_Disp_Loc_CheckedChanged);
            // 
            // Button_Remove_ROI
            // 
            this.Button_Remove_ROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Remove_ROI.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Remove_ROI.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Remove_ROI.Location = new System.Drawing.Point(221, 220);
            this.Button_Remove_ROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Remove_ROI.Name = "Button_Remove_ROI";
            this.Button_Remove_ROI.Size = new System.Drawing.Size(89, 29);
            this.Button_Remove_ROI.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Remove_ROI.TabIndex = 195;
            this.Button_Remove_ROI.Text = "删除";
            this.Button_Remove_ROI.Click += new System.EventHandler(this.Button_Remove_ROI_Click);
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel14.Location = new System.Drawing.Point(20, 223);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(78, 23);
            this.uiLabel14.TabIndex = 194;
            this.uiLabel14.Text = "ROI";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Direction
            // 
            this.CbB_Direction.DataSource = null;
            this.CbB_Direction.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Direction.FillColor = System.Drawing.Color.White;
            this.CbB_Direction.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Direction.Items.AddRange(new object[] {
            "从左往右",
            "从右往左",
            "从上往下",
            "从下往上"});
            this.CbB_Direction.Location = new System.Drawing.Point(117, 134);
            this.CbB_Direction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Direction.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Direction.Name = "CbB_Direction";
            this.CbB_Direction.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Direction.Size = new System.Drawing.Size(240, 29);
            this.CbB_Direction.TabIndex = 193;
            this.CbB_Direction.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Direction.SelectedIndexChanged += new System.EventHandler(this.CbB_Direction_SelectedIndexChanged);
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel13.Location = new System.Drawing.Point(20, 137);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(78, 23);
            this.uiLabel13.TabIndex = 192;
            this.uiLabel13.Text = "方向";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_Confirm
            // 
            this.Button_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Confirm.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Confirm.Location = new System.Drawing.Point(137, 602);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 197;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // TB_Hot_Pixcel_Filter
            // 
            this.TB_Hot_Pixcel_Filter.ButtonSymbol = 61761;
            this.TB_Hot_Pixcel_Filter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Hot_Pixcel_Filter.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Hot_Pixcel_Filter.Location = new System.Drawing.Point(117, 173);
            this.TB_Hot_Pixcel_Filter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Hot_Pixcel_Filter.Maximum = 2147483647D;
            this.TB_Hot_Pixcel_Filter.Minimum = -2147483648D;
            this.TB_Hot_Pixcel_Filter.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Hot_Pixcel_Filter.Name = "TB_Hot_Pixcel_Filter";
            this.TB_Hot_Pixcel_Filter.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Hot_Pixcel_Filter.Size = new System.Drawing.Size(240, 29);
            this.TB_Hot_Pixcel_Filter.TabIndex = 199;
            this.TB_Hot_Pixcel_Filter.Text = "0";
            this.TB_Hot_Pixcel_Filter.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Hot_Pixcel_Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Hot_Pixcel_Filter.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(20, 176);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(78, 23);
            this.uiLabel5.TabIndex = 198;
            this.uiLabel5.Text = "噪点过滤";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ResultsContainer
            // 
            this.ResultsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsContainer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsContainer.Location = new System.Drawing.Point(3, 315);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(379, 263);
            this.ResultsContainer.TabIndex = 201;
            // 
            // FitLineToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.TB_Hot_Pixcel_Filter);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.CB_IsRising);
            this.Controls.Add(this.Button_Add_ROI);
            this.Controls.Add(this.CB_Disp_Loc);
            this.Controls.Add(this.Button_Remove_ROI);
            this.Controls.Add(this.uiLabel14);
            this.Controls.Add(this.CbB_Direction);
            this.Controls.Add(this.uiLabel13);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.TB_Max_Luminace);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.TB_Min_Luminace);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.TB_Max_Height);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.TB_Min_Height);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FitLineToolView";
            this.Size = new System.Drawing.Size(385, 650);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox TB_Name;
        private Sunny.UI.UITextBox TB_Max_Luminace;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TB_Min_Luminace;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox TB_Max_Height;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox TB_Min_Height;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UICheckBox CB_IsRising;
        private Sunny.UI.UIButton Button_Add_ROI;
        private Sunny.UI.UICheckBox CB_Disp_Loc;
        private Sunny.UI.UIButton Button_Remove_ROI;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UIComboBox CbB_Direction;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UIButton Button_Confirm;
        private Sunny.UI.UITextBox TB_Hot_Pixcel_Filter;
        private Sunny.UI.UILabel uiLabel5;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

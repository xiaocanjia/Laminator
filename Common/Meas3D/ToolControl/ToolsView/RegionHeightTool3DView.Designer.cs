namespace Meas3D.Tool
{
    partial class RegionHeightTool3DView
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
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CbB_Planes = new Sunny.UI.UIComboBox();
            this.CbB_Height_Type = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.Button_Confirm = new Sunny.UI.UIButton();
            this.CbB_ROI_Type = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_Max_Luminace = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.TB_Min_Luminace = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.ResultsContainer = new MeasResult.ResultsContainer();
            this.SuspendLayout();
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(20, 20);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(78, 23);
            this.uiLabel9.TabIndex = 191;
            this.uiLabel9.Text = "名称";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(122, 20);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Name.Maximum = 2147483647D;
            this.TB_Name.Minimum = -2147483648D;
            this.TB_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Name.Size = new System.Drawing.Size(241, 29);
            this.TB_Name.TabIndex = 190;
            this.TB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(20, 74);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(78, 23);
            this.uiLabel2.TabIndex = 193;
            this.uiLabel2.Text = "基准面";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Planes
            // 
            this.CbB_Planes.DataSource = null;
            this.CbB_Planes.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Planes.FillColor = System.Drawing.Color.White;
            this.CbB_Planes.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Planes.Location = new System.Drawing.Point(122, 74);
            this.CbB_Planes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Planes.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Planes.Name = "CbB_Planes";
            this.CbB_Planes.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Planes.Size = new System.Drawing.Size(240, 29);
            this.CbB_Planes.TabIndex = 194;
            this.CbB_Planes.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Height_Type
            // 
            this.CbB_Height_Type.DataSource = null;
            this.CbB_Height_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Height_Type.FillColor = System.Drawing.Color.White;
            this.CbB_Height_Type.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Height_Type.Items.AddRange(new object[] {
            "最大值",
            "最小值",
            "平均值",
            "最大直接距离",
            "最小直接距离",
            "平均直接距离"});
            this.CbB_Height_Type.Location = new System.Drawing.Point(122, 171);
            this.CbB_Height_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Height_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Height_Type.Name = "CbB_Height_Type";
            this.CbB_Height_Type.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Height_Type.Size = new System.Drawing.Size(240, 29);
            this.CbB_Height_Type.TabIndex = 198;
            this.CbB_Height_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(20, 174);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(78, 23);
            this.uiLabel3.TabIndex = 197;
            this.uiLabel3.Text = "高度类型";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_Confirm
            // 
            this.Button_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Confirm.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Confirm.Location = new System.Drawing.Point(126, 601);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 198;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // CbB_ROI_Type
            // 
            this.CbB_ROI_Type.DataSource = null;
            this.CbB_ROI_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_ROI_Type.FillColor = System.Drawing.Color.White;
            this.CbB_ROI_Type.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_ROI_Type.Items.AddRange(new object[] {
            "矩形",
            "圆形",
            "线段"});
            this.CbB_ROI_Type.Location = new System.Drawing.Point(122, 123);
            this.CbB_ROI_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_ROI_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_ROI_Type.Name = "CbB_ROI_Type";
            this.CbB_ROI_Type.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_ROI_Type.Size = new System.Drawing.Size(240, 29);
            this.CbB_ROI_Type.TabIndex = 200;
            this.CbB_ROI_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(20, 123);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 199;
            this.uiLabel1.Text = "ROI类型";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Max_Luminace
            // 
            this.TB_Max_Luminace.ButtonSymbol = 61761;
            this.TB_Max_Luminace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Max_Luminace.DoubleValue = 2000D;
            this.TB_Max_Luminace.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Max_Luminace.IntValue = 2000;
            this.TB_Max_Luminace.Location = new System.Drawing.Point(259, 221);
            this.TB_Max_Luminace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Luminace.Maximum = 2147483647D;
            this.TB_Max_Luminace.Minimum = -2147483648D;
            this.TB_Max_Luminace.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Luminace.Name = "TB_Max_Luminace";
            this.TB_Max_Luminace.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Luminace.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Luminace.TabIndex = 203;
            this.TB_Max_Luminace.Text = "2000";
            this.TB_Max_Luminace.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Luminace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Luminace.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(233, 224);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(19, 23);
            this.uiLabel4.TabIndex = 204;
            this.uiLabel4.Text = "-";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Min_Luminace
            // 
            this.TB_Min_Luminace.ButtonSymbol = 61761;
            this.TB_Min_Luminace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Luminace.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Luminace.Location = new System.Drawing.Point(122, 221);
            this.TB_Min_Luminace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Luminace.Maximum = 2147483647D;
            this.TB_Min_Luminace.Minimum = -2147483648D;
            this.TB_Min_Luminace.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Luminace.Name = "TB_Min_Luminace";
            this.TB_Min_Luminace.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Luminace.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Luminace.TabIndex = 202;
            this.TB_Min_Luminace.Text = "0";
            this.TB_Min_Luminace.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Luminace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Luminace.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(20, 224);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(78, 23);
            this.uiLabel5.TabIndex = 201;
            this.uiLabel5.Text = "亮度范围";
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
            this.ResultsContainer.TabIndex = 211;
            // 
            // RegionHeightToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.TB_Max_Luminace);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.TB_Min_Luminace);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.CbB_ROI_Type);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.CbB_Height_Type);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.CbB_Planes);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.TB_Name);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RegionHeightToolView";
            this.Size = new System.Drawing.Size(385, 650);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox TB_Name;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox CbB_Planes;
        private Sunny.UI.UIComboBox CbB_Height_Type;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton Button_Confirm;
        private Sunny.UI.UIComboBox CbB_ROI_Type;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_Max_Luminace;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox TB_Min_Luminace;
        private Sunny.UI.UILabel uiLabel5;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

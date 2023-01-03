namespace Meas2D
{
    partial class ReadCodeToolView
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
            this.Button_Confirm = new Sunny.UI.UIButton();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.TB_Name = new Sunny.UI.UITextBox();
            this.CbB_Code_Type = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.ResultsContainer = new MeasResult.ResultsContainer();
            this.SuspendLayout();
            // 
            // Button_Confirm
            // 
            this.Button_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Confirm.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Confirm.Location = new System.Drawing.Point(143, 636);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 211;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(29, 20);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(78, 23);
            this.uiLabel9.TabIndex = 206;
            this.uiLabel9.Text = "名称";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(126, 17);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Name.Maximum = 2147483647D;
            this.TB_Name.Minimum = -2147483648D;
            this.TB_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Name.Size = new System.Drawing.Size(241, 29);
            this.TB_Name.TabIndex = 190;
            this.TB_Name.Text = "0";
            this.TB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Code_Type
            // 
            this.CbB_Code_Type.DataSource = null;
            this.CbB_Code_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Code_Type.FillColor = System.Drawing.Color.White;
            this.CbB_Code_Type.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Code_Type.Items.AddRange(new object[] {
            "Data Matrix ECC 200",
            "QR Code",
            "Micro QR Code",
            "PDF417",
            "Aztec Code"});
            this.CbB_Code_Type.Location = new System.Drawing.Point(126, 71);
            this.CbB_Code_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Code_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Code_Type.Name = "CbB_Code_Type";
            this.CbB_Code_Type.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Code_Type.Size = new System.Drawing.Size(241, 29);
            this.CbB_Code_Type.TabIndex = 213;
            this.CbB_Code_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Code_Type.SelectedIndexChanged += new System.EventHandler(this.CbB_Code_Type_SelectedIndexChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(25, 74);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(94, 23);
            this.uiLabel3.TabIndex = 212;
            this.uiLabel3.Text = "二维码类型";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ResultsContainer
            // 
            this.ResultsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsContainer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsContainer.Location = new System.Drawing.Point(3, 279);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(390, 263);
            this.ResultsContainer.TabIndex = 214;
            // 
            // ReadCodeToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.CbB_Code_Type);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.TB_Name);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ReadCodeToolView";
            this.Size = new System.Drawing.Size(400, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Button_Confirm;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox TB_Name;
        private Sunny.UI.UIComboBox CbB_Code_Type;
        private Sunny.UI.UILabel uiLabel3;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

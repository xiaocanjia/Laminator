namespace Meas2D.FixPos
{
    partial class LinesFixPos2DView
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
            this.CbB_Direction2 = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CB_IsRising2 = new Sunny.UI.UICheckBox();
            this.Button_Add_ROI2 = new Sunny.UI.UIButton();
            this.Button_Remove_ROI2 = new Sunny.UI.UIButton();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.TB_Max_Gray1 = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.TB_Max_Gray2 = new Sunny.UI.UITextBox();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.TB_Min_Gray2 = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.CbB_Direction1 = new Sunny.UI.UIComboBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.Button_Add_ROI1 = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.Button_Remove_ROI1 = new Sunny.UI.UIButton();
            this.TB_Min_Gray1 = new Sunny.UI.UITextBox();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.CB_IsRising1 = new Sunny.UI.UICheckBox();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbB_Direction2
            // 
            this.CbB_Direction2.DataSource = null;
            this.CbB_Direction2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Direction2.FillColor = System.Drawing.Color.White;
            this.CbB_Direction2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Direction2.Items.AddRange(new object[] {
            "从左往右",
            "从右往左"});
            this.CbB_Direction2.Location = new System.Drawing.Point(110, 76);
            this.CbB_Direction2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Direction2.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Direction2.Name = "CbB_Direction2";
            this.CbB_Direction2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Direction2.Size = new System.Drawing.Size(240, 29);
            this.CbB_Direction2.TabIndex = 195;
            this.CbB_Direction2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(13, 79);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(78, 23);
            this.uiLabel2.TabIndex = 194;
            this.uiLabel2.Text = "方向";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_IsRising2
            // 
            this.CB_IsRising2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_IsRising2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CB_IsRising2.Location = new System.Drawing.Point(16, 161);
            this.CB_IsRising2.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_IsRising2.Name = "CB_IsRising2";
            this.CB_IsRising2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_IsRising2.Size = new System.Drawing.Size(89, 29);
            this.CB_IsRising2.TabIndex = 148;
            this.CB_IsRising2.Text = "上升沿";
            // 
            // Button_Add_ROI2
            // 
            this.Button_Add_ROI2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Add_ROI2.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Add_ROI2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Add_ROI2.Location = new System.Drawing.Point(110, 120);
            this.Button_Add_ROI2.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Add_ROI2.Name = "Button_Add_ROI2";
            this.Button_Add_ROI2.Size = new System.Drawing.Size(89, 29);
            this.Button_Add_ROI2.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Add_ROI2.StyleCustomMode = true;
            this.Button_Add_ROI2.TabIndex = 157;
            this.Button_Add_ROI2.Text = "添加";
            this.Button_Add_ROI2.Click += new System.EventHandler(this.Button_Add_ROI2_Click);
            // 
            // Button_Remove_ROI2
            // 
            this.Button_Remove_ROI2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Remove_ROI2.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Remove_ROI2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Remove_ROI2.Location = new System.Drawing.Point(214, 120);
            this.Button_Remove_ROI2.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Remove_ROI2.Name = "Button_Remove_ROI2";
            this.Button_Remove_ROI2.Size = new System.Drawing.Size(89, 29);
            this.Button_Remove_ROI2.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Remove_ROI2.StyleCustomMode = true;
            this.Button_Remove_ROI2.TabIndex = 156;
            this.Button_Remove_ROI2.Text = "删除";
            this.Button_Remove_ROI2.Click += new System.EventHandler(this.Button_Remove_ROI2_Click);
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel14.Location = new System.Drawing.Point(13, 123);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(78, 23);
            this.uiLabel14.TabIndex = 155;
            this.uiLabel14.Text = "ROI";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Max_Gray1
            // 
            this.TB_Max_Gray1.ButtonSymbol = 61761;
            this.TB_Max_Gray1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Max_Gray1.DoubleValue = 255D;
            this.TB_Max_Gray1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Max_Gray1.IntValue = 255;
            this.TB_Max_Gray1.Location = new System.Drawing.Point(246, 37);
            this.TB_Max_Gray1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Gray1.Maximum = 2147483647D;
            this.TB_Max_Gray1.Minimum = -2147483648D;
            this.TB_Max_Gray1.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Gray1.Name = "TB_Max_Gray1";
            this.TB_Max_Gray1.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Gray1.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Gray1.TabIndex = 147;
            this.TB_Max_Gray1.Text = "255";
            this.TB_Max_Gray1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Gray1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Gray1.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(220, 40);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(19, 23);
            this.uiLabel5.TabIndex = 148;
            this.uiLabel5.Text = "-";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Max_Gray2
            // 
            this.TB_Max_Gray2.ButtonSymbol = 61761;
            this.TB_Max_Gray2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Max_Gray2.DoubleValue = 255D;
            this.TB_Max_Gray2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Max_Gray2.IntValue = 255;
            this.TB_Max_Gray2.Location = new System.Drawing.Point(246, 37);
            this.TB_Max_Gray2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Gray2.Maximum = 2147483647D;
            this.TB_Max_Gray2.Minimum = -2147483648D;
            this.TB_Max_Gray2.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Gray2.Name = "TB_Max_Gray2";
            this.TB_Max_Gray2.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Gray2.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Gray2.TabIndex = 147;
            this.TB_Max_Gray2.Text = "255";
            this.TB_Max_Gray2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Gray2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Gray2.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel11.Location = new System.Drawing.Point(220, 40);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(19, 23);
            this.uiLabel11.TabIndex = 148;
            this.uiLabel11.Text = "-";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Min_Gray2
            // 
            this.TB_Min_Gray2.ButtonSymbol = 61761;
            this.TB_Min_Gray2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Gray2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Gray2.Location = new System.Drawing.Point(109, 37);
            this.TB_Min_Gray2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Gray2.Maximum = 2147483647D;
            this.TB_Min_Gray2.Minimum = -2147483648D;
            this.TB_Min_Gray2.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Gray2.Name = "TB_Min_Gray2";
            this.TB_Min_Gray2.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Gray2.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Gray2.TabIndex = 146;
            this.TB_Min_Gray2.Text = "0";
            this.TB_Min_Gray2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Gray2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Gray2.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(12, 40);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(78, 23);
            this.uiLabel6.TabIndex = 145;
            this.uiLabel6.Text = "灰度范围";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel12.Location = new System.Drawing.Point(12, 40);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(78, 23);
            this.uiLabel12.TabIndex = 145;
            this.uiLabel12.Text = "灰度范围";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Direction1
            // 
            this.CbB_Direction1.DataSource = null;
            this.CbB_Direction1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Direction1.FillColor = System.Drawing.Color.White;
            this.CbB_Direction1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Direction1.Items.AddRange(new object[] {
            "从上往下",
            "从下往上"});
            this.CbB_Direction1.Location = new System.Drawing.Point(109, 76);
            this.CbB_Direction1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Direction1.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Direction1.Name = "CbB_Direction1";
            this.CbB_Direction1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Direction1.Size = new System.Drawing.Size(240, 29);
            this.CbB_Direction1.TabIndex = 195;
            this.CbB_Direction1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel13.Location = new System.Drawing.Point(12, 79);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(78, 23);
            this.uiLabel13.TabIndex = 194;
            this.uiLabel13.Text = "方向";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_Add_ROI1
            // 
            this.Button_Add_ROI1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Add_ROI1.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Add_ROI1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Add_ROI1.Location = new System.Drawing.Point(109, 123);
            this.Button_Add_ROI1.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Add_ROI1.Name = "Button_Add_ROI1";
            this.Button_Add_ROI1.Size = new System.Drawing.Size(89, 29);
            this.Button_Add_ROI1.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Add_ROI1.StyleCustomMode = true;
            this.Button_Add_ROI1.TabIndex = 157;
            this.Button_Add_ROI1.Text = "添加";
            this.Button_Add_ROI1.Click += new System.EventHandler(this.Button_Add_ROI1_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(12, 126);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 155;
            this.uiLabel1.Text = "ROI";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.CbB_Direction1);
            this.uiGroupBox1.Controls.Add(this.uiLabel13);
            this.uiGroupBox1.Controls.Add(this.Button_Add_ROI1);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.CB_IsRising1);
            this.uiGroupBox1.Controls.Add(this.Button_Remove_ROI1);
            this.uiGroupBox1.Controls.Add(this.TB_Max_Gray1);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.Controls.Add(this.TB_Min_Gray1);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 16);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(392, 197);
            this.uiGroupBox1.TabIndex = 160;
            this.uiGroupBox1.Text = "水平方向";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_Remove_ROI1
            // 
            this.Button_Remove_ROI1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Remove_ROI1.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Remove_ROI1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Remove_ROI1.Location = new System.Drawing.Point(213, 123);
            this.Button_Remove_ROI1.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Remove_ROI1.Name = "Button_Remove_ROI1";
            this.Button_Remove_ROI1.Size = new System.Drawing.Size(89, 29);
            this.Button_Remove_ROI1.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Remove_ROI1.StyleCustomMode = true;
            this.Button_Remove_ROI1.TabIndex = 156;
            this.Button_Remove_ROI1.Text = "删除";
            this.Button_Remove_ROI1.Click += new System.EventHandler(this.Button_Remove_ROI1_Click);
            // 
            // TB_Min_Gray1
            // 
            this.TB_Min_Gray1.ButtonSymbol = 61761;
            this.TB_Min_Gray1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Gray1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Gray1.Location = new System.Drawing.Point(109, 37);
            this.TB_Min_Gray1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Gray1.Maximum = 2147483647D;
            this.TB_Min_Gray1.Minimum = -2147483648D;
            this.TB_Min_Gray1.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Gray1.Name = "TB_Min_Gray1";
            this.TB_Min_Gray1.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Gray1.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Gray1.TabIndex = 146;
            this.TB_Min_Gray1.Text = "0";
            this.TB_Min_Gray1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Gray1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Gray1.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.CbB_Direction2);
            this.uiGroupBox2.Controls.Add(this.uiLabel2);
            this.uiGroupBox2.Controls.Add(this.CB_IsRising2);
            this.uiGroupBox2.Controls.Add(this.Button_Add_ROI2);
            this.uiGroupBox2.Controls.Add(this.Button_Remove_ROI2);
            this.uiGroupBox2.Controls.Add(this.uiLabel14);
            this.uiGroupBox2.Controls.Add(this.TB_Max_Gray2);
            this.uiGroupBox2.Controls.Add(this.uiLabel11);
            this.uiGroupBox2.Controls.Add(this.TB_Min_Gray2);
            this.uiGroupBox2.Controls.Add(this.uiLabel12);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 236);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(392, 197);
            this.uiGroupBox2.TabIndex = 159;
            this.uiGroupBox2.Text = "竖直方向";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_IsRising1
            // 
            this.CB_IsRising1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_IsRising1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CB_IsRising1.Location = new System.Drawing.Point(16, 163);
            this.CB_IsRising1.MinimumSize = new System.Drawing.Size(1, 1);
            this.CB_IsRising1.Name = "CB_IsRising1";
            this.CB_IsRising1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.CB_IsRising1.Size = new System.Drawing.Size(89, 29);
            this.CB_IsRising1.TabIndex = 148;
            this.CB_IsRising1.Text = "上升沿";
            // 
            // LinesFixPosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiGroupBox2);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LinesFixPosView";
            this.Size = new System.Drawing.Size(400, 700);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIComboBox CbB_Direction2;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UICheckBox CB_IsRising2;
        private Sunny.UI.UIButton Button_Add_ROI2;
        private Sunny.UI.UIButton Button_Remove_ROI2;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UITextBox TB_Max_Gray1;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox TB_Max_Gray2;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox TB_Min_Gray2;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIComboBox CbB_Direction1;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UIButton Button_Add_ROI1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton Button_Remove_ROI1;
        private Sunny.UI.UITextBox TB_Min_Gray1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UICheckBox CB_IsRising1;
    }
}

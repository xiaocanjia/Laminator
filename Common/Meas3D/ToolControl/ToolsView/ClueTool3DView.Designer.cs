namespace Meas3D.Tool
{
    partial class ClueTool3DView
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
            this.Lbl_Name = new Sunny.UI.UILabel();
            this.TB_Name = new Sunny.UI.UITextBox();
            this.TB_Max_Luminace = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.TB_Min_Luminace = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.TB_Max_Height = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TB_Min_Height = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_Line_Width = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.TB_Density = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.Btn_Add_Begin = new Sunny.UI.UIButton();
            this.Btn_Add_Finished = new Sunny.UI.UIButton();
            this.Btn_Delete_Points = new Sunny.UI.UIButton();
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
            this.Button_Confirm.Location = new System.Drawing.Point(135, 599);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 211;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Lbl_Name.Location = new System.Drawing.Point(21, 19);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(78, 23);
            this.Lbl_Name.TabIndex = 206;
            this.Lbl_Name.Text = "名称";
            this.Lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(118, 16);
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
            // TB_Max_Luminace
            // 
            this.TB_Max_Luminace.ButtonSymbol = 61761;
            this.TB_Max_Luminace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Max_Luminace.DoubleValue = 1000D;
            this.TB_Max_Luminace.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Max_Luminace.IntValue = 1000;
            this.TB_Max_Luminace.Location = new System.Drawing.Point(255, 94);
            this.TB_Max_Luminace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Luminace.Maximum = 2147483647D;
            this.TB_Max_Luminace.Minimum = -2147483648D;
            this.TB_Max_Luminace.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Luminace.Name = "TB_Max_Luminace";
            this.TB_Max_Luminace.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Luminace.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Luminace.TabIndex = 218;
            this.TB_Max_Luminace.Text = "1000";
            this.TB_Max_Luminace.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Luminace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Luminace.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(229, 97);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(19, 23);
            this.uiLabel3.TabIndex = 219;
            this.uiLabel3.Text = "-";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Min_Luminace
            // 
            this.TB_Min_Luminace.ButtonSymbol = 61761;
            this.TB_Min_Luminace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Luminace.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Luminace.Location = new System.Drawing.Point(118, 94);
            this.TB_Min_Luminace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Luminace.Maximum = 2147483647D;
            this.TB_Min_Luminace.Minimum = -2147483648D;
            this.TB_Min_Luminace.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Luminace.Name = "TB_Min_Luminace";
            this.TB_Min_Luminace.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Luminace.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Luminace.TabIndex = 217;
            this.TB_Min_Luminace.Text = "0";
            this.TB_Min_Luminace.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Luminace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Luminace.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(21, 97);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(78, 23);
            this.uiLabel4.TabIndex = 216;
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
            this.TB_Max_Height.Location = new System.Drawing.Point(255, 55);
            this.TB_Max_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Max_Height.Maximum = 2147483647D;
            this.TB_Max_Height.Minimum = -2147483648D;
            this.TB_Max_Height.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Max_Height.Name = "TB_Max_Height";
            this.TB_Max_Height.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Max_Height.Size = new System.Drawing.Size(104, 29);
            this.TB_Max_Height.TabIndex = 215;
            this.TB_Max_Height.Text = "1000";
            this.TB_Max_Height.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Max_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Max_Height.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(229, 58);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(19, 23);
            this.uiLabel2.TabIndex = 214;
            this.uiLabel2.Text = "-";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Min_Height
            // 
            this.TB_Min_Height.ButtonSymbol = 61761;
            this.TB_Min_Height.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Min_Height.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Min_Height.Location = new System.Drawing.Point(118, 55);
            this.TB_Min_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Min_Height.Maximum = 2147483647D;
            this.TB_Min_Height.Minimum = -2147483648D;
            this.TB_Min_Height.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Min_Height.Name = "TB_Min_Height";
            this.TB_Min_Height.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Min_Height.Size = new System.Drawing.Size(104, 29);
            this.TB_Min_Height.TabIndex = 213;
            this.TB_Min_Height.Text = "0";
            this.TB_Min_Height.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Min_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Min_Height.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(21, 58);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 212;
            this.uiLabel1.Text = "高度范围";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Line_Width
            // 
            this.TB_Line_Width.ButtonSymbol = 61761;
            this.TB_Line_Width.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Line_Width.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Line_Width.Location = new System.Drawing.Point(118, 133);
            this.TB_Line_Width.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Line_Width.Maximum = 2147483647D;
            this.TB_Line_Width.Minimum = -2147483648D;
            this.TB_Line_Width.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Line_Width.Name = "TB_Line_Width";
            this.TB_Line_Width.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Line_Width.Size = new System.Drawing.Size(241, 29);
            this.TB_Line_Width.TabIndex = 221;
            this.TB_Line_Width.Text = "0";
            this.TB_Line_Width.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Line_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Line_Width_KeyPress);
            this.TB_Line_Width.Leave += new System.EventHandler(this.TB_Line_Width_Leave);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(21, 136);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(78, 23);
            this.uiLabel5.TabIndex = 220;
            this.uiLabel5.Text = "线宽";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Density
            // 
            this.TB_Density.ButtonSymbol = 61761;
            this.TB_Density.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Density.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Density.Location = new System.Drawing.Point(118, 172);
            this.TB_Density.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Density.Maximum = 2147483647D;
            this.TB_Density.Minimum = -2147483648D;
            this.TB_Density.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Density.Name = "TB_Density";
            this.TB_Density.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Density.Size = new System.Drawing.Size(241, 29);
            this.TB_Density.TabIndex = 223;
            this.TB_Density.Text = "0";
            this.TB_Density.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Density.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Density_KeyPress);
            this.TB_Density.Leave += new System.EventHandler(this.TB_Density_Leave);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(21, 175);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(78, 23);
            this.uiLabel6.TabIndex = 222;
            this.uiLabel6.Text = "检测密度";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Add_Begin
            // 
            this.Btn_Add_Begin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Add_Begin.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Add_Begin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Add_Begin.Location = new System.Drawing.Point(25, 222);
            this.Btn_Add_Begin.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Add_Begin.Name = "Btn_Add_Begin";
            this.Btn_Add_Begin.Size = new System.Drawing.Size(89, 29);
            this.Btn_Add_Begin.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Add_Begin.TabIndex = 226;
            this.Btn_Add_Begin.Text = "开始添加";
            this.Btn_Add_Begin.Click += new System.EventHandler(this.Btn_Add_Begin_Click);
            // 
            // Btn_Add_Finished
            // 
            this.Btn_Add_Finished.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Add_Finished.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Add_Finished.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Add_Finished.Location = new System.Drawing.Point(146, 222);
            this.Btn_Add_Finished.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Add_Finished.Name = "Btn_Add_Finished";
            this.Btn_Add_Finished.Size = new System.Drawing.Size(89, 29);
            this.Btn_Add_Finished.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Add_Finished.TabIndex = 227;
            this.Btn_Add_Finished.Text = "添加完成";
            this.Btn_Add_Finished.Click += new System.EventHandler(this.Btn_Add_Finished_Click);
            // 
            // Btn_Delete_Points
            // 
            this.Btn_Delete_Points.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Delete_Points.FillColor = System.Drawing.Color.SteelBlue;
            this.Btn_Delete_Points.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Btn_Delete_Points.Location = new System.Drawing.Point(270, 222);
            this.Btn_Delete_Points.MinimumSize = new System.Drawing.Size(1, 1);
            this.Btn_Delete_Points.Name = "Btn_Delete_Points";
            this.Btn_Delete_Points.Size = new System.Drawing.Size(89, 29);
            this.Btn_Delete_Points.Style = Sunny.UI.UIStyle.Custom;
            this.Btn_Delete_Points.TabIndex = 228;
            this.Btn_Delete_Points.Text = "全部删除";
            this.Btn_Delete_Points.Click += new System.EventHandler(this.Btn_Delete_Points_Click);
            // 
            // ResultsContainer
            // 
            this.ResultsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsContainer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsContainer.Location = new System.Drawing.Point(3, 292);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(379, 263);
            this.ResultsContainer.TabIndex = 229;
            // 
            // ClueToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.Btn_Delete_Points);
            this.Controls.Add(this.Btn_Add_Finished);
            this.Controls.Add(this.Btn_Add_Begin);
            this.Controls.Add(this.TB_Density);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.TB_Line_Width);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.TB_Max_Luminace);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.TB_Min_Luminace);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.TB_Max_Height);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.TB_Min_Height);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.Lbl_Name);
            this.Controls.Add(this.TB_Name);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClueToolView";
            this.Size = new System.Drawing.Size(385, 650);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Button_Confirm;
        private Sunny.UI.UILabel Lbl_Name;
        private Sunny.UI.UITextBox TB_Name;
        private Sunny.UI.UITextBox TB_Max_Luminace;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TB_Min_Luminace;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox TB_Max_Height;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox TB_Min_Height;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_Line_Width;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox TB_Density;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton Btn_Add_Begin;
        private Sunny.UI.UIButton Btn_Add_Finished;
        private Sunny.UI.UIButton Btn_Delete_Points;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

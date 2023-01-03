namespace Meas3D.Tool
{
    partial class CTLDistTool3DView
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
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Name = new Sunny.UI.UITextBox();
            this.CbB_Circles_List = new Sunny.UI.UIComboBox();
            this.CbB_Lines_List = new Sunny.UI.UIComboBox();
            this.Button_Confirm = new Sunny.UI.UIButton();
            this.ResultsContainer = new MeasResult.ResultsContainer();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(23, 122);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 187;
            this.label6.Text = "直线";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 21);
            this.label1.TabIndex = 186;
            this.label1.Text = "圆";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 183;
            this.label4.Text = "名称";
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(99, 22);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Name.Maximum = 2147483647D;
            this.TB_Name.Minimum = -2147483648D;
            this.TB_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Name.Size = new System.Drawing.Size(260, 29);
            this.TB_Name.TabIndex = 192;
            this.TB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Circles_List
            // 
            this.CbB_Circles_List.DataSource = null;
            this.CbB_Circles_List.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Circles_List.FillColor = System.Drawing.Color.White;
            this.CbB_Circles_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Circles_List.Location = new System.Drawing.Point(99, 70);
            this.CbB_Circles_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Circles_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Circles_List.Name = "CbB_Circles_List";
            this.CbB_Circles_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Circles_List.Size = new System.Drawing.Size(260, 29);
            this.CbB_Circles_List.TabIndex = 196;
            this.CbB_Circles_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Circles_List.SelectedIndexChanged += new System.EventHandler(this.ComboBox_List_SelectedIndexChanged);
            // 
            // CbB_Lines_List
            // 
            this.CbB_Lines_List.DataSource = null;
            this.CbB_Lines_List.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Lines_List.FillColor = System.Drawing.Color.White;
            this.CbB_Lines_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Lines_List.Location = new System.Drawing.Point(99, 118);
            this.CbB_Lines_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Lines_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Lines_List.Name = "CbB_Lines_List";
            this.CbB_Lines_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Lines_List.Size = new System.Drawing.Size(260, 29);
            this.CbB_Lines_List.TabIndex = 196;
            this.CbB_Lines_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Lines_List.SelectedIndexChanged += new System.EventHandler(this.ComboBox_List_SelectedIndexChanged);
            // 
            // Button_Confirm
            // 
            this.Button_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Confirm.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Confirm.Location = new System.Drawing.Point(145, 601);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 200;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // ResultsContainer
            // 
            this.ResultsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsContainer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsContainer.Location = new System.Drawing.Point(3, 250);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(379, 263);
            this.ResultsContainer.TabIndex = 201;
            // 
            // CTLDistToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.CbB_Lines_List);
            this.Controls.Add(this.CbB_Circles_List);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CTLDistToolView";
            this.Size = new System.Drawing.Size(385, 650);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UITextBox TB_Name;
        private Sunny.UI.UIComboBox CbB_Circles_List;
        private Sunny.UI.UIComboBox CbB_Lines_List;
        private Sunny.UI.UIButton Button_Confirm;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

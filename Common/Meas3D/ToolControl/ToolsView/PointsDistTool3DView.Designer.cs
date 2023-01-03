namespace Meas3D.Tool
{
    partial class PointsDistTool3DView
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
            this.CbB_Points_List2 = new Sunny.UI.UIComboBox();
            this.CbB_Points_List1 = new Sunny.UI.UIComboBox();
            this.TB_Name = new Sunny.UI.UITextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.Button_Confirm.Location = new System.Drawing.Point(141, 587);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(85, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 209;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // CbB_Points_List2
            // 
            this.CbB_Points_List2.DataSource = null;
            this.CbB_Points_List2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Points_List2.FillColor = System.Drawing.Color.White;
            this.CbB_Points_List2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Points_List2.Location = new System.Drawing.Point(106, 105);
            this.CbB_Points_List2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Points_List2.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Points_List2.Name = "CbB_Points_List2";
            this.CbB_Points_List2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Points_List2.Size = new System.Drawing.Size(240, 29);
            this.CbB_Points_List2.TabIndex = 208;
            this.CbB_Points_List2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbB_Points_List1
            // 
            this.CbB_Points_List1.DataSource = null;
            this.CbB_Points_List1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Points_List1.FillColor = System.Drawing.Color.White;
            this.CbB_Points_List1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Points_List1.Location = new System.Drawing.Point(106, 61);
            this.CbB_Points_List1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Points_List1.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Points_List1.Name = "CbB_Points_List1";
            this.CbB_Points_List1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Points_List1.Size = new System.Drawing.Size(240, 29);
            this.CbB_Points_List1.TabIndex = 206;
            this.CbB_Points_List1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(106, 15);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Name.Maximum = 2147483647D;
            this.TB_Name.Minimum = -2147483648D;
            this.TB_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Name.Size = new System.Drawing.Size(241, 29);
            this.TB_Name.TabIndex = 205;
            this.TB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(30, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 21);
            this.label6.TabIndex = 203;
            this.label6.Text = "点2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 21);
            this.label1.TabIndex = 202;
            this.label1.Text = "点1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(30, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 200;
            this.label4.Text = "名称";
            // 
            // ResultsContainer
            // 
            this.ResultsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsContainer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsContainer.Location = new System.Drawing.Point(3, 289);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(379, 263);
            this.ResultsContainer.TabIndex = 210;
            // 
            // PointsDistToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.CbB_Points_List2);
            this.Controls.Add(this.CbB_Points_List1);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PointsDistToolView";
            this.Size = new System.Drawing.Size(385, 650);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton Button_Confirm;
        private Sunny.UI.UIComboBox CbB_Points_List2;
        private Sunny.UI.UIComboBox CbB_Points_List1;
        private Sunny.UI.UITextBox TB_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

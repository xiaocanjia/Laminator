namespace Meas3D.Tool
{
    partial class PlanesIntersectionTool3DView
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
            this.CbB_Plane2_List = new Sunny.UI.UIComboBox();
            this.CbB_Plane1_List = new Sunny.UI.UIComboBox();
            this.TB_Name = new Sunny.UI.UITextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CbB_Plane3_List = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.Button_Confirm.Location = new System.Drawing.Point(140, 596);
            this.Button_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Confirm.Name = "Button_Confirm";
            this.Button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.Button_Confirm.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Confirm.TabIndex = 216;
            this.Button_Confirm.Text = "关闭";
            this.Button_Confirm.Click += new System.EventHandler(this.Button_Confirm_Click);
            // 
            // CbB_Plane2_List
            // 
            this.CbB_Plane2_List.DataSource = null;
            this.CbB_Plane2_List.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Plane2_List.FillColor = System.Drawing.Color.White;
            this.CbB_Plane2_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Plane2_List.Location = new System.Drawing.Point(99, 116);
            this.CbB_Plane2_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Plane2_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Plane2_List.Name = "CbB_Plane2_List";
            this.CbB_Plane2_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Plane2_List.Size = new System.Drawing.Size(251, 29);
            this.CbB_Plane2_List.TabIndex = 214;
            this.CbB_Plane2_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Plane2_List.SelectedIndexChanged += new System.EventHandler(this.ComboBox_List_SelectedIndexChanged);
            // 
            // CbB_Plane1_List
            // 
            this.CbB_Plane1_List.DataSource = null;
            this.CbB_Plane1_List.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Plane1_List.FillColor = System.Drawing.Color.White;
            this.CbB_Plane1_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Plane1_List.Location = new System.Drawing.Point(99, 68);
            this.CbB_Plane1_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Plane1_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Plane1_List.Name = "CbB_Plane1_List";
            this.CbB_Plane1_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Plane1_List.Size = new System.Drawing.Size(251, 29);
            this.CbB_Plane1_List.TabIndex = 215;
            this.CbB_Plane1_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Plane1_List.SelectedIndexChanged += new System.EventHandler(this.ComboBox_List_SelectedIndexChanged);
            // 
            // TB_Name
            // 
            this.TB_Name.ButtonSymbol = 61761;
            this.TB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Name.Location = new System.Drawing.Point(99, 20);
            this.TB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Name.Maximum = 2147483647D;
            this.TB_Name.Minimum = -2147483648D;
            this.TB_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Name.Size = new System.Drawing.Size(251, 29);
            this.TB_Name.TabIndex = 213;
            this.TB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 21);
            this.label6.TabIndex = 212;
            this.label6.Text = "面2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 21);
            this.label1.TabIndex = 211;
            this.label1.Text = "面1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 209;
            this.label4.Text = "名称";
            // 
            // CbB_Plane3_List
            // 
            this.CbB_Plane3_List.DataSource = null;
            this.CbB_Plane3_List.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CbB_Plane3_List.FillColor = System.Drawing.Color.White;
            this.CbB_Plane3_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Plane3_List.Location = new System.Drawing.Point(99, 164);
            this.CbB_Plane3_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Plane3_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Plane3_List.Name = "CbB_Plane3_List";
            this.CbB_Plane3_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Plane3_List.Size = new System.Drawing.Size(251, 29);
            this.CbB_Plane3_List.TabIndex = 216;
            this.CbB_Plane3_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CbB_Plane3_List.SelectedIndexChanged += new System.EventHandler(this.ComboBox_List_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 21);
            this.label2.TabIndex = 215;
            this.label2.Text = "面3";
            // 
            // ResultsContainer
            // 
            this.ResultsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsContainer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultsContainer.Location = new System.Drawing.Point(3, 296);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(379, 263);
            this.ResultsContainer.TabIndex = 217;
            // 
            // PlanesIntersectionToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.CbB_Plane3_List);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.CbB_Plane2_List);
            this.Controls.Add(this.CbB_Plane1_List);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PlanesIntersectionToolView";
            this.Size = new System.Drawing.Size(385, 650);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton Button_Confirm;
        private Sunny.UI.UIComboBox CbB_Plane2_List;
        private Sunny.UI.UIComboBox CbB_Plane1_List;
        private Sunny.UI.UITextBox TB_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UIComboBox CbB_Plane3_List;
        private System.Windows.Forms.Label label2;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

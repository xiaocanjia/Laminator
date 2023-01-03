namespace Meas3D.Tool
{
    partial class FitPlaneTool3DView
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
            this.Button_Add_ROI = new Sunny.UI.UIButton();
            this.Button_Remove_ROI = new Sunny.UI.UIButton();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.Button_Confirm = new Sunny.UI.UIButton();
            this.ResultsContainer = new MeasResult.ResultsContainer();
            this.SuspendLayout();
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(25, 21);
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
            this.TB_Name.Location = new System.Drawing.Point(122, 18);
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
            // Button_Add_ROI
            // 
            this.Button_Add_ROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Add_ROI.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Add_ROI.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Add_ROI.Location = new System.Drawing.Point(122, 69);
            this.Button_Add_ROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Add_ROI.Name = "Button_Add_ROI";
            this.Button_Add_ROI.Size = new System.Drawing.Size(89, 29);
            this.Button_Add_ROI.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Add_ROI.TabIndex = 199;
            this.Button_Add_ROI.Text = "添加";
            this.Button_Add_ROI.Click += new System.EventHandler(this.Button_Add_Region_Click);
            // 
            // Button_Remove_ROI
            // 
            this.Button_Remove_ROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Remove_ROI.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Remove_ROI.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Remove_ROI.Location = new System.Drawing.Point(226, 69);
            this.Button_Remove_ROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Remove_ROI.Name = "Button_Remove_ROI";
            this.Button_Remove_ROI.Size = new System.Drawing.Size(89, 29);
            this.Button_Remove_ROI.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Remove_ROI.TabIndex = 198;
            this.Button_Remove_ROI.Text = "删除";
            this.Button_Remove_ROI.Click += new System.EventHandler(this.Button_Remove_Region_Click);
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel14.Location = new System.Drawing.Point(25, 72);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(78, 23);
            this.uiLabel14.TabIndex = 197;
            this.uiLabel14.Text = "ROI";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_Confirm
            // 
            this.Button_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Confirm.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Confirm.Location = new System.Drawing.Point(131, 524);
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
            this.ResultsContainer.Location = new System.Drawing.Point(3, 211);
            this.ResultsContainer.Name = "ResultsContainer";
            this.ResultsContainer.Size = new System.Drawing.Size(379, 263);
            this.ResultsContainer.TabIndex = 201;
            // 
            // FitPlaneToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.ResultsContainer);
            this.Controls.Add(this.Button_Confirm);
            this.Controls.Add(this.Button_Add_ROI);
            this.Controls.Add(this.Button_Remove_ROI);
            this.Controls.Add(this.uiLabel14);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.TB_Name);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FitPlaneToolView";
            this.Size = new System.Drawing.Size(385, 575);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox TB_Name;
        private Sunny.UI.UIButton Button_Add_ROI;
        private Sunny.UI.UIButton Button_Remove_ROI;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UIButton Button_Confirm;
        private MeasResult.ResultsContainer ResultsContainer;
    }
}

namespace Meas2D.FixPos
{
    partial class ModelMatchFixPos2DView
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
            this.Button_Add_ROI = new Sunny.UI.UIButton();
            this.Button_Remove_ROI = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TB_Pyramid_Levels = new Sunny.UI.UITextBox();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // Button_Add_ROI
            // 
            this.Button_Add_ROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Add_ROI.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Add_ROI.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Add_ROI.Location = new System.Drawing.Point(133, 31);
            this.Button_Add_ROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Add_ROI.Name = "Button_Add_ROI";
            this.Button_Add_ROI.Size = new System.Drawing.Size(89, 29);
            this.Button_Add_ROI.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Add_ROI.TabIndex = 171;
            this.Button_Add_ROI.Text = "添加";
            this.Button_Add_ROI.Click += new System.EventHandler(this.Button_Add_ROI_Click);
            // 
            // Button_Remove_ROI
            // 
            this.Button_Remove_ROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Remove_ROI.FillColor = System.Drawing.Color.SteelBlue;
            this.Button_Remove_ROI.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Remove_ROI.Location = new System.Drawing.Point(237, 31);
            this.Button_Remove_ROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Remove_ROI.Name = "Button_Remove_ROI";
            this.Button_Remove_ROI.Size = new System.Drawing.Size(89, 29);
            this.Button_Remove_ROI.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Remove_ROI.TabIndex = 170;
            this.Button_Remove_ROI.Text = "删除";
            this.Button_Remove_ROI.Click += new System.EventHandler(this.Button_Remove_ROI_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(36, 34);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(78, 23);
            this.uiLabel1.TabIndex = 169;
            this.uiLabel1.Text = "ROI";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Pyramid_Levels
            // 
            this.TB_Pyramid_Levels.ButtonSymbol = 61761;
            this.TB_Pyramid_Levels.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Pyramid_Levels.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TB_Pyramid_Levels.Location = new System.Drawing.Point(177, 95);
            this.TB_Pyramid_Levels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Pyramid_Levels.Maximum = 2147483647D;
            this.TB_Pyramid_Levels.Minimum = -2147483648D;
            this.TB_Pyramid_Levels.MinimumSize = new System.Drawing.Size(1, 1);
            this.TB_Pyramid_Levels.Name = "TB_Pyramid_Levels";
            this.TB_Pyramid_Levels.Padding = new System.Windows.Forms.Padding(5);
            this.TB_Pyramid_Levels.Size = new System.Drawing.Size(104, 29);
            this.TB_Pyramid_Levels.TabIndex = 173;
            this.TB_Pyramid_Levels.Text = "0";
            this.TB_Pyramid_Levels.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel15
            // 
            this.uiLabel15.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel15.Location = new System.Drawing.Point(36, 98);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(103, 23);
            this.uiLabel15.TabIndex = 172;
            this.uiLabel15.Text = "金字塔层数";
            this.uiLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModelMatchFixPosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.Button_Add_ROI);
            this.Controls.Add(this.Button_Remove_ROI);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.TB_Pyramid_Levels);
            this.Controls.Add(this.uiLabel15);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModelMatchFixPosView";
            this.Size = new System.Drawing.Size(400, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Button_Add_ROI;
        private Sunny.UI.UIButton Button_Remove_ROI;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TB_Pyramid_Levels;
        private Sunny.UI.UILabel uiLabel15;
    }
}

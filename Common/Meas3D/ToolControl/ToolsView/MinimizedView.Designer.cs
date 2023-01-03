namespace Meas3D.Tool
{
    partial class MinimizedView
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
            this.Label_Name = new System.Windows.Forms.Label();
            this.Button_Copy = new Sunny.UI.UISymbolButton();
            this.Button_Delete = new Sunny.UI.UISymbolButton();
            this.Button_Setup = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Name.ForeColor = System.Drawing.Color.Black;
            this.Label_Name.Location = new System.Drawing.Point(10, 8);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(131, 21);
            this.Label_Name.TabIndex = 1;
            this.Label_Name.Text = "锡球平面度检测1";
            // 
            // Button_Copy
            // 
            this.Button_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Copy.FillColor = System.Drawing.Color.Transparent;
            this.Button_Copy.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Copy.ForeColor = System.Drawing.Color.Black;
            this.Button_Copy.Location = new System.Drawing.Point(263, 5);
            this.Button_Copy.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.RectColor = System.Drawing.Color.Black;
            this.Button_Copy.Size = new System.Drawing.Size(30, 26);
            this.Button_Copy.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Copy.Symbol = 62029;
            this.Button_Copy.TabIndex = 2;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Delete.FillColor = System.Drawing.Color.Transparent;
            this.Button_Delete.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Delete.ForeColor = System.Drawing.Color.Black;
            this.Button_Delete.Location = new System.Drawing.Point(299, 5);
            this.Button_Delete.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.RectColor = System.Drawing.Color.Black;
            this.Button_Delete.Size = new System.Drawing.Size(30, 26);
            this.Button_Delete.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Delete.Symbol = 57369;
            this.Button_Delete.TabIndex = 3;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Setup
            // 
            this.Button_Setup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Setup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Setup.FillColor = System.Drawing.Color.Transparent;
            this.Button_Setup.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_Setup.ForeColor = System.Drawing.Color.Black;
            this.Button_Setup.Location = new System.Drawing.Point(227, 5);
            this.Button_Setup.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_Setup.Name = "Button_Setup";
            this.Button_Setup.RectColor = System.Drawing.Color.Black;
            this.Button_Setup.Size = new System.Drawing.Size(30, 26);
            this.Button_Setup.Style = Sunny.UI.UIStyle.Custom;
            this.Button_Setup.Symbol = 108;
            this.Button_Setup.TabIndex = 4;
            this.Button_Setup.Click += new System.EventHandler(this.Button_Setup_Click);
            // 
            // MinimizedView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Button_Setup);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.Button_Copy);
            this.Controls.Add(this.Label_Name);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MinimizedView";
            this.Size = new System.Drawing.Size(335, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private Sunny.UI.UISymbolButton Button_Copy;
        private Sunny.UI.UISymbolButton Button_Delete;
        private Sunny.UI.UISymbolButton Button_Setup;
    }
}

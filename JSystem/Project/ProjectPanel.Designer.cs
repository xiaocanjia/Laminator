namespace JSystem.Project
{
    partial class ProjectPanel
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
            this.Button_DeletePro = new Sunny.UI.UISymbolButton();
            this.Button_SavePro = new Sunny.UI.UISymbolButton();
            this.CbB_Project_List = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // Button_DeletePro
            // 
            this.Button_DeletePro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DeletePro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_DeletePro.FillColor = System.Drawing.Color.Transparent;
            this.Button_DeletePro.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_DeletePro.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_DeletePro.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.Button_DeletePro.Location = new System.Drawing.Point(357, 5);
            this.Button_DeletePro.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_DeletePro.Name = "Button_DeletePro";
            this.Button_DeletePro.RectColor = System.Drawing.Color.Transparent;
            this.Button_DeletePro.Size = new System.Drawing.Size(30, 30);
            this.Button_DeletePro.Style = Sunny.UI.UIStyle.Custom;
            this.Button_DeletePro.Symbol = 61944;
            this.Button_DeletePro.SymbolSize = 30;
            this.Button_DeletePro.TabIndex = 151;
            this.Button_DeletePro.TipsText = "删除";
            this.Button_DeletePro.Click += new System.EventHandler(this.Button_Delete_Pro_Click);
            // 
            // Button_SavePro
            // 
            this.Button_SavePro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SavePro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_SavePro.FillColor = System.Drawing.Color.Transparent;
            this.Button_SavePro.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Button_SavePro.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_SavePro.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.Button_SavePro.Location = new System.Drawing.Point(325, 5);
            this.Button_SavePro.MinimumSize = new System.Drawing.Size(1, 1);
            this.Button_SavePro.Name = "Button_SavePro";
            this.Button_SavePro.RectColor = System.Drawing.Color.Transparent;
            this.Button_SavePro.Size = new System.Drawing.Size(30, 30);
            this.Button_SavePro.Style = Sunny.UI.UIStyle.Custom;
            this.Button_SavePro.Symbol = 61639;
            this.Button_SavePro.SymbolSize = 30;
            this.Button_SavePro.TabIndex = 150;
            this.Button_SavePro.TipsText = "保存";
            this.Button_SavePro.Click += new System.EventHandler(this.Button_Save_Project_Click);
            // 
            // CbB_Project_List
            // 
            this.CbB_Project_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbB_Project_List.DataSource = null;
            this.CbB_Project_List.FillColor = System.Drawing.Color.White;
            this.CbB_Project_List.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbB_Project_List.Location = new System.Drawing.Point(91, 5);
            this.CbB_Project_List.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbB_Project_List.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbB_Project_List.Name = "CbB_Project_List";
            this.CbB_Project_List.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbB_Project_List.Size = new System.Drawing.Size(227, 29);
            this.CbB_Project_List.Style = Sunny.UI.UIStyle.Custom;
            this.CbB_Project_List.TabIndex = 149;
            this.CbB_Project_List.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(4, 8);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(80, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 153;
            this.uiLabel1.Text = "当前产品";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProjectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.Button_DeletePro);
            this.Controls.Add(this.Button_SavePro);
            this.Controls.Add(this.CbB_Project_List);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProjectPanel";
            this.Size = new System.Drawing.Size(390, 39);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton Button_DeletePro;
        private Sunny.UI.UISymbolButton Button_SavePro;
        private Sunny.UI.UIComboBox CbB_Project_List;
        private Sunny.UI.UILabel uiLabel1;
    }
}

using System;

namespace JSystem.Perform
{
    partial class LogPanel
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
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => { Dispose(disposing); }));
            }
            else
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.Tab_Log = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TB_Log = new Sunny.UI.UITextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TB_Error_Log = new Sunny.UI.UITextBox();
            this.uiPanel1.SuspendLayout();
            this.Tab_Log.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.Tab_Log);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(489, 185);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tab_Log
            // 
            this.Tab_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_Log.Controls.Add(this.tabPage1);
            this.Tab_Log.Controls.Add(this.tabPage2);
            this.Tab_Log.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Tab_Log.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tab_Log.ItemSize = new System.Drawing.Size(150, 35);
            this.Tab_Log.Location = new System.Drawing.Point(1, 1);
            this.Tab_Log.MainPage = "";
            this.Tab_Log.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Tab_Log.Name = "Tab_Log";
            this.Tab_Log.SelectedIndex = 0;
            this.Tab_Log.Size = new System.Drawing.Size(487, 184);
            this.Tab_Log.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tab_Log.Style = Sunny.UI.UIStyle.Custom;
            this.Tab_Log.TabBackColor = System.Drawing.Color.LightSteelBlue;
            this.Tab_Log.TabIndex = 1;
            this.Tab_Log.TabSelectedColor = System.Drawing.Color.SteelBlue;
            this.Tab_Log.TabSelectedForeColor = System.Drawing.Color.White;
            this.Tab_Log.TabUnSelectedForeColor = System.Drawing.Color.SteelBlue;
            this.Tab_Log.SelectedIndexChanged += new System.EventHandler(this.Tab_Log_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TB_Log);
            this.tabPage1.Location = new System.Drawing.Point(0, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(487, 149);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "运行日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TB_Log
            // 
            this.TB_Log.AutoScroll = true;
            this.TB_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TB_Log.ButtonSymbol = 61761;
            this.TB_Log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Log.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TB_Log.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Log.Location = new System.Drawing.Point(0, 0);
            this.TB_Log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Log.Maximum = 2147483647D;
            this.TB_Log.Minimum = -2147483648D;
            this.TB_Log.MinimumSize = new System.Drawing.Size(1, 16);
            this.TB_Log.Multiline = true;
            this.TB_Log.Name = "TB_Log";
            this.TB_Log.ReadOnly = true;
            this.TB_Log.ShowScrollBar = true;
            this.TB_Log.Size = new System.Drawing.Size(487, 149);
            this.TB_Log.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Log.StyleCustomMode = true;
            this.TB_Log.TabIndex = 3;
            this.TB_Log.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TB_Error_Log);
            this.tabPage2.Location = new System.Drawing.Point(0, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(487, 149);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "错误日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TB_Error_Log
            // 
            this.TB_Error_Log.AutoScroll = true;
            this.TB_Error_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TB_Error_Log.ButtonSymbol = 61761;
            this.TB_Error_Log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_Error_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Error_Log.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TB_Error_Log.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Error_Log.Location = new System.Drawing.Point(0, 0);
            this.TB_Error_Log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Error_Log.Maximum = 2147483647D;
            this.TB_Error_Log.Minimum = -2147483648D;
            this.TB_Error_Log.MinimumSize = new System.Drawing.Size(1, 16);
            this.TB_Error_Log.Multiline = true;
            this.TB_Error_Log.Name = "TB_Error_Log";
            this.TB_Error_Log.ReadOnly = true;
            this.TB_Error_Log.ShowScrollBar = true;
            this.TB_Error_Log.Size = new System.Drawing.Size(487, 149);
            this.TB_Error_Log.Style = Sunny.UI.UIStyle.Custom;
            this.TB_Error_Log.StyleCustomMode = true;
            this.TB_Error_Log.TabIndex = 4;
            this.TB_Error_Log.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_Error_Log.WordWarp = false;
            // 
            // LogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.uiPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogPanel";
            this.Size = new System.Drawing.Size(489, 185);
            this.uiPanel1.ResumeLayout(false);
            this.Tab_Log.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITabControl Tab_Log;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UITextBox TB_Log;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UITextBox TB_Error_Log;
    }
}

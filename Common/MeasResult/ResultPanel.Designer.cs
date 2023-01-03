namespace MeasResult
{
    partial class ResultPanel
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
            this.Panel_Limit = new System.Windows.Forms.Panel();
            this.CB_IsOutput = new System.Windows.Forms.CheckBox();
            this.CB_IsAbs = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Offset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Lower_Limit = new System.Windows.Forms.TextBox();
            this.TB_Upper_Limit = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Value = new System.Windows.Forms.Label();
            this.Panel_Limit.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Limit
            // 
            this.Panel_Limit.Controls.Add(this.CB_IsOutput);
            this.Panel_Limit.Controls.Add(this.CB_IsAbs);
            this.Panel_Limit.Controls.Add(this.label4);
            this.Panel_Limit.Controls.Add(this.TB_ID);
            this.Panel_Limit.Controls.Add(this.label3);
            this.Panel_Limit.Controls.Add(this.TB_Offset);
            this.Panel_Limit.Controls.Add(this.label2);
            this.Panel_Limit.Controls.Add(this.label1);
            this.Panel_Limit.Controls.Add(this.TB_Lower_Limit);
            this.Panel_Limit.Controls.Add(this.TB_Upper_Limit);
            this.Panel_Limit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Limit.Location = new System.Drawing.Point(0, 0);
            this.Panel_Limit.Name = "Panel_Limit";
            this.Panel_Limit.Size = new System.Drawing.Size(390, 71);
            this.Panel_Limit.TabIndex = 0;
            // 
            // CB_IsOutput
            // 
            this.CB_IsOutput.AutoSize = true;
            this.CB_IsOutput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_IsOutput.ForeColor = System.Drawing.Color.Black;
            this.CB_IsOutput.Location = new System.Drawing.Point(323, 41);
            this.CB_IsOutput.Name = "CB_IsOutput";
            this.CB_IsOutput.Size = new System.Drawing.Size(61, 25);
            this.CB_IsOutput.TabIndex = 96;
            this.CB_IsOutput.Text = "输出";
            this.CB_IsOutput.UseVisualStyleBackColor = true;
            this.CB_IsOutput.CheckedChanged += new System.EventHandler(this.CB_Output_CheckedChanged);
            // 
            // CB_IsAbs
            // 
            this.CB_IsAbs.AutoSize = true;
            this.CB_IsAbs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_IsAbs.ForeColor = System.Drawing.Color.Black;
            this.CB_IsAbs.Location = new System.Drawing.Point(241, 41);
            this.CB_IsAbs.Name = "CB_IsAbs";
            this.CB_IsAbs.Size = new System.Drawing.Size(77, 25);
            this.CB_IsAbs.TabIndex = 95;
            this.CB_IsAbs.Text = "绝对值";
            this.CB_IsAbs.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(133, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 21);
            this.label4.TabIndex = 93;
            this.label4.Text = "ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_ID
            // 
            this.TB_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_ID.Location = new System.Drawing.Point(164, 40);
            this.TB_ID.Margin = new System.Windows.Forms.Padding(4);
            this.TB_ID.Multiline = true;
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(65, 25);
            this.TB_ID.TabIndex = 92;
            this.TB_ID.Text = "a";
            this.TB_ID.WordWrap = false;
            this.TB_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_ID.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 91;
            this.label3.Text = "补偿";
            // 
            // TB_Offset
            // 
            this.TB_Offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Offset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Offset.Location = new System.Drawing.Point(58, 40);
            this.TB_Offset.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Offset.Multiline = true;
            this.TB_Offset.Name = "TB_Offset";
            this.TB_Offset.Size = new System.Drawing.Size(65, 25);
            this.TB_Offset.TabIndex = 90;
            this.TB_Offset.WordWrap = false;
            this.TB_Offset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Offset.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(176, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 89;
            this.label2.Text = "公差";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(293, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 21);
            this.label1.TabIndex = 88;
            this.label1.Text = "-";
            // 
            // TB_Lower_Limit
            // 
            this.TB_Lower_Limit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Lower_Limit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Lower_Limit.Location = new System.Drawing.Point(226, 6);
            this.TB_Lower_Limit.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Lower_Limit.Multiline = true;
            this.TB_Lower_Limit.Name = "TB_Lower_Limit";
            this.TB_Lower_Limit.Size = new System.Drawing.Size(65, 25);
            this.TB_Lower_Limit.TabIndex = 87;
            this.TB_Lower_Limit.WordWrap = false;
            this.TB_Lower_Limit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Lower_Limit.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TB_Upper_Limit
            // 
            this.TB_Upper_Limit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Upper_Limit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_Upper_Limit.Location = new System.Drawing.Point(313, 6);
            this.TB_Upper_Limit.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Upper_Limit.Multiline = true;
            this.TB_Upper_Limit.Name = "TB_Upper_Limit";
            this.TB_Upper_Limit.Size = new System.Drawing.Size(65, 25);
            this.TB_Upper_Limit.TabIndex = 86;
            this.TB_Upper_Limit.WordWrap = false;
            this.TB_Upper_Limit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TB_Upper_Limit.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Name.ForeColor = System.Drawing.Color.Black;
            this.Label_Name.Location = new System.Drawing.Point(9, 8);
            this.Label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(42, 21);
            this.Label_Name.TabIndex = 96;
            this.Label_Name.Text = "结果";
            // 
            // Label_Value
            // 
            this.Label_Value.AutoSize = true;
            this.Label_Value.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Value.ForeColor = System.Drawing.Color.Black;
            this.Label_Value.Location = new System.Drawing.Point(53, 8);
            this.Label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Value.Name = "Label_Value";
            this.Label_Value.Size = new System.Drawing.Size(59, 21);
            this.Label_Value.TabIndex = 95;
            this.Label_Value.Text = "11.111";
            // 
            // ResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Label_Value);
            this.Controls.Add(this.Panel_Limit);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ResultPanel";
            this.Size = new System.Drawing.Size(390, 71);
            this.Panel_Limit.ResumeLayout(false);
            this.Panel_Limit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Limit;
        private System.Windows.Forms.CheckBox CB_IsAbs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Offset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Lower_Limit;
        private System.Windows.Forms.TextBox TB_Upper_Limit;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_Value;
        private System.Windows.Forms.CheckBox CB_IsOutput;
    }
}

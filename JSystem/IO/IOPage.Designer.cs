namespace JSystem.IO
{
    partial class IOPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Tab_IO = new Sunny.UI.UITabControlMenu();
            this.Page_In = new System.Windows.Forms.TabPage();
            this.Panel_In = new System.Windows.Forms.FlowLayoutPanel();
            this.Page_Out = new System.Windows.Forms.TabPage();
            this.Panel_Out = new System.Windows.Forms.FlowLayoutPanel();
            this.Timer_IO_Monitor = new System.Windows.Forms.Timer(this.components);
            this.Tab_IO.SuspendLayout();
            this.Page_In.SuspendLayout();
            this.Page_Out.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_IO
            // 
            this.Tab_IO.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.Tab_IO.Controls.Add(this.Page_In);
            this.Tab_IO.Controls.Add(this.Page_Out);
            this.Tab_IO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_IO.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Tab_IO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tab_IO.ItemSize = new System.Drawing.Size(40, 200);
            this.Tab_IO.Location = new System.Drawing.Point(0, 0);
            this.Tab_IO.Multiline = true;
            this.Tab_IO.Name = "Tab_IO";
            this.Tab_IO.SelectedIndex = 0;
            this.Tab_IO.Size = new System.Drawing.Size(1378, 788);
            this.Tab_IO.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tab_IO.TabIndex = 0;
            this.Tab_IO.SelectedIndexChanged += new System.EventHandler(this.Tab_IO_SelectedIndexChanged);
            // 
            // Page_In
            // 
            this.Page_In.Controls.Add(this.Panel_In);
            this.Page_In.Location = new System.Drawing.Point(201, 0);
            this.Page_In.Name = "Page_In";
            this.Page_In.Size = new System.Drawing.Size(1177, 788);
            this.Page_In.TabIndex = 0;
            this.Page_In.Text = "输入";
            this.Page_In.UseVisualStyleBackColor = true;
            // 
            // Panel_In
            // 
            this.Panel_In.AutoScroll = true;
            this.Panel_In.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_In.Location = new System.Drawing.Point(0, 0);
            this.Panel_In.Name = "Panel_In";
            this.Panel_In.Size = new System.Drawing.Size(1177, 788);
            this.Panel_In.TabIndex = 2;
            // 
            // Page_Out
            // 
            this.Page_Out.Controls.Add(this.Panel_Out);
            this.Page_Out.Location = new System.Drawing.Point(201, 0);
            this.Page_Out.Name = "Page_Out";
            this.Page_Out.Size = new System.Drawing.Size(1177, 788);
            this.Page_Out.TabIndex = 1;
            this.Page_Out.Text = "输出";
            this.Page_Out.UseVisualStyleBackColor = true;
            // 
            // Panel_Out
            // 
            this.Panel_Out.AutoScroll = true;
            this.Panel_Out.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Out.Location = new System.Drawing.Point(0, 0);
            this.Panel_Out.Name = "Panel_Out";
            this.Panel_Out.Size = new System.Drawing.Size(1177, 788);
            this.Panel_Out.TabIndex = 1;
            // 
            // Timer_IO_Monitor
            // 
            this.Timer_IO_Monitor.Interval = 300;
            this.Timer_IO_Monitor.Tick += new System.EventHandler(this.Timer_IO_Monitor_Tick);
            // 
            // IOPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 788);
            this.Controls.Add(this.Tab_IO);
            this.Name = "IOPage";
            this.Text = "IOPage";
            this.Tab_IO.ResumeLayout(false);
            this.Page_In.ResumeLayout(false);
            this.Page_Out.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITabControlMenu Tab_IO;
        private System.Windows.Forms.TabPage Page_In;
        private System.Windows.Forms.TabPage Page_Out;
        private System.Windows.Forms.FlowLayoutPanel Panel_Out;
        private System.Windows.Forms.FlowLayoutPanel Panel_In;
        private System.Windows.Forms.Timer Timer_IO_Monitor;
    }
}
namespace JSystem.Station
{
    partial class StationsPage
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
            this.Tab_Stations = new Sunny.UI.UITabControlMenu();
            this.SuspendLayout();
            // 
            // Tab_Stations
            // 
            this.Tab_Stations.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.Tab_Stations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Stations.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Tab_Stations.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tab_Stations.ItemSize = new System.Drawing.Size(40, 200);
            this.Tab_Stations.Location = new System.Drawing.Point(0, 0);
            this.Tab_Stations.Multiline = true;
            this.Tab_Stations.Name = "Tab_Stations";
            this.Tab_Stations.SelectedIndex = 0;
            this.Tab_Stations.Size = new System.Drawing.Size(1300, 788);
            this.Tab_Stations.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tab_Stations.Style = Sunny.UI.UIStyle.Custom;
            this.Tab_Stations.TabIndex = 0;
            // 
            // StationsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1300, 788);
            this.Controls.Add(this.Tab_Stations);
            this.Name = "StationsPage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "StationsWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControlMenu Tab_Stations;
    }
}
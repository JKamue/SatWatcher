namespace SatWatcher.Forms
{
    partial class SimulationScreen
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
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectSatellitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predictPassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSimulation.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.Controls.Add(this.menuStrip1);
            this.pnlSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSimulation.Location = new System.Drawing.Point(0, 0);
            this.pnlSimulation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(1067, 554);
            this.pnlSimulation.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSatellitesToolStripMenuItem,
            this.predictPassesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectSatellitesToolStripMenuItem
            // 
            this.selectSatellitesToolStripMenuItem.Name = "selectSatellitesToolStripMenuItem";
            this.selectSatellitesToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.selectSatellitesToolStripMenuItem.Text = "Select Satellites";
            this.selectSatellitesToolStripMenuItem.Click += new System.EventHandler(this.selectSatellitesToolStripMenuItem_Click);
            // 
            // predictPassesToolStripMenuItem
            // 
            this.predictPassesToolStripMenuItem.Name = "predictPassesToolStripMenuItem";
            this.predictPassesToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.predictPassesToolStripMenuItem.Text = "Predict Passes";
            // 
            // SimulationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlSimulation);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SimulationScreen";
            this.Text = "SimulationScreen";
            this.pnlSimulation.ResumeLayout(false);
            this.pnlSimulation.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectSatellitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem predictPassesToolStripMenuItem;
    }
}
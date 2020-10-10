namespace SatWatcher.Forms
{
    partial class SatChooser
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
            this.lbxShownSats = new System.Windows.Forms.ListBox();
            this.lbxStoredSats = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddToShown = new System.Windows.Forms.Button();
            this.btnRemoveFromShown = new System.Windows.Forms.Button();
            this.nbxNorad = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbxNorad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxShownSats
            // 
            this.lbxShownSats.FormattingEnabled = true;
            this.lbxShownSats.ItemHeight = 16;
            this.lbxShownSats.Location = new System.Drawing.Point(315, 46);
            this.lbxShownSats.Name = "lbxShownSats";
            this.lbxShownSats.Size = new System.Drawing.Size(220, 292);
            this.lbxShownSats.TabIndex = 0;
            this.lbxShownSats.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxShownSats_MouseDoubleClick);
            // 
            // lbxStoredSats
            // 
            this.lbxStoredSats.FormattingEnabled = true;
            this.lbxStoredSats.ItemHeight = 16;
            this.lbxStoredSats.Location = new System.Drawing.Point(45, 46);
            this.lbxStoredSats.Name = "lbxStoredSats";
            this.lbxStoredSats.Size = new System.Drawing.Size(220, 292);
            this.lbxStoredSats.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Saved Satellites";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shown satellites";
            // 
            // btnAddToShown
            // 
            this.btnAddToShown.Location = new System.Drawing.Point(271, 153);
            this.btnAddToShown.Name = "btnAddToShown";
            this.btnAddToShown.Size = new System.Drawing.Size(38, 23);
            this.btnAddToShown.TabIndex = 4;
            this.btnAddToShown.Text = "▶";
            this.btnAddToShown.UseVisualStyleBackColor = true;
            this.btnAddToShown.Click += new System.EventHandler(this.btnAddToShown_Click);
            // 
            // btnRemoveFromShown
            // 
            this.btnRemoveFromShown.Location = new System.Drawing.Point(271, 182);
            this.btnRemoveFromShown.Name = "btnRemoveFromShown";
            this.btnRemoveFromShown.Size = new System.Drawing.Size(38, 23);
            this.btnRemoveFromShown.TabIndex = 5;
            this.btnRemoveFromShown.Text = "◀";
            this.btnRemoveFromShown.UseVisualStyleBackColor = true;
            this.btnRemoveFromShown.Click += new System.EventHandler(this.btnRemoveFromShown_Click);
            // 
            // nbxNorad
            // 
            this.nbxNorad.Location = new System.Drawing.Point(177, 38);
            this.nbxNorad.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nbxNorad.Name = "nbxNorad";
            this.nbxNorad.Size = new System.Drawing.Size(120, 22);
            this.nbxNorad.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nbxNorad);
            this.groupBox1.Location = new System.Drawing.Point(45, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 74);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new satellite";
            // 
            // btnAddSat
            // 
            this.btnAddSat.Location = new System.Drawing.Point(317, 37);
            this.btnAddSat.Name = "btnAddSat";
            this.btnAddSat.Size = new System.Drawing.Size(75, 23);
            this.btnAddSat.TabIndex = 8;
            this.btnAddSat.Text = "Add";
            this.btnAddSat.UseVisualStyleBackColor = true;
            this.btnAddSat.Click += new System.EventHandler(this.btnAddSat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "NORAD no.";
            // 
            // SatChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 425);
            this.Controls.Add(this.btnRemoveFromShown);
            this.Controls.Add(this.btnAddToShown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxStoredSats);
            this.Controls.Add(this.lbxShownSats);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SatChooser";
            this.Text = "SatChooser";
            ((System.ComponentModel.ISupportInitialize)(this.nbxNorad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxShownSats;
        private System.Windows.Forms.ListBox lbxStoredSats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddToShown;
        private System.Windows.Forms.Button btnRemoveFromShown;
        private System.Windows.Forms.NumericUpDown nbxNorad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddSat;
        private System.Windows.Forms.Label label3;
    }
}
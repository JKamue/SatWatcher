namespace SatWatcher.Forms
{
    partial class PassCalculator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStoreLocation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nbxLocLng = new System.Windows.Forms.NumericUpDown();
            this.nbxLocLat = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.nbxMinElev = new System.Windows.Forms.NumericUpDown();
            this.nbxSpanDays = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lviewPasses = new System.Windows.Forms.ListView();
            this.btnGenPdf = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxLocLng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxLocLat)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxMinElev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxSpanDays)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStoreLocation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nbxLocLng);
            this.groupBox1.Controls.Add(this.nbxLocLat);
            this.groupBox1.Location = new System.Drawing.Point(12, 475);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // btnStoreLocation
            // 
            this.btnStoreLocation.Location = new System.Drawing.Point(296, 42);
            this.btnStoreLocation.Name = "btnStoreLocation";
            this.btnStoreLocation.Size = new System.Drawing.Size(75, 35);
            this.btnStoreLocation.TabIndex = 4;
            this.btnStoreLocation.Text = "save";
            this.btnStoreLocation.UseVisualStyleBackColor = true;
            this.btnStoreLocation.Click += new System.EventHandler(this.btnStoreLocation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Longitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Latitude";
            // 
            // nbxLocLng
            // 
            this.nbxLocLng.DecimalPlaces = 6;
            this.nbxLocLng.Location = new System.Drawing.Point(144, 63);
            this.nbxLocLng.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nbxLocLng.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nbxLocLng.Name = "nbxLocLng";
            this.nbxLocLng.Size = new System.Drawing.Size(120, 22);
            this.nbxLocLng.TabIndex = 1;
            // 
            // nbxLocLat
            // 
            this.nbxLocLat.DecimalPlaces = 6;
            this.nbxLocLat.Location = new System.Drawing.Point(144, 35);
            this.nbxLocLat.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nbxLocLat.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nbxLocLat.Name = "nbxLocLat";
            this.nbxLocLat.Size = new System.Drawing.Size(120, 22);
            this.nbxLocLat.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCalc);
            this.groupBox2.Controls.Add(this.nbxMinElev);
            this.groupBox2.Controls.Add(this.nbxSpanDays);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timespan";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(277, 76);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(83, 31);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // nbxMinElev
            // 
            this.nbxMinElev.Location = new System.Drawing.Point(132, 85);
            this.nbxMinElev.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nbxMinElev.Name = "nbxMinElev";
            this.nbxMinElev.Size = new System.Drawing.Size(61, 22);
            this.nbxMinElev.TabIndex = 5;
            this.nbxMinElev.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nbxSpanDays
            // 
            this.nbxSpanDays.Location = new System.Drawing.Point(132, 58);
            this.nbxSpanDays.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.nbxSpanDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbxSpanDays.Name = "nbxSpanDays";
            this.nbxSpanDays.Size = new System.Drawing.Size(61, 22);
            this.nbxSpanDays.TabIndex = 2;
            this.nbxSpanDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "min Elev.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Days";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(132, 28);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(228, 22);
            this.dtpStart.TabIndex = 1;
            // 
            // lviewPasses
            // 
            this.lviewPasses.HideSelection = false;
            this.lviewPasses.Location = new System.Drawing.Point(12, 148);
            this.lviewPasses.Name = "lviewPasses";
            this.lviewPasses.Size = new System.Drawing.Size(420, 290);
            this.lviewPasses.TabIndex = 2;
            this.lviewPasses.UseCompatibleStateImageBehavior = false;
            // 
            // btnGenPdf
            // 
            this.btnGenPdf.Enabled = false;
            this.btnGenPdf.Location = new System.Drawing.Point(308, 444);
            this.btnGenPdf.Name = "btnGenPdf";
            this.btnGenPdf.Size = new System.Drawing.Size(124, 25);
            this.btnGenPdf.TabIndex = 5;
            this.btnGenPdf.Text = "Generate PDF";
            this.btnGenPdf.UseVisualStyleBackColor = true;
            this.btnGenPdf.Click += new System.EventHandler(this.btnGenPdf_Click);
            // 
            // PassCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 585);
            this.Controls.Add(this.btnGenPdf);
            this.Controls.Add(this.lviewPasses);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PassCalculator";
            this.Text = "PassCalculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxLocLng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxLocLat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxMinElev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxSpanDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nbxMinElev;
        private System.Windows.Forms.NumericUpDown nbxSpanDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnStoreLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nbxLocLng;
        private System.Windows.Forms.NumericUpDown nbxLocLat;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.ListView lviewPasses;
        private System.Windows.Forms.Button btnGenPdf;
    }
}
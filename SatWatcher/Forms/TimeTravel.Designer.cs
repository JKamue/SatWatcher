namespace SatWatcher.Forms
{
    partial class TimeTravel
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
            this.dtpCurrentTime = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.cbxNumber = new System.Windows.Forms.ComboBox();
            this.cbxTime = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.rdbSimulation = new System.Windows.Forms.RadioButton();
            this.rdbRealtime = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dtpCurrentTime
            // 
            this.dtpCurrentTime.CustomFormat = "yyyy/MM/dd HH:mm:ss ";
            this.dtpCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCurrentTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentTime.Location = new System.Drawing.Point(12, 12);
            this.dtpCurrentTime.Name = "dtpCurrentTime";
            this.dtpCurrentTime.Size = new System.Drawing.Size(310, 34);
            this.dtpCurrentTime.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(247, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 46);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSub
            // 
            this.btnSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSub.Location = new System.Drawing.Point(12, 95);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(118, 46);
            this.btnSub.TabIndex = 3;
            this.btnSub.Text = "Subtract";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // cbxNumber
            // 
            this.cbxNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNumber.FormattingEnabled = true;
            this.cbxNumber.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "1",
            "5",
            "15",
            "30",
            ""});
            this.cbxNumber.Location = new System.Drawing.Point(12, 56);
            this.cbxNumber.Name = "cbxNumber";
            this.cbxNumber.Size = new System.Drawing.Size(102, 33);
            this.cbxNumber.TabIndex = 5;
            // 
            // cbxTime
            // 
            this.cbxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTime.FormattingEnabled = true;
            this.cbxTime.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours",
            "days"});
            this.cbxTime.Location = new System.Drawing.Point(159, 56);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(163, 33);
            this.cbxTime.TabIndex = 6;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(147, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 46);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rdbSimulation
            // 
            this.rdbSimulation.AutoSize = true;
            this.rdbSimulation.Location = new System.Drawing.Point(159, 157);
            this.rdbSimulation.Name = "rdbSimulation";
            this.rdbSimulation.Size = new System.Drawing.Size(94, 21);
            this.rdbSimulation.TabIndex = 8;
            this.rdbSimulation.TabStop = true;
            this.rdbSimulation.Text = "Simulation";
            this.rdbSimulation.UseVisualStyleBackColor = true;
            // 
            // rdbRealtime
            // 
            this.rdbRealtime.AutoSize = true;
            this.rdbRealtime.Location = new System.Drawing.Point(46, 157);
            this.rdbRealtime.Name = "rdbRealtime";
            this.rdbRealtime.Size = new System.Drawing.Size(84, 21);
            this.rdbRealtime.TabIndex = 9;
            this.rdbRealtime.TabStop = true;
            this.rdbRealtime.Text = "Realtime";
            this.rdbRealtime.UseVisualStyleBackColor = true;
            // 
            // TimeTravel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 188);
            this.Controls.Add(this.rdbRealtime);
            this.Controls.Add(this.rdbSimulation);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbxTime);
            this.Controls.Add(this.cbxNumber);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpCurrentTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TimeTravel";
            this.Text = "TimeTravel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCurrentTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.ComboBox cbxNumber;
        private System.Windows.Forms.ComboBox cbxTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdbSimulation;
        private System.Windows.Forms.RadioButton rdbRealtime;
    }
}
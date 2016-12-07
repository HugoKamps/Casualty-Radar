using KBS_SE3.Properties;

namespace KBS_SE3.Modules {
    partial class SettingsModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.locationExampleLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.feedTickerLabel = new System.Windows.Forms.Label();
            this.feedTickerInfoLabel = new System.Windows.Forms.Label();
            this.feedTickerEnabledLabel = new System.Windows.Forms.Label();
            this.feedTickerCheckBox = new System.Windows.Forms.CheckBox();
            this.feedTickerNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.feedTickerNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // locationLabel
            // 
            this.locationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLabel.ForeColor = System.Drawing.Color.White;
            this.locationLabel.Location = new System.Drawing.Point(16, 19);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(131, 26);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Uw locatie:";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTextBox.Location = new System.Drawing.Point(147, 19);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(227, 26);
            this.locationTextBox.TabIndex = 1;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // locationExampleLabel
            // 
            this.locationExampleLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.locationExampleLabel.Location = new System.Drawing.Point(150, 48);
            this.locationExampleLabel.Name = "locationExampleLabel";
            this.locationExampleLabel.Size = new System.Drawing.Size(191, 19);
            this.locationExampleLabel.TabIndex = 2;
            this.locationExampleLabel.Text = "Voorbeeld: Rozenlaan 12, Amsterdam";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(742, 393);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(124, 46);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Opslaan";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.warningLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.warningLabel.Location = new System.Drawing.Point(487, 409);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(229, 16);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.Text = "Je hebt geen adres opgegeven!";
            this.warningLabel.Visible = false;
            // 
            // feedTickerLabel
            // 
            this.feedTickerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.feedTickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedTickerLabel.ForeColor = System.Drawing.Color.White;
            this.feedTickerLabel.Location = new System.Drawing.Point(16, 134);
            this.feedTickerLabel.Name = "feedTickerLabel";
            this.feedTickerLabel.Size = new System.Drawing.Size(131, 26);
            this.feedTickerLabel.TabIndex = 6;
            this.feedTickerLabel.Text = "Ververs tijd (feed):";
            this.feedTickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // feedTickerInfoLabel
            // 
            this.feedTickerInfoLabel.AutoSize = true;
            this.feedTickerInfoLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.feedTickerInfoLabel.Location = new System.Drawing.Point(150, 163);
            this.feedTickerInfoLabel.Name = "feedTickerInfoLabel";
            this.feedTickerInfoLabel.Size = new System.Drawing.Size(85, 13);
            this.feedTickerInfoLabel.TabIndex = 7;
            this.feedTickerInfoLabel.Text = "Tijd in seconden";
            // 
            // feedTickerEnabledLabel
            // 
            this.feedTickerEnabledLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.feedTickerEnabledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedTickerEnabledLabel.ForeColor = System.Drawing.Color.White;
            this.feedTickerEnabledLabel.Location = new System.Drawing.Point(16, 83);
            this.feedTickerEnabledLabel.Name = "feedTickerEnabledLabel";
            this.feedTickerEnabledLabel.Size = new System.Drawing.Size(131, 26);
            this.feedTickerEnabledLabel.TabIndex = 8;
            this.feedTickerEnabledLabel.Text = "Gebruik timer: ";
            this.feedTickerEnabledLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // feedTickerCheckBox
            // 
            this.feedTickerCheckBox.AutoSize = true;
            this.feedTickerCheckBox.Checked = true;
            this.feedTickerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.feedTickerCheckBox.Location = new System.Drawing.Point(153, 90);
            this.feedTickerCheckBox.Name = "feedTickerCheckBox";
            this.feedTickerCheckBox.Size = new System.Drawing.Size(15, 14);
            this.feedTickerCheckBox.TabIndex = 10;
            this.feedTickerCheckBox.UseVisualStyleBackColor = true;
            this.feedTickerCheckBox.CheckedChanged += new System.EventHandler(this.feedTickerCheckBox_CheckedChanged);
            // 
            // feedTickerNumeric
            // 
            this.feedTickerNumeric.Enabled = this.feedTickerCheckBox.Checked;
            this.feedTickerNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedTickerNumeric.Location = new System.Drawing.Point(147, 134);
            this.feedTickerNumeric.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.feedTickerNumeric.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.feedTickerNumeric.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.feedTickerNumeric.Name = "feedTickerNumeric";
            this.feedTickerNumeric.Size = new System.Drawing.Size(90, 26);
            this.feedTickerNumeric.TabIndex = 5;
            this.feedTickerNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.feedTickerNumeric.ValueChanged += new System.EventHandler(this.feedTickerNumeric_ValueChanged);
            // 
            // SettingsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.feedTickerCheckBox);
            this.Controls.Add(this.feedTickerEnabledLabel);
            this.Controls.Add(this.feedTickerInfoLabel);
            this.Controls.Add(this.feedTickerLabel);
            this.Controls.Add(this.feedTickerNumeric);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.locationExampleLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.locationLabel);
            this.Name = "SettingsModule";
            this.Size = new System.Drawing.Size(953, 480);
            ((System.ComponentModel.ISupportInitialize)(this.feedTickerNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationLabel;
        public System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label locationExampleLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.NumericUpDown feedTickerNumeric;
        private System.Windows.Forms.Label feedTickerLabel;
        private System.Windows.Forms.Label feedTickerInfoLabel;
        private System.Windows.Forms.Label feedTickerEnabledLabel;
        private System.Windows.Forms.CheckBox feedTickerCheckBox;
    }
}

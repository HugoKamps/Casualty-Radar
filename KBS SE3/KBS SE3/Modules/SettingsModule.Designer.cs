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
            this.SuspendLayout();
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(16, 19);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(60, 13);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Uw locatie:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(83, 19);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(227, 20);
            this.locationTextBox.TabIndex = 1;
            // 
            // locationExampleLabel
            // 
            this.locationExampleLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.locationExampleLabel.Location = new System.Drawing.Point(80, 42);
            this.locationExampleLabel.Name = "locationExampleLabel";
            this.locationExampleLabel.Size = new System.Drawing.Size(191, 19);
            this.locationExampleLabel.TabIndex = 2;
            this.locationExampleLabel.Text = "Voorbeeld: Rozenlaan 12, Amsterdam";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(83, 137);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Opslaan";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // SettingsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.locationExampleLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.locationLabel);
            this.Name = "SettingsModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label locationExampleLabel;
        private System.Windows.Forms.Button saveBtn;
    }
}

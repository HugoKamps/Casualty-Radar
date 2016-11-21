namespace KBS_SE3.Modules {
    partial class GetStartedModule {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetStartedModule));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.welcomeInstructionsLabel = new System.Windows.Forms.Label();
            this.fillLocationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.continueBtn = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(214, 74);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(507, 100);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welkom!";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomeInstructionsLabel
            // 
            this.welcomeInstructionsLabel.BackColor = System.Drawing.Color.LightGray;
            this.welcomeInstructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeInstructionsLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.welcomeInstructionsLabel.Location = new System.Drawing.Point(214, 174);
            this.welcomeInstructionsLabel.Name = "welcomeInstructionsLabel";
            this.welcomeInstructionsLabel.Size = new System.Drawing.Size(507, 119);
            this.welcomeInstructionsLabel.TabIndex = 1;
            this.welcomeInstructionsLabel.Text = resources.GetString("welcomeInstructionsLabel.Text");
            this.welcomeInstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fillLocationLabel
            // 
            this.fillLocationLabel.BackColor = System.Drawing.Color.Gray;
            this.fillLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fillLocationLabel.ForeColor = System.Drawing.Color.White;
            this.fillLocationLabel.Location = new System.Drawing.Point(217, 331);
            this.fillLocationLabel.Name = "fillLocationLabel";
            this.fillLocationLabel.Size = new System.Drawing.Size(507, 35);
            this.fillLocationLabel.TabIndex = 3;
            this.fillLocationLabel.Text = "Vul hieronder je locatie in (voorbeeld: Rozenstraat 1, Amsterdam)";
            this.fillLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTextBox.Location = new System.Drawing.Point(217, 366);
            this.locationTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(353, 26);
            this.locationTextBox.TabIndex = 2;
            this.locationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // continueBtn
            // 
            this.continueBtn.BackColor = System.Drawing.Color.LightGray;
            this.continueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.continueBtn.Location = new System.Drawing.Point(570, 366);
            this.continueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(154, 26);
            this.continueBtn.TabIndex = 4;
            this.continueBtn.Text = "Ga verder";
            this.continueBtn.UseCompatibleTextRendering = true;
            this.continueBtn.UseVisualStyleBackColor = false;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(353, 402);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(229, 16);
            this.warningLabel.TabIndex = 5;
            this.warningLabel.Text = "Je hebt geen adres opgegeven!";
            this.warningLabel.Visible = false;
            // 
            // GetStartedModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.fillLocationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.welcomeInstructionsLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "GetStartedModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label welcomeInstructionsLabel;
        private System.Windows.Forms.Label fillLocationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.Label warningLabel;
    }
}

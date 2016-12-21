namespace Casualty_Radar.Modules {
    partial class SplashScreenModule {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.CurrentlyLoadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Casualty_Radar.Properties.Resources.load_splash_screen;
            this.pictureBox1.Location = new System.Drawing.Point(526, 372);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logo.Image = global::Casualty_Radar.Properties.Resources.logo_final;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(1095, 567);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logo.TabIndex = 4;
            this.logo.TabStop = false;
            // 
            // currentlyLoadingLabel
            // 
            this.CurrentlyLoadingLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.CurrentlyLoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.CurrentlyLoadingLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentlyLoadingLabel.Location = new System.Drawing.Point(423, 436);
            this.CurrentlyLoadingLabel.Name = "CurrentlyLoadingLabel";
            this.CurrentlyLoadingLabel.Size = new System.Drawing.Size(246, 38);
            this.CurrentlyLoadingLabel.TabIndex = 6;
            this.CurrentlyLoadingLabel.Text = "Laden..";
            this.CurrentlyLoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreenModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CurrentlyLoadingLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logo);
            this.Name = "SplashScreenModule";
            this.Size = new System.Drawing.Size(1095, 567);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

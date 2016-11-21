using System.Windows.Forms;

namespace KBS_SE3.Modules {
    partial class HomeModule {
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.refreshFeedButton = new System.Windows.Forms.Button();
            this.alertsTitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(639, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(314, 444);
            this.listBox1.TabIndex = 1;
            // 
            // mapBox
            // 
            this.mapBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapBox.Location = new System.Drawing.Point(0, 0);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(641, 480);
            this.mapBox.TabIndex = 2;
            this.mapBox.TabStop = false;
            // 
            // refreshFeedButton
            // 
            this.refreshFeedButton.Location = new System.Drawing.Point(852, 5);
            this.refreshFeedButton.Name = "refreshFeedButton";
            this.refreshFeedButton.Size = new System.Drawing.Size(98, 27);
            this.refreshFeedButton.TabIndex = 3;
            this.refreshFeedButton.Text = "Vernieuwen";
            this.refreshFeedButton.UseVisualStyleBackColor = true;
            this.refreshFeedButton.Click += new System.EventHandler(this.refreshFeedButton_Click);
            // 
            // alertsTitleLabel
            // 
            this.alertsTitleLabel.AutoSize = true;
            this.alertsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleLabel.Location = new System.Drawing.Point(647, 7);
            this.alertsTitleLabel.Name = "alertsTitleLabel";
            this.alertsTitleLabel.Size = new System.Drawing.Size(82, 20);
            this.alertsTitleLabel.TabIndex = 4;
            this.alertsTitleLabel.Text = "Meldingen";
            // 
            // HomeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.alertsTitleLabel);
            this.Controls.Add(this.refreshFeedButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.mapBox);
            this.Name = "HomeModule";
            this.Size = new System.Drawing.Size(953, 480);
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox mapBox;
        private Button refreshFeedButton;
        private Label alertsTitleLabel;
    }
}

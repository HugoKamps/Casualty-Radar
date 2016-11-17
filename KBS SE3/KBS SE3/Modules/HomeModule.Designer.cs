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

            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();

            this.homeLabel = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // homeLabel
            // 

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";

            this.homeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeLabel.Location = new System.Drawing.Point(3, 0);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(100, 23);
            this.homeLabel.TabIndex = 1;
            this.homeLabel.Text = "Home";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(316, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(69, 238);
            this.listBox1.TabIndex = 1;
            // 
            // HomeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.homeLabel);
            this.Name = "HomeModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label homeLabel;

    }
}

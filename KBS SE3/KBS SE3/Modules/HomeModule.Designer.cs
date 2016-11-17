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
            this.mapTest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapTest)).BeginInit();
            this.SuspendLayout();
            // 
            // mapTest
            // 
            this.mapTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.mapTest.Location = new System.Drawing.Point(0, 0);
            this.mapTest.Name = "mapTest";
            this.mapTest.Size = new System.Drawing.Size(700, 480);
            this.mapTest.TabIndex = 2;
            this.mapTest.TabStop = false;
            // 
            // HomeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapTest);
            this.Name = "HomeModule";
            this.Size = new System.Drawing.Size(953, 480);
            ((System.ComponentModel.ISupportInitialize)(this.mapTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapTest;
    }
}

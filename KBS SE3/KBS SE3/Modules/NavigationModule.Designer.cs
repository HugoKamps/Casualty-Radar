namespace KBS_SE3.Modules {
    partial class NavigationModule {
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
            this.routePanel = new System.Windows.Forms.Panel();
            this.routeInfoPanel = new System.Windows.Forms.Panel();
            this.alertInfoPanel = new System.Windows.Forms.Panel();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.routePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // routePanel
            // 
            this.routePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.routePanel.Controls.Add(this.routeInfoPanel);
            this.routePanel.Controls.Add(this.alertInfoPanel);
            this.routePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.routePanel.Location = new System.Drawing.Point(648, 0);
            this.routePanel.Name = "routePanel";
            this.routePanel.Size = new System.Drawing.Size(305, 480);
            this.routePanel.TabIndex = 0;
            // 
            // routeInfoPanel
            // 
            this.routeInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeInfoPanel.Location = new System.Drawing.Point(0, 105);
            this.routeInfoPanel.Name = "routeInfoPanel";
            this.routeInfoPanel.Size = new System.Drawing.Size(305, 375);
            this.routeInfoPanel.TabIndex = 1;
            // 
            // alertInfoPanel
            // 
            this.alertInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.alertInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.alertInfoPanel.Name = "alertInfoPanel";
            this.alertInfoPanel.Size = new System.Drawing.Size(305, 105);
            this.alertInfoPanel.TabIndex = 0;
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(648, 480);
            this.mapPanel.TabIndex = 1;
            // 
            // NavigationModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.routePanel);
            this.Name = "NavigationModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.routePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel routePanel;
        private System.Windows.Forms.Panel routeInfoPanel;
        public System.Windows.Forms.Panel alertInfoPanel;
        private System.Windows.Forms.Panel mapPanel;
    }
}

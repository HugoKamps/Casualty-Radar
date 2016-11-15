namespace KBS_SE3 {
    partial class Container {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.topBar = new System.Windows.Forms.Panel();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.subBar = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.logoTopBar = new System.Windows.Forms.PictureBox();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(73)))), ((int)(((byte)(57)))));
            this.topBar.Controls.Add(this.logoTopBar);
            this.topBar.Controls.Add(this.minimizeBtn);
            this.topBar.Controls.Add(this.closeBtn);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1095, 67);
            this.topBar.TabIndex = 0;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeBtn.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(913, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(91, 67);
            this.minimizeBtn.TabIndex = 1;
            this.minimizeBtn.Text = "-";
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.topBarButtons_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.topBarButtons_MouseLeave);
            // 
            // closeBtn
            // 
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1004, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(91, 67);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.topBarButtons_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.topBarButtons_MouseLeave);
            // 
            // subBar
            // 
            this.subBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(89)))), ((int)(((byte)(71)))));
            this.subBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.subBar.Location = new System.Drawing.Point(0, 67);
            this.subBar.Name = "subBar";
            this.subBar.Size = new System.Drawing.Size(1095, 20);
            this.subBar.TabIndex = 1;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.contentPanel.Location = new System.Drawing.Point(220, 87);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(875, 480);
            this.contentPanel.TabIndex = 2;
            // 
            // menuPanel
            // 
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 87);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(220, 480);
            this.menuPanel.TabIndex = 3;
            // 
            // logoTopBar
            // 
            this.logoTopBar.Image = global::KBS_SE3.Properties.Resources.logo_final;
            this.logoTopBar.Location = new System.Drawing.Point(10, 11);
            this.logoTopBar.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.logoTopBar.Name = "logoTopBar";
            this.logoTopBar.Size = new System.Drawing.Size(287, 50);
            this.logoTopBar.TabIndex = 2;
            this.logoTopBar.TabStop = false;
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1095, 567);
            this.ControlBox = false;
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.subBar);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Container";
            this.Text = "Casualty Radar";
            this.topBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoTopBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Panel subBar;
        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.PictureBox logoTopBar;
    }
}


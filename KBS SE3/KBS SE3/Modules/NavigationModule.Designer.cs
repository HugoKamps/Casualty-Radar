namespace Casualty_Radar.Modules {
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
            this.routeInfoLabelPanel = new System.Windows.Forms.Panel();
            this.routeInfoLabel = new System.Windows.Forms.Label();
            this.alertInfoPanel = new System.Windows.Forms.Panel();
            this.infoTitleLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.alertTypePicturebox = new System.Windows.Forms.PictureBox();
            this.alertInfoLabelPanel = new System.Windows.Forms.Panel();
            this.alertInfoLabel = new System.Windows.Forms.Label();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.routePanel.SuspendLayout();
            this.routeInfoLabelPanel.SuspendLayout();
            this.alertInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertTypePicturebox)).BeginInit();
            this.alertInfoLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // routePanel
            // 
            this.routePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.routePanel.Controls.Add(this.routeInfoPanel);
            this.routePanel.Controls.Add(this.routeInfoLabelPanel);
            this.routePanel.Controls.Add(this.alertInfoPanel);
            this.routePanel.Controls.Add(this.alertInfoLabelPanel);
            this.routePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.routePanel.Location = new System.Drawing.Point(615, 0);
            this.routePanel.Name = "routePanel";
            this.routePanel.Size = new System.Drawing.Size(338, 480);
            this.routePanel.TabIndex = 0;
            // 
            // routeInfoPanel
            // 
            this.routeInfoPanel.BackColor = System.Drawing.Color.White;
            this.routeInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeInfoPanel.Location = new System.Drawing.Point(0, 179);
            this.routeInfoPanel.Name = "routeInfoPanel";
            this.routeInfoPanel.Size = new System.Drawing.Size(338, 301);
            this.routeInfoPanel.TabIndex = 6;
            // 
            // routeInfoLabelPanel
            // 
            this.routeInfoLabelPanel.Controls.Add(this.routeInfoLabel);
            this.routeInfoLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.routeInfoLabelPanel.Location = new System.Drawing.Point(0, 142);
            this.routeInfoLabelPanel.Name = "routeInfoLabelPanel";
            this.routeInfoLabelPanel.Size = new System.Drawing.Size(338, 37);
            this.routeInfoLabelPanel.TabIndex = 5;
            // 
            // routeInfoLabel
            // 
            this.routeInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.routeInfoLabel.ForeColor = System.Drawing.Color.White;
            this.routeInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.routeInfoLabel.Name = "routeInfoLabel";
            this.routeInfoLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.routeInfoLabel.Size = new System.Drawing.Size(338, 37);
            this.routeInfoLabel.TabIndex = 0;
            this.routeInfoLabel.Text = "Routebeschrijving";
            this.routeInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // alertInfoPanel
            // 
            this.alertInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(89)))), ((int)(((byte)(71)))));
            this.alertInfoPanel.Controls.Add(this.infoTitleLabel);
            this.alertInfoPanel.Controls.Add(this.timeLabel);
            this.alertInfoPanel.Controls.Add(this.alertTypePicturebox);
            this.alertInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.alertInfoPanel.Location = new System.Drawing.Point(0, 37);
            this.alertInfoPanel.Name = "alertInfoPanel";
            this.alertInfoPanel.Size = new System.Drawing.Size(338, 105);
            this.alertInfoPanel.TabIndex = 4;
            // 
            // infoTitleLabel
            // 
            this.infoTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.infoTitleLabel.ForeColor = System.Drawing.Color.White;
            this.infoTitleLabel.Location = new System.Drawing.Point(10, 5);
            this.infoTitleLabel.Name = "infoTitleLabel";
            this.infoTitleLabel.Size = new System.Drawing.Size(200, 90);
            this.infoTitleLabel.TabIndex = 0;
            this.infoTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(150, 65);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(200, 30);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alertTypePicturebox
            // 
            this.alertTypePicturebox.Location = new System.Drawing.Point(220, 10);
            this.alertTypePicturebox.Name = "alertTypePicturebox";
            this.alertTypePicturebox.Size = new System.Drawing.Size(60, 60);
            this.alertTypePicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.alertTypePicturebox.TabIndex = 1;
            this.alertTypePicturebox.TabStop = false;
            // 
            // alertInfoLabelPanel
            // 
            this.alertInfoLabelPanel.Controls.Add(this.alertInfoLabel);
            this.alertInfoLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.alertInfoLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.alertInfoLabelPanel.Name = "alertInfoLabelPanel";
            this.alertInfoLabelPanel.Size = new System.Drawing.Size(338, 37);
            this.alertInfoLabelPanel.TabIndex = 3;
            // 
            // alertInfoLabel
            // 
            this.alertInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.alertInfoLabel.ForeColor = System.Drawing.Color.White;
            this.alertInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.alertInfoLabel.Name = "alertInfoLabel";
            this.alertInfoLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.alertInfoLabel.Size = new System.Drawing.Size(338, 37);
            this.alertInfoLabel.TabIndex = 0;
            this.alertInfoLabel.Text = "Informatie ongeval";
            this.alertInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.Color.Silver;
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(615, 480);
            this.mapPanel.TabIndex = 1;
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.Dock = System.Windows.Forms.DockStyle.Left;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 32;
            this.map.MinZoom = 1;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(615, 480);
            this.map.TabIndex = 6;
            this.map.Zoom = 7D;
            // 
            // NavigationModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.map);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.routePanel);
            this.Name = "NavigationModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.routePanel.ResumeLayout(false);
            this.routeInfoLabelPanel.ResumeLayout(false);
            this.alertInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertTypePicturebox)).EndInit();
            this.alertInfoLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel routePanel;
        private System.Windows.Forms.Panel mapPanel;
        public System.Windows.Forms.Panel alertInfoPanel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.PictureBox alertTypePicturebox;
        private System.Windows.Forms.Label infoTitleLabel;
        private System.Windows.Forms.Panel alertInfoLabelPanel;
        private System.Windows.Forms.Label alertInfoLabel;
        private System.Windows.Forms.Panel routeInfoLabelPanel;
        private System.Windows.Forms.Label routeInfoLabel;
        private System.Windows.Forms.Panel routeInfoPanel;
        private GMap.NET.WindowsForms.GMapControl map;
    }
}

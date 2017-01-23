using System.ComponentModel;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace Casualty_Radar.Modules {
    partial class NavigationModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.stepsLoadingLabel = new System.Windows.Forms.Label();
            this.routeInfoPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PageNumber = new System.Windows.Forms.Label();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.routeInfoLabelPanel = new System.Windows.Forms.Panel();
            this.printingPictureBox = new System.Windows.Forms.PictureBox();
            this.routeInfoLabel = new System.Windows.Forms.Label();
            this.alertInfoPanel = new System.Windows.Forms.Panel();
            this.infoTitleLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.alertTypePicturebox = new System.Windows.Forms.PictureBox();
            this.alertInfoLabelPanel = new System.Windows.Forms.Panel();
            this.alertInfoLabel = new System.Windows.Forms.Label();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.mapLoadingOverlay = new System.Windows.Forms.PictureBox();
            this.mapLoadingLabel = new System.Windows.Forms.Label();
            this.loadMapIcon = new System.Windows.Forms.PictureBox();
            this.routePanel.SuspendLayout();
            this.routeInfoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.routeInfoLabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingPictureBox)).BeginInit();
            this.alertInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertTypePicturebox)).BeginInit();
            this.alertInfoLabelPanel.SuspendLayout();
            this.map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapLoadingOverlay)).BeginInit();
            this.mapLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadMapIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // routePanel
            // 
            this.routePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.routePanel.Controls.Add(this.routeInfoPanel);
            this.routePanel.Controls.Add(this.panel2);
            this.routePanel.Controls.Add(this.routeInfoLabelPanel);
            this.routePanel.Controls.Add(this.alertInfoPanel);
            this.routePanel.Controls.Add(this.alertInfoLabelPanel);
            this.routePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.routePanel.Location = new System.Drawing.Point(615, 0);
            this.routePanel.Name = "routePanel";
            this.routePanel.Size = new System.Drawing.Size(338, 480);
            this.routePanel.TabIndex = 0;
            // 
            // stepsLoadingLabel
            // 
            this.stepsLoadingLabel.AutoSize = true;
            this.stepsLoadingLabel.BackColor = System.Drawing.Color.White;
            this.stepsLoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsLoadingLabel.Location = new System.Drawing.Point(88, 97);
            this.stepsLoadingLabel.Name = "stepsLoadingLabel";
            this.stepsLoadingLabel.Size = new System.Drawing.Size(178, 15);
            this.stepsLoadingLabel.TabIndex = 9;
            this.stepsLoadingLabel.Text = "Routestappen wordt berekend..";
            this.stepsLoadingLabel.Visible = false;
            // 
            // routeInfoPanel
            // 
            this.routeInfoPanel.AutoScroll = true;
            this.routeInfoPanel.BackColor = System.Drawing.Color.White;
            this.routeInfoPanel.Controls.Add(this.stepsLoadingLabel);
            this.routeInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeInfoPanel.Location = new System.Drawing.Point(0, 179);
            this.routeInfoPanel.Name = "routeInfoPanel";
            this.routeInfoPanel.Size = new System.Drawing.Size(338, 254);
            this.routeInfoPanel.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(89)))), ((int)(((byte)(71)))));
            this.panel2.Controls.Add(this.PageNumber);
            this.panel2.Controls.Add(this.NextPageButton);
            this.panel2.Controls.Add(this.PreviousPageButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 433);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 47);
            this.panel2.TabIndex = 0;
            // 
            // PageNumber
            // 
            this.PageNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.PageNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.PageNumber.ForeColor = System.Drawing.Color.White;
            this.PageNumber.Location = new System.Drawing.Point(88, 0);
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.Size = new System.Drawing.Size(162, 47);
            this.PageNumber.TabIndex = 3;
            this.PageNumber.Text = "Pagina";
            this.PageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NextPageButton
            // 
            this.NextPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(89)))), ((int)(((byte)(71)))));
            this.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextPageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.NextPageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NextPageButton.FlatAppearance.BorderSize = 0;
            this.NextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.NextPageButton.ForeColor = System.Drawing.Color.White;
            this.NextPageButton.Location = new System.Drawing.Point(250, 0);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(88, 47);
            this.NextPageButton.TabIndex = 1;
            this.NextPageButton.Text = "Volgende";
            this.NextPageButton.UseVisualStyleBackColor = false;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(89)))), ((int)(((byte)(71)))));
            this.PreviousPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousPageButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.PreviousPageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PreviousPageButton.FlatAppearance.BorderSize = 0;
            this.PreviousPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.PreviousPageButton.ForeColor = System.Drawing.Color.White;
            this.PreviousPageButton.Location = new System.Drawing.Point(0, 0);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(88, 47);
            this.PreviousPageButton.TabIndex = 0;
            this.PreviousPageButton.Text = "Vorige";
            this.PreviousPageButton.UseVisualStyleBackColor = false;
            this.PreviousPageButton.Click += new System.EventHandler(this.PreviousPageButton_Click);
            // 
            // routeInfoLabelPanel
            // 
            this.routeInfoLabelPanel.Controls.Add(this.printingPictureBox);
            this.routeInfoLabelPanel.Controls.Add(this.routeInfoLabel);
            this.routeInfoLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.routeInfoLabelPanel.Location = new System.Drawing.Point(0, 142);
            this.routeInfoLabelPanel.Name = "routeInfoLabelPanel";
            this.routeInfoLabelPanel.Size = new System.Drawing.Size(338, 37);
            this.routeInfoLabelPanel.TabIndex = 5;
            // 
            // printingPictureBox
            // 
            this.printingPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printingPictureBox.Image = global::Casualty_Radar.Properties.Resources.printing_icon;
            this.printingPictureBox.Location = new System.Drawing.Point(301, 4);
            this.printingPictureBox.Name = "printingPictureBox";
            this.printingPictureBox.Size = new System.Drawing.Size(30, 30);
            this.printingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.printingPictureBox.TabIndex = 0;
            this.printingPictureBox.TabStop = false;
            this.printingPictureBox.Click += new System.EventHandler(this.printingPictureBox_Click);
            // 
            // routeInfoLabel
            // 
            this.routeInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
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
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
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
            this.alertInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
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
            this.mapPanel.Location = new System.Drawing.Point(615, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(0, 480);
            this.mapPanel.TabIndex = 1;
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.Controls.Add(this.mapLoadingOverlay);
            this.map.Dock = System.Windows.Forms.DockStyle.Left;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 20;
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
            // mapLoadingOverlay
            // 
            this.mapLoadingOverlay.BackColor = System.Drawing.Color.Transparent;
            this.mapLoadingOverlay.BackgroundImage = global::Casualty_Radar.Properties.Resources.load_map_overlay;
            this.mapLoadingOverlay.Controls.Add(this.mapLoadingLabel);
            this.mapLoadingOverlay.Controls.Add(this.loadMapIcon);
            this.mapLoadingOverlay.Image = global::Casualty_Radar.Properties.Resources.load_map_overlay;
            this.mapLoadingOverlay.InitialImage = null;
            this.mapLoadingOverlay.Location = new System.Drawing.Point(0, 0);
            this.mapLoadingOverlay.Name = "mapLoadingOverlay";
            this.mapLoadingOverlay.Size = new System.Drawing.Size(615, 480);
            this.mapLoadingOverlay.TabIndex = 7;
            this.mapLoadingOverlay.TabStop = false;
            this.mapLoadingOverlay.Visible = false;
            // 
            // mapLoadingLabel
            // 
            this.mapLoadingLabel.AutoSize = true;
            this.mapLoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapLoadingLabel.Location = new System.Drawing.Point(245, 256);
            this.mapLoadingLabel.Name = "mapLoadingLabel";
            this.mapLoadingLabel.Size = new System.Drawing.Size(134, 15);
            this.mapLoadingLabel.TabIndex = 8;
            this.mapLoadingLabel.Text = "Route wordt berekend..";
            // 
            // loadMapIcon
            // 
            this.loadMapIcon.BackColor = System.Drawing.Color.Transparent;
            this.loadMapIcon.Image = global::Casualty_Radar.Properties.Resources.load_map;
            this.loadMapIcon.Location = new System.Drawing.Point(280, 177);
            this.loadMapIcon.Name = "loadMapIcon";
            this.loadMapIcon.Size = new System.Drawing.Size(62, 64);
            this.loadMapIcon.TabIndex = 7;
            this.loadMapIcon.TabStop = false;
            // 
            // NavigationModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.routePanel);
            this.Controls.Add(this.map);
            this.Name = "NavigationModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.routePanel.ResumeLayout(false);
            this.routeInfoPanel.ResumeLayout(false);
            this.routeInfoPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.routeInfoLabelPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingPictureBox)).EndInit();
            this.alertInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertTypePicturebox)).EndInit();
            this.alertInfoLabelPanel.ResumeLayout(false);
            this.map.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapLoadingOverlay)).EndInit();
            this.mapLoadingOverlay.ResumeLayout(false);
            this.mapLoadingOverlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadMapIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel routePanel;
        private Panel mapPanel;
        public Panel alertInfoPanel;
        private Label timeLabel;
        private PictureBox alertTypePicturebox;
        private Label infoTitleLabel;
        private Panel alertInfoLabelPanel;
        private Label alertInfoLabel;
        private Panel routeInfoLabelPanel;
        private Label routeInfoLabel;
        private Panel routeInfoPanel;
        private GMapControl map;
        private PictureBox printingPictureBox;
        private Panel panel2;
        private Button NextPageButton;
        private Button PreviousPageButton;
        private Label PageNumber;
        private PictureBox mapLoadingOverlay;
        private PictureBox loadMapIcon;
        private Label mapLoadingLabel;
        private Label stepsLoadingLabel;
    }
}

﻿using System.Windows.Forms;

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
            this.feedListBox = new System.Windows.Forms.ListBox();
            this.alertsTitleLabel = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.refreshPanel = new System.Windows.Forms.Panel();
            this.alertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.refreshFeedButton = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.legendaPanel = new System.Windows.Forms.Panel();
            this.yourLocationLabel = new System.Windows.Forms.Label();
            this.fireFighterLabel = new System.Windows.Forms.Label();
            this.blueMarkerPicturebox = new System.Windows.Forms.PictureBox();
            this.redMarkerPicturebox = new System.Windows.Forms.PictureBox();
            this.yellowMarkerPicturebox = new System.Windows.Forms.PictureBox();
            this.ambulanceLabel = new System.Windows.Forms.Label();
            this.refreshPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.legendaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueMarkerPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redMarkerPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowMarkerPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // feedListBox
            // 
            this.feedListBox.BackColor = System.Drawing.Color.White;
            this.feedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedListBox.FormattingEnabled = true;
            this.feedListBox.ItemHeight = 20;
            this.feedListBox.Location = new System.Drawing.Point(0, 37);
            this.feedListBox.Name = "feedListBox";
            this.feedListBox.Size = new System.Drawing.Size(338, 443);
            this.feedListBox.TabIndex = 1;
            // 
            // alertsTitleLabel
            // 
            this.alertsTitleLabel.BackColor = System.Drawing.Color.White;
            this.alertsTitleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.alertsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.alertsTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.alertsTitleLabel.Name = "alertsTitleLabel";
            this.alertsTitleLabel.Size = new System.Drawing.Size(248, 37);
            this.alertsTitleLabel.TabIndex = 4;
            this.alertsTitleLabel.Text = "Meldingen";
            this.alertsTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.map.MaxZoom = 10;
            this.map.MinZoom = 7;
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
            this.map.TabIndex = 5;
            this.map.Zoom = 7D;
            // 
            // refreshPanel
            // 
            this.refreshPanel.BackColor = System.Drawing.Color.White;
            this.refreshPanel.Controls.Add(this.alertTypeComboBox);
            this.refreshPanel.Controls.Add(this.refreshFeedButton);
            this.refreshPanel.Controls.Add(this.alertsTitleLabel);
            this.refreshPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshPanel.Location = new System.Drawing.Point(0, 0);
            this.refreshPanel.Name = "refreshPanel";
            this.refreshPanel.Size = new System.Drawing.Size(338, 37);
            this.refreshPanel.TabIndex = 6;
            // 
            // alertTypeComboBox
            // 
            this.alertTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertTypeComboBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.alertTypeComboBox.FormattingEnabled = true;
            this.alertTypeComboBox.Items.AddRange(new object[] {
            "Alle",
            "Ambulance",
            "Brandweer"});
            this.alertTypeComboBox.Location = new System.Drawing.Point(197, 5);
            this.alertTypeComboBox.Name = "alertTypeComboBox";
            this.alertTypeComboBox.Size = new System.Drawing.Size(101, 28);
            this.alertTypeComboBox.TabIndex = 6;
            this.alertTypeComboBox.Text = "Alle";
            this.alertTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.alertTypeComboBox_SelectedIndexChanged);
            // 
            // refreshFeedButton
            // 
            this.refreshFeedButton.BackColor = System.Drawing.Color.White;
            this.refreshFeedButton.Image = global::KBS_SE3.Properties.Resources.refresh_icon;
            this.refreshFeedButton.Location = new System.Drawing.Point(304, 3);
            this.refreshFeedButton.Name = "refreshFeedButton";
            this.refreshFeedButton.Size = new System.Drawing.Size(31, 31);
            this.refreshFeedButton.TabIndex = 5;
            this.refreshFeedButton.TabStop = false;
            this.refreshFeedButton.Click += new System.EventHandler(this.refreshFeedButton_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.feedListBox);
            this.rightPanel.Controls.Add(this.refreshPanel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(615, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(338, 480);
            this.rightPanel.TabIndex = 7;
            // 
            // legendaPanel
            // 
            this.legendaPanel.BackColor = System.Drawing.Color.White;
            this.legendaPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.legendaPanel.Controls.Add(this.yourLocationLabel);
            this.legendaPanel.Controls.Add(this.fireFighterLabel);
            this.legendaPanel.Controls.Add(this.blueMarkerPicturebox);
            this.legendaPanel.Controls.Add(this.redMarkerPicturebox);
            this.legendaPanel.Controls.Add(this.yellowMarkerPicturebox);
            this.legendaPanel.Controls.Add(this.ambulanceLabel);
            this.legendaPanel.ForeColor = System.Drawing.Color.White;
            this.legendaPanel.Location = new System.Drawing.Point(12, 15);
            this.legendaPanel.Name = "legendaPanel";
            this.legendaPanel.Size = new System.Drawing.Size(120, 116);
            this.legendaPanel.TabIndex = 14;
            // 
            // yourLocationLabel
            // 
            this.yourLocationLabel.AutoSize = true;
            this.yourLocationLabel.BackColor = System.Drawing.Color.Transparent;
            this.yourLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.yourLocationLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.yourLocationLabel.Location = new System.Drawing.Point(37, 89);
            this.yourLocationLabel.Name = "yourLocationLabel";
            this.yourLocationLabel.Size = new System.Drawing.Size(74, 15);
            this.yourLocationLabel.TabIndex = 19;
            this.yourLocationLabel.Text = "Uw locatie";
            // 
            // fireFighterLabel
            // 
            this.fireFighterLabel.AutoSize = true;
            this.fireFighterLabel.BackColor = System.Drawing.Color.Transparent;
            this.fireFighterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.fireFighterLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fireFighterLabel.Location = new System.Drawing.Point(37, 51);
            this.fireFighterLabel.Name = "fireFighterLabel";
            this.fireFighterLabel.Size = new System.Drawing.Size(76, 15);
            this.fireFighterLabel.TabIndex = 18;
            this.fireFighterLabel.Text = "Brandweer";
            // 
            // blueMarkerPicturebox
            // 
            this.blueMarkerPicturebox.Image = global::KBS_SE3.Properties.Resources.marker_icon_blue;
            this.blueMarkerPicturebox.Location = new System.Drawing.Point(3, 79);
            this.blueMarkerPicturebox.Name = "blueMarkerPicturebox";
            this.blueMarkerPicturebox.Size = new System.Drawing.Size(28, 32);
            this.blueMarkerPicturebox.TabIndex = 17;
            this.blueMarkerPicturebox.TabStop = false;
            // 
            // redMarkerPicturebox
            // 
            this.redMarkerPicturebox.Image = global::KBS_SE3.Properties.Resources.marker_icon_red;
            this.redMarkerPicturebox.Location = new System.Drawing.Point(3, 41);
            this.redMarkerPicturebox.Name = "redMarkerPicturebox";
            this.redMarkerPicturebox.Size = new System.Drawing.Size(28, 32);
            this.redMarkerPicturebox.TabIndex = 16;
            this.redMarkerPicturebox.TabStop = false;
            // 
            // yellowMarkerPicturebox
            // 
            this.yellowMarkerPicturebox.Image = global::KBS_SE3.Properties.Resources.marker_icon_yellow;
            this.yellowMarkerPicturebox.Location = new System.Drawing.Point(3, 3);
            this.yellowMarkerPicturebox.Name = "yellowMarkerPicturebox";
            this.yellowMarkerPicturebox.Size = new System.Drawing.Size(28, 32);
            this.yellowMarkerPicturebox.TabIndex = 15;
            this.yellowMarkerPicturebox.TabStop = false;
            // 
            // ambulanceLabel
            // 
            this.ambulanceLabel.AutoSize = true;
            this.ambulanceLabel.BackColor = System.Drawing.Color.Transparent;
            this.ambulanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.ambulanceLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ambulanceLabel.Location = new System.Drawing.Point(37, 13);
            this.ambulanceLabel.Name = "ambulanceLabel";
            this.ambulanceLabel.Size = new System.Drawing.Size(78, 15);
            this.ambulanceLabel.TabIndex = 14;
            this.ambulanceLabel.Text = "Ambulance";
            // 
            // HomeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.legendaPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.map);
            this.Name = "HomeModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.refreshPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.legendaPanel.ResumeLayout(false);
            this.legendaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueMarkerPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redMarkerPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowMarkerPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListBox feedListBox;
        private Label alertsTitleLabel;
        private GMap.NET.WindowsForms.GMapControl map;
        private Panel refreshPanel;
        private Panel rightPanel;
        private PictureBox refreshFeedButton;
        public ComboBox alertTypeComboBox;
        private Panel legendaPanel;
        private Label yourLocationLabel;
        private Label fireFighterLabel;
        private PictureBox blueMarkerPicturebox;
        private PictureBox redMarkerPicturebox;
        private PictureBox yellowMarkerPicturebox;
        private Label ambulanceLabel;
    }
}

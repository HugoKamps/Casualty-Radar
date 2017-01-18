using System.Windows.Forms;

namespace Casualty_Radar.Modules {
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
            this.alertsTitleLabel = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.refreshPanel = new System.Windows.Forms.Panel();
            this.alertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.refreshFeedButton = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.loadFeedLabel = new System.Windows.Forms.Label();
            this.loadFeedPictureBox = new System.Windows.Forms.PictureBox();
            this.feedPanel = new System.Windows.Forms.Panel();
            this.legendaPanel = new System.Windows.Forms.Panel();
            this.yourLocationLabel = new System.Windows.Forms.Label();
            this.fireFighterLabel = new System.Windows.Forms.Label();
            this.blueMarkerPicturebox = new System.Windows.Forms.PictureBox();
            this.redMarkerPicturebox = new System.Windows.Forms.PictureBox();
            this.yellowMarkerPicturebox = new System.Windows.Forms.PictureBox();
            this.ambulanceLabel = new System.Windows.Forms.Label();
            this.navigationBtn = new System.Windows.Forms.Button();
            this.noAlertsLabel = new System.Windows.Forms.Label();
            this.refreshPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadFeedPictureBox)).BeginInit();
            this.feedPanel.SuspendLayout();
            this.legendaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueMarkerPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redMarkerPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowMarkerPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // alertsTitleLabel
            // 
            this.alertsTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.alertsTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleLabel.ForeColor = System.Drawing.Color.White;
            this.alertsTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.alertsTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.alertsTitleLabel.Name = "alertsTitleLabel";
            this.alertsTitleLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.alertsTitleLabel.Size = new System.Drawing.Size(309, 37);
            this.alertsTitleLabel.TabIndex = 4;
            this.alertsTitleLabel.Text = "Meldingen";
            this.alertsTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.map.TabIndex = 5;
            this.map.Zoom = 7D;
            // 
            // refreshPanel
            // 
            this.refreshPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.refreshPanel.Controls.Add(this.alertTypeComboBox);
            this.refreshPanel.Controls.Add(this.alertsTitleLabel);
            this.refreshPanel.Controls.Add(this.refreshFeedButton);
            this.refreshPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshPanel.Location = new System.Drawing.Point(0, 0);
            this.refreshPanel.Name = "refreshPanel";
            this.refreshPanel.Size = new System.Drawing.Size(338, 37);
            this.refreshPanel.TabIndex = 6;
            // 
            // alertTypeComboBox
            // 
            this.alertTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.alertTypeComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alertTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alertTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alertTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertTypeComboBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.alertTypeComboBox.FormattingEnabled = true;
            this.alertTypeComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.alertTypeComboBox.Items.AddRange(new object[] {
            "Alle",
            "Ambulance",
            "Brandweer"});
            this.alertTypeComboBox.Location = new System.Drawing.Point(174, 5);
            this.alertTypeComboBox.Name = "alertTypeComboBox";
            this.alertTypeComboBox.Size = new System.Drawing.Size(129, 26);
            this.alertTypeComboBox.TabIndex = 6;
            this.alertTypeComboBox.SelectedIndex = 0;
            this.alertTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.alertTypeComboBox_SelectedIndexChanged);
            // 
            // refreshFeedButton
            // 
            this.refreshFeedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.refreshFeedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshFeedButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.refreshFeedButton.Image = global::Casualty_Radar.Properties.Resources.refresh_icon;
            this.refreshFeedButton.Location = new System.Drawing.Point(309, 0);
            this.refreshFeedButton.Name = "refreshFeedButton";
            this.refreshFeedButton.Size = new System.Drawing.Size(29, 37);
            this.refreshFeedButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.refreshFeedButton.TabIndex = 5;
            this.refreshFeedButton.TabStop = false;
            this.refreshFeedButton.Click += new System.EventHandler(this.refreshFeedButton_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.loadFeedLabel);
            this.rightPanel.Controls.Add(this.loadFeedPictureBox);
            this.rightPanel.Controls.Add(this.feedPanel);
            this.rightPanel.Controls.Add(this.refreshPanel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(615, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(338, 480);
            this.rightPanel.TabIndex = 7;
            // 
            // loadFeedLabel
            // 
            this.loadFeedLabel.AutoSize = true;
            this.loadFeedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadFeedLabel.Location = new System.Drawing.Point(92, 200);
            this.loadFeedLabel.Name = "loadFeedLabel";
            this.loadFeedLabel.Size = new System.Drawing.Size(156, 13);
            this.loadFeedLabel.TabIndex = 0;
            this.loadFeedLabel.Text = "Meldingen worden opgehaald...";
            // 
            // loadFeedPictureBox
            // 
            this.loadFeedPictureBox.Image = global::Casualty_Radar.Properties.Resources.load_feed;
            this.loadFeedPictureBox.Location = new System.Drawing.Point(118, 91);
            this.loadFeedPictureBox.Name = "loadFeedPictureBox";
            this.loadFeedPictureBox.Size = new System.Drawing.Size(100, 99);
            this.loadFeedPictureBox.TabIndex = 16;
            this.loadFeedPictureBox.TabStop = false;
            // 
            // feedPanel
            // 
            this.feedPanel.BackColor = System.Drawing.Color.White;
            this.feedPanel.Controls.Add(this.noAlertsLabel);
            this.feedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedPanel.Location = new System.Drawing.Point(0, 37);
            this.feedPanel.Name = "feedPanel";
            this.feedPanel.Size = new System.Drawing.Size(338, 443);
            this.feedPanel.TabIndex = 7;
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
            this.blueMarkerPicturebox.Image = global::Casualty_Radar.Properties.Resources.marker_icon_blue;
            this.blueMarkerPicturebox.Location = new System.Drawing.Point(3, 79);
            this.blueMarkerPicturebox.Name = "blueMarkerPicturebox";
            this.blueMarkerPicturebox.Size = new System.Drawing.Size(28, 32);
            this.blueMarkerPicturebox.TabIndex = 17;
            this.blueMarkerPicturebox.TabStop = false;
            // 
            // redMarkerPicturebox
            // 
            this.redMarkerPicturebox.Image = global::Casualty_Radar.Properties.Resources.marker_icon_red;
            this.redMarkerPicturebox.Location = new System.Drawing.Point(3, 41);
            this.redMarkerPicturebox.Name = "redMarkerPicturebox";
            this.redMarkerPicturebox.Size = new System.Drawing.Size(28, 32);
            this.redMarkerPicturebox.TabIndex = 16;
            this.redMarkerPicturebox.TabStop = false;
            // 
            // yellowMarkerPicturebox
            // 
            this.yellowMarkerPicturebox.Image = global::Casualty_Radar.Properties.Resources.marker_icon_yellow;
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
            // navigationBtn
            // 
            this.navigationBtn.BackColor = System.Drawing.Color.Gray;
            this.navigationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navigationBtn.Enabled = false;
            this.navigationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navigationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.navigationBtn.ForeColor = System.Drawing.Color.White;
            this.navigationBtn.Location = new System.Drawing.Point(12, 435);
            this.navigationBtn.Name = "navigationBtn";
            this.navigationBtn.Size = new System.Drawing.Size(120, 30);
            this.navigationBtn.TabIndex = 15;
            this.navigationBtn.Text = "Bereken route";
            this.navigationBtn.UseVisualStyleBackColor = false;
            this.navigationBtn.EnabledChanged += new System.EventHandler(this.navigationBtn_EnabledChanged);
            this.navigationBtn.Click += new System.EventHandler(this.navigationBtn_Click);
            // 
            // noAlertsLabel
            // 
            this.noAlertsLabel.AutoSize = true;
            this.noAlertsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.noAlertsLabel.Location = new System.Drawing.Point(83, 20);
            this.noAlertsLabel.Name = "noAlertsLabel";
            this.noAlertsLabel.Size = new System.Drawing.Size(174, 13);
            this.noAlertsLabel.TabIndex = 17;
            this.noAlertsLabel.Text = "Er zijn geen ongevallen gevonden..";
            // 
            // HomeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationBtn);
            this.Controls.Add(this.legendaPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.map);
            this.Name = "HomeModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.Load += new System.EventHandler(this.HomeModule_Load);
            this.refreshPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadFeedPictureBox)).EndInit();
            this.feedPanel.ResumeLayout(false);
            this.feedPanel.PerformLayout();
            this.legendaPanel.ResumeLayout(false);
            this.legendaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueMarkerPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redMarkerPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowMarkerPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public GMap.NET.WindowsForms.GMapControl map;
        private Panel refreshPanel;
        private Panel rightPanel;
        public PictureBox refreshFeedButton;
        public ComboBox alertTypeComboBox;
        public Panel feedPanel;
        private Panel legendaPanel;
        private Label yourLocationLabel;
        private Label fireFighterLabel;
        private PictureBox blueMarkerPicturebox;
        private PictureBox redMarkerPicturebox;
        private PictureBox yellowMarkerPicturebox;
        private Label ambulanceLabel;
        public Button navigationBtn;
        public Label alertsTitleLabel;
        public PictureBox loadFeedPictureBox;
        public Label loadFeedLabel;
        public Label noAlertsLabel;
    }
}

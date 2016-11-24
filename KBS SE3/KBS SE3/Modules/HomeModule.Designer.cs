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
            this.alertsTitleLabel = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.refreshPanel = new System.Windows.Forms.Panel();
            this.alertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.refreshFeedButton = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.feedPanel = new System.Windows.Forms.Panel();
            this.refreshPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.alertTypeComboBox.Location = new System.Drawing.Point(200, 6);
            this.alertTypeComboBox.Name = "alertTypeComboBox";
            this.alertTypeComboBox.Size = new System.Drawing.Size(101, 28);
            this.alertTypeComboBox.TabIndex = 6;
            this.alertTypeComboBox.Text = "Alle";
            this.alertTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.alertTypeComboBox_SelectedIndexChanged);
            // 
            // refreshFeedButton
            // 
            this.refreshFeedButton.BackColor = System.Drawing.Color.White;
            this.refreshFeedButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.refreshFeedButton.Image = global::KBS_SE3.Properties.Resources.refresh_icon;
            this.refreshFeedButton.Location = new System.Drawing.Point(307, 0);
            this.refreshFeedButton.Name = "refreshFeedButton";
            this.refreshFeedButton.Size = new System.Drawing.Size(31, 37);
            this.refreshFeedButton.TabIndex = 5;
            this.refreshFeedButton.TabStop = false;
            this.refreshFeedButton.Click += new System.EventHandler(this.refreshFeedButton_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.feedPanel);
            this.rightPanel.Controls.Add(this.refreshPanel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(615, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(338, 480);
            this.rightPanel.TabIndex = 7;
            // 
            // feedPanel
            // 
            this.feedPanel.BackColor = System.Drawing.Color.White;
            this.feedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedPanel.Location = new System.Drawing.Point(0, 37);
            this.feedPanel.Name = "feedPanel";
            this.feedPanel.Size = new System.Drawing.Size(338, 443);
            this.feedPanel.TabIndex = 7;
            // 
            // HomeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.map);
            this.Name = "HomeModule";
            this.Size = new System.Drawing.Size(953, 480);
            this.refreshPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label alertsTitleLabel;
        private GMap.NET.WindowsForms.GMapControl map;
        private Panel refreshPanel;
        private Panel rightPanel;
        private PictureBox refreshFeedButton;
        public ComboBox alertTypeComboBox;
        public Panel feedPanel;
    }
}

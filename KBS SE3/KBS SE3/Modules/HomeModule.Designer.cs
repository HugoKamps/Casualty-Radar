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
            this.feedListBox = new System.Windows.Forms.ListBox();
            this.alertsTitleLabel = new System.Windows.Forms.Label();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.refreshPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.refreshFeedButton = new System.Windows.Forms.PictureBox();
            this.refreshPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).BeginInit();
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
            this.alertsTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertsTitleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.alertsTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.alertsTitleLabel.Name = "alertsTitleLabel";
            this.alertsTitleLabel.Size = new System.Drawing.Size(338, 37);
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
            this.refreshPanel.Controls.Add(this.refreshFeedButton);
            this.refreshPanel.Controls.Add(this.alertsTitleLabel);
            this.refreshPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshPanel.Location = new System.Drawing.Point(0, 0);
            this.refreshPanel.Name = "refreshPanel";
            this.refreshPanel.Size = new System.Drawing.Size(338, 37);
            this.refreshPanel.TabIndex = 6;
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
            // refreshFeedButton
            // 
            this.refreshFeedButton.BackColor = System.Drawing.Color.White;
            this.refreshFeedButton.Image = global::KBS_SE3.Properties.Resources.refresh_icon;
            this.refreshFeedButton.Location = new System.Drawing.Point(307, 3);
            this.refreshFeedButton.Name = "refreshFeedButton";
            this.refreshFeedButton.Size = new System.Drawing.Size(28, 29);
            this.refreshFeedButton.TabIndex = 5;
            this.refreshFeedButton.TabStop = false;
            this.refreshFeedButton.Click += new System.EventHandler(this.refreshFeedButton_Click);
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
            this.rightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshFeedButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListBox feedListBox;
        private Label alertsTitleLabel;
        private GMap.NET.WindowsForms.GMapControl map;
        private Panel refreshPanel;
        private Panel rightPanel;
        private PictureBox refreshFeedButton;
    }
}

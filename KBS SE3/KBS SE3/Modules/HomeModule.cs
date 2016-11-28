using System;
using System.Windows.Forms;
using GMap.NET;
using KBS_SE3.Core;
using KBS_SE3.Models;
using System.Drawing;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule
    {
        private readonly LocationManager _locationManager;
        public HomeModule() {
            InitializeComponent();
            _locationManager = new LocationManager(map);
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));
        }

        private void refreshFeedButton_Click(object sender, EventArgs e) {
            Feed.GetInstance().UpdateFeed();
            _locationManager.GetMap(false);
        }

        private void alertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Feed.GetInstance().UpdateAlerts();
            _locationManager.GetMap(false);
        }

        private void refreshFeedButton_MouseDown(object sender, MouseEventArgs e)
        {
            refreshFeedButton.Image = resizeImage(refreshFeedButton.Image, new Size(23, 23));
            refreshFeedButton.Left = refreshFeedButton.Left + 2;
            refreshFeedButton.Top = refreshFeedButton.Top + 2;
            refreshFeedButton.Width = 23;
            refreshFeedButton.Height = 23;
            
        }

        private void refreshFeedButton_MouseUp(object sender, MouseEventArgs e)
        {
            refreshFeedButton.Image = KBS_SE3.Properties.Resources.refresh_icon;
            refreshFeedButton.Width = 25;
            refreshFeedButton.Height = 25;
            refreshFeedButton.Left = refreshFeedButton.Left - 2;
            refreshFeedButton.Top = refreshFeedButton.Top - 2;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}


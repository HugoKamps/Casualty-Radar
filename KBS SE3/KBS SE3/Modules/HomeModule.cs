using System;
using System.Drawing;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Properties;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule {
        private readonly LocationManager _locationManager;
        public HomeModule() {
            InitializeComponent();
            _locationManager = new LocationManager(map);
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));
        }

        public static Image ResizeImage(Image imgToResize, Size size) => new Bitmap(imgToResize, size);

        private void refreshFeedButton_Click(object sender, EventArgs e) {
            Feed.GetInstance().UpdateFeed();
            _locationManager.GetMap(false);
        }

        private void alertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Feed.GetInstance().UpdateAlerts();
            _locationManager.GetMap(false);
        }

        private void navigationBtn_Click(object sender, EventArgs e) {
            var selectedPanel = Feed.GetInstance().GetSelectedPanel;
            var alertPanels = Feed.GetInstance().GetAlertPanels;
            Alert selectedAlert = null;

            for (var i = 0; i < alertPanels.Count; i++) {
                if (selectedPanel != alertPanels[i]) continue;
                selectedAlert = Feed.GetInstance().GetAlerts()[i];
                break;
            }

            var navigationModule = (NavigationModule)ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule));
            if (selectedAlert != null) navigationModule.SetAlertInfo(selectedAlert.Title, selectedAlert.Info, selectedAlert.Type, selectedAlert.PubDate.TimeOfDay.ToString());
            ModuleManager.GetInstance().UpdateModule(KBS_SE3.Container.GetInstance().breadCrumbStart, KBS_SE3.Container.GetInstance().contentPanel, navigationModule);
        }

        private void navigationBtn_EnabledChanged(object sender, EventArgs e) {
            var button = (Button)sender;
            button.ForeColor = Color.White;
            button.BackColor = button.Enabled ? Color.FromArgb(210, 73, 57) : Color.Gray;
        }

        private void refreshFeedButton_MouseDown(object sender, MouseEventArgs e) {
            refreshFeedButton.Image = ResizeImage(refreshFeedButton.Image, new Size(23, 23));
            refreshFeedButton.Left = refreshFeedButton.Left + 2;
            refreshFeedButton.Top = refreshFeedButton.Top + 2;
            refreshFeedButton.Width = 23;
            refreshFeedButton.Height = 23;

        }

        private void refreshFeedButton_MouseUp(object sender, MouseEventArgs e) {
            refreshFeedButton.Image = Resources.refresh_icon;
            refreshFeedButton.Width = 25;
            refreshFeedButton.Height = 25;
            refreshFeedButton.Left = refreshFeedButton.Left - 2;
            refreshFeedButton.Top = refreshFeedButton.Top - 2;
        }

    }
}


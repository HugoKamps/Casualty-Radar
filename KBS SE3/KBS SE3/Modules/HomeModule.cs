using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using System.Threading.Tasks;
using KBS_SE3.Properties;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule
    {
        private LocationManager _locationManager;
        private FeedTicker _feedTicker;
        private bool _isRefreshing = false;

        public HomeModule() {
            InitializeComponent();
        }

        public bool IsRefreshing {
            get { return _isRefreshing; }
            set { _isRefreshing = value; }
        }

        public FeedTicker FeedTicker {
            get { return _feedTicker; }
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));
        }

        public LocationManager GetLocationManager() => _locationManager;

        private void refreshFeedButton_Click(object sender, EventArgs e) {
            if (!_isRefreshing) {
                _feedTicker.StopTimerIfEnabled();
                Feed.GetInstance().UpdateFeed();
                _feedTicker.StartTimerIfEnabled();
            }
        }

        private void alertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Feed.GetInstance().UpdateAlerts();
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

        private void navigationBtn_EnabledChanged(object sender, EventArgs e)
        {
            var button = (Button) sender;
            button.ForeColor = Color.White;
            button.BackColor = button.Enabled ? Color.FromArgb(210, 73, 57) : Color.Gray;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public void FormLoaded(object sender, EventArgs e)
        {
            var bw = new BackgroundWorker();
            if (_locationManager == null)
            {
                // Load the feed & instantiate the location manager
                _locationManager = new LocationManager(map);
                int tickTime = Settings.Default.feedTickerTime * 1000;
                _feedTicker = new FeedTicker(tickTime, Feed.GetInstance());
            }
        }
    }
}


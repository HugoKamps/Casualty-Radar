using System;
using System.Device.Location;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Properties;

namespace KBS_SE3.Modules {
    partial class HomeModule : UserControl, IModule {
        private LocationManager _locationManager;
        private bool _hasLocationservice;    //Indicates if the user has GPS enabled or not
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

        /* 
        Function that displays a map in the HomeModule. First it checks if the user has a working internet connection. 
        It creates a marker on the user's current location and on all the incidents coming from the Feed.
        */
        public void GetAlertsMap(bool hasLocationService) {
            if (ConnectionUtil.HasInternetConnection()) {
                map.Overlays.Clear();
                map.ShowCenter = false;
                map.MapProvider = GoogleMapProvider.Instance;
                map.DragButton = MouseButtons.Left;
                GMaps.Instance.Mode = AccessMode.ServerOnly;
                var markersOverlay = new GMapOverlay("markers");
                map.Overlays.Add(markersOverlay);

                //If the user has location services enabled it uses the lat and lng that the GPS returns. If not it uses the user's standard location
                if (hasLocationService) {
                    markersOverlay.Markers.Add(_locationManager.CreateMarker(_locationManager.GetCurrentLatitude(), _locationManager.GetCurrentLongitude(), 0));
                } else {
                    _locationManager.SetCoordinatesByLocationSetting();
                    markersOverlay.Markers.Add(_locationManager.CreateMarker(_locationManager.GetCurrentLatitude(), _locationManager.GetCurrentLongitude(), 0));
                }

                foreach (var alert in Feed.GetInstance().GetAlerts()) {
                    var type = alert.Type == 1 ? 1 : 2;
                    markersOverlay.Markers.Add(_locationManager.CreateMarker(alert.Lat, alert.Lng, type));
                }
            }
        }

        public static Image ResizeImage(Image imgToResize, Size size) => new Bitmap(imgToResize, size);

        //Keeps track of the user's current location. Everytime the location changes the map is renewed and the coordinates are updated
        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            _locationManager._currentLatitude = e.Position.Location.Latitude;
            _locationManager._currentLongitude = e.Position.Location.Longitude;
            //GetAlertsMap(true);
        }

        //Keeps track of the watcher's status. If the user has no GPS or has shut off the GPS the user's default location will be used
        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e) {
            switch (e.Status) {
                case GeoPositionStatus.Initializing:
                    _hasLocationservice = true;
                    break;

                case GeoPositionStatus.Ready:
                    _hasLocationservice = true;
                    break;

                case GeoPositionStatus.NoData:
                    _hasLocationservice = false;
                    break;

                case GeoPositionStatus.Disabled:
                    _hasLocationservice = false;
                    break;
            }
            //GetAlertsMap(_hasLocationservice);
        }

        public LocationManager GetLocationManager() {
            if (_locationManager == null) {
                _locationManager = new LocationManager();
                LoadLocationManager();
            }
            return _locationManager;
        }

        public LocationManager LocationManager {
            set { _locationManager = value; }
        }

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
            if (selectedAlert != null) navigationModule.SetAlertInfo(selectedAlert.Title, selectedAlert.Info, selectedAlert.Type, selectedAlert.PubDate.TimeOfDay.ToString(), _locationManager.GetLocationPoint(), new PointLatLng(selectedAlert.Lat, selectedAlert.Lng));
            ModuleManager.GetInstance().UpdateModule(navigationModule);
        }

        private void navigationBtn_EnabledChanged(object sender, EventArgs e) {
            var button = (Button)sender;
            button.ForeColor = Color.White;
            button.BackColor = button.Enabled ? Color.FromArgb(210, 73, 57) : Color.Gray;
        }

        public void HomeModule_Load(object sender, EventArgs e) {
            if (_locationManager == null) {
                // Load the feed & instantiate the location manager
                int tickTime = Settings.Default.feedTickerTime * 1000;
                _feedTicker = new FeedTicker(tickTime, Feed.GetInstance());
            }
        }

        private void LoadLocationManager() {
            _locationManager.SetCoordinatesByLocationSetting();
            map.IgnoreMarkerOnMouseWheel = true;
            _hasLocationservice = false;
            var watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.StatusChanged += watcher_StatusChanged;
            watcher.Start();
            if (_hasLocationservice)
                map.Position = new PointLatLng(_locationManager._currentLatitude, _locationManager._currentLongitude);
            else map.SetPositionByKeywords(Settings.Default.userLocation);
        }

    }
}


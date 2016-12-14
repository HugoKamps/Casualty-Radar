using System;
using System.Collections.Generic;
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
        private Panel _selectedPanel;
        private readonly List<Panel> _alertPanels = new List<Panel>();
        public GMapOverlay RouteOverlay { get; set; }

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
                GMaps.Instance.Mode = AccessMode.ServerOnly;
                var markersOverlay = new GMapOverlay("markers");
                map.Overlays.Add(markersOverlay);
                /* kan weg */
                this.RouteOverlay = new GMapOverlay("route");
                /* kan weg */
                map.Overlays.Add(RouteOverlay);
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
            Alert selectedAlert = null;

            for (var i = 0; i < _alertPanels.Count; i++) {
                if (_selectedPanel != _alertPanels[i]) continue;
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

        public void LoadComponents() {
            BackgroundWorker bwFeed = new BackgroundWorker();
            BackgroundWorker bwMap = new BackgroundWorker();

            bwFeed.RunWorkerAsync();

            bwMap.DoWork += delegate {
                Invoke(new Action(() => GetLocationManager()));
            };

            bwMap.RunWorkerCompleted += delegate {
                GetAlertsMap(false);
                RemoveLoadIcon();
                try {
                    foreach (Panel p in GetAlertPanels)
                        feedPanel.Controls.Add(p);
                } catch (InvalidOperationException e) {
                    MessageBox.Show(e.ToString());
                }
                alertsTitleLabel.Text = "Meldingen (" + Feed.GetInstance().GetFilteredAlerts.Count.ToString() + ")";
            };

            // Create panels in background thread
            bwFeed.DoWork += delegate {
                int y = 0;
                GetAlertPanels.Clear();
                foreach (var a in Feed.GetInstance().GetFilteredAlerts) {
                    GetAlertPanels.Add(CreateAlertPanel(a.Type, a.Title, a.Info, a.PubDate.TimeOfDay.ToString(), y));
                    y += 105;
                }
            };

            bwFeed.RunWorkerCompleted += delegate {
                bwMap.RunWorkerAsync();
            };
        }

        public void DisplayLoadIcon() {
            loadFeedPictureBox.Visible = true;
            loadFeedPictureBox.Refresh();
            loadFeedLabel.Visible = true;
            loadFeedLabel.Refresh();
            IsRefreshing = true;
            feedPanel.Controls.Clear();
        }

        public void RemoveLoadIcon() {
            loadFeedPictureBox.Visible = false;
            loadFeedLabel.Visible = false;
            IsRefreshing = false;
            feedPanel.AutoScroll = true;
        }

        public Panel GetSelectedPanel => _selectedPanel;
        public List<Panel> GetAlertPanels => _alertPanels;
        public int GetAlertType => alertTypeComboBox.SelectedIndex;

        public Panel CreateAlertPanel(int type, string title, string info, string time, int y) {
            //The panel which will be filled with all of the controls below
            var newPanel = new Panel {
                Location = new Point(0, y),
                Size = new Size(320, 100),
                BackColor = Color.FromArgb(236, 89, 71)
            };

            //The picture which indicates the type of alert (Firefighter or ambulance)
            var newPictureBox = new PictureBox {
                Location = new Point(220, 10),
                Size = new Size(60, 60),
                Image = type == 1 ? Properties.Resources.Medic : Properties.Resources.Firefighter,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            //The label which will be filled with the information about the alert
            var label = new Label {
                ForeColor = Color.White,
                Location = new Point(10, 5),
                Font = new Font("Microsoft Sans Serif", 10),
                Size = new Size(200, 90),
                BackColor = Color.Transparent,
                Text = title + "\n" + info
            };

            if (_selectedPanel != null) {
                foreach (var control in _selectedPanel.Controls) {
                    if (control is Label) {
                        var selectedLabel = (Label)control;
                        if (selectedLabel.Text == label.Text) {
                            newPanel.BackColor = Color.FromArgb(245, 120, 105);
                            _selectedPanel = newPanel;
                        }
                    }
                }
            }

            //The label which will be filled with the time of the alert
            var timeLabel = new Label {
                ForeColor = Color.White,
                Location = new Point(150, 65),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 30),
                BackColor = Color.Transparent,
                Text = time
            };

            //Events for each control in the panel;
            newPictureBox.MouseEnter += feedPanelItem_MouseEnter;
            newPictureBox.MouseLeave += feedPanelItem_MouseLeave;
            newPictureBox.Click += feedPanelItem_Click;

            label.MouseEnter += feedPanelItem_MouseEnter;
            label.MouseLeave += feedPanelItem_MouseLeave;
            label.Click += feedPanelItem_Click;
            label.TextAlign = ContentAlignment.MiddleCenter;

            timeLabel.MouseEnter += feedPanelItem_MouseEnter;
            timeLabel.MouseLeave += feedPanelItem_MouseLeave;
            timeLabel.Click += feedPanelItem_Click;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;

            newPanel.MouseEnter += feedPanelItem_MouseEnter;
            newPanel.MouseLeave += feedPanelItem_MouseLeave;
            newPanel.Click += feedPanelItem_Click;
            newPanel.Cursor = Cursors.Hand;

            //The panel is filled with all the controls initialized above
            newPanel.Controls.Add(newPictureBox);
            newPanel.Controls.Add(label);
            newPanel.Controls.Add(timeLabel);

            return newPanel;
        }

        private void feedPanelItem_Click(object sender, EventArgs e) {
            var homeModule = (HomeModule)ModuleManager.GetInstance().ParseInstance(typeof(HomeModule));

            if (sender.GetType() == typeof(Panel)) {
                var panel = (Panel)sender;
                if (_selectedPanel != null) _selectedPanel.BackColor = Color.FromArgb(236, 86, 71);
                if (_selectedPanel == panel) {
                    _selectedPanel = null;
                    homeModule.navigationBtn.Enabled = false;
                    homeModule.navigationBtn.BackColor = Color.Gray;
                } else {
                    _selectedPanel = panel;
                    _selectedPanel.BackColor = Color.FromArgb(245, 120, 105);
                    homeModule.navigationBtn.Enabled = true;
                }
            } else {
                var control = (Control)sender;
                if (_selectedPanel != null) _selectedPanel.BackColor = Color.FromArgb(236, 86, 71);
                if (_selectedPanel == control.Parent) {
                    _selectedPanel = null;
                    homeModule.navigationBtn.Enabled = false;
                } else {
                    _selectedPanel = (Panel)control.Parent;
                    _selectedPanel.BackColor = Color.FromArgb(245, 120, 105);
                    homeModule.navigationBtn.Enabled = true;
                }
            }

            var marker = homeModule.map.Overlays[0].Markers[_alertPanels.FindIndex(panel => panel == _selectedPanel) + 1];
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
        }

        private void feedPanelItem_MouseEnter(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                var panel = (Panel)sender;
                if (panel != _selectedPanel) panel.BackColor = Color.FromArgb(210, 73, 57);
            } else {
                var control = (Control)sender;
                if (control.Parent != _selectedPanel) control.Parent.BackColor = Color.FromArgb(210, 73, 57);
            }
        }

        private void feedPanelItem_MouseLeave(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                var panel = (Panel)sender;
                if (panel != _selectedPanel) panel.BackColor = Color.FromArgb(236, 86, 71);
            } else {
                var control = (Control)sender;
                if (control.Parent != _selectedPanel) control.Parent.BackColor = Color.FromArgb(236, 86, 71);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Casualty_Radar.Core;
using Casualty_Radar.Core.Dialog;
using Casualty_Radar.Models;
using Casualty_Radar.Properties;

namespace Casualty_Radar.Modules {
    /// <summary>
    /// The landing page of the application. Contains a map with all alerts and the user's current location. Also contains a panel with all alerts in the Netherlands
    /// </summary>
    public partial class HomeModule : UserControl, IModule {
        private bool _hasLocationservice; //Indicates if the user has GPS enabled or not
        private Panel _selectedPanel;
        private GMarkerGoogle _previousMarker;
        private int _previousMarkerIndex;
        private List<Panel> _alertPanels = new List<Panel>();
        public GMapOverlay RouteOverlay { get; set; }
        public bool IsRefreshing { get; set; }
        public FeedTicker FeedTicker { get; private set; }
        public LocationManager LocationManager { get; set; }

        public HomeModule() {
            InitializeComponent();
        }

        public Breadcrumb GetBreadcrumb() => new Breadcrumb(this, "Home", ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule)));

        /// <summary>
        /// Function that displays a map in the HomeModule. First it checks if the user has a working internet connection. 
        /// It creates a marker on the user's current location and on all the incidents coming from the Feed.
        /// </summary>
        /// <param name="hasLocationService">Indicates if the user's location setting should be used or the location service</param>
        public void InitAlertsMap(bool hasLocationService) {
            if (!ConnectionUtil.HasInternetConnection()) return;

            map.Overlays.Clear();
            map.ShowCenter = false;
            map.MapProvider = GoogleMapProvider.Instance;
            map.DragButton = MouseButtons.Left;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            map.Overlays.Add(markersOverlay);
            map.OnMarkerClick += Marker_Click;

            RouteOverlay = new GMapOverlay("route");
            map.Overlays.Add(RouteOverlay);

            //If the user has location services enabled it uses the lat and lng that the GPS returns. If not it uses the user's standard location
            if (hasLocationService) {
                markersOverlay.Markers.Add(LocationManager.CreateMarker(LocationManager.CurrentLatitude,
                    LocationManager.CurrentLongitude, 0));
            } else {
                LocationManager.SetCoordinatesByLocationSetting();
                markersOverlay.Markers.Add(LocationManager.CreateMarker(LocationManager.CurrentLatitude,
                    LocationManager.CurrentLongitude, 0));
            }

            foreach (Alert alert in Feed.GetInstance().GetFilteredAlerts) {
                int type = alert.Type == 1 ? 1 : 2;
                if (_previousMarker != null && _previousMarker.Position.Lat.Equals(alert.Lat) &&
                    _previousMarker.Position.Lng.Equals(alert.Lng)) type = 3;
                markersOverlay.Markers.Add(LocationManager.CreateMarker(alert.Lat, alert.Lng, type));
            }
        }

        public static Image ResizeImage(Image imgToResize, Size size) => new Bitmap(imgToResize, size);
        public Panel GetSelectedPanel => _selectedPanel;
        public int GetAlertType => alertTypeComboBox.SelectedIndex;

        public LocationManager GetLocationManager() {
            if (LocationManager != null) return LocationManager;
            LocationManager = new LocationManager();
            LoadLocationManager();
            return LocationManager;
        }

        /// <summary>
        /// Initializes the watcher and sets the user's location
        /// </summary>
        private void LoadLocationManager() {
            LocationManager.SetCoordinatesByLocationSetting();
            map.IgnoreMarkerOnMouseWheel = true;
            _hasLocationservice = false;
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.StatusChanged += watcher_StatusChanged;
            watcher.Start();
            if (_hasLocationservice)
                map.Position = new PointLatLng(LocationManager.CurrentLatitude, LocationManager.CurrentLongitude);
            else map.SetPositionByKeywords(Settings.Default.userLocation);
        }

        public void HomeModule_Load(object sender, EventArgs e) {
            if (LocationManager == null) {
                // Load the feed & instantiate the location manager
                int tickTime = Settings.Default.feedTickerTime * 1000;
                FeedTicker = new FeedTicker(tickTime, Feed.GetInstance());
            }
        }

        /// <summary>
        /// </summary>
        public void LoadComponents() {
            BackgroundWorker bwFeed = new BackgroundWorker();
            BackgroundWorker bwMap = new BackgroundWorker();

            // Create panels in background thread
            bwFeed.DoWork += delegate {
                int y = 0;
                _alertPanels.Clear();

                foreach (Alert a in Feed.GetInstance().GetFilteredAlerts) {
                    _alertPanels.Add(CreateAlertPanel(a.Type, a.Title, a.Info, a.PubDate.TimeOfDay.ToString(), y));
                    y += 81;
                }
            };

            bwFeed.RunWorkerCompleted += delegate {
                Casualty_Radar.Container.GetInstance().SplashScreen.CurrentlyLoadingLabel.Text = "Ophalen kaart";
                bwMap.RunWorkerAsync();
            };

            bwMap.DoWork += delegate { Invoke(new Action(() => GetLocationManager())); };

            bwMap.RunWorkerCompleted += delegate {
                InitAlertsMap(false);
                RemoveLoadIcon();
                try {
                    if (_alertPanels.Count > 0) {
                        noAlertsLabel.Visible = false;
                        for (int i = 0; i < _alertPanels.Count; i++) {
                            foreach (Alert alert in Feed.GetInstance().GetNewAlerts) {
                                if (alert == Feed.GetInstance().GetAlerts[i] ||
                                    alert == Feed.GetInstance().GetFilteredAlerts[i]) {
                                    _alertPanels[i].Controls[3].Show();
                                }
                            }
                            feedPanel.Controls.Add(_alertPanels[i]);
                        }
                    } else {
                        feedPanel.Controls.Add(noAlertsLabel);
                        noAlertsLabel.Visible = true;
                    }
                } catch (InvalidOperationException e) {
                    Casualty_Radar.Container.GetInstance()
                    .DisplayDialog(DialogType.DialogMessageType.ERROR, "Invalid Operation Exception", e.ToString());
                }
                alertsTitleLabel.Text = "Meldingen (" + Feed.GetInstance().GetFilteredAlerts.Count + ")";
                Casualty_Radar.Container.GetInstance().SplashScreen.Hide();
            };

            Casualty_Radar.Container.GetInstance().SplashScreen.CurrentlyLoadingLabel.Text = "Ophalen meldingen";
            bwFeed.RunWorkerAsync();
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

        /// <summary>
        /// Function for creating a panel in het feed
        /// </summary>
        /// <param name="type">The alert type (firefighter or ambulance)</param>
        /// <param name="title">The title of the alert</param>
        /// <param name="info">Information about the alert</param>
        /// <param name="time">The time of the alert</param>
        /// <param name="height">The height of the panel</param>
        /// <returns>Returns the panel with all of it's content</returns>
        public Panel CreateAlertPanel(int type, string title, string info, string time, int height) {
            //The panel which will be filled with all of the controls below
            Panel newPanel = new Panel {
                Location = new Point(0, height),
                Size = new Size(320, 80),
                BackColor = Color.FromArgb(236, 89, 71),
                Cursor = Cursors.Hand
            };

            //The picture which indicates the type of alert (Firefighter or ambulance)
            PictureBox newPictureBox = new PictureBox {
                Location = new Point(225, 5),
                Size = new Size(40, 40),
                Image = type == 1 ? Resources.Medic : Resources.Firefighter,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            //The label which will be filled with the information about the alert
            Label informationLabel = new Label {
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Font = new Font("Microsoft Sans Serif", 9),
                Size = new Size(200, 80),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = title + "\n" + info
            };

            Label newStampLabel = new Label {
                ForeColor = Color.White,
                Location = new Point(280, 0),
                Size = new Size(40, 20),
                Font = new Font("Microsoft Sans Serif", 9),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "New",
                Visible = false
            };

            if (_selectedPanel != null) {
                foreach (object control in _selectedPanel.Controls) {
                    if (control is Label) {
                        Label selectedLabel = (Label)control;

                        if (selectedLabel.Text == informationLabel.Text) {

                            newPanel.BackColor = Color.FromArgb(245, 120, 105);
                            _selectedPanel = newPanel;
                        }
                    }
                }
            }

            //The label which will be filled with the time of the alert
            Label timeLabel = new Label {
                ForeColor = Color.White,
                Location = new Point(145, 50),
                Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                Size = new Size(200, 30),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = time
            };

            //Events for each control in the panel;
            newPictureBox.MouseEnter += feedPanelItem_MouseEnter;
            newPictureBox.MouseLeave += feedPanelItem_MouseLeave;
            newPictureBox.Click += feedPanelItem_Click;

            informationLabel.MouseEnter += feedPanelItem_MouseEnter;
            informationLabel.MouseLeave += feedPanelItem_MouseLeave;
            informationLabel.Click += feedPanelItem_Click;

            timeLabel.MouseEnter += feedPanelItem_MouseEnter;
            timeLabel.MouseLeave += feedPanelItem_MouseLeave;
            timeLabel.Click += feedPanelItem_Click;

            newPanel.MouseEnter += feedPanelItem_MouseEnter;
            newPanel.MouseLeave += feedPanelItem_MouseLeave;
            newPanel.Click += feedPanelItem_Click;

            //The panel is filled with all the controls initialized above
            newPanel.Controls.Add(newPictureBox);
            newPanel.Controls.Add(informationLabel);
            newPanel.Controls.Add(timeLabel);
            newPanel.Controls.Add(newStampLabel);

            return newPanel;
        }

        public void PreviousButton_Click() {
            _previousMarker = null;
            _selectedPanel = null;
            Feed.GetInstance().UpdateFeed();
        }

        private void Marker_Click(GMapMarker item, MouseEventArgs e) {
            int markerIndex = map.Overlays[0].Markers.IndexOf(item) - 1;
            if (markerIndex < 0) return;
            Panel selectedPanel = _alertPanels[markerIndex];
            feedPanelItem_Click(selectedPanel, EventArgs.Empty);
            feedPanel.ScrollControlIntoView(selectedPanel);

        }

        private void feedPanelItem_Click(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                Panel panel = (Panel)sender;
                if (_selectedPanel != null) _selectedPanel.BackColor = Color.FromArgb(236, 86, 71);
                if (_selectedPanel == panel) {
                    _selectedPanel = null;
                    navigationBtn.Enabled = false;
                    navigationBtn.BackColor = Color.Gray;
                } else {
                    _selectedPanel = panel;
                    _selectedPanel.BackColor = Color.FromArgb(245, 120, 105);
                    navigationBtn.Enabled = true;
                }
            } else {
                Control control = (Control)sender;
                if (_selectedPanel != null) _selectedPanel.BackColor = Color.FromArgb(236, 86, 71);
                if (_selectedPanel == control.Parent) {
                    _selectedPanel = null;
                    navigationBtn.Enabled = false;
                } else {
                    _selectedPanel = (Panel)control.Parent;
                    _selectedPanel.BackColor = Color.FromArgb(245, 120, 105);
                    navigationBtn.Enabled = true;
                }
            }

            if (_previousMarker != null) map.Overlays[0].Markers[_previousMarkerIndex] = _previousMarker;
            int index = _alertPanels.FindIndex(panel => panel == _selectedPanel) + 1;
            _previousMarkerIndex = index;
            _previousMarker = (GMarkerGoogle)map.Overlays[0].Markers[index];
            if (index != 0)
                map.Overlays[0].Markers[index] = LocationManager.CreateMarker(_previousMarker.Position.Lat,
                    _previousMarker.Position.Lng, 3);
        }

        private void feedPanelItem_MouseEnter(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                Panel panel = (Panel)sender;
                if (panel != _selectedPanel) panel.BackColor = Color.FromArgb(210, 73, 57);
            } else {
                Control control = (Control)sender;
                if (control.Parent != _selectedPanel) control.Parent.BackColor = Color.FromArgb(210, 73, 57);
            }
        }

        private void feedPanelItem_MouseLeave(object sender, EventArgs e) {
            if (sender.GetType() == typeof(Panel)) {
                Panel panel = (Panel)sender;
                if (panel != _selectedPanel) panel.BackColor = Color.FromArgb(236, 86, 71);
            } else {
                Control control = (Control)sender;
                if (control.Parent != _selectedPanel) control.Parent.BackColor = Color.FromArgb(236, 86, 71);
            }
        }

        /// <summary>
        /// Keeps track of the user's current location. Everytime the location changes the map is renewed and the coordinates are updated
        /// </summary>
        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            LocationManager.CurrentLatitude = e.Position.Location.Latitude;
            LocationManager.CurrentLongitude = e.Position.Location.Longitude;
            InitAlertsMap(true);
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
            InitAlertsMap(_hasLocationservice);
        }

        private void refreshFeedButton_Click(object sender, EventArgs e) {
            if (IsRefreshing) return;
            FeedTicker.StopTimerIfEnabled();
            Feed.GetInstance().UpdateFeed();
            FeedTicker.StartTimerIfEnabled();
        }

        private void alertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Feed.GetInstance().UpdateAlerts();
            _previousMarker = null;
            _previousMarkerIndex = 0;
        }

        private void navigationBtn_Click(object sender, EventArgs e) {
            Alert selectedAlert = null;
            FeedTicker.StopTimerIfEnabled();

            for (int i = 0; i < _alertPanels.Count; i++) {
                if (_selectedPanel != _alertPanels[i]) continue;
                selectedAlert = Feed.GetInstance().GetAlerts[i];
                break;
            }

            NavigationModule navigationModule = (NavigationModule)ModuleManager.GetInstance().ParseInstance(typeof(NavigationModule));

            if (selectedAlert != null) {
                Alert alert = new Alert(selectedAlert.Title, selectedAlert.Info, selectedAlert.PubDate,
                    selectedAlert.Lat, selectedAlert.Lng) {Type = selectedAlert.Type};
                navigationModule.Init(alert,new PointLatLng(LocationManager.CurrentLatitude, LocationManager.CurrentLongitude));
            }
            ModuleManager.GetInstance().UpdateModule(navigationModule);
        }

        private void navigationBtn_EnabledChanged(object sender, EventArgs e) {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
            button.BackColor = button.Enabled ? Color.FromArgb(210, 73, 57) : Color.Gray;
        }
    }
}
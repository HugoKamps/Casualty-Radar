using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Casualty_Radar.Core;
using Casualty_Radar.Core.Algorithms;
using Casualty_Radar.Core.Dialog;
using Casualty_Radar.Models;
using Casualty_Radar.Models.DataControl;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Models.Navigation;
using Casualty_Radar.Properties;
using Casualty_Radar.Utils;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace Casualty_Radar.Modules {
    /// <summary>
    /// Module that contains a map displaying the starting and ending point for the route and the route between them. Also contains a panel in which the information about the alert is being shown.
    /// </summary>
    partial class NavigationModule : UserControl, IModule {
        private readonly LocationManager _locationManager;
        private GMapOverlay _routeOverlay;
        private PdfUtil _pdfUtil;
        private Route _route;
        private int _page;
        private Panel _panel;
        public GeoMapLoader MapLoader { get; }

        public NavigationModule() {
            InitializeComponent();
            _locationManager = new LocationManager();
            _pdfUtil = new PdfUtil();
            _page = 1;
            _route = new Route();
            MapLoader = new GeoMapLoader();
            MapLoader.GetGeoMapSections();
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Navigation", null,
                ModuleManager.GetInstance().ParseInstance(typeof(HomeModule)));
        }

        /// <summary>
        /// Readies the module for when the user has clicked the navigation button in HomeModule. Fills the alert information panel and calculates and draws the fastest route
        /// </summary>
        /// <param name="alert">Alert which contains all the information about the chosen alert</param>
        /// <param name="start">Point with the user's current latitude and longitude</param>
        public void Init(Alert alert, PointLatLng start) {
            Reset();
            _locationManager.CurrentLatitude = start.Lat;
            _locationManager.CurrentLongitude = start.Lng;

            // Set the alert _panel with the information of the selected alert
            UpdatePanel(alert);
            InitRouteMap(start.Lat, start.Lng, alert.Lat, alert.Lng);
            mapLoadingOverlay.Visible = true;
            stepsLoadingLabel.Visible = true;
            routeInfoLabel.Text = "Routebeschrijving";
            
            // Creating a BackgroundWorker for running the route algorithm in the background
            BackgroundWorker routeWorker = new BackgroundWorker();
            GeoMapSection startingSection = null;
            GeoMapSection endingSection = null;

            // The BackgroundWorker has to call the method ParseRoutes for calculating a route
            routeWorker.DoWork += delegate {
                startingSection = MapLoader.ParseDataSection(start);
                endingSection = MapLoader.ParseDataSection(alert.GetPoint());
                if (startingSection != null && endingSection != null) {
                    if (startingSection.FilePath == endingSection.FilePath)
                        ParseLocalRoute(start, alert.GetPoint(), startingSection);
                    else ParseRoutes(start, alert.GetPoint(), startingSection, endingSection, _route);
                } else {
                    Invoke((MethodInvoker) delegate {
                        Casualty_Radar.Container.GetInstance()
                            .DisplayDialog(DialogType.DialogMessageType.ERROR, "Kan route niet berekenen",
                                "Locatie is onbereikbaar.");
                    });
                }
            };

            // When the BackgroundWorker is done, display the route on the map
            routeWorker.RunWorkerCompleted += delegate {
                if (startingSection != null && endingSection != null) {
                    // Draw the entire calculated route
                    _locationManager.DrawRoute(_route.GetRoutePoints(), _routeOverlay, Color.FromArgb(210, 73, 57));
                    DrawSections();

                    // Calculate the navigation steps and generate a _panel for each step
                    _route.CalculateRouteSteps();
                    PageRoutePanel(_page);
                    routeInfoLabel.Text = "Routebeschrijving (" + _route.TotalDistance + "km)";
                }
                mapLoadingOverlay.Visible = false;
                stepsLoadingLabel.Visible = false;
            };

            // Run the BackgroundWorker
            routeWorker.RunWorkerAsync();
        }

        public void DrawSections() {
            List<GeoMapSection> sections = MapLoader.GetGeoMapSections();
            foreach (GeoMapSection section in sections) {
                _locationManager.DrawRoute(new List<PointLatLng> {
                    new PointLatLng(section.UpperBound.Lat, section.LowerBound.Lng),
                    section.UpperBound,
                    new PointLatLng(section.LowerBound.Lat, section.UpperBound.Lng),
                    section.LowerBound,
                    new PointLatLng(section.UpperBound.Lat, section.LowerBound.Lng)
                }, _routeOverlay, Color.Black);
            }
        }

        /// <summary>
        /// Creates the route by using the algorithm
        /// First, a route on the highways will be generated
        /// Then the routes from starting point to highway and highway to ending point will be generated
        /// These routes get reversed to be in the correct order of nodes
        /// </summary>
        /// <param name="start">The starting point for the route</param>
        /// <param name="end">The ending point for the route</param>
        /// <returns></returns>
        public void ParseRoutes(PointLatLng start, PointLatLng end, GeoMapSection startingSection, GeoMapSection endingSection, Route route) {
            List<Node> highWay = ParseRoute(ParseHighways(), start, end);
            List<Node> origin = ParseRoute(startingSection, start, highWay[highWay.Count - 1].GetPoint());
            List<Node> dest = ParseRoute(endingSection, highWay[0].GetPoint(), end);

            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(highWay[0].Lat, highWay[0].Lon, 1));
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(highWay[highWay.Count - 1].Lat, highWay[highWay.Count - 1].Lon, 1));

            highWay.Reverse();
            origin.Reverse();
            dest.Reverse();

            route.RouteNodes = origin;
            route.RouteNodes.AddRange(highWay);
            route.RouteNodes.AddRange(dest);
        }

        /// <summary>
        /// This function calculates the route when the user's location and the destination are in the same XML section
        /// </summary>
        /// <param name="start">The point of the user's location</param>
        /// <param name="end">The point of the destination</param>
        /// <param name="section">The section the user and destination are both in</param>
        private void ParseLocalRoute(PointLatLng start, PointLatLng end, GeoMapSection section)
            => _route.RouteNodes = ParseRoute(section, start, end);

        private void UpdatePanel(Alert alert) {
            infoTitleLabel.Text = $@"{alert.Title}{alert.Info}";
            alertTypePicturebox.Image = alert.Type == 1 ? Resources.Medic : Resources.Firefighter;
            timeLabel.Text = alert.PubDate.TimeOfDay.ToString();
        }

        /// <summary>
        /// Parses a route based on the given datacollection and coordinates
        /// </summary>
        /// <param name="collection">The datacollection that is used to run the algorithm over</param>
        /// <param name="origin">The original geographical location</param>
        /// <param name="dest">The destination from the route</param>
        /// <returns>A list of nodes that represent the final route</returns>
        private List<Node> ParseRoute(DataCollection collection, PointLatLng origin, PointLatLng dest) {
            Node start = MapUtil.GetNearest(origin.Lat, origin.Lng, collection.Nodes);
            Node end = MapUtil.GetNearest(dest.Lat, dest.Lng, collection.Nodes);
            RouteCalculation calc = new RouteCalculation(start, end);
            calc.Search();
            return calc.GetNodes();
        }

        /// <summary>
        /// Parses a route based on the given mapsection and coordinates
        /// </summary>
        /// <param name="section">The current mapsection that requires a route</param>
        /// <param name="origin">The original geographical location</param>
        /// <param name="dest">The destination from the route</param>
        /// <returns>A list of nodes that represent the final route</returns>
        private List<Node> ParseRoute(GeoMapSection section, PointLatLng origin, PointLatLng dest) {
            try {
                section.Load();
                return ParseRoute(section.Data, origin, dest);
            }
            catch (NullReferenceException) {
                Casualty_Radar.Container.GetInstance()
                    .DisplayDialog(DialogType.DialogMessageType.ERROR, "Route niet gevonden",
                        "Er is helaas geen route beschikbaar op dit moment.");
                return new List<Node>();
            }
        }

        /// <summary>
        /// Parses all highways from the netherlands
        /// </summary>
        /// <returns>The deserialized data collection with all highways and large roads</returns>
        private DataCollection ParseHighways() {
            DataParser parser = new DataParser(@"../../Resources/XML/nederland_snelwegen.xml");
            parser.Deserialize();
            return parser.GetCollection();
        }

        /// <summary>
        /// Initializes the GMapControl in the module. Creates markers on the current location and the chosen alert's location
        /// </summary>
        /// <param name="startLat">User's current latitude</param>
        /// <param name="startLng">User's current longitude</param>
        /// <param name="destLat">The alert's latitude</param>
        /// <param name="destLng">The alert's longitude</param>
        public void InitRouteMap(double startLat, double startLng, double destLat, double destLng) {
            map.Overlays.Clear();
            map.ShowCenter = false;
            map.MapProvider = GoogleMapProvider.Instance;
            map.IgnoreMarkerOnMouseWheel = true;
            map.DragButton = MouseButtons.Left;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            map.Zoom = 7;
            map.Position = new PointLatLng((startLat + destLat) / 2, (startLng + destLng) / 2);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            _routeOverlay = new GMapOverlay("routes");
            map.Overlays.Add(markersOverlay);
            map.Overlays.Add(_routeOverlay);

            markersOverlay.Markers.Add(_locationManager.CreateMarker(startLat, startLng, 0));
            markersOverlay.Markers.Add(_locationManager.CreateMarker(destLat, destLng, 4));
        }

        private void printingPictureBox_Click(object sender, EventArgs e)
            => _pdfUtil.CreatePdf(_route.RouteSteps, _route.StartingRoad, _route.DestinationRoad);

        /// <summary>
        /// Function for printing 5 routesteps, which depend from the given pagenumber
        /// </summary>
        /// <param name="page">The pagenumber</param>
        private void PageRoutePanel(int page) {
            routeInfoPanel.Controls.Clear();
            for (int index = 0; index < 5; index++) {
                if (index + (page * 5 - 5) < _route.RouteStepPanels.Count &&
                    index + (page * 5 - 5) < _route.RouteStepPanels.Count) {
                    _panel = _route.RouteStepPanels[index + (page * 5 - 5)];
                    routeInfoPanel.Controls.Add(_panel);
                }
                PreviousPageButton.Enabled = page != 1;
                NextPageButton.Enabled = page != _route.RouteStepPanels.Count / 5 + 1;
            }
            PageNumber.Text = "Pagina " + page + "/" + (_route.RouteStepPanels.Count / 5 + 1);
        }

        /// <summary>
        /// Clears all route step panels
        /// </summary>
        public void Reset() {
            if (routeInfoPanel.Controls.Count > 0) routeInfoPanel.Controls.Clear();
            _routeOverlay?.Clear();
            PageNumber.Text = "";
            _route = new Route();
            _page = 1;
        }

        private void PreviousPageButton_Click(object sender, EventArgs e) {
            if (_page <= 1) return;
            _page--;
            PageRoutePanel(_page);
        }

        private void NextPageButton_Click(object sender, EventArgs e) {
            if (_page * 5 >= _route.RouteStepPanels.Count) return;
            _page++;
            PageRoutePanel(_page);
        }
    }
}
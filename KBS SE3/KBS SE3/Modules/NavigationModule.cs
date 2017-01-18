using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Casualty_Radar.Core;
using Casualty_Radar.Models;
using Casualty_Radar.Models.Navigation;
using Casualty_Radar.Properties;
using Casualty_Radar.Utils;
using Casualty_Radar.Models.DataControl;
using Casualty_Radar.Core.Algorithms;
using Casualty_Radar.Models.DataControl.Graph;

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
        private GeoMapLoader _mapLoader;

        public NavigationModule() {
            InitializeComponent();
            _locationManager = new LocationManager();
            _pdfUtil = new PdfUtil();
            _page = 1;
            _route = new Route();
            _mapLoader = new GeoMapLoader();
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
            ClearPanels();

            _locationManager.CurrentLatitude = start.Lat;
            _locationManager.CurrentLongitude = start.Lng;

            // Set the alert _panel with the information of the selected alert
            UpdatePanel(alert);
            InitRouteMap(start.Lat, start.Lng, alert.Lat, alert.Lng);

            List<Node> highWay = ParseRoute(ParseHighways(), start, alert.GetPoint());
            List<Node> origin = ParseRoute(FetchDataSection(start), start, highWay[highWay.Count - 1].GetPoint());
            List<Node> dest = ParseRoute(FetchDataSection(alert.GetPoint()), highWay[0].GetPoint(), alert.GetPoint());

            origin.Reverse();
            dest.Reverse();
            highWay.Reverse();

            _route.RouteNodes = origin;
            _route.RouteNodes.AddRange(highWay);
            _route.RouteNodes.AddRange(dest);
    
            // Draw the entire calculated route
            _locationManager.DrawRoute(_route.GetRoutePoints(), _routeOverlay);

            // Calculate the navigation steps and generate a _panel for each step
            _route.CalculateRouteSteps();
            PageRoutePanel(_page);
            routeInfoLabel.Text = "Routebeschrijving (" + _route.TotalDistance + "km)";
        }

        private void UpdatePanel(Alert alert) {
            infoTitleLabel.Text = string.Format("{0}\n{1}", alert.Title, alert.Info);
            alertTypePicturebox.Image = alert.Type == 1 ? Resources.Medic : Resources.Firefighter;
            timeLabel.Text = alert.PubDate.TimeOfDay.ToString();
        }

        public List<Node> ParseRoute(DataCollection collection, PointLatLng origin, PointLatLng dest) {
            Node start = MapUtil.GetNearest(origin.Lat, origin.Lng, collection.Intersections);
            Node end = MapUtil.GetNearest(dest.Lat, dest.Lng, collection.Intersections);
            RouteCalculation calc = new RouteCalculation(start, end);
            calc.Search();
            return calc.GetNodes();
        }

        private List<Node> ParseRoute(GeoMapSection section, PointLatLng origin, PointLatLng dest) {
            section.Load();
            return ParseRoute(section.Data, origin, dest);
        }

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

        private GeoMapSection FetchDataSection(PointLatLng point) {
            foreach (GeoMapSection section in _mapLoader.GetGeoMapSections()) {
                if (!MapUtil.IsInSection(point, section)) continue;
                section.Load();
                return section;
            }
            return null;
        }

        /// <summary>
        /// Function for printing 5 routesteps, which depend from the given pagenumber
        /// </summary>
        /// <param name="page">The pagenumber</param>
        private void PageRoutePanel(int page) {
            for (int index = 0; index < 5; index++) {
                if (index + (page * 5 - 5) < _route.RouteStepPanels.Count &&
                    index + (page * 5 - 5) < _route.RouteStepPanels.Count) {
                    _panel = _route.RouteStepPanels[index + (page * 5 - 5)];
                    routeInfoPanel.Controls.Add(_panel);
                }
                PreviousPageButton.Enabled = page != 1;
                NextPageButton.Enabled = page != _route.RouteStepPanels.Count / 5 + 1;
            }
            PageNumber.Text = "Pagina " + page + "/" + ((_route.RouteStepPanels.Count / 5) + 1);
        }

        /// <summary>
        /// Clears all route step panels
        /// </summary>
        public void ClearPanels() {
            if (routeInfoPanel.Controls.Count > 0) routeInfoPanel.Controls.Clear();
        }

        /// <summary>
        ///  Function for going to previous page with route steps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousPageButton_Click(object sender, EventArgs e) {
            if (_page <= 1) return;
            _page--;
            PageRoutePanel(_page);
        }

        /// <summary>
        /// Function for going to next _page with route steps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPageButton_Click(object sender, EventArgs e) {
            if (_page * 5 >= _route.RouteStepPanels.Count) return;
            _page++;
            PageRoutePanel(_page);
        }
    }
}
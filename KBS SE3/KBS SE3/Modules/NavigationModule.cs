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
        private Pathfinder _pathfinder;
        private Node _startNode;
        private Node _endNode;
        private PdfUtil _pdfUtil;
        private Route _route;

        private DataParser parser;
        private DataCollection collection;
        private List<Node> targetCollection;

        public NavigationModule() {
            InitializeComponent();
            _locationManager = new LocationManager();
            _pdfUtil = new PdfUtil();
            _route = new Route();

            parser = new DataParser(@"../../Resources/XML/nederland_snelwegen.xml");
            parser.Deserialize();
            collection = parser.GetCollection();
            targetCollection = collection.Intersections;
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
            _locationManager.CurrentLatitude = start.Lat;
            _locationManager.CurrentLongitude = start.Lng;

            // Get the provinces for the start and destination and set the needed XML file paths
            //string startingXml = 
            //string destinationXml = 

            // Set the alert panel with the information of the selected alert
            infoTitleLabel.Text = string.Format("{0}\n{1}", alert.Title, alert.Info);
            alertTypePicturebox.Image = alert.Type == 1 ? Resources.Medic : Resources.Firefighter;
            timeLabel.Text = alert.PubDate.TimeOfDay.ToString();
            InitRouteMap(start.Lat, start.Lng, alert.Lat, alert.Lng);

            routeInfoPanel.Controls.Clear();
            _routeOverlay.Clear();

            // Get the nearest nodes on the highway of the starting and end point
            _startNode = MapUtil.GetNearest(start.Lat, start.Lng, targetCollection);
            _endNode = MapUtil.GetNearest(alert.Lat, alert.Lng, targetCollection);

            // Calculate the route on the highway
            _pathfinder = new Pathfinder(_startNode, _endNode);
            _route.RouteNodes = _pathfinder.FindPath(); // Moet 'List<Node> highwaynodes' zijn

            /*
            //Calculate the route from the user's location to the starting point on the highway
            SetParserData(startingXml);
            _startNode = MapUtil.GetNearest(start.Lat, start.Lng, targetCollection);
            _endNode = highwayNodes[0];
            _pathfinder = new Pathfinder(_startNode, _endNode);
            
            // Set the list with nodes in the route with the starting route and the highway route
            _route.RouteNodes = _pathfinder.FindPath();            
            _route.RouteNodes.AddRange(highwayNodes);
            
            // Calculate the route from the last point on the highway to the location of the alert
            SetParserData(destinationXml);
            _startNode = highwayNodes[highwayNodes.Count - 1];
            _endNode = MapUtil.GetNearest(alert.Lat, alert.Lng, targetCollection);
            _pathfinder = new Pathfinder(_startNode, _endNode);

            // Add the final route to the current route
            _route.RouteNodes.AddRange(_pathfinder.FindPath());
            */
            // Draw the entire calculated route
            _locationManager.DrawRoute(_route.GetRoutePoints(), _routeOverlay);

            // Calculate the navigation steps and generate a panel for each step
            _route.CalculateRouteSteps();
            for (var index = 0; index < 7; index++) {
                Panel panel = _route.RouteStepPanels[index];
                routeInfoPanel.Controls.Add(panel);
            }

            routeInfoLabel.Text = "Routebeschrijving (" + _route.TotalDistance + "km)";
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

        private void printingPictureBox_Click(object sender, EventArgs e) => _pdfUtil.CreatePdf(_route.RouteSteps, _route.StartingRoad, _route.DestinationRoad);

        private void SetParserData(string path) {
            parser = new DataParser(@"../../Resources/XML/" + path);
            parser.Deserialize();
            collection = parser.GetCollection();
            targetCollection = collection.Intersections;
        }
    }
}
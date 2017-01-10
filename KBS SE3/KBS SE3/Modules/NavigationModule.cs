using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        public NavigationModule() {
            InitializeComponent();
            _locationManager = new LocationManager();
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

            infoTitleLabel.Text = string.Format("{0}\n{1}", alert.Title, alert.Info);
            alertTypePicturebox.Image = alert.Type == 1 ? Resources.Medic : Resources.Firefighter;
            timeLabel.Text = alert.PubDate.TimeOfDay.ToString();
            InitRouteMap(start.Lat, start.Lng, alert.Lat, alert.Lng);

            //Instantiates a data parser which creates a collection with all nodes and ways of a specific zone
            DataParser parser = new DataParser(@"../../Resources/hattem.xml");
            parser.Deserialize();
            DataCollection collection = parser.GetCollection();
            List<Node> targetCollection = collection.Intersections;

            //_startNode = MapUtil.GetNearest(start.Lat, start.Lng, targetCollection);
            //_endNode = MapUtil.GetNearest(dest.Lat, dest.Lng, targetCollection);
            Random rand = new Random();
            _startNode = targetCollection[rand.Next(0, 161)]; //131
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(_startNode.Lat, _startNode.Lon, 2));
            _endNode = targetCollection[rand.Next(0, 161)]; //124
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(_endNode.Lat, _endNode.Lon, 3));

            _pathfinder = new Pathfinder(_startNode, _endNode);
            List<Node> path = _pathfinder.FindPath();
            List<PointLatLng> points = new List<PointLatLng>();
            double totalDistance = 0;
            double prevAngle = -1;
            int height = 0;
            Color color = Color.Gainsboro;
            string startingRoad = "";
            string endRoad = "";
            List<NavigationStep> steps = new List<NavigationStep>();
            for (int index = 0; index < path.Count; index++) {
                Node node = path[index];
                points.Add(node.GetPoint());
                if (index + 1 != path.Count && index + 2 != path.Count) {
                    map.Overlays[0].Markers.Add(_locationManager.CreateMarker(node.Lat, node.Lon, 0));
                    Node nextNode = path[index + 1];
                    Node nextNextNode = path[index + 2];

                    if (index == 0) startingRoad = MapUtil.GetWay(nextNode, nextNextNode).Name;

                    double angle = AngleFromCoordinate(nextNode.Lat, nextNode.Lon, nextNextNode.Lat, nextNextNode.Lon);
                    var type = prevAngle >= 0
                        ? CalcRouteStepType(CalcBearing(prevAngle, angle))
                        : RouteStepType.Straight;
                    string distance =
                        NavigationStep.GetFormattedDistance(Math.Round(MapUtil.GetDistance(node, nextNode), 2));
                    NavigationStep step = new NavigationStep(distance, type, MapUtil.GetWay(nextNode, nextNextNode));
                    totalDistance += MapUtil.GetDistance(node, nextNode);
                    prevAngle = angle;

                    if (index + 3 == path.Count) {
                        step = new NavigationStep(distance, RouteStepType.DestinationReached,
                            MapUtil.GetWay(nextNode, nextNextNode));
                        routeInfoPanel.Controls.Add(NavigationStep.CreateRouteStepPanel(step, color, height));
                        endRoad = MapUtil.GetWay(nextNode, nextNextNode).Name;
                    }
                    else routeInfoPanel.Controls.Add(NavigationStep.CreateRouteStepPanel(step, color, height));
                    steps.Add(step);
                    color = color == Color.Gainsboro ? Color.White : Color.Gainsboro;
                    height += 51;
                }
                else break;
            }
            PdfUtil pdfUtil = new PdfUtil();
            pdfUtil.CreatePdf(steps, startingRoad, endRoad);

            _locationManager.DrawRoute(points, _routeOverlay);
            totalDistance = Math.Round(totalDistance, 2);
            routeInfoLabel.Text = "Routebeschrijving (" + totalDistance + "km)";
        }

        /// <summary>
        /// Get the angle in degrees between two lat & long points
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="long1"></param>
        /// <param name="lat2"></param>
        /// <param name="long2"></param>
        /// <returns>The angle between two coordinates</returns>
        private double AngleFromCoordinate(double lat1, double long1, double lat2,
            double long2) {
            double dLon = (long2 - long1);

            double y = Math.Sin(dLon) * Math.Cos(lat2);
            double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1)
                       * Math.Cos(lat2) * Math.Cos(dLon);

            double angle = Math.Atan2(y, x);

            angle = angle * (180 / Math.PI);
            angle = (angle + 360) % 360;
            angle = 360 - angle;

            return angle;
        }

        /// <summary>
        /// Calculate the bearing between two angles
        /// If it is lower than 0, add 360 to it so it will always be a positive number
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns>The bearing between two angles</returns>
        private double CalcBearing(double angle1, double angle2) {
            double bearing = angle2 - angle1;

            if (bearing < 0)
                bearing = 360 + bearing;

            return bearing;
        }

        /// <summary>
        /// Determine the RouteStepType based on the bearing
        /// </summary>
        /// <param name="bearing"></param>
        /// <returns>The RouteStepType based on the bearing</returns>
        private RouteStepType CalcRouteStepType(double bearing) {
            RouteStepType type;

            if (bearing == 0 || bearing == 360 || bearing > 0 && bearing < 25 || bearing < 360 && bearing > 335)
                type = RouteStepType.Straight;
            else if (bearing >= 25 && bearing < 45)
                type = RouteStepType.CurveRight;
            else if (bearing > 45 && bearing <= 90)
                type = RouteStepType.Right;
            else if (bearing > 90 && bearing <= 180)
                type = RouteStepType.SharpRight;
            else if (bearing <= 335 && bearing > 315)
                type = RouteStepType.CurveLeft;
            else if (bearing < 315 && bearing >= 270)
                type = RouteStepType.Left;
            else if (bearing < 270 && bearing >= 180)
                type = RouteStepType.SharpLeft;
            else type = RouteStepType.Straight;

            return type;
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
            markersOverlay.Markers.Add(_locationManager.CreateMarker(destLat, destLng, 2));
        }

        private void printingPictureBox_Click(object sender, EventArgs e) => Process.Start("Route.pdf"); 
    }
}
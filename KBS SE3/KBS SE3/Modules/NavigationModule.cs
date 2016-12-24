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
using Casualty_Radar.Core.Dialog;
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
            _startNode = targetCollection[130];
            _startNode = targetCollection[131];
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(_startNode.Lat, _startNode.Lon, 2));
            _endNode = targetCollection[124];
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(_endNode.Lat, _endNode.Lon, 3));

            _pathfinder = new Pathfinder(_startNode, _endNode);
            List<Node> path = _pathfinder.FindPath();
            List<PointLatLng> points = new List<PointLatLng>();
            double totalDistance = 0;
            double prevAngle = -1;
            int height = 0;
            Color color = Color.Gainsboro;
            for (int index = 0; index < path.Count; index++) {
                Node node = path[index];
                points.Add(node.GetPoint());

                if (index + 1 != path.Count && index + 2 != path.Count) {
                    map.Overlays[0].Markers.Add(_locationManager.CreateMarker(node.Lat, node.Lon, 0));
                    Node nextNode = path[index + 1];
                    Node nextNextNode = path[index + 2];
                    double angle = AngleFromCoordinate(nextNode.Lat, nextNode.Lon, nextNextNode.Lat, nextNextNode.Lon);
                    var type = prevAngle >= 0 ? CalcRouteStepType(CalcBearing(prevAngle, angle)) : RouteStepType.Straight;
                    string distance =
                        NavigationStep.GetFormattedDistance(Math.Round(MapUtil.GetDistance(node, nextNode), 2));
                    NavigationStep step = new NavigationStep(distance, type, MapUtil.GetWay(nextNode, nextNextNode));
                    totalDistance += MapUtil.GetDistance(node, nextNode);
                    prevAngle = angle;

                    if (index + 3 == path.Count) CreateRouteStepPanel(new NavigationStep(distance, RouteStepType.DestinationReached,
                        MapUtil.GetWay(nextNode, nextNextNode)), color, height);
                    else CreateRouteStepPanel(step, color, height);

                    color = color == Color.Gainsboro ? Color.White : Color.Gainsboro;
                    height += 51;
                } else break;

            }
            _locationManager.DrawRoute(points, _routeOverlay);
            totalDistance = Math.Round(totalDistance, 2);
            routeInfoLabel.Text += " (" + totalDistance + "km)";
        }

        private double AngleFromCoordinate(double lat1, double long1, double lat2,
        double long2) {
            double dLon = (long2 - long1);

            double y = Math.Sin(dLon) * Math.Cos(lat2);
            double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1)
                    * Math.Cos(lat2) * Math.Cos(dLon);

            double brng = Math.Atan2(y, x);

            brng = brng * (180 / Math.PI);
            brng = (brng + 360) % 360;
            brng = 360 - brng;

            return brng;
        }

        private double CalcBearing(double angle1, double angle2) {
            double bearing = angle2 - angle1;

            if (bearing < 0)
                bearing = 360 + bearing;

            return bearing;
        }

        private RouteStepType CalcRouteStepType(double bearing) {
            RouteStepType type;

            if (bearing == 0 || bearing == 360 || bearing > 0 && bearing < 25 || bearing < 360 && bearing > 335) // rechtdoor
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
            map.Position = new PointLatLng((startLat + destLat) / 2, (startLng + destLng) / 2);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            _routeOverlay = new GMapOverlay("routes");
            map.Overlays.Add(markersOverlay);
            map.Overlays.Add(_routeOverlay);

            markersOverlay.Markers.Add(_locationManager.CreateMarker(startLat, startLng, 0));
            markersOverlay.Markers.Add(_locationManager.CreateMarker(destLat, destLng, 2));
        }

        /// <summary>
        /// Creates a routestep based on a given NavigationStep
        /// </summary>
        /// <param name="step">The NavigationStep with all the information</param>
        /// <param name="color">Background color for the panel</param>
        /// <param name="height">Height of the panel</param>
        public void CreateRouteStepPanel(NavigationStep step, Color color, int height) {
            Image icon;

            switch (step.Type) {
                case RouteStepType.Straight:
                    icon = Resources.straight_icon;
                    break;
                case RouteStepType.CurveLeft:
                    icon = Resources.turn_curve_left_icon;
                    break;
                case RouteStepType.Left:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.SharpLeft:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.CurveRight:
                    icon = Resources.turn_curve_right_icon;
                    break;
                case RouteStepType.Right:
                    icon = Resources.turn_right_icon;
                    break;
                case RouteStepType.SharpRight:
                    icon = Resources.turn_right_icon;
                    break;
                case RouteStepType.DestinationReached:
                    icon = Resources.destination_icon;
                    break;
                default:
                    icon = Resources.straight_icon;
                    break;
            }

            //The panel which will be filled with all of the controls below
            Panel newPanel = new Panel {
                Location = new Point(0, height),
                Size = new Size(338, 50),
                BackColor = color
            };

            if (step.Distance != null) {
                Label distanceLabel = new Label {
                    Location = new Point(10, 0),
                    Size = new Size(50, 50),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DarkSlateGray,
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                    Text = step.Distance
                };
                newPanel.Controls.Add(distanceLabel);
            }

            Label instructionLabel = new Label {
                Location = new Point(60, 0),
                Size = new Size(210, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9),
                Text = step.Instruction
            };

            PictureBox instructionIcon = new PictureBox {
                Location = new Point(280, 10),
                Size = new Size(30, 30),
                Image = icon,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            newPanel.Controls.Add(instructionIcon);
            newPanel.Controls.Add(instructionLabel);

            routeInfoPanel.AutoScroll = true;
            routeInfoPanel.HorizontalScroll.Enabled = false;
            routeInfoPanel.Controls.Add(newPanel);
        }
    }
}
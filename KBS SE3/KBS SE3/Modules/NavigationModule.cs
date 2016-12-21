using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
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
    partial class NavigationModule : UserControl, IModule {

        private readonly LocationManager _locationManager;
        private GMapOverlay _routeOverlay;
        private Pathfinder _pathfinder;
        private Node _startNode;
        private Node _endNode;

        public NavigationModule() {
            InitializeComponent();
            _locationManager = new LocationManager();
            int y = 0;
            Color color = Color.Gainsboro;

            List<NavigationStep> navSteps = new List<NavigationStep> {
                new NavigationStep("Sla rechtsaf", "100m", RouteStepType.Right),
                new NavigationStep("Sla linksaf", "500m", RouteStepType.Left),
                new NavigationStep("Ga rechtdoor", "1.2km", RouteStepType.Straight),
                new NavigationStep("Sla linksaf", "5km", RouteStepType.Left),
                new NavigationStep("Ga links op de rotonde", "2km", RouteStepType.Left),
                new NavigationStep("Rijd een kind aan", "500m", RouteStepType.Straight)
            };

            foreach (NavigationStep t in navSteps) {
                CreateRouteStepPanel(t, color, y);
                y += 50;
                color = color == Color.Gainsboro ? Color.White : Color.Gainsboro;
            }
        }

        public Breadcrumb GetBreadcrumb() {
            return new Breadcrumb(this, "Navigation", null, ModuleManager.GetInstance().ParseInstance(typeof(HomeModule)));
        }

        public void SetAlertInfo(string title, string info, int type, string time, PointLatLng start, PointLatLng dest) {
            infoTitleLabel.Text = title + "\n" + info;
            alertTypePicturebox.Image = type == 1 ? Resources.Medic : Resources.Firefighter;
            timeLabel.Text = time;
            GetRouteMap(start.Lat, start.Lng, dest.Lat, dest.Lng);

            DataParser parser = new DataParser(@"../../Resources/hattem.xml");
            parser.Deserialize();
            DataCollection collection = parser.GetCollection();
            List<Node> targetCollection = collection.Intersections;
            
            //_startNode = MapUtil.GetNearest(start.Lat, start.Lng, targetCollection);
            //_endNode = MapUtil.GetNearest(dest.Lat, dest.Lng, targetCollection);

            _startNode = targetCollection[80];
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(_startNode.Lat, _startNode.Lon, 2));
            _endNode = targetCollection[40];
            map.Overlays[0].Markers.Add(_locationManager.CreateMarker(_endNode.Lat, _endNode.Lon, 1));

            _pathfinder = new Pathfinder(_startNode, _endNode);
            List<PointLatLng> path = _pathfinder.FindPath(); //.Result voor Async poging

            foreach (PointLatLng point in path) Debug.WriteLine("Lat: " + point.Lat + "    Lng: " + point.Lng);

            _routeOverlay.Routes.Add(new GMapRoute(path, "route") {
                Stroke =
                {
                        DashStyle = DashStyle.Solid,
                        Color = Color.FromArgb(0, 0, 0)
                    }
            });
        }

        public void GetRouteMap(double startLat, double startLng, double destLat, double destLng) {
            map.Overlays.Clear();
            map.ShowCenter = false;
            map.MapProvider = GoogleMapProvider.Instance;
            map.IgnoreMarkerOnMouseWheel = true;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            map.Position = new PointLatLng((startLat + destLat) / 2, (startLng + destLng) / 2);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            _routeOverlay = new GMapOverlay("routes");
            map.Overlays.Add(markersOverlay);
            map.Overlays.Add(_routeOverlay);

            markersOverlay.Markers.Add(_locationManager.CreateMarker(startLat, startLng, 0));
            markersOverlay.Markers.Add(_locationManager.CreateMarker(destLat, destLng, 2));


            // Reading data for adding test route
            //_locationManager.DrawRoute(collection, _routeOverlay);
            //_locationManager.DrawTestRoute(collection, _routeOverlay);
        }

        public void CreateRouteStepPanel(NavigationStep step, Color color, int y) {
            Image icon;

            switch (step.Type) {
                case RouteStepType.Straight:
                    icon = Resources.straight_icon;
                    break;
                case RouteStepType.Left:
                    icon = Resources.turn_left_icon;
                    break;
                case RouteStepType.Right:
                    icon = Resources.turn_right_icon;
                    break;
                default:
                    icon = Resources.straight_icon;
                    break;
            }

            //The panel which will be filled with all of the controls below
            Panel newPanel = new Panel {
                Location = new Point(0, y),
                Size = new Size(338, 50),
                BackColor = color
            };

            Label distanceLabel = new Label {
                Location = new Point(10, 0),
                Size = new Size(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Text = step.Distance
            };

            Label instructionLabel = new Label {
                Location = new Point(60, 0),
                Size = new Size(130, 50),
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

            newPanel.Controls.Add(distanceLabel);
            newPanel.Controls.Add(instructionLabel);
            newPanel.Controls.Add(instructionIcon);

            routeInfoPanel.AutoScroll = true;
            routeInfoPanel.HorizontalScroll.Enabled = false;
            routeInfoPanel.Controls.Add(newPanel);
        }
    }
}

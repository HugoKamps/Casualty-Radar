using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using KBS_SE3.Core;
using KBS_SE3.Models;
using KBS_SE3.Models.Navigation;
using KBS_SE3.Properties;
using KBS_SE3.Utils;

namespace KBS_SE3.Modules {
    partial class NavigationModule : UserControl, IModule
    {
        private readonly LocationManager _locationManager;
        private GMapOverlay _routeOverlay;

        public NavigationModule() {
            InitializeComponent();
            _locationManager = new LocationManager();
            var y = 0;
            var color = Color.Gainsboro;

            var navSteps = new List<NavigationStep> {
                new NavigationStep("Sla rechtsaf", "100m", RouteStepType.Right),
                new NavigationStep("Sla linksaf", "500m", RouteStepType.Left),
                new NavigationStep("Ga rechtdoor", "1.2km", RouteStepType.Straight),
                new NavigationStep("Sla linksaf", "5km", RouteStepType.Left),
                new NavigationStep("Ga links op de rotonde", "2km", RouteStepType.Left),
                new NavigationStep("Rijd een kind aan", "500m", RouteStepType.Straight)
            };

            foreach (var t in navSteps) {
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
        }

        public void GetRouteMap(double startLat, double startLng, double destLat, double destLng) {
            map.Overlays.Clear();
            map.ShowCenter = false;
            map.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            map.Position = new PointLatLng((startLat + destLat) / 2, (startLng + destLng) / 2);
            var markersOverlay = new GMapOverlay("markers");
            _routeOverlay = new GMapOverlay("routes");
            map.Overlays.Add(markersOverlay);
            map.Overlays.Add(_routeOverlay);

            markersOverlay.Markers.Add(_locationManager.CreateMarker(startLat, startLng, 0));
            markersOverlay.Markers.Add(_locationManager.CreateMarker(destLat, destLng, 2));

            // Dummy data for drawing a route
            var points = new List<PointLatLng>();
            points.Add(new PointLatLng(52.1744700, 5.3933600));
            points.Add(new PointLatLng(52.1746868, 5.3938107));
            points.Add(new PointLatLng(52.1748315, 5.3942292));
            _locationManager.DrawRoute(points, _routeOverlay);
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
            var newPanel = new Panel {
                Location = new Point(0, y),
                Size = new Size(338, 50),
                BackColor = color
            };

            var distanceLabel = new Label {
                Location = new Point(10, 0),
                Size = new Size(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Text = step.Distance
            };

            var instructionLabel = new Label {
                Location = new Point(60, 0),
                Size = new Size(130, 50),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Microsoft Sans Serif", 9),
                Text = step.Instruction
            };

            var instructionIcon = new PictureBox {
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

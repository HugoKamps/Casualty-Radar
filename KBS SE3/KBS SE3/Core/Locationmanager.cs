using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using KBS_SE3.Models.DataControl;
using KBS_SE3.Models.DataControl.Graph;
using KBS_SE3.Properties;
using KBS_SE3.Utils;

namespace KBS_SE3.Core {
    public class LocationManager {
        public double CurrentLatitude { get; set; } //The user's current latitude
        public double CurrentLongitude { get; set; } //The user's current longitude
        public List<Way> Ways = new List<Way>();

        //Function that gets the coordinates of the user's default location (in settings) and changes the local lat and lng variables
        public void SetCoordinatesByLocationSetting() {
            string location = Settings.Default.userLocation + ", The Netherlands";
            string requestUri =
                $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(location)}&sensor=false";

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            if (result != null) {
                XElement locationElement = result.Element("geometry").Element("location");
                string lat = Regex.Replace(locationElement.Element("lat").ToString(), "<.*?>", string.Empty);
                string lng = Regex.Replace(locationElement.Element("lng").ToString(), "<.*?>", string.Empty);
                CurrentLatitude = double.Parse(lat.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                CurrentLongitude = double.Parse(lng.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }

        //Returns a marker that will be placed on a given location. The color and type are variable
        public GMarkerGoogle CreateMarker(double lat, double lng, int type) {
            string imgLocation = "../../Resources../marker_icon_";
            if (type == 0) imgLocation += "blue.png";
            if (type == 1) imgLocation += "yellow.png";
            if (type == 2) imgLocation += "red.png";
            if (type == 3) imgLocation += "selected.png";

            Image image = new Bitmap(@imgLocation);

            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng), new Bitmap(image, 30, 30));
            var distance = MapUtil.GetDistance(lat, lng, CurrentLatitude, CurrentLongitude);
            marker.ToolTip = new GMapToolTip(marker);
            marker.ToolTip.Font = new Font(FontFamily.GenericMonospace, 10);
            marker.ToolTip.TextPadding = new Size(10, 10);
            marker.ToolTipText = Math.Round(distance, 0) + "km";
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            return marker;
        }

        public PointLatLng GetLocationPoint() => new PointLatLng(CurrentLatitude, CurrentLongitude);

        // Draw streets on map
        public void DrawRoute(DataCollection collection, GMapOverlay routeOverlay) {
            List<List<PointLatLng>> list = new List<List<PointLatLng>>();

            int loop = 0;
            foreach (Way w in collection.Ways) {
                loop++;
                if (loop == 20) break;
                List<PointLatLng> points = new List<PointLatLng>();

                for (int i = 0; i < w.References.Count - 1; i++) {
                    try {
                        points.Add(new PointLatLng(w.References[i].Node.Lat, w.References[i].Node.Lon));
                    } catch {
                        throw new Exception();
                    }
                    list.Add(points);
                }
            }

            foreach (List<PointLatLng> l in list) {
                List<PointLatLng> points = l.ToList();
                routeOverlay.Routes.Add(new GMapRoute(points, "MyRoute") {
                    Stroke =
                    {
                        DashStyle = DashStyle.Solid,
                        Color = Color.FromArgb(244, 191, 66)
                    }
                });
            }
        }

        public void DrawTestRoute(DataCollection collection, GMapOverlay _routeOverlay) {
            Node begin = MapUtil.GetNearest(CurrentLatitude, CurrentLongitude, collection.Nodes);

            foreach (Way w in begin.ConnectedWays) {
                Ways.Add(w);
            }

            for (int i = 0; i < Ways.Count; i++)
                foreach (NodeReference t in Ways[i].References)
                    if (t.Node.ConnectedWays.Count >= 2)
                        for (int x = 0; x <= t.Node.ConnectedWays.Count; x++)
                            foreach (Way way in t.Node.ConnectedWays)
                                if (!Ways.Contains(way)) Ways.Add(way);

            foreach (Way w in Ways) {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (NodeReference t in w.References) {
                    try {
                        points.Add(new PointLatLng(t.Node.Lat, t.Node.Lon));
                    } catch {
                        throw new Exception();
                    }
                }

                foreach (PointLatLng p in points) {
                    List<PointLatLng> l = new List<PointLatLng>();

                    foreach (PointLatLng t in l) {
                        points.Add(t);
                    }
                    _routeOverlay.Routes.Add(new GMapRoute(points, "MyRoute") {
                        Stroke =
                        {
                            DashStyle = DashStyle.Solid,
                            Color = Color.SeaGreen
                        }
                    });
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
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
using Casualty_Radar.Models.DataControl;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Properties;
using Casualty_Radar.Utils;


namespace Casualty_Radar.Core {
    /// <summary>
    /// Class that contains functionality which can be used on a GMAP.net control
    /// </summary>
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
            marker.ToolTip.Fill = new SolidBrush(Color.White);
            marker.ToolTip.Foreground = new SolidBrush(Color.FromArgb(210, 73, 57));
            marker.ToolTip.Font = new Font(FontFamily.GenericMonospace, 10);
            marker.ToolTip.TextPadding = new Size(10, 10);
            marker.ToolTipText = Math.Round(distance, 0) + "km";
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            return marker;
        }

        public PointLatLng GetLocationPoint() => new PointLatLng(CurrentLatitude, CurrentLongitude);

        // Draw streets on map
        public void DrawRoute(List<PointLatLng> points, GMapOverlay routeOverlay) {
            routeOverlay.Routes.Add(new GMapRoute(points, "MyRoute") {
                Stroke = {
                    DashStyle = DashStyle.Solid,
                    Color = Color.FromArgb(244, 191, 66)
                }
            });
        }
    }
}
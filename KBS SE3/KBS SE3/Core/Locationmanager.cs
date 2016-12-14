using System;
using System.Device.Location;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using KBS_SE3.Models;
using KBS_SE3.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using KBS_SE3.Utils;
using System.Windows.Forms;

namespace KBS_SE3.Core {
    internal class LocationManager {
        public double _currentLatitude { get; set; }  //The user's current latitude
        public double _currentLongitude { get; set; }  //The user's current longitude

        //Function that gets the coordinates of the user's default location (in settings) and changes the local lat and lng variables
        public void SetCoordinatesByLocationSetting() {
            var location = Settings.Default.userLocation + ", The Netherlands";
            var requestUri = $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(location)}&sensor=false";

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            if (result != null) {
                var locationElement = result.Element("geometry").Element("location");
                var lat = Regex.Replace(locationElement.Element("lat").ToString(), "<.*?>", string.Empty);
                var lng = Regex.Replace(locationElement.Element("lng").ToString(), "<.*?>", string.Empty);
                _currentLatitude = double.Parse(lat.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                _currentLongitude = double.Parse(lng.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }

        //Returns a marker that will be placed on a given location. The color and type are variable
        public GMarkerGoogle CreateMarker(double lat, double lng, int type) {
            var imgLocation = "../../Resources../marker_icon_";
            if (type == 0) imgLocation += "blue.png";
            if (type == 1) imgLocation += "yellow.png";
            if (type == 2) imgLocation += "red.png";
            if (type == 3) imgLocation += "selected.png";
            
            var image = (Image)new Bitmap(@imgLocation);

            var marker = new GMarkerGoogle(new PointLatLng(lat, lng), new Bitmap(image, 30, 30));
            return marker;
        }

        public PointLatLng GetLocationPoint() => new PointLatLng(_currentLatitude, _currentLongitude);

        public void DrawRoute(IList<PointLatLng> points, GMapOverlay _routeOverlay) {
            //_routeOverlay.Routes.Clear();
            GMapRoute r = new GMapRoute(points, "MyRoute") {
                Stroke = {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Solid,
                    Color = Color.FromArgb(210, 73, 57)
                }
            };
            _routeOverlay.Routes.Add(r);
        }

        public double GetCurrentLatitude() => _currentLatitude;
        public double GetCurrentLongitude() => _currentLongitude;
    }
}
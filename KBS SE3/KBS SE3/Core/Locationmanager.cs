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
        private readonly GMapControl _map;  //Control which the map will be placed on
        private double _currentLatitude;    //The user's current latitude
        private double _currentLongitude;   //The user's current longitude
        private bool _hasLocationservice;    //Indicates if the user has GPS enabled or not
        private GMapOverlay _routeOverlay;

        //Initializes the GPS watcher and it's events and initializes the Map control of the HomeModule which the map will be placed on
        public LocationManager(GMapControl map) {
            _hasLocationservice = false;
            SetCoordinatesByLocationSetting();
            _map = map;
            var watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.StatusChanged += watcher_StatusChanged;
            watcher.Start();
            if (_hasLocationservice) _map.Position = new PointLatLng(_currentLatitude, _currentLongitude);
            else _map.SetPositionByKeywords(Settings.Default.userLocation);
        }

        /* 
        Function that displays a map in the HomeModule. First it checks if the user has a working internet connection. 
        It creates a marker on the user's current location and on all the incidents coming from the Feed.
        */
        public void GetMap(bool hasLocationService) {
            if (ConnectionUtil.HasInternetConnection()) {
                _map.Overlays.Clear();
                _map.ShowCenter = false;
                _map.MapProvider = GoogleMapProvider.Instance;
                GMaps.Instance.Mode = AccessMode.ServerOnly;
                var markersOverlay = new GMapOverlay("markers");
                _routeOverlay = new GMapOverlay("routes");
                _map.Overlays.Add(markersOverlay);
                _map.Overlays.Add(_routeOverlay);

                //If the user has location services enabled it uses the lat and lng that the GPS returns. If not it uses the user's standard location
                if (hasLocationService) {
                    markersOverlay.Markers.Add(CreateMarker(_currentLatitude, _currentLongitude, 0));
                } else {
                    SetCoordinatesByLocationSetting();
                    markersOverlay.Markers.Add(CreateMarker(_currentLatitude, _currentLongitude, 0));
                }
                foreach (var alert in Feed.GetInstance().GetAlerts()) {
                    var type = alert.Type == 1 ? 1 : 2;
                    markersOverlay.Markers.Add(CreateMarker(alert.Lat, alert.Lng, type));
                }

                XMLUtil.read();
            }
        }

        //Function that gets the coordinates of the user's default location (in settings) and changes the local lat and lng variables
        public void SetCoordinatesByLocationSetting() {
            var location = Settings.Default.userLocation + ", The Netherlands";
            var requestUri = $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(location)}&sensor=false";

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            if (result != null)
            {
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
            var image = (Image)new Bitmap(@imgLocation);
            return new GMarkerGoogle(new PointLatLng(lat, lng), new Bitmap(image, 30, 30));
        }

        //Keeps track of the user's current location. Everytime the location changes the map is renewed and the coordinates are updated
        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            _currentLatitude = e.Position.Location.Latitude;
            _currentLongitude = e.Position.Location.Longitude;
            //GetMap(true);
        }

        //Keeps track of the watcher's status. If the user has no GPS or has shut off the GPS the user's default location will be used
        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e) {
            switch (e.Status) {
                case GeoPositionStatus.Initializing:
                    _hasLocationservice = true;
                    break;

                case GeoPositionStatus.Ready:
                    _hasLocationservice = true;
                    break;

                case GeoPositionStatus.NoData:
                    _hasLocationservice = false;
                    break;

                case GeoPositionStatus.Disabled:
                    _hasLocationservice = false;
                    break;
            }
            //GetMap(_hasLocationservice);
        }

        public void DrawRoute(IList<PointLatLng> points)
        {
            //_routeOverlay.Routes.Clear();
            GMapRoute r = new GMapRoute(points, "MyRoute")
            {
                Stroke = {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Solid,
                    Color = Color.FromArgb(210, 73, 57)
                }
            };
            _routeOverlay.Routes.Add(r);
        }
    }
}
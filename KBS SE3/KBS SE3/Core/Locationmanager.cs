using System.Device.Location;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using KBS_SE3.Models;
using KBS_SE3.Properties;

namespace KBS_SE3.Core
{
    internal class LocationManager
    {
        private readonly GMapControl _map;  //Control which the map will be placed on
        private double _currentLatitude;    //The user's current latitude
        private double _currentLongitude;   //The user's current longitude

        //Initializes the GPS watcher and it's events and initializes the Map control of the HomeModule which the map will be placed on
        public LocationManager(GMapControl map){
            _map = map;
            var watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.StatusChanged += watcher_StatusChanged;
            watcher.Start();
        }

        /* 
        Function that displays a map in the HomeModule. First it checks if the user has a working internet connection. 
        It creates a marker on the user's current location and on all the incidents coming from the Feed.
        */
        public void GetMap(bool hasLocationService) {
            if (ConnectionUtil.HasInternetConnection()) { 
                _map.ShowCenter = false;
                _map.MapProvider = GoogleMapProvider.Instance;
                GMaps.Instance.Mode = AccessMode.ServerOnly;
                var markersOverlay = new GMapOverlay("markers");

                if (hasLocationService) {
                    _map.Position = new PointLatLng(_currentLatitude, _currentLongitude);
                    markersOverlay.Markers.Add(CreateMarker(_currentLatitude, _currentLongitude, GMarkerGoogleType.blue));
                }
                else {
                    _map.SetPositionByKeywords(Settings.Default.userLocation);
                    markersOverlay.Markers.Add(CreateMarker(_currentLatitude, _currentLongitude, GMarkerGoogleType.blue));
                }

                foreach (var alert in Feed.GetInstance().GetAlerts()) {
                    markersOverlay.Markers.Add(CreateMarker(alert.Lat, alert.Lng, GMarkerGoogleType.red));
                }
                _map.Overlays.Add(markersOverlay);
            }
        }

        //Returns a marker that will be placed on a given location. The color and type are variable
        public GMarkerGoogle CreateMarker(double lat, double lng, GMarkerGoogleType type) {
            return new GMarkerGoogle(new PointLatLng(lat, lng), type);
            
        }

        //Keeps track of the user's current location. Everytime the location changes the map is renewed and the coordinates are updated
        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            _currentLatitude = e.Position.Location.Latitude;
            _currentLongitude = e.Position.Location.Longitude;
            GetMap(true);
        }

        //Keeps track of the watcher's status. If the user has no GPS or has shut off the GPS the user's default location will be used
        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e) {
            switch (e.Status) {
                case GeoPositionStatus.Initializing:
                    GetMap(true);
                    break;

                case GeoPositionStatus.Ready:
                    GetMap(true);
                    break;

                case GeoPositionStatus.NoData:
                    GetMap(false);
                    break;

                case GeoPositionStatus.Disabled:
                    GetMap(false);
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Windows.Forms;

namespace KBS_SE3.Core
{
    internal class LocationManager
    {
        private PictureBox _pictureBox;
        private double _currentLongitude;
        private double _currentLatitude;
        private readonly List<string> _points = new List<string>() {
            "52.501356,6.083451",
            "52.501988,6.082142"
        };

        public LocationManager(PictureBox pictureBox) {
            _pictureBox = pictureBox;
            var watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.TryStart(false, TimeSpan.FromMilliseconds(10000));
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            _currentLatitude = e.Position.Location.Latitude;
            _currentLongitude = e.Position.Location.Longitude;
            _points[0] = (_currentLatitude + 0.005) + ", " + (_currentLongitude + 0.005);
            _points[1] = (_currentLatitude - 0.005) + ", " + (_currentLongitude - 0.005);
            _pictureBox.Load(GetMap(_currentLatitude, _currentLongitude, _points));
        }

        public string GetMap(double currentLatitude, double currentLongitude, List<string> locations) {
            var currentLocation = currentLatitude + ", " + currentLongitude;
            var url = "https://maps.googleapis.com/maps/api/staticmap?center=" + currentLocation +
                      "&zoom=15&size=700x480&maptype=terrain&";
            url += "markers=color:blue%7Clabel:L%7C" + currentLocation + "&";

            foreach (var location in locations) {
                url += "markers=color:red%7Clabel:O%7C" + location + "&";
            }

            url += "&key=AIzaSyDoRzUMAF3osX972CDWR2rDoWc9nKafV5A";
            return url;
        }
    }
}
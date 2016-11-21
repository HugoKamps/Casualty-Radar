using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Windows.Forms;
using KBS_SE3.Models;

namespace KBS_SE3.Core
{
    internal class LocationManager
    {
        private readonly PictureBox _pictureBox;
        private double _currentLongitude;
        private double _currentLatitude;
        private string _currentLocation;
        private bool _locationFound;

        public LocationManager(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            var watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.StatusChanged += watcher_StatusChanged;
            watcher.Start();
        }

        public string GetMap(string currentLocation) {
            var url = "https://maps.googleapis.com/maps/api/staticmap?center=the,netherlands&zoom=7&size=700x480&maptype=roadmap&";
            url += "markers=color:blue%7Clabel:L%7C" + currentLocation + "&";

            foreach (var alert in Feed.Instance.Alerts) {
                url += "markers=size:mid%7Ccolor:red%7Clabel:O%7C" + alert.Lat + "," + alert.Lng + "&";
            }

            url += "&key=AIzaSyDoRzUMAF3osX972CDWR2rDoWc9nKafV5A";
            return url;
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            _currentLatitude = e.Position.Location.Latitude;
            _currentLongitude = e.Position.Location.Longitude;
            _currentLocation = _currentLatitude + "," + _currentLongitude;
            _pictureBox.Load(GetMap(_currentLocation));
        }

        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e) {
            switch (e.Status) {
                case GeoPositionStatus.Initializing:
                    _currentLocation = _currentLatitude + "," + _currentLongitude;
                    break;

                case GeoPositionStatus.Ready:
                    _currentLocation = _currentLatitude + "," + _currentLongitude;
                    break;

                case GeoPositionStatus.NoData:
                    _currentLocation = Properties.Settings.Default.userLocation;
                    break;

                case GeoPositionStatus.Disabled:
                    _currentLocation = Properties.Settings.Default.userLocation;
                    break;
            }
            _pictureBox.Load(GetMap(_currentLocation));
        }
    }
}
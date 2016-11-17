using System;
using System.Device.Location;
using System.Windows.Forms;

namespace KBS_SE3.Core {
    class LocationManager {

        public static string GetLocationProperty()
        {
            var location = "";
            var watcher = new GeoCoordinateWatcher();
            
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            MessageBox.Show("1");

            var coord = watcher.Position.Location;
            if (coord.IsUnknown) return location;
            var currentLat = coord.Latitude;
            var currentLng = coord.Longitude;
            location = currentLat + "," + currentLng;
            MessageBox.Show(location);

            return location;
        }
    }
}

using System;
using Casualty_Radar.Models.DataControl.Graph;

namespace Casualty_Radar.Utils {
    class RouteUtil {
        public static double AngleFromCoordinate(Node node1, Node node2) {
            double dLon = (node2.Lon - node1.Lon);

            double y = Math.Sin(dLon) * Math.Cos(node2.Lat);
            double x = Math.Cos(node1.Lat) * Math.Sin(node2.Lat) - Math.Sin(node1.Lat)
                       * Math.Cos(node2.Lat) * Math.Cos(dLon);

            double brng = Math.Atan2(y, x);

            brng = brng * (180 / Math.PI);
            brng = (brng + 360) % 360;
            brng = 360 - brng;

            return brng;
        }

        public static double CalcBearing(double angle1, double angle2) {
            double bearing = angle2 - angle1;

            if (bearing < 0)
                bearing = 360 + bearing;

            return bearing;
        }
    }
}

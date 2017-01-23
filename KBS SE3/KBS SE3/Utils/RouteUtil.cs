using System;
using Casualty_Radar.Models.DataControl.Graph;

namespace Casualty_Radar.Utils {
    class RouteUtil {
        /// <summary>		
        /// Get the angle in degrees between two lat & long points		
        /// </summary>		
        /// <param name="node1">The current node in the route</param>		
        /// <param name="node2">The next node in the route</param>				
        /// <returns>The angle between two coordinates</returns>
        public static double AngleFromCoordinate(Node node1, Node node2) {
            double dLon = node2.Lon - node1.Lon;

            double y = Math.Sin(dLon) * Math.Cos(node2.Lat);
            double x = Math.Cos(node1.Lat) * Math.Sin(node2.Lat) - Math.Sin(node1.Lat)
                       * Math.Cos(node2.Lat) * Math.Cos(dLon);

            double brng = Math.Atan2(y, x);

            brng = brng * (180 / Math.PI);
            brng = (brng + 360) % 360;
            brng = 360 - brng;

            return brng;
        }

        /// <summary>
        /// Calculate the bearing between two angles
        /// If it is lower than 0, add 360 to it so it will always be a positive number
        /// </summary>
        /// <param name="angle1">The angle of the current node</param>
        /// <param name="angle2">The angle of the next node</param>
        /// <returns>The bearing between two angles</returns>
        public static double CalcBearing(double angle1, double angle2) {
            double bearing = angle2 - angle1;

            if (bearing < 0)
                bearing = 360 + bearing;

            return bearing;
        }
    }
}
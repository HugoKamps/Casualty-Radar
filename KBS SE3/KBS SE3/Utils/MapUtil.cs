using KBS_SE3.Models.DataControl.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Utils {
    static class MapUtil {

        // Radius of the earth in KM
        private const double EARTH_RADIUS = 6371;

        // Converts the given angle to a radian
        private static double ToRad(double input) {
            return input * (Math.PI / 180);
        }

        /*
        * Calculates the distance in KM between node A and node B.
        * This calculation uses the 'Haversine' algorithm to calculate the distances 
        * based on Longitude and Latitude.
        */
        public static double GetDistance(Node alpha, Node beta) {
            double dLat = ToRad(beta.Lat - alpha.Lat);
            double dLon = ToRad(beta.Lon - alpha.Lon);
            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(ToRad(alpha.Lat)) * Math.Cos(ToRad(beta.Lat)) *
                       Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EARTH_RADIUS * c;
        }




    }
}

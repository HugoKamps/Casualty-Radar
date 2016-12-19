using KBS_SE3.Models.DataControl;
using KBS_SE3.Models.DataControl.Graph;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS_SE3.Core.Algorithms.AStar;

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
            return GetDistance(alpha.Lat, alpha.Lon, beta.Lat, beta.Lon);
        }

        /*
        * Calculates the distance in KM between the given longitude and latitudes.
        * This calculation uses the 'Haversine' algorithm to calculate the distances 
        * based on Longitude and Latitude.
        */
        public static double GetDistance(double lat1, double lon1, double lat2, double lon2) {
            double dLat = ToRad(lat2 - lat1);
            double dLon = ToRad(lon2 - lon1);
            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                       Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EARTH_RADIUS * c;
        }

        /*
        * Returns the Node that is the most near to the given latitude and longitude.
        * Nodes from the given collection will be compared to the longitude and latitude.
        * Be aware that this method should only be used to compare latitudes and longitudes and not
        * two nodes since the given node might be existent in the given collection aswell, this would return the
        * same node you passed as parameter.
        */
        public static Node GetNearest(double lat, double lon, List<Node> targetCollection) => 
            targetCollection.Select(x => x).OrderBy(x => GetDistance(x.Lat, x.Lon, lat, lon)).First();

        /*
        * Returns the node that is the most near to the given Node.
        * This method will not return the given node (since that is technically the most near one) but a
        * different node that is 'technically' the second most near.
        */
        public static Node GetNearest(Node origin, List<Node> targetCollection) =>
            targetCollection.Select(x => x).OrderBy(x => GetDistance(x.Lat, x.Lon, origin.Lat, origin.Lon)).ElementAt(1);

        /*
        * Returns all nodes that are adjacent to the given origin Node.
        * This method will return both intersections and straight-line nodes.
        * Adjacent nodes are nodes that are located next to the given node as long as they're
        * part of the same way.
        */
        public static List<Node> GetAdjacentNodes(Node origin) {
            List<Node> rtn = new List<Node>();
            foreach (Way w in origin.ConnectedWays) {
                List<Node> references = w.References.Select(x => x.Node).OrderBy(x => x.ID).ToList();
                int idx = references.IndexOf(origin);
                if(idx > 0) rtn.Add(references[idx-1]);
                if(references.Count > idx+1) rtn.Add(references[idx+1]);
            }
            return rtn;
        }



    }
}

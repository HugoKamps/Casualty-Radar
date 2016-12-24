using Casualty_Radar.Models.DataControl.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Casualty_Radar.Utils {
    static class MapUtil {

        /// <summary>
        /// Radius of the earth in KM
        /// </summary>
        private const double EARTH_RADIUS = 6371;

        /// <summary>
        /// Converts the given angle to a radian
        /// </summary>
        /// <param name="input">The double input that you want to convert</param>
        /// <returns>The converted radian</returns>
        private static double ToRad(double input) {
            return input * (Math.PI / 180);
        }

        /// <summary>
        /// Calculates the distance in KM between node A and node B.
        /// This calculation uses the 'Haversine' algorithm to calculate the distances
        /// based on Longitude and Latitude.
        /// </summary>
        /// <param name="alpha">The first node</param>
        /// <param name="beta">The second node</param>
        /// <returns>The distance between both nodes in km</returns>
        public static double GetDistance(Node alpha, Node beta) {
            return GetDistance(alpha.Lat, alpha.Lon, beta.Lat, beta.Lon);
        }

        /// <summary>
        /// Calculates the distance in KM between the given longitude and latitudes.
        /// This calculation uses the 'Haversine' algorithm to calculate the distances
        /// based on Longitude and Latitude.
        /// </summary>
        /// <param name="lat1">The latitude of the first location</param>
        /// <param name="lon1">The longitude of the first location</param>
        /// <param name="lat2">The latitude of the second location</param>
        /// <param name="lon2">The longitude of the second location</param>
        /// <returns>The distance between both locations in km</returns>
        public static double GetDistance(double lat1, double lon1, double lat2, double lon2) {
            double dLat = ToRad(lat2 - lat1);
            double dLon = ToRad(lon2 - lon1);
            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                       Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EARTH_RADIUS * c;
        }

        /// <summary>
        /// Returns the Node that is the most near to the given latitude and longitude.
        /// Nodes from the given collection will be compared to the longitude and latitude.
        /// Be aware that this method should only be used to compare latitudes and longitudes and not
        /// two nodes since the given node might be existent in the given collection aswell, this would return the
        /// same node you passed as parameter.
        /// </summary>
        /// <param name="lat">The latitude of the location</param>
        /// <param name="lon">The longitude of the location</param>
        /// <param name="targetCollection">The collection with nodes that will be compared</param>
        /// <returns>A node from the given collection that is considered the most near one to the given location</returns>
        public static Node GetNearest(double lat, double lon, List<Node> targetCollection) => 
            targetCollection.Select(x => x).OrderBy(x => GetDistance(x.Lat, x.Lon, lat, lon)).First();

        /// <summary>
        /// Returns the node that is the most near to the given Node.
        /// This method will not return the given node(since that is technically the most near one) but a
        /// different node that is 'technically' the second most near.
        /// </summary>
        /// <param name="origin">The node that will be used to compare distances</param>
        /// <param name="targetCollection">The collection with nodes that will be compared</param>
        /// <returns>A node from the given collection that is considered the most near one to the origin node</returns>
        public static Node GetNearest(Node origin, List<Node> targetCollection) =>
            targetCollection.Select(x => x).OrderBy(x => GetDistance(x.Lat, x.Lon, origin.Lat, origin.Lon)).ElementAt(1);

        /// <summary>
        /// Returns all nodes that are adjacent to the given origin Node.
        /// This method will return both intersections and straight-line nodes.
        /// Adjacent nodes are nodes that are located next to the given node as long as they're
        /// part of the same way.
        /// </summary>
        /// <param name="origin">The node that will be compared</param>
        /// <returns>The list with nodes that are adjacent to the origin node</returns>
        public static List<Node> GetAdjacentNodes(Node origin) {
            List<Node> rtn = new List<Node>();
            foreach (Way w in origin.ConnectedWays) {
                List<Node> references = w.References.Select(x => x.Node).Where(x=> x!=null).OrderBy(x => x.ID).ToList();
                int idx = references.IndexOf(origin);
                if (idx > 0) rtn.Add(references[idx - 1]);
                if (references.Count > idx + 1) rtn.Add(references[idx + 1]);
            }
            return rtn;
        }

        public static Way GetWay(Node node1, Node node2) => node1.ConnectedWays.Find(w => w.References.Contains(w.References.Find(n => n.Node == node2)));
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Casualty_Radar.Core.Algorithms;
using Casualty_Radar.Models.DataControl.Graph.Ways;
using Casualty_Radar.Utils;
using GMap.NET;

namespace Casualty_Radar.Models.DataControl.Graph {

    /// <summary>
    /// A Node is a geographic point that is used to connect paths and ways.
    /// Multiple Nodes combined form a way
    /// </summary>
    [Serializable]
    public class Node {

        /// <summary>
        ///  Represents the ID from the Node
        /// </summary>
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }

        /// <summary>
        /// Represents the Latitude value from the Node
        /// </summary>
        [XmlAttribute("b", DataType = "double")]
        public double Lat { get; set; }

        /// <summary>
        /// Represents the Longitude value from the Node
        /// </summary>
        [XmlAttribute("l", DataType = "double")]
        public double Lon { get; set; }

        /// <summary>
        /// Represents the list of ways that are directly connected to this node
        /// </summary>
        [XmlIgnore]
        public List<Way> ConnectedWays { get; private set; }

        /// <summary>
        /// The linked StarData that is used to apply the A-Star algorithm to the graph
        /// </summary>
        [XmlIgnore]
        public StarData StarData { get; set; }

        public Node() {
            ConnectedWays = new List<Way>();
        }

        /// <summary>
        /// Returns the Geo location from the Node based on the Longitude and Latitude of the Node.
        /// </summary>
        /// <returns>The location as PointLatLng object</returns>
        public PointLatLng GetPoint() => new PointLatLng(Lat, Lon);

        /// <summary>
        /// Calculates the distance between the current node and the given node
        /// </summary>
        /// <param name="node">The node that you want to calculate the distance to</param>
        /// <returns>The distance in KM between the current node and the given node</returns>
        public double DistanceTo(Node node) => MapUtil.GetDistance(this, node);

        /// <summary>
        /// Determines whether the current Node is considered an intersection
        /// </summary>
        /// <returns>True if the Node is an intersection, false if it isn't</returns>
        public bool IsIntersection() => ConnectedWays.Count > DataCollection.INTERSECTION_WAY_MINIMUM;


    }
}

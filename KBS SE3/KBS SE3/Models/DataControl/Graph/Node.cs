using GMap.NET;
using KBS_SE3.Utils;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using KBS_SE3.Core.Algorithms;

namespace KBS_SE3.Models.DataControl.Graph {

    [Serializable()]
    public class Node {

        // Represents the ID from the Node
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }

        // Represents the Latitude value from the Node
        [XmlAttribute("b", DataType = "double")]
        public double Lat { get; set; }

        // Represents the Longitude value from the Node
        [XmlAttribute("l", DataType = "double")]
        public double Lon { get; set; }

        // Represents the list of ways that are directly connected to this node
        [XmlIgnore]
        public List<Way> ConnectedWays { get; private set; }

        [XmlIgnore]
        public StarData StarData { get; set; }

        public Node() {
            ConnectedWays = new List<Way>();
        }

        // Returns the Geo location from the Node based on the Longitude and Latitude of the Node.
        public PointLatLng GetPoint() => new PointLatLng(this.Lat, this.Lon);

        // Returns the distance between the current node and the given node
        public double DistanceTo(Node node) => MapUtil.GetDistance(this, node);

        public bool IsIntersection() => this.ConnectedWays.Count > DataCollection.INTERSECTION_WAY_MINIMUM;


    }
}

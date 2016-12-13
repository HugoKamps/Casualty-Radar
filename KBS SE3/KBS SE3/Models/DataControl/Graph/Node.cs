using GMap.NET;
using KBS_SE3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public Node() {
            this.ConnectedWays = new List<Way>();
        }

        // Returns the Geo location from the Node based on the Longitude and Latitude of the Node.
        public PointLatLng GetPoint() {
            return new PointLatLng(this.Lat, this.Lon); 
        }

        // Returns the distance between the current node and the given node
        public double DistanceTo(Node node) {
            return MapUtil.GetDistance(this, node);
        }


    }
}

using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Models.DataControl.Graph.Ways;

namespace Casualty_Radar.Models.DataControl {
    /// <summary>
    /// The DataCollection consists of the result of the DataParser class.
    /// All nodes, ways and references are accessed using the DataCollection;
    /// this instance is created based on XML deserialization.
    /// </summary>
    [XmlRoot("osm")]
    public class DataCollection {
        [XmlIgnore] public static readonly int INTERSECTION_WAY_MINIMUM = 2;

        [XmlIgnore]
        public WayTypeControl WayControl { get; }

        [XmlElement("n")]
        public List<Node> Nodes { get; private set; }

        [XmlElement("w")]
        public List<Way> Ways { get; private set; }

        [XmlIgnore]
        public List<Node> Intersections { get; }

        public DataCollection() {
            Nodes = new List<Node>();
            Ways = new List<Way>();
            Intersections = new List<Node>();
            WayControl = new WayTypeControl(this);
        }

        /// <summary>
        /// Indexes all Nodes using a Dictionary.
        /// Dictionaries are faster than plain looping which means the loading is faster.
        /// After deserialization each NodeReference is connected to the correct Node instance.
        /// This method prevents identical instances of the Node object.
        /// </summary>
        public void Index() {
            Dictionary<long, Node> nodeCollection = this.Nodes.ToDictionary(n => n.ID, n => n);
            foreach (Way way in this.Ways) {
                way.WayType = WayControl.ParseWayType(way.TypeDescription);
                foreach (NodeReference reference in way.References)
                    if (nodeCollection.ContainsKey(reference.ReferenceID)) {
                        reference.Node = nodeCollection[reference.ReferenceID];
                        reference.Node.ConnectedWays.Add(way);
                        if (reference.Node.IsIntersection())
                            Intersections.Add(reference.Node);
                    }
            }
        }
    }
}
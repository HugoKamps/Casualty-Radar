using Casualty_Radar.Models.DataControl.Graph;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Casualty_Radar.Models.DataControl.Graph.Ways;

namespace Casualty_Radar.Models.DataControl {

    /// <summary>
    /// The DataCollection consists of the result of the DataParser class.
    /// This class is the main link between the object data and the object logic
    /// </summary>
    [XmlRoot("osm")]
    public class DataCollection {

        [XmlIgnore]
        public static readonly int INTERSECTION_WAY_MINIMUM = 2;

        /// <summary>
        /// The WayControl is used to apply logic and calculations to the ways.
        /// This field is also used to determine zoomlevels on waytypes
        /// </summary>
        [XmlIgnore]
        public WayTypeControl WayControl { get; }

        /// <summary>
        /// All 'Node' elements that are returned from the deserialization.
        /// We require an in-memory list of nodes to link Node references that are linked to a way
        /// to a Node instance from our software.
        /// </summary>
        [XmlElement("n")]
        public List<Node> Nodes { get; private set; }


        /// <summary>
        /// All 'Way' elements that are returned from the deserialization.
        /// We require an in-memory list of ways for applying our own algorithms 
        /// and draw a graph.
        /// </summary>
        [XmlElement("w")]
        public List<Way> Ways { get; private set; }


        /// <summary>
        /// Nodes that have connected ways are considered Intersections.
        /// Intersections are used to build maps and calculate routes.
        /// Without intersections we wouldn't know how the roads are connected.
        /// </summary>
        [XmlIgnore]
        public List<Node> Intersections { get; }

        public DataCollection() {
            this.Nodes = new List<Node>();
            this.Ways = new List<Way>();
            this.Intersections = new List<Node>();
            this.WayControl = new WayTypeControl(this);
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
                way.WayType = WayControl.GetTypeBase(way.TypeDescription);
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

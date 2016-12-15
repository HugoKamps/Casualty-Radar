using KBS_SE3.Models.DataControl.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KBS_SE3.Models.DataControl {

    [XmlRoot("osm")]
    public class DataCollection {

        [XmlIgnore]
        public static readonly int INTERSECTION_WAY_MINIMUM = 2; 

        /*
        * All 'Node' elements that are returned from the deserialization.
        * We require an in-memory list of nodes to link Node references that are linked to a way
        * to a Node instance from our software.
        */
        [XmlElement("n")]
        public List<Node> Nodes { get; private set; }

        /*
        * All 'Way' elements that are returned from the deserialization.
        * We require an in-memory list of ways for applying our own algorithms 
        * and draw a graph.
        */
        [XmlElement("w")]
        public List<Way> Ways { get; private set; }

        /*
        * Nodes that have connected ways are considered Intersections.
        * Intersections are used to build maps and calculate routes.
        * Without intersections we wouldn't know how the roads are connected.
        */
        [XmlIgnore]
        public List<Node> Intersections { get; private set; }

        public DataCollection() {
            this.Nodes = new List<Node>();
            this.Ways = new List<Way>();
            this.Intersections = new List<Node>();
        }

        /*
        * Indexes all Nodes using a Dictionary.
        * Dictionaries are faster than plain looping which means the loading is faster.
        * After deserialization each NodeReference is connected to the correct Node instance.
        * This method prevents identical instances of the Node object.
        */
        public void Index() {
            Dictionary<long, Node> nodeCollection = this.Nodes.ToDictionary(n => n.ID, n => n);
            foreach (Way way in this.Ways)
                foreach (NodeReference reference in way.References)
                    if (nodeCollection.ContainsKey(reference.ReferenceID)) {
                        reference.Node = nodeCollection[reference.ReferenceID];
                        reference.Node.ConnectedWays.Add(way);
                        if (reference.Node.ConnectedWays.Count > INTERSECTION_WAY_MINIMUM)
                            Intersections.Add(reference.Node);
                    }
        }

    }
}

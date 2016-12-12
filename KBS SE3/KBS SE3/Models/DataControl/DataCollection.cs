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

        public DataCollection() {
            this.Nodes = new List<Node>();
            this.Ways = new List<Way>();
        }

        /*
        * Indexes all Nodes using a Dictionary.
        * Dictionaries are faster than plain looping which means the loading is faster.
        * After deserialization each NodeReference is connected to the correct Node instance.
        * This method prevents identical instances of the Node object.
        */
        public void Index() {
            var nodeCollection = this.Nodes.ToDictionary(n => n.ID, n => n);
            foreach (Way way in this.Ways)
                foreach (NodeReference reference in way.References)
                    reference.Node = nodeCollection[reference.ReferenceID];
        }
        
    }
}

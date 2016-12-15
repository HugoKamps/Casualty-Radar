using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KBS_SE3.Models.DataControl.Graph {

    [Serializable()]
    public class NodeReference {

        /*
        * The reference ID represents the reference to a Node ID.
        * Because multiple ways might contain the same Node we have to use references instead of the full node
        */
        [XmlAttribute("rf", DataType = "long")]
        public long ReferenceID { get; set; }

        /*
        * To prevent multiple instances from the same Node we have to link the ReferenceID to an actual Node instance.
        * If we would create a new node from every Node reference we would get multiple (identical) Node instances with the same data.
        * This way we guarantee we create only one instance of a node.
        *
        * Because the Node doesn't exist in the XML we have to add the XMLIgnore attribute so the deserialization won't throw an error
        */
        [XmlIgnore]
        public Node Node { get; set; }
    }
}

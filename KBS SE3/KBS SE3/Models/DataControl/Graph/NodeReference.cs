using System;
using System.Xml.Serialization;

namespace Casualty_Radar.Models.DataControl.Graph {

    /// <summary>
    /// A NodeReference instance is linked to a Node instance.
    /// Each ReferenceID attribute is equal to a Node ID attribute.
    /// Using this class we can link Ways directly to the connected nodes
    /// </summary>
    [Serializable]
    public class NodeReference {

        /// <summary>
        /// The reference ID represents the reference to a Node ID.
        /// Because multiple ways might contain the same Node we have to use references instead of the full node
        /// </summary>
        [XmlAttribute("rf", DataType = "long")]
        public long ReferenceID { get; set; }

        /// <summary>
        /// To prevent multiple instances from the same Node we have to link the ReferenceID to an actual Node instance.
        /// If we would create a new node from every Node reference we would get multiple(identical) Node instances with the same data.
        /// This way we guarantee we create only one instance of a node.
        /// 
        /// Because the Node doesn't exist in the XML we have to add the XMLIgnore attribute so the deserialization won't throw an error
        /// </summary>
        [XmlIgnore]
        public Node Node { get; set; }
    }
}

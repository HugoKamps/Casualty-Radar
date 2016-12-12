using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KBS_SE3.Models.DataControl.Graph {

    [Serializable()]
    public class Way {

        // Represents the ID from the Way
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }

        // Represents all of the Node references in the Way
        [XmlElement("nd")]
        public List<NodeReference> References { get; private set; }

        public Way() {
            this.References = new List<NodeReference>();
        }
    }
}

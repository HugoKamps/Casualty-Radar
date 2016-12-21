using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using KBS_SE3.Models.DataControl.Graph.Ways;

namespace KBS_SE3.Models.DataControl.Graph {

    [Serializable()]
    public class Way {

        // Represents the ID from the Way
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }

        // Represents the Name of the Way, may be null
        [XmlAttribute("nm", DataType = "string")]
        public string Name { get; set; }

        /*
        * Represents the maxspeed of the way, may be null.
        * The maximumspeed is currently not based on km/h and requires
        * a manual parser to get the km/h.
        */
        [XmlAttribute("ms", DataType = "double")]
        public double MaxSpeed { get; set; }

        // Represents the type description of the way, may be null
        [XmlAttribute("t", DataType = "string")]
        public string TypeDescription { get; set; }

        /*
        * Represents the type of the way
        * This is used for zoomlevels and drawing purposes.
        * The way type is based on the TypeDescription.
        */
        [XmlIgnore]
        public WayTypeBase WayType { get; set; }

        // Represents all of the Node references in the Way
        [XmlElement("nd")]
        public List<NodeReference> References { get; private set; }

        public Way() {
            this.References = new List<NodeReference>();
        }
    }
}

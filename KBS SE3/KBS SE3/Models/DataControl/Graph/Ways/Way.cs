using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Casualty_Radar.Models.DataControl.Graph.Ways;

namespace Casualty_Radar.Models.DataControl.Graph {

    /// <summary>
    /// A Way is a geographical way that consists of multiple node references.
    /// Those nodes connected make the way.
    /// </summary>
    [Serializable()]
    public class Way {


        /// <summary>
        /// Represents the ID from the Way
        /// </summary>
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }


        /// <summary>
        /// Represents the Name of the Way, may be null
        /// </summary>
        [XmlAttribute("nm", DataType = "string")]
        public string Name { get; set; }

        /// <summary>
        /// Represents the maxspeed of the way, may be null.
        /// The maximumspeed is currently not based on km/h and requires
        /// a manual parser to get the km/h.
        /// </summary>
        [XmlAttribute("ms", DataType = "double")]
        public double MaxSpeed { get; set; }


        /// <summary>
        /// Represents the junction type from the way, may be null.
        /// If the way is considered a junction there is a chance the way
        /// is actually a roundabout.
        /// </summary>
        [XmlAttribute("jc", DataType = "string")]
        public String JunctionType { get; set; } 

        /// <summary>
        /// Represents the type description of the way, may be null
        /// </summary>
        [XmlAttribute("t", DataType = "string")]
        public string TypeDescription { get; set; }

        /// <summary>
        /// Represents the type of the way
        /// This is used for zoomlevels and drawing purposes.
        /// The way type is based on the TypeDescription.
        /// </summary>
        [XmlIgnore]
        public WayTypeBase WayType { get; set; }

        /// <summary>
        /// Represents all of the Node references in the Way
        /// </summary>
        [XmlElement("nd")]
        public List<NodeReference> References { get; private set; }

        public Way() {
            this.References = new List<NodeReference>();
        }
    }
}

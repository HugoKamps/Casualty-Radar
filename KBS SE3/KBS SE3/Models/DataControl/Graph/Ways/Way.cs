using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Casualty_Radar.Models.DataControl.Graph.Ways {
    /// <summary>
    /// A Way is a geographical way that consists of multiple node references.
    /// Those nodes connected make the way.
    /// A way consists of multiple attributes that are deserialized from the flatfile. 
    /// </summary>
    [Serializable]
    public class Way {
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }

        [XmlAttribute("nm", DataType = "string")]
        public string Name { get; set; }

        [XmlAttribute("ms", DataType = "double")]
        public double MaxSpeed { get; set; }

        [XmlAttribute("ow", DataType = "string")]
        public String OneWayTag { get; set; }

        /// <summary>
        /// A junctiontype is a simple tag that determines what kind of way the current way is.
        /// This tag is used to check if a the current Way is a roundabout or a different kind of junction.
        /// </summary>
        [XmlAttribute("jc", DataType = "string")]
        public String JunctionType { get; set; }

        /// <summary>
        /// The TypeDescription is a small key that represents a certain kind of way type.
        /// This key is used to fetch the correct WayType.
        /// </summary>
        [XmlAttribute("t", DataType = "string")]
        public string TypeDescription { get; set; }

        [XmlIgnore]
        public WayType WayType { get; set; }

        [XmlElement("nd")]
        public List<NodeReference> References { get; private set; }

        public Way() {
            References = new List<NodeReference>();
        }

        /// <summary>
        /// Determines whether the current Way is one-way or not.
        /// If there is no available tag the method will return false
        /// </summary>
        /// <returns>True if the way is considered a one-way street</returns>
        public bool OneWay() {
            return OneWayTag != null && OneWayTag == "yes";
        }

        /// <summary>
        /// Determines whether the current way is a roundabout or not.
        /// This is based on the junction type and will return false if the junction type
        /// is not available
        /// </summary>
        /// <returns>True if the way is a roundabout</returns>
        public bool Roundabout() {
            return JunctionType != null && JunctionType == "ra";
        }
    }
}
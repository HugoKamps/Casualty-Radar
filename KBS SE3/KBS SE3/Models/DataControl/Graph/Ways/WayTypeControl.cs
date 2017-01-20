using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Casualty_Radar.Models.DataControl.Graph.Ways {
    
    /// <summary>
    /// The WayTypeControl class is used to identify waytypes of a way.
    /// Using the given datacollection each way will be linked to a waytype which 
    /// in itself is linked to a zoomlevel.
    /// </summary>
    public class WayTypeControl {

        private readonly DataCollection _collection;

        public WayTypeControl(DataCollection collection) {
            this._collection = collection;
        }

        /// <summary>
        /// Returns a WayType based on the given key.
        /// A waytype is related to a zoomlevel therefor it is important to identify ways.
        /// </summary>
        /// <param name="key">The key name of the waytype</param>
        /// <returns>A WayType constant</returns>
        public WayType ParseWayType(string key) {
            switch (key) {
                case "liv": return WayType.LivingStreet;
                case "mot": return WayType.MotorWay;
                case "mot_l": return WayType.MotorWayLink;
                case "pth": return WayType.Path;
                case "pri_l": return WayType.PrimaryLink;
                case "pri": return WayType.PrimaryWay;
                case "res": return WayType.ResidentialWay;
                case "sec_l": return WayType.SecondaryLink;
                case "sec": return WayType.SecondaryWay;
                case "ter_l": return WayType.TertiaryLink;
                case "ter": return WayType.TertiaryWay;
                case "tru": return WayType.Trunk;
                case "tru_l": return WayType.TrunkLink;
                default: case "unc": return WayType.UnclassifiedWay;


            }
        }

        /// <summary>
        /// Returns a collection of ways based on the given Zoomlevel.
        /// This method returns a(lazy-loaded) IEnumerable filled with all ways that are at the same zoom level 
        /// as the given zoomlevel.
        /// This method uses the given data collection
        /// </summary>
        /// <param name="level">The requested zoomlevel</param>
        /// <returns>An lazy-loaded collection with all ways that have the same zoomlevel as the given level</returns>
        public IEnumerable<Way> GetByZoomLevel(WayZoomLevel level) => _collection.Ways.Select(x => x).Where(x => (int) x.WayType == (int) level);
    }
}

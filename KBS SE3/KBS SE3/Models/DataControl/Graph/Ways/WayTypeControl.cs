using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Casualty_Radar.Models.DataControl.Graph.Ways {
    
    /// <summary>
    /// A WayTypeControl consist of calculations and logic that are used for zoomlevels and waytypes.
    /// The WayTypeControl can only be accessed using the DataCollection.
    /// </summary>
    public class WayTypeControl {

        private readonly Dictionary<string, WayTypeBase> _typeMap;
        private readonly DataCollection _collection;

        private const string NAMESPACE_PATH = @"Casualty_Radar.Models.DataControl.Graph.Ways.WayTypes";

        public WayTypeControl(DataCollection collection) {
            this._typeMap = new Dictionary<string, WayTypeBase>();
            this._collection = collection;
            Init();
        }

        /// <summary>
        /// Uses C# reflection to loop through a folder and initializes every instance of WayTypeBase.
        /// Because we use reflection every new waytype will be initalized dynamically.This means we don't have to
        /// manually initialize every instance of WayTypeBase.
        /// Because we create only one instance of each WayTypeBase we make sure there aren't duplicate instances.
        /// </summary>
        private void Init() {
            List<Type> wayTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => a.IsClass && a.Namespace != null &&
                a.Namespace.Contains(NAMESPACE_PATH)).ToList();
            foreach (Type t in wayTypes) {
                WayTypeBase type = (WayTypeBase)Activator.CreateInstance(t);
                _typeMap[type.Key] = type;
            }
        }

        /// <summary>
        /// Returns a WayTypeBase that has the same key as the given key.
        /// This method is used to link ways to the proper WayTypeBase using a dictionary.
        /// Dictionaries are much faster than a list in this case because we don't require a loop.
        /// </summary>
        /// <param name="key">The key name of the waytype</param>
        /// <returns>A WayTypeBase instance if a there's a link between the key and a way type, null if there's no link.</returns>
        public WayTypeBase GetTypeBase(string key) {
            WayTypeBase rtn = null;
            return _typeMap.TryGetValue(key, out rtn) ? rtn : null;
        }

        /// <summary>
        /// Returns a collection of ways based on the given Zoomlevel.
        /// This method returns a(lazy-loaded) IEnumerable filled with all ways that are at the same zoom level 
        /// as the given zoomlevel.
        /// This method uses the entire way collection inside the datacollection.
        /// </summary>
        /// <param name="level">The requested zoomlevel</param>
        /// <returns>An lazy-loaded collection with all ways that have the same zoomlevel as the given level</returns>
        public IEnumerable<Way> GetByZoomLevel(WayZoomLevel level) => _collection.Ways.Select(x => x).Where(x => x.WayType.ZoomLevel == level);
    }
}

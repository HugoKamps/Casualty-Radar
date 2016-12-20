﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KBS_SE3.Models.DataControl.Graph.Ways {
    public class WayTypeControl {

        private readonly Dictionary<string, WayTypeBase> _typeMap;
        private readonly DataCollection _collection;

        private const string NAMESPACE_PATH = @"KBS_SE3.Models.DataControl.Graph.Ways.WayTypes";

        public WayTypeControl(DataCollection collection) {
            this._typeMap = new Dictionary<string, WayTypeBase>();
            this._collection = collection;
            Init();
        }

        /*
        * Uses C# reflection to loop through a folder and initializes every instance of WayTypeBase.
        * Because we use reflection every new waytype will be initalized dynamically. This means we don't have to
        * manually initialize every instance of WayTypeBase.
        * Because we create only one instance of each WayTypeBase we make sure there aren't duplicate instances.
        */
        private void Init() {
            var wayTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => a.IsClass && a.Namespace != null && 
                a.Namespace.Contains(NAMESPACE_PATH)).ToList();
            foreach (Type t in wayTypes) {
                WayTypeBase type = (WayTypeBase)Activator.CreateInstance(t);
                _typeMap[type.Key] = type;
            }
        }

        /*
        * Returns a WayTypeBase that has the same key as the given key.
        * This method is used to link ways to the proper WayTypeBase using a dictionary.
        * Dictionaries are much faster than a list in this case because we don't require a loop.
        */
        public WayTypeBase GetTypeBase(string key) {
            WayTypeBase rtn = null;
            return _typeMap.TryGetValue(key, out rtn) ? rtn : null;
        } 

        /*
        * Returns a collection of ways based on the given Zoomlevel.
        * This method returns a (lazy-loaded) IEnumerable filled with all ways that are at the same zoom level 
        * as the given zoomlevel.
        * This method uses the entire way collection inside t
        */
        public IEnumerable<Way> GetByZoomLevel(WayZoomLevel level) => _collection.Ways.Select(x => x).Where(x => x.WayType.ZoomLevel == level);
    }
}
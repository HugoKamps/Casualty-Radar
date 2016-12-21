namespace Casualty_Radar.Models.DataControl.Graph.Ways {

    public abstract class WayTypeBase {

        public string Key { get; set; }
        public string Name { get; set; }
        public WayZoomLevel ZoomLevel { get; set; }

        protected WayTypeBase() { }

        protected WayTypeBase(string key, string name) {
            this.Key = key;
            this.Name = name;
        }

        protected WayTypeBase(string key, string name, WayZoomLevel level) : this(key, name) {
            this.ZoomLevel = level;
        }

        /*
          TODO: Tekenen???
        
        */
    }
}

namespace Casualty_Radar.Models.DataControl.Graph.Ways {
    /// <summary>
    /// The zoomlevel represents the current layerlevel that the user is in.
    /// The lower the zoomlevel the more details you get, the higher the zoomlevel the
    /// less details you get.
    /// The zoomlevel is used to efficiently draw roads and nodes.
    /// </summary>
    public enum WayZoomLevel {
        /// <summary>
        /// Zoomlevel of an entire country
        /// </summary>
        National = 5,

        /// <summary>
        /// Zoomlevel of a certain section or city
        /// </summary>
        Regional = 4,

        /// <summary>
        ///  Zoomlevel of a few roads 
        /// </summary>
        Local = 3
    }
}
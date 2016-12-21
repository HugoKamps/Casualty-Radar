namespace Casualty_Radar.Models.DataControl.Graph.Ways {

    /*
    * The zoomlevel represents the current layerlevel that the user is in.
    * The lower the zoomlevel the more details you get, the higher the zoomlevel the 
    * less details you get.
    * The zoomlevel is used to efficiently draw roads and nodes.
    */
    public enum WayZoomLevel {
        
        // Zoomlevel of an entire country
        National = 5,

        // Zoomlevel of a certain section or city
        Regional = 4,

        // Zoomlevel of a few roads
        Local = 3

    }
}

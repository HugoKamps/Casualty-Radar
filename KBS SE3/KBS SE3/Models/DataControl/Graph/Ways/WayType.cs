namespace Casualty_Radar.Models.DataControl.Graph.Ways {
    /// <summary>
    /// A WayType is a simple description of a way.
    /// Each waytype is visible in a specific zoomlevel, this
    /// can be used to draw only specific ways to increase loadingspeed.
    /// </summary>
    public enum WayType {
        LivingStreet = WayZoomLevel.Local,
        MotorWay = WayZoomLevel.National,
        Path = WayZoomLevel.Local,
        MotorWayLink = WayZoomLevel.National,
        PrimaryLink = WayZoomLevel.National,
        PrimaryWay = WayZoomLevel.National,
        ResidentialWay = WayZoomLevel.Local,
        SecondaryLink = WayZoomLevel.Regional,
        SecondaryWay = WayZoomLevel.Regional,
        TertiaryLink = WayZoomLevel.Regional,
        TertiaryWay = WayZoomLevel.Regional,
        Trunk = WayZoomLevel.National,
        TrunkLink = WayZoomLevel.National,
        UnclassifiedWay = WayZoomLevel.Local
    }
}
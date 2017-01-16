using GMap.NET;

namespace Casualty_Radar.Models
{
    /// <summary>
    /// Class that contains the boundary data and filename of each XML file
    /// </summary>
    class GeoMapSection
    {
        public PointLatLng UpperBound { get; set; } // The coordinates for the upper boundary
        public PointLatLng LowerBound { get; set; } // The coordinates for the lower boundary
        public string TargetFilePath { get; set; }  // The filename of the XML file

        public GeoMapSection(PointLatLng upperBound, PointLatLng lowerBound, string targetFilePath) {
            UpperBound = upperBound;
            LowerBound = lowerBound;
            TargetFilePath = targetFilePath;
        }
    }
}

using GMap.NET;

namespace Casualty_Radar.Models
{
    class GeoMapSection
    {
        public PointLatLng UpperBound { get; set; }
        public PointLatLng LowerBound { get; set; }
        public string TargetFilePath { get; set; }

        public GeoMapSection(PointLatLng upperBound, PointLatLng lowerBound, string targetFilePath) {
            UpperBound = upperBound;
            LowerBound = lowerBound;
            TargetFilePath = targetFilePath;
        }
    }
}

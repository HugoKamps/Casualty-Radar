using Casualty_Radar.Models.DataControl;
using GMap.NET;

namespace Casualty_Radar.Models {
    /// <summary>
    /// Class that contains the boundary data and filename of each XML file
    /// </summary>
    class GeoMapSection {
        public PointLatLng UpperBound { get; set; } // The coordinates for the upper boundary
        public PointLatLng LowerBound { get; set; } // The coordinates for the lower boundary
        public string FilePath { get; set; } // The filename of the XML file
        public DataCollection Data { get; private set; }

        public GeoMapSection(PointLatLng upperBound, PointLatLng lowerBound, string filePath) {
            UpperBound = upperBound;
            LowerBound = lowerBound;
            FilePath = filePath;
        }

        public void Load() {
            DataParser parser = new DataParser(FilePath);
            parser.Deserialize();
            Data = parser.GetCollection();
        }
    }
}
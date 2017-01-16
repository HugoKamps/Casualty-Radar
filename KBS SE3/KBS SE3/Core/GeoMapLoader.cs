using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Casualty_Radar.Models;
using GMap.NET;

namespace Casualty_Radar.Core {
    class GeoMapLoader {
        private readonly List<GeoMapSection> _geoMapSections; // List that contains all the GeoMapSection instances of the XML files

        private const string NAMESPACE_PATH = @"../../Resources/XML";

        public GeoMapLoader() {
            _geoMapSections = new List<GeoMapSection>();
        }
        
        /// <summary>
        /// Retrieves boundary data from each XML file and creates a GeoMapSection instance for each of them
        /// </summary>
        /// <returns>Returns the list with all GeoMapSection instances</returns>
        public List<GeoMapSection> GetGeoMapSections() {
            _geoMapSections.Clear();

            List<string> filepaths = Directory.GetFiles(NAMESPACE_PATH).Select(Path.GetFileName).ToList();
            foreach (string path in filepaths) {
                XDocument document = XDocument.Load(NAMESPACE_PATH + "/" + path);
                List<double> points = new List<double>();
                foreach (var attribute in document.Element("osm").Element("bounds").Attributes().ToList()) points.Add(double.Parse(attribute.Value, CultureInfo.InvariantCulture));
                PointLatLng upperBound = new PointLatLng(points[2], points[3]);
                PointLatLng lowerBound = new PointLatLng(points[0], points[1]);
                _geoMapSections.Add(new GeoMapSection(upperBound, lowerBound, path));
            }
            return _geoMapSections;
        }
    }
}
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Casualty_Radar.Models;
using Casualty_Radar.Models.DataControl;
using GMap.NET;

namespace Casualty_Radar.Core {
    class GeoMapLoader {

        private readonly List<GeoMapSection> _geoMapSections; // List that contains all the GeoMapSection instances of the XML files


        public GeoMapLoader() {
            _geoMapSections = new List<GeoMapSection>();
        }

        private void Init() {
            List<string> directory = Directory.GetFiles(FILE_PATH).Select(Path.GetFileName).ToList();
            foreach (string fileName in directory) {
                XDocument document = XDocument.Load(FILE_PATH + "/" + fileName);
                List<double> points = new List<double>();
                foreach (var attribute in document.Element("osm").Element("bnd").Attributes().ToList()) points.Add(double.Parse(attribute.Value, CultureInfo.InvariantCulture));
                PointLatLng upperBound = new PointLatLng(points[2], points[3]);
                PointLatLng lowerBound = new PointLatLng(points[0], points[1]);
                _geoMapSections.Add(new GeoMapSection(upperBound, lowerBound, FILE_PATH + "/" + fileName));
            }
        }

        /// <summary>
        /// Retrieves boundary data from each XML file and creates a GeoMapSection instance for each of them
        /// </summary>
        /// <returns>Returns the list with all GeoMapSection instances</returns>
        public List<GeoMapSection> GetGeoMapSections() {
            if (_geoMapSections.Count == 0)
                Init();
            return _geoMapSections;
        } 
       
    }
}
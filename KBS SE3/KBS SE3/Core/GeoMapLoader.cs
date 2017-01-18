using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Casualty_Radar.Models;
using Casualty_Radar.Models.DataControl;
using GMap.NET;

namespace Casualty_Radar.Core {
    class GeoMapLoader {

        private readonly List<GeoMapSection> _geoMapSections; // List that contains all the GeoMapSection instances of the XML files

        private const string FILE_PATH = @"../../Resources/XML/Sections";

        public GeoMapLoader() {
            _geoMapSections = new List<GeoMapSection>();
        }

        private void Init() {
            List<string> directory = Directory.GetFiles(FILE_PATH).Select(Path.GetFileName).ToList();
            foreach (string fileName in directory) {
                XmlReaderSettings settings = new XmlReaderSettings();
                
                XmlReader reader = XmlReader.Create(FILE_PATH + "/" + fileName);
                if (reader.ReadToDescendant("bnd")) {
                    double minLat = double.Parse(reader.GetAttribute("minlat"), CultureInfo.InvariantCulture);
                    double minLon = double.Parse(reader.GetAttribute("minlon"), CultureInfo.InvariantCulture);
                    double maxLat = double.Parse(reader.GetAttribute("maxlat"), CultureInfo.InvariantCulture);
                    double maxLon = double.Parse(reader.GetAttribute("maxlon"), CultureInfo.InvariantCulture);

                    PointLatLng upperBound = new PointLatLng(maxLat, maxLon);
                    PointLatLng lowerBound = new PointLatLng(minLat, minLon);
                    _geoMapSections.Add(new GeoMapSection(upperBound, lowerBound, FILE_PATH + "/" + fileName));
                    reader.Close();
                }

                /*XDocument document = XDocument.Load(FILE_PATH + "/" + fileName);
                List<double> points = document.Element("osm").Element("bnd").Attributes().ToList().
                    Select(attribute => double.Parse(attribute.Value, CultureInfo.InvariantCulture)).ToList();*/
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
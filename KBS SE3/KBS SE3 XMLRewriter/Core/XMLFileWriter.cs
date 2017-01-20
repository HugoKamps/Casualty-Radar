using System;
using System.Xml.Linq;

namespace XMLRewriter.Core {
    class XmlFileWriter {

        private XDocument _doc;
        private String _destination, _fileName;
        private XElement _root;
        public XmlFileWriter(String dest, String fileName) {
            _destination = dest;
            _fileName = fileName;
            _root = new XElement("osm");
            _doc = new XDocument(new XDeclaration("1.0", "utf - 16", "true"), _root);
        }

        /// <summary>
        /// Appends the given XElement to the root element
        /// </summary>
        /// <param name="element">The new XElement</param>
        public void Append(XElement element) {
            _root.Add(element);
        }

        /// <summary>
        /// Saves the new XDocument to the destination folder with the new file name
        /// </summary>
        public void Save() {
            _doc.Save(_destination + "/"+_fileName+".xml", SaveOptions.DisableFormatting);
        }
    }
}

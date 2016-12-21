using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLRewriter.Core {
    class XMLFileWriter {

        private XDocument _doc;
        private String _destination, _fileName;
        private XElement _root;
        public XMLFileWriter(String dest, String fileName) {
            this._destination = dest;
            this._fileName = fileName;
            this._root = new XElement("osm");
            this._doc = new XDocument(new XDeclaration("1.0", "utf - 16", "true"), _root);
        }

        public void append(XElement element) {
            _root.Add(element);
        }

        public void save() {
            _doc.Save(_destination + "/"+_fileName+".xml");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLRewriter.Core {
    class XMLFileReader {

        private String _path, _destination, _fileName;
        private XMLFileWriter _writer;
        public TextBox DataLog { set; private get; }
        public ProgressBar StatusBar { set; private get; }

        public XMLFileReader(String path) {
            this._path = path;
        }

        public XMLFileReader(String path, String destination, String fileName) : this(path) {
            this._destination = destination;
            this._fileName = fileName;
        }

        public void convert() {
            if (String.IsNullOrEmpty(_fileName) || String.IsNullOrWhiteSpace(_fileName)) {
                MessageBox.Show("Please supply a name for your XML File.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            } else {
                this._writer = new XMLFileWriter(_destination, _fileName);
                log("Reading started");
                var elements = ParsedElements();
                var size = elements.Count();
                log("Found " + size + " elements to convert");
                StatusBar.Maximum = size;
                log("Writing data to new XML file");
                foreach (var element in elements) {
                    _writer.append(convertElement(element));
                    StatusBar.Value++;
                }
                log("Started Saving");
                _writer.save();
                log("Saved succesfully");
                MessageBox.Show("Converting finished, you can locate the converted file at: " + _path + @"\" + _fileName + ".xml", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }


        /*
        * Loops through the XML File and parses all the Way elements and the Node elements.
        * This method uses lazy-loading for optimalization purposes.
        */
        private IEnumerable<XElement> ParsedElements() {
            using (XmlReader reader = XmlReader.Create(_path)) {
                reader.MoveToContent();
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        if (reader.Name.Equals("node") || reader.Name.Equals("way")) {
                            XElement element = XElement.ReadFrom(reader) as XElement;
                            yield return element;
                        }
                    }
                }
            }
        }

        // Logs the given message to the DataLog usercontrol
        private void log(String msg) {
            DataLog.AppendText(msg + "\n");
        }

        /*
        * Converts the given element to a newly, rewritten, XElement.
        * Both Nodes and Ways can be returned from this method.
        * All tags and attributes are shortened to 1/2 char words.
        */
        private XElement convertElement(XElement origin) {
            switch (origin.Name.ToString()) {
                case "node":
                    string lon = origin.Attribute("lon").Value;
                    string lat = origin.Attribute("lat").Value;
                    string node_id = origin.Attribute("id").Value;
                    return new XElement("n", new XAttribute("id", node_id), new XAttribute("l", lon), new XAttribute("b", lat));
                default:
                case "way":
                    string way_id = origin.Attribute("id").Value;
                    XElement rtn = new XElement("w", new XAttribute("id", way_id));
                    foreach (XElement element in origin.Descendants()) {
                        if (element.Name.ToString().Equals("nd")) {
                            rtn.Add(new XElement("nd", new XAttribute("rf", element.FirstAttribute.Value)));
                        } else if (element.Attribute("k") != null) {
                            var value = element.Attribute("v").Value;
                            switch (element.Attribute("k").Value) {
                                case "highway":
                                    rtn.Add(new XAttribute("t", ParseWayValue(value)));
                                    break;
                                case "name":
                                    rtn.Add(new XAttribute("nm", value));
                                    break;
                                case "maxspeed":
                                    int speed;
                                    if (int.TryParse(value, out speed)) {
                                        rtn.Add(new XAttribute("ms", value));
                                    }
                                    break;
                                case "oneway":
                                    rtn.Add(new XAttribute("ow", value));
                                    break;
                            }
                        }
                    }
                    return rtn;
            }
        }

        public static String ParseWayValue(string origin) {
            switch (origin) {
                case "residential": return "res";
                case "unclassified": return "unc";
                case "motorway": return "mot";
                case "primary": return "pri";
                case "path": return "pth";
                case "trunk": return "tru";
                case "tertiary": return "ter";
                case "motorway_link": return "mot_l";
                case "trunk_link": return "tru_l";
                case "primary_link": return "pri_l";
                case "secondary_link": return "sec_l";
                case "tertiary_link": return "ter_l";
                default: case "secondary": {
                        return "sec";
                    }
            }
        }

    }
}

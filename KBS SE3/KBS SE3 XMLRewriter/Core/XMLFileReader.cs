﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLRewriter.Core {
    class XmlFileReader {
        private string _path, _destination, _fileName;
        private XmlFileWriter _writer;
        public TextBox DataLog { set; private get; }
        public ProgressBar StatusBar { set; private get; }

        public XmlFileReader(string path) {
            _path = path;
        }

        public XmlFileReader(string path, string destination, string fileName) : this(path) {
            _destination = destination;
            _fileName = fileName;
        }

        /// <summary>
        /// Starts the conversion process.
        /// This method is essentially the core method.
        /// After conversion the new XML content is saved to the destination folder.
        /// A progressbar is used to represent the status of the processing.
        /// </summary>
        public void Convert() {
            if (string.IsNullOrEmpty(_fileName) || string.IsNullOrWhiteSpace(_fileName)) {
                MessageBox.Show("Please supply a name for your XML File.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else {
                _writer = new XmlFileWriter(_destination, _fileName);
                Log("Reading started");
                IEnumerable<XElement> elements = ParsedElements();
                int size = elements.Count();
                Log("Found " + size + " elements to convert");
                StatusBar.Maximum = size;
                Log("Writing data to new XML file");
                foreach (XElement element in ParsedElements()) {
                    _writer.Append(ConvertElement(element));
                    StatusBar.Value++;
                }
                Log("Started Saving");
                _writer.Save();
                Log("Saved succesfully");
                MessageBox.Show(
                    "Converting finished, you can locate the converted file at: " + _path + @"\" + _fileName + ".xml",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Reset();
            }
        }

        private void Reset() {
            StatusBar.Value = 0;
            DataLog.Clear();
        }

        /// <summary>
        /// Loops through the XML File and parses all the Way elements and the Node elements.
        /// This method uses lazy-loading for optimalization purposes.
        /// </summary>
        /// <returns>An IEnumerable with all Node and Way elements</returns>
        private IEnumerable<XElement> ParsedElements() {
            using (XmlReader reader = XmlReader.Create(_path)) {
                reader.MoveToContent();
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        if (reader.Name.Equals("node") || reader.Name.Equals("way") || reader.Name.Equals("bounds")) {
                            XElement element = XElement.ReadFrom(reader) as XElement;
                            yield return element;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Logs the given message to the DataLog usercontrol
        /// </summary>
        /// <param name="msg">message that will be logged</param>
        private void Log(string msg) {
            DataLog.AppendText(msg + "\n");
        }

        /// <summary>
        /// Converts the given element to a newly, rewritten, XElement.
        /// Both Nodes and Ways can be returned from this method.
        /// All tags and attributes are shortened to 1/2 char words.
        /// </summary>
        /// <param name="origin">The original XElement in the existent XML file</param>
        /// <returns>A newly, shortened, XElement that is used for the new XML file</returns>
        private XElement ConvertElement(XElement origin) {
            switch (origin.Name.ToString()) {
                case "bounds":
                    return new XElement("bnd",
                        origin.Attribute("minlon"),
                        origin.Attribute("minlat"),
                        origin.Attribute("maxlon"),
                        origin.Attribute("maxlat"));
                case "node":
                    string lon = origin.Attribute("lon").Value;
                    string lat = origin.Attribute("lat").Value;
                    string nodeId = origin.Attribute("id").Value;
                    return new XElement("n", new XAttribute("id", nodeId), new XAttribute("l", lon),
                        new XAttribute("b", lat));
                default:
                case "way":
                    string wayId = origin.Attribute("id").Value;
                    XElement rtn = new XElement("w", new XAttribute("id", wayId));
                    string name = null;
                    foreach (XElement element in origin.Descendants()) {
                        if (element.Name.ToString().Equals("nd")) {
                            rtn.Add(new XElement("nd", new XAttribute("rf", element.FirstAttribute.Value)));
                        }
                        else if (element.Attribute("k") != null) {
                            string value = element.Attribute("v").Value;
                            switch (element.Attribute("k").Value) {
                                case "junction":
                                    rtn.Add(new XAttribute("jc", value == "roundabout" ? "ra" : "jh"));
                                    break;
                                case "highway":
                                    rtn.Add(new XAttribute("t", ParseWayValue(value)));
                                    break;
                                case "name":
                                    name = value;
                                    break;
                                case "ref":
                                    if (name == null)
                                        name = value;
                                    break;
                                case "maxspeed":
                                    int speed;
                                    if (int.TryParse(value, out speed))
                                        rtn.Add(new XAttribute("ms", value));
                                    break;
                                case "oneway":
                                    rtn.Add(new XAttribute("ow", value));
                                    break;
                            }
                        }
                    }
                    if (name != null)
                        rtn.Add(new XAttribute("nm", name));
                    return rtn;
            }
        }

        /// <summary>
        /// Returns the new XML key based on the original string.
        /// These keys are used to parse zoomlevels from the ways.
        /// Each key consists of a few letters that are present in the origin string.
        /// </summary>
        /// <param name="origin">The original string value</param>
        /// <returns>A shortened string (key) based on the origin value</returns>
        public static string ParseWayValue(string origin) {
            switch (origin) {
                case "residential":
                    return "res";
                case "unclassified":
                    return "unc";
                case "motorway":
                    return "mot";
                case "living_street":
                    return "liv";
                case "primary":
                    return "pri";
                case "trunk":
                    return "tru";
                case "tertiary":
                    return "ter";
                case "motorway_link":
                    return "mot_l";
                case "trunk_link":
                    return "tru_l";
                case "primary_link":
                    return "pri_l";
                case "secondary_link":
                    return "sec_l";
                case "tertiary_link":
                    return "ter_l";
                default:
                    return "sec";
            }
        }
    }
}
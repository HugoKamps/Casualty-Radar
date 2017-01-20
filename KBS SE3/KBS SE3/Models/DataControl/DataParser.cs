using System;
using System.IO;
using System.Xml.Serialization;

namespace Casualty_Radar.Models.DataControl {

    public class DataParser {

        private readonly string _filePath;
        private DataCollection _collection;

        public DataParser(string path) {
            _filePath = path;
            _collection = null;
        }

        /// <summary>
        /// Deserializes XML text data to C# Objects using data annotations.
        /// After building the objects we index the Node and NodeReferences so we 
        /// can link the correct reference with the correct Node.
        /// </summary>
        public void Deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(DataCollection));
            using(FileStream stream = new FileStream(_filePath, FileMode.Open)) {
                _collection = (DataCollection)serializer.Deserialize(stream);
                _collection.Index();
            }
        }

        /// <summary>
        /// Returns the DataCollection which holds the information regarding the Nodes and Ways
        /// This method will throw an exception if the data isn't deserialized yet.
        /// </summary>
        /// <returns>A DataCollection instance</returns>
        public DataCollection GetCollection() {
            if (_collection == null)
                throw new Exception("There's no data de-serialized yet.");
            return _collection;
        }
    }
}

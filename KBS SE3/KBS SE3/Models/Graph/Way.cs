using System.Collections.Generic;

namespace KBS_SE3.Models.Graph {
    public class Way {
        public List<Node> Nodes { get; private set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public bool OneWay { get; set; }

        public Way() {
            Nodes = new List<Node>();
        }
    }
}

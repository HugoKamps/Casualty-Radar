using System.Collections.Generic;

namespace KBS_SE3.Models.Graph.XmlClasses {
    public class Way {
        private int _id;
        private List<Node> _nodeList;
        private List<Tag> _tagList;
        public int Cost;

        public Way(int id, List<Node> nodeList, List<Tag> tagList) {
            _id = id;
            _nodeList = nodeList;
            _tagList = tagList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
    public class Way {
        private int _id;
        private List<Node> _nodeList;
        private List<Tag> _tagList;

        public Way(int id, List<Node> nodeList, List<Tag> tagList) {
            _id = id;
            _nodeList = nodeList;
            _tagList = tagList;
        }
    }
}

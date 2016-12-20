using KBS_SE3.Models.DataControl.Graph;
using KBS_SE3.Utils;

namespace KBS_SE3.Core.Algorithms {
    public enum NodeState {
        Untested,
        Open,
        Closed
    }

    public class StarData {
        private Node _parentNode;
        private Node _origin;
        public double G { get; set; } // The value which indicates the distance from the current node to an adjacent node
        public double H { get; set; } // The value which indicates the distance from the current node to the destination node
        public double F => G + H; // This value that determines the current node's usefulness for the route
        public NodeState State { get; set; }

        public Node Parent {
            get { return _parentNode; }
            set {
                _parentNode = value;
                G = _parentNode.StarData.G + MapUtil.GetDistance(_origin, _parentNode);
            }
        }

        public StarData(Node origin, Node dest) {
            _origin = origin;
            State = NodeState.Untested;
            H = MapUtil.GetDistance(_origin, dest);
            G = 0;
        }
    }
}

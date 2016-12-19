using KBS_SE3.Models.DataControl.Graph;
using KBS_SE3.Utils;

namespace KBS_SE3.Core.Algorithms {
    public enum NodeState {
        Untested,
        Open,
        Closed
    }

    public class StarNode : Node {
        private StarNode _parentNode;

        public double G { get; set; } // The value which indicates the distance from the current node to an adjacent node
        public double H { get; set; } // The value which indicates the distance from the current node to the destination node
        public double F => G + H; // This value that determines the current node's usefulness for the route
        public NodeState State { get; set; }

        public StarNode Parent {
            get { return _parentNode; }
            set {
                _parentNode = value;
                G = _parentNode.G + MapUtil.GetDistance(this, _parentNode);
            }
        }

        public StarNode(Node dest) {
            State = NodeState.Untested;
            H = MapUtil.GetDistance(this, dest);
            G = 0;
        }
    }
}

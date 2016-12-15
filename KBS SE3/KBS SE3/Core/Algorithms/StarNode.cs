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

        public double G { get; set; }
        public double H { get; set; }
        public double F => G + H;
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

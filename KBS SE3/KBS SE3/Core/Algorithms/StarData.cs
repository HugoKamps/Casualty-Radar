using System;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Utils;


namespace Casualty_Radar.Core.Algorithms {
    /// <summary>
    /// Untested nodes are nodes which are new to the algorithm.
    /// Open nodes are nodes which are being tested or have been tested and not been used.
    /// Closed nodes are the nodes that have been chosen for the path.
    /// </summary>
    public enum NodeState {
        Untested,
        Open,
        Closed
    }

    /// <summary>
    /// A class which contains all the data needed for a node in the A-Star algorithm
    /// </summary>
    public class StarData {
        private Node _parentNode;
        private Node _origin;
        public double G { get; set; } // The value which indicates the distance from the current node to an adjacent node
        public double H { get; set; } // The value which indicates the distance from the current node to the destination node
        public double F => G + H; // The value that determines the current node's usefulness for the route
        public NodeState State { get; set; } // Indicates the state of the node, see the enum

        /// <summary>
        /// Returns the parent of the current node.
        /// When a parent is being set changes the G for the current node
        /// </summary>
        public Node Parent {
            get { return _parentNode; }
            set {
                _parentNode = value;
                G = _parentNode.StarData.G + ComputeHScore(_origin.Lat, _origin.Lon, _parentNode.Lat, _parentNode.Lon);
            }
        }

        private double ComputeHScore(double lat1, double lon1, double lat2, double lon2)
        {
            return Math.Abs(lat2 - lat1) + Math.Abs(lon2 - lon1);
        }


        /// <summary>
        /// Sets and calculates the StarData for a node
        /// </summary>
        /// <param name="origin">The node which the data will be linked to</param>
        /// <param name="dest">The destination of the current path</param>
        public StarData(Node origin, Node dest) {
            _origin = origin;
            State = NodeState.Untested;
            H = MapUtil.GetDistance(_origin, dest);
            G = 0;
        }
    }
}

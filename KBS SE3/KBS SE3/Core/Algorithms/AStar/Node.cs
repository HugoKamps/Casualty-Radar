using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Core.Algorithms.AStar {
    public enum NodeState {
        Untested,
        Open,
        Closed
    }

    public class Node {
        private Node _parentNode;
        public Point Location { get; }
        public float G { get; private set; }
        public float H { get; }
        public NodeState State { get; set; }
        public float F => G + H;

        public Node ParentNode {
            get { return _parentNode; }
            set {
                // When setting the parent, also calculate the traversal cost from the start node to here (the 'G' value)
                _parentNode = value;
                G = _parentNode.G + GetTraversalCost(Location, _parentNode.Location);
            }
        }

        public Node(int lat, int lng, Point endLocation) {
            Location = new Point(lat, lng);
            State = NodeState.Untested;
            H = GetTraversalCost(Location, endLocation);
            G = 0;
        }

        public override string ToString() => $"{Location.X}, {Location.Y}: {State}";

        internal static float GetTraversalCost(Point location, Point otherLocation) {
            float deltaX = otherLocation.X - location.X;
            float deltaY = otherLocation.Y - location.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}

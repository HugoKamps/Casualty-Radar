using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Utils;

namespace Casualty_Radar.Core.Algorithms {
    /// <summary>
    /// A class which contains all the data needed for a node in the A-Star algorithm
    /// </summary>
    public class StarData {

        private Node _parentNode, _origin;
        /// <summary>
        /// The value which indicates the distance from the current node to an adjacent node
        /// </summary>
        public double G { get; set; } 
        /// <summary>
        /// The value which indicates the distance from the current node to the destination node
        /// </summary>
        public double H { get; set; }  
        /// <summary>
        /// The value that determines the current node's usefulness for the route
        /// </summary>
        public double F => G + H;  
        public bool Closed { get; set; } 

        /// <summary>
        /// Returns the parent of the current node.
        /// When a parent is being set changes the G for the current node
        /// </summary>
        public Node Parent {
            get { return _parentNode; }
            set {
                _parentNode = value;
                G = _parentNode.StarData.G +
                    MapUtil.GetAbsoluteDistance(_origin.Lat, _origin.Lon, _parentNode.Lat, _parentNode.Lon);
            }
        }

        /// <summary>
        /// Sets and calculates the StarData for a node
        /// </summary>
        /// <param name="origin">The node which the data will be linked to</param>
        /// <param name="dest">The destination of the current path</param>
        public StarData(Node origin, Node dest) {
            _origin = origin;
            Closed = false;
            H = MapUtil.GetAbsoluteDistance(_origin.Lat, _origin.Lon, dest.Lat, dest.Lon);
            G = 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Core.Algorithms.AStar {
    class Pathfinder {
        private int _width;
        private int _height;
        private Node[,] _nodes;
        private readonly Node _startNode;
        private readonly Node _endNode;
        private readonly SearchParameters _searchParameters;

        public Pathfinder(SearchParameters searchParameters) {
            _searchParameters = searchParameters;
            InitializeNodes(searchParameters.Map);
            _startNode = _nodes[searchParameters.StartLocation.X, searchParameters.StartLocation.Y];
            _startNode.State = NodeState.Open;
            _endNode = _nodes[searchParameters.EndLocation.X, searchParameters.EndLocation.Y];
        }


        /// Attempts to find a path from the start location to the end location based on the supplied SearchParameters

        /// <returns>A List of Points representing the path. If no path was found, the returned list is empty.</returns>
        public List<Point> FindPath() {
            // The start node is the first entry in the 'open' list
            var path = new List<Point>();
            var success = Search(_startNode);
            if (!success) return path;
            // If a path was found, follow the parents from the end node to build a list of locations
            var node = _endNode;
            while (node.ParentNode != null) {
                path.Add(node.Location);
                node = node.ParentNode;
            }

            // Reverse the list so it's in the correct order when returned
            path.Reverse();

            return path;
        }

        private void InitializeNodes(bool[,] map) {
            _width = map.GetLength(0);
            _height = map.GetLength(1);
            _nodes = new Node[_width, _height];
            for (var y = 0; y < _height; y++) {
                for (var x = 0; x < _width; x++) {
                    _nodes[x, y] = new Node(x, y, _searchParameters.EndLocation);
                }
            }
        }

        private bool Search(Node currentNode) {
            // Set the current node to Closed since it cannot be traversed more than once
            currentNode.State = NodeState.Closed;
            var nextNodes = GetAdjacentNodes(currentNode);

            // Sort by F-value so that the shortest possible routes are considered first
            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            foreach (var nextNode in nextNodes) {
                // Check whether the end node has been reached
                if (nextNode.Location == _endNode.Location) {
                    return true;
                }
                // If not, check the next set of nodes
                if (Search(nextNode)) // Note: Recurses back into Search(Node)
                    return true;
            }

            // The method returns false if this path leads to be a dead end
            return false;
        }

        private List<Node> GetAdjacentNodes(Node fromNode) {
            var nodes = new List<Node>();
            var nextLocations = GetAdjacentLocations(fromNode.Location);

            foreach (var location in nextLocations) {
                var x = location.X;
                var y = location.Y;

                // Stay within the grid's boundaries
                if (x < 0 || x >= _width || y < 0 || y >= _height)
                    continue;

                var node = _nodes[x, y];

                // Ignore already-closed nodes
                switch (node.State) {
                    case NodeState.Closed:
                        continue;
                    case NodeState.Open:
                        var traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
                        var gTemp = fromNode.G + traversalCost;
                        if (gTemp < node.G) {
                            node.ParentNode = fromNode;
                            nodes.Add(node);
                        }
                        break;
                    default:
                        // If it's untested, set the parent and flag it as 'Open' for consideration
                        node.ParentNode = fromNode;
                        node.State = NodeState.Open;
                        nodes.Add(node);
                        break;
                }
            }

            return nodes;
        }

        private static IEnumerable<Point> GetAdjacentLocations(Point location) {
            return new[] {
                new Point(2, 2)
            };
        }
    }
}

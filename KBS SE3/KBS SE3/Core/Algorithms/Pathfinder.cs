using System.Collections.Generic;
using GMap.NET;
using KBS_SE3.Core.Algorithms.AStar;
using KBS_SE3.Utils;

namespace KBS_SE3.Core.Algorithms {
    class Pathfinder {
        private readonly StarNode _startNode;
        private readonly StarNode _endNode;

        public Pathfinder(StarNode startNode, StarNode endNode) {
            _startNode = startNode;
            _startNode.State = NodeState.Open;
            _endNode = endNode;
        }


        // Attempts to find a path from the start location to the end location based on the supplied SearchParameters
        // Returns a List of Points representing the path. If no path was found, the returned list is empty
        public List<PointLatLng> FindPath() {
            // The start node is the first entry in the 'open' list
            var path = new List<PointLatLng>();
            var success = Search(_startNode);
            if (!success) return path;

            // If a path was found, follow the parents from the end node to build a list of locations
            var node = _endNode;
            while (node.Parent != null) {
                path.Add(node.GetPoint());
                node = node.Parent;
            }

            // Reverse the list so it's in the correct order when returned
            path.Reverse();

            return path;
        }

        private bool Search(StarNode currentNode) {
            // Set the current node to Closed since it cannot be traversed more than once
            currentNode.State = NodeState.Closed;
            var nextNodes = GetAdjacentNodes(currentNode);

            // Sort by F-value so that the shortest possible routes are considered first
            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            foreach (var nextNode in nextNodes) {
                // Check whether the end node has been reached
                if (nextNode.GetPoint() == _endNode.GetPoint()) {
                    return true;
                }
                // If not, check the next set of nodes
                if (Search(nextNode)) // Note: Recurses back into Search(Node)
                    return true;
            }

            // The method returns false if this path leads to be a dead end
            return false;
        }

        private List<StarNode> GetAdjacentNodes(StarNode fromNode) {
            var nodes = new List<StarNode>();
            var adjacentNodes = MapUtil.GetAdjacentNodes();

            foreach (var node in adjacentNodes) {
                // Ignore already-closed nodes
                switch (node.State) {
                    case NodeState.Closed:
                        continue;
                    case NodeState.Open:
                        var traversalCost = MapUtil.GetDistance(node, node.Parent);
                        var gTemp = fromNode.G + traversalCost;
                        if (gTemp < node.G) {
                            node.Parent = fromNode;
                            nodes.Add(node);
                        }
                        break;
                    case NodeState.Untested:
                        break;
                    default:
                        // If it's untested, set the parent and flag it as 'Open' for consideration
                        node.Parent = fromNode;
                        node.State = NodeState.Open;
                        nodes.Add(node);
                        break;
                }
            }

            return nodes;
        }
    }
}

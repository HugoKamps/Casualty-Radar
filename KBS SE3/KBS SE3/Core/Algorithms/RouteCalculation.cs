using System.Collections.Generic;
using System.Linq;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Utils;

namespace Casualty_Radar.Core.Algorithms {
    class RouteCalculation {
        private Node _current;
        private readonly Node _start, _end;
        private readonly List<Node> _open, _closed;
        private int _g;

        public RouteCalculation(Node start, Node end) {
            _open = new List<Node>();
            _closed = new List<Node>();
            _start = start;
            _end = end;
            _g = 0;
        }

        public void Search() {
            _start.StarData = new StarData(_start, _end);
            _open.Add(_start);
            while (_open.Count > 0) {
                _current = _open.Select(x => x).OrderBy(x => x.StarData.F).First();
                _open.Remove(_current);
                _closed.Add(_current);
                if (_closed.Contains(_end)) break;
                List<Node> nodes = MapUtil.GetAdjacentNodes(_current);
                _g++;
                foreach (Node n in nodes) {
                    if (_closed.Contains(n)) continue;
                    if (!_open.Contains(n)) {
                        n.StarData = new StarData(n, _end) {
                            G = _g,
                            H = MapUtil.GetAbsoluteDistance(n.Lat, n.Lon, _end.Lat, _end.Lon),
                            Parent = _current
                        };
                        _open.Insert(0, n);
                    } else if (_g + n.StarData.H < n.StarData.F) {
                        n.StarData.G = _g;
                        n.StarData.Parent = _current;
                    }
                }
            }
        }

        public List<Node> GetNodes() {
            List<Node> rtn = new List<Node>();
            while (_current != null) {
                rtn.Add(_current);
                _current = _current.StarData.Parent;
            }
            return rtn;
        }
    }
}

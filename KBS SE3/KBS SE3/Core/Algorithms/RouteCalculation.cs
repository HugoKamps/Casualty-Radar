using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casualty_Radar.Models.DataControl.Graph;
using Casualty_Radar.Utils;
using GMap.NET;

namespace Casualty_Radar.Core.Algorithms {
    class RouteCalculation {

        /* Eelco is een beest */
        private Node _current;
        private readonly Node _end, _start;
        private readonly List<Node> _open, _closed;
        private int _g;

        public RouteCalculation(Node start, Node end) {
            this._open = new List<Node>();
            this._closed = new List<Node>();
            this._end = end;
            this._start = start;
            this._g = 0;
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
                    else if (!_open.Contains(n)) {
                        n.StarData = new StarData(n, _end);
                        n.StarData.G = _g;
                        n.StarData.H = MapUtil.GetAbsoluteDistance(n.Lat, n.Lon, _end.Lat, _end.Lon);
                        n.StarData.Parent = _current;
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

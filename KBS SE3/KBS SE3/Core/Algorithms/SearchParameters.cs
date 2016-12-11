using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Core.Algorithms {
    class SearchParameters {
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public bool[,] Map { get; set; }

        public SearchParameters(Point startLocation, Point endLocation, bool[,] map) {
            StartLocation = startLocation;
            EndLocation = endLocation;
            Map = map;
        }
    }
}

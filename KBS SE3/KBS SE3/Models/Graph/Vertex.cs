using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
    class Vertex {
        public String name;   // Vertex name    
        public List<Edge> adj;    // Adjacent vertices    
        public double dist;
        public Vertex prev;   /* Previous vertex on 					shortest path */

        public Vertex() {
        }
    }
}

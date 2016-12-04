using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Models.Graph {
    class Graph {
        public Dictionary<String, Vertex> vertexMap = new Dictionary<string, Vertex>();

        public Vertex getVertex(string name) {
            Vertex v = vertexMap[name];
            if (v == null) {
                v = new Vertex();
                vertexMap.Add(name, v);
            }
            return v;
        }

        public void addEdge(String sourceName, String destName, double cost) {
            Vertex v = vertexMap[sourceName]; Vertex w = vertexMap[destName]; v.adj.Add(new Edge(w, cost));
        }

        public void printVertex() {
            foreach (var item in vertexMap.Values) {
                foreach (var edges in item.adj) {
                    Console.WriteLine(edges);
                }
            }

        }
    }
}

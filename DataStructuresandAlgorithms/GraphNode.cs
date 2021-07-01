using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class GraphNode
    {
        public string label { get; set; }

         private List<Edge> edges; 

        public GraphNode()
        {
            this.edges = new List<Edge>();
        }
        public void addEdge(GraphNode to, int weight)
        {
            this.edges.Add(new Edge(this, to, weight));
        }

        public List<Edge> getEdges()
        {
            return this.edges;
        }
    }

    
}

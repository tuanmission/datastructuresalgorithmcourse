using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class Edge
    {
        public int weight { get; set; }
        public GraphNode From { get; set; }
        public GraphNode To { get; set; }

        

        public Edge(GraphNode From, GraphNode To, int weight)
        {
            this.From = From;
            this.To = To;
            this.weight = weight;
        }

         public override string ToString()
        {
            return this.From.label + " ->" + this.To.label;
        }
    }
}

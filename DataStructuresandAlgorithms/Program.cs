using System;
using System.Collections.Generic;


namespace DataStructuresandAlgorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {

            UndirectedGraph graph = new UndirectedGraph();
            graph.addNode("A");
            graph.addNode("B");
            graph.addNode("C");
            graph.addNode("D");

            graph.addEdge("A", "B", 3);
            graph.addEdge("B", "C", 2);
            graph.addEdge("B", "D", 4);
            graph.addEdge("A", "C", 1);
            graph.addEdge("C", "D", 5);
            string spanningTree = graph.primsAlgorithm("A");
            Console.WriteLine(spanningTree);





        }
    }
}

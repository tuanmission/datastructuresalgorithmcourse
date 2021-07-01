using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class NodeEntry
    {
        public GraphNode Node;
        public int priority;

        public NodeEntry(GraphNode Node, int priority)
        {
            this.Node = Node;
            this.priority = priority;
        }
    }
}

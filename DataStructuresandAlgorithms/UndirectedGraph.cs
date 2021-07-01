using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class UndirectedGraph
    {

        private Dictionary<string, GraphNode> NodeDict;
        

        public UndirectedGraph()
        {
            this.NodeDict = new Dictionary<string, GraphNode>();
           
        }

        private bool containsNodes(string from, string to)
        {
            if (this.NodeDict.ContainsKey(from) == false)
            {
                return false;
            }
            else if (this.NodeDict.ContainsKey(to) == false)
            {
                return false;
            }
            return true;

        }


        public void addNode(string label)
        {
            GraphNode newNode = new GraphNode { label = label };
            this.NodeDict.Add(label, newNode);
            List<Edge> Adjacencylist = new List<Edge>();
            
        }

        public void addEdge(string from, string to, int weight)
        {
            if (containsNodes(from, to) == false)
            {
                throw new InvalidOperationException();
            } 

            GraphNode fromNode = this.NodeDict[from];
            GraphNode toNode = this.NodeDict[to];
            fromNode.addEdge(toNode, weight);
            toNode.addEdge(fromNode, weight);
            
        }

        public void print()
        {
            
            foreach (GraphNode gn in this.NodeDict.Values)
            {
                string output = gn.label + " is connected to:";
                List<Edge> connectionList = gn.getEdges();
                string connections = "[";
                foreach (Edge connection in connectionList)
                {
                    connections = connections + connection.ToString() + ",";
                }
                connections = connections + "]";
                output = output + " " + connections;
                Console.WriteLine(output);
            }
        }

        public bool hasCycle(string root)
        {
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            if (this.NodeDict.ContainsKey(root)==false)
            {
                throw new InvalidOperationException();
            }
            GraphNode rootNode = this.NodeDict[root];
           return  hasCycle(rootNode, rootNode, visited);
        }

        private bool hasCycle(GraphNode Parent, GraphNode current, HashSet<GraphNode> visited)
        {
            visited.Add(current);
            List<Edge> neighbours = current.getEdges();
            foreach(Edge ed in neighbours)
            {
                if(Parent == ed.To)
                {
                    continue;
                }
                if (visited.Contains(ed.To))
                {
                    return true;
                }
                else
                {
                    return hasCycle(current, ed.To, visited);
                }
            }

            return false;
        }

        public string primsAlgorithm(string root)
        {
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            PriorityQueueGraph queue = new PriorityQueueGraph();
            List<NodeEntry> minTree = new List<NodeEntry>();
            if (this.NodeDict.ContainsKey(root) == false)
            {
                throw new InvalidOperationException();
            }
            GraphNode rootNode = this.NodeDict[root];
            NodeEntry initial = new NodeEntry(rootNode, 0);
            queue.enQueue(initial);
            while (queue.isEmpty()!= true)
            {
                NodeEntry currentEntry = queue.deQueue();
                
                GraphNode current = currentEntry.Node;
                if (visited.Contains(current) == false)
                {
                    minTree.Add(currentEntry);
                    visited.Add(current);
                    List<Edge> neighbours = current.getEdges();
                    foreach (Edge neighbour in neighbours)
                    {
                        if (visited.Contains(neighbour.To) == false)
                        {
                            NodeEntry newEntry = new NodeEntry(neighbour.To, neighbour.weight);
                            queue.enQueue(newEntry);
                        }
                    }
                }
                
            }

            string output = "Min Spanning Tree [";
            int distance = 0;
            foreach(NodeEntry ne in minTree)
            {
                GraphNode current = ne.Node;
                output = output + current.label + "->";
                distance = distance + ne.priority;
            }
            output = output + "]" + " Distance:" + distance;
            return output;

        }

        public string shortestDistance(string from, string to)
        {
           if(containsNodes(from, to) == false)
           {
                throw new InvalidOperationException();
           }

            GraphNode fromNode = this.NodeDict[from];
            GraphNode toNode = this.NodeDict[to];
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            Dictionary<GraphNode, int> distances = new Dictionary<GraphNode, int>();
            Dictionary<GraphNode, GraphNode> previous = new Dictionary<GraphNode, GraphNode>();
            
            PriorityQueueGraph queue = new PriorityQueueGraph();
            distances[fromNode] = 0;
            foreach (GraphNode gn in this.NodeDict.Values)
            {
                if (gn == fromNode)
                {
                    continue;
                }
                distances[gn] = int.MaxValue;
            }
            NodeEntry initial = new NodeEntry(fromNode, 0);
            queue.enQueue(initial);
            while (queue.isEmpty() == false)
            {
                NodeEntry current = queue.deQueue();
                
                GraphNode currentNode = current.Node;
                int currentDistance = distances[currentNode];
                visited.Add(currentNode);
                List<Edge> neighbouringEdges = currentNode.getEdges();
                foreach(Edge e in neighbouringEdges)
                {
                    int neighbouringdistance = currentDistance + e.weight;
                    GraphNode n = e.To;
                    if (neighbouringdistance < distances[n])
                    {
                        previous[n] = currentNode;
                        distances[n] = neighbouringdistance;
                        if (visited.Contains(n) == false)
                        {
                            NodeEntry ne = new NodeEntry(n, neighbouringdistance);
                            queue.enQueue(ne);
                        }
                    }
                }

            }

            GraphNode currentToNode = toNode;
            Stack<GraphNode> pathStack = new Stack<GraphNode>();
            while (currentToNode != fromNode)
            {
                pathStack.Push(currentToNode);
                currentToNode = previous[currentToNode];
            }
            string output = "Shortest path [" + fromNode.label + ",";
            while (pathStack.Count > 0)
            {
                GraphNode popped = pathStack.Pop();
                output = output + popped.label + ",";
            }

            output = output + "]" + "distance: " + distances[toNode];
            return output;
        }

    }
}

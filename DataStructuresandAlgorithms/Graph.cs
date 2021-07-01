using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class Graph
    {
        private Dictionary<string, GraphNode> NodeDict;
        private Dictionary<GraphNode, List<GraphNode>> AdjancyList;

        public Graph()
        {
            this.NodeDict = new Dictionary<string, GraphNode>();
            this.AdjancyList = new Dictionary<GraphNode, List<GraphNode>>();
        }

        public void addNode(string label)
        {
            GraphNode newNode = new GraphNode { label = label };
            this.NodeDict.Add(label, newNode);
            List <GraphNode> Adjacencylist = new List<GraphNode>();
            this.AdjancyList.Add(newNode, Adjacencylist);
        }

        public void print()
        {
            List<GraphNode> keyList = new List<GraphNode>(this.AdjancyList.Keys);
            foreach (GraphNode gn in keyList)
            {
                string output = gn.label + " is connected to:";
                List<GraphNode> connectionList = this.AdjancyList[gn];
                string connections = "[";
                foreach(GraphNode connection in connectionList)
                {
                    connections = connections + connection.label + ",";
                }
                connections = connections + "]";
                output = output + " " + connections;
                Console.WriteLine(output);
            }
        }


        public void depthFirstRecursive(string root)
        {
            if (!this.NodeDict.ContainsKey(root))
            {
                return;
            }
            else
            {
                GraphNode gn = this.NodeDict[root];
                HashSet<GraphNode> visited = new HashSet<GraphNode>();
                depthFirstRecursive(gn, visited);
            }
        }

        private void depthFirstRecursive(GraphNode Node, HashSet<GraphNode> visited)
        {
            List<GraphNode> Adjacencylist = this.AdjancyList[Node];
            Console.WriteLine(Node.label);
            visited.Add(Node);
            foreach(GraphNode gn in Adjacencylist)
            {
                if (!visited.Contains(gn))
                {
                    depthFirstRecursive(gn, visited);
                }
            }
        }

        public List<string> TopologicalSort(string root)
        {

            List<string> returnList = new List<string>();
            if (!this.NodeDict.ContainsKey(root))
            {
                return returnList;
            }

            GraphNode gn = this.NodeDict[root];
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            Stack<GraphNode> sorted = new Stack<GraphNode>();
            TopologicalSort(gn, visited, sorted);
            while (sorted.Count > 0)
            {
                GraphNode popped = sorted.Pop();
                returnList.Add(popped.label);
            }
            return returnList;
        }

        private void TopologicalSort(GraphNode Node, HashSet<GraphNode> visited, Stack<GraphNode> sorted)
        {
            List<GraphNode> Adjacencylist = this.AdjancyList[Node];
            visited.Add(Node);
            foreach (GraphNode gn in Adjacencylist)
            {
                if (!visited.Contains(gn))
                {
                    TopologicalSort(gn, visited, sorted);
                }
            }

            sorted.Push(Node);
        }


        public void depthFirstIterative(string root)
        {
            if (!this.NodeDict.ContainsKey(root))
            {
                return;
            }

            GraphNode initial = this.NodeDict[root];
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            Stack<GraphNode> traverseStack = new Stack<GraphNode>();
            traverseStack.Push(initial);
            while (traverseStack.Count> 0)
            {
                GraphNode current = traverseStack.Pop();
                Console.WriteLine(current.label);
                visited.Add(current);
                List<GraphNode> adjacncyList = this.AdjancyList[current];
                foreach(GraphNode gn in adjacncyList)
                {
                    if (visited.Contains(gn) == false)
                    {
                        traverseStack.Push(gn);
                    }
                }
            }
        }

        public void breadthFirst(string root)
        {
            if (!this.NodeDict.ContainsKey(root))
            {
                return;
            }

            GraphNode initial = this.NodeDict[root];
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            Queue<GraphNode> traverseQueue = new Queue<GraphNode>();
            traverseQueue.Enqueue(initial);
            while (traverseQueue.Count > 0)
            {
                GraphNode current = traverseQueue.Dequeue();
                Console.WriteLine(current.label);
                visited.Add(current);
                List<GraphNode> adjancyList = this.AdjancyList[current];
               foreach (GraphNode gn in adjancyList)
                {
                    if (visited.Contains(gn) == false)
                    {
                        traverseQueue.Enqueue(gn);
                    }
                }
            }
        }

        public void removeNode(string label)
        {
            if (this.NodeDict.ContainsKey(label) == false)
            {
                throw new InvalidOperationException();
            }
            GraphNode rmNode = this.NodeDict[label];
            this.AdjancyList.Remove(rmNode);
            List<GraphNode> AdjancyKeyList = new List<GraphNode>(this.AdjancyList.Keys);
            foreach( GraphNode gn in AdjancyKeyList)
            {
                List<GraphNode> adjancyList = this.AdjancyList[gn];
                if (adjancyList.Contains(rmNode))
                {
                    adjancyList.Remove(rmNode);
                }
            }

            this.NodeDict.Remove(label);
        }

        public void addEdge(string from, string to)
        {
            if (containsNodes(from, to)==false)
            {
                throw new InvalidOperationException();
            }

            GraphNode fromNode = this.NodeDict[from];
            GraphNode toNode = this.NodeDict[to];
            List<GraphNode> adjacencyList = this.AdjancyList[fromNode];
            adjacencyList.Add(toNode);
            this.AdjancyList[fromNode] = adjacencyList;

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

        public void removeEdge(string from, string to)
        {
            if (containsNodes(from, to) == false)
            {
                throw new InvalidOperationException();
            }

            GraphNode fromNode = this.NodeDict[from];
            GraphNode toNode = this.NodeDict[to];
            List<GraphNode> adjacencyList = this.AdjancyList[fromNode];
            adjacencyList.Remove(toNode);
            this.AdjancyList[fromNode] = adjacencyList;


        }

        public bool hasCycle()
        {
            bool returnval = false;
            HashSet<GraphNode> all = new HashSet<GraphNode>();
            HashSet<GraphNode> visiting = new HashSet<GraphNode>();
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            foreach (GraphNode gn  in this.NodeDict.Values)
            {
                all.Add(gn);
            }



            while (all.Count > 0)
            {
                List<GraphNode> setList = new List<GraphNode>();
                foreach (GraphNode n in all)
                {
                    setList.Add(n);
                }
                if (setList.Count > 0)
                {
                    GraphNode current = setList[0];
                    returnval = hasCycle(current, all, visiting, visited);
                    if (returnval == true)
                    {
                        return returnval;
                    }
                }
            }
           


            return returnval;
           

        }

        private bool hasCycle(GraphNode root, HashSet<GraphNode> all, HashSet<GraphNode> visiting, HashSet<GraphNode> visited)
        {
            List<GraphNode> adjancylist = this.AdjancyList[root];
            visiting.Add(root);
            all.Remove(root);
            bool returnVal = false;
            foreach (GraphNode nd in adjancylist)
            {
                if (visited.Contains(nd))
                {
                    continue;
                }
                if (visiting.Contains(nd))
                {
                    visiting.Remove(nd);
                    visited.Add(nd);
                    return true;
                }
                if (adjancylist.Count == 0)
                {
                    visiting.Remove(nd);
                    visited.Add(nd);
                    return false;
                }
                else
                {
                    returnVal = hasCycle(nd, all, visiting, visited);
                }

               

            }

            visiting.Remove(root);
            visited.Add(root);
            return returnVal;



        }
    }
}

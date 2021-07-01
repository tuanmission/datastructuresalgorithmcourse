using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class Node
    {
        public Node next { get; set; }
        public int data { get; set; }
       
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
       
        }

       
    }
}

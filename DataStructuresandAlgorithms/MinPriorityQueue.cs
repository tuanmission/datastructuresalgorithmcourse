using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class MinPriorityQueue
    {

        public PriorityQueueMinHeap priorityqueueheap;
        public MinPriorityQueue()
        {
            this.priorityqueueheap = new PriorityQueueMinHeap();
        }

        public void add (string value, int key)
        {
            Entry en = new Entry
            {
                key = key,
                value = value
            };
            this.priorityqueueheap.insert(en);
        }

        public void remove()
        {
            Entry outp = this.priorityqueueheap.remove();
            Console.WriteLine(outp.value);
        }
    }
}

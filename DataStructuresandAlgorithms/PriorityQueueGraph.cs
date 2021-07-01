using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class PriorityQueueGraph
    {

        private int count;
        private int length;
        private NodeEntry[] array;
        public PriorityQueueGraph()
        {
            this.count = 0;
            this.length = 5;
            this.array = new NodeEntry[this.length];
        }

        private NodeEntry[] expandArray(int newlength, int currentlength, NodeEntry[] Currentarray)
        {
            NodeEntry[] biggerarray = new NodeEntry[newlength];
            for (int i = 0; i < currentlength; i++)
            {
                biggerarray[i] = Currentarray[i];
            }

            return biggerarray;
        }

        public void enQueue(NodeEntry data)
        {
            if (this.count == 0)
            {
                this.array[0] = data;
            }
            else
            {
                if (this.count >= this.length)
                {
                    this.array = expandArray(this.length * 2, this.length, this.array);
                }
                int i = this.count;

                while (i > 0 && data.priority < this.array[i - 1].priority)
                {

                    this.array[i] = this.array[i - 1];
                    i = i - 1;

                }
                this.array[i] = data;

            }
            this.count++;
        }

        public NodeEntry deQueue()
        {
            NodeEntry returnval = this.array[0];
            this.array[0] = null;
            this.count--;
            for (int i = 0; i < count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            return returnval;
        }

        public bool isEmpty()
        {
            if (this.count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void printArray()
        {
            for (int i = 0; i < count; i++)
            {
                int output = this.array[i].priority;
                System.Console.WriteLine(output);
            }
        }
    }
}

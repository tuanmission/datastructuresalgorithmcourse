using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class LinkedListQueue
    {
        private linkedlist ll;
        public LinkedListQueue()
        {
            this.ll = new linkedlist();
        }

        public void enQueue(int data)
        {
            if (this.ll.Size() == 0)
            {
                this.ll.addFirst(data);
            }
            else
            {
                this.ll.addLast(data);
            }
        }

        public int deQueue(int data)
        {
            int returnint = ll.deleteFirst();
            return returnint;
        }

        public int peek()
        {
            return this.ll.getFirst();
        }

        public int size()
        {
            return this.ll.Size();
        }

        public bool isempty()
        {
            if (this.ll.Size() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

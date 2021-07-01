using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class ArrayQueue
    {
        private int length;
        private int front;
        private int rear;
        private int [] array;
        public ArrayQueue()
        {
            this.length = 5;
            this.front = 0;
            this.rear = 0;
            this.array = new int[5];

        }

        public void enqueue(int data)
        {
            if(this.rear >= this.length)
            {
                throw new InsufficientMemoryException("Array Queue is full");
            }
            this.array[this.rear] = data;
            this.rear++;
            
        }

        public int dequeue()
        {
            if (this.front >= this.length)
            {
                throw new IndexOutOfRangeException("Reached end of array Queue");
            }
            int returnval = this.array[this.front];
            this.array[this.front] = 0;
            this.front++;
            return returnval;
        }

        public int peak()
        {
            return this.array[this.front];
        }

        public bool isEmpty()
        {
            if (this.rear==0 && this.front==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isFull()
        {
            if (this.rear >= this.length)
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

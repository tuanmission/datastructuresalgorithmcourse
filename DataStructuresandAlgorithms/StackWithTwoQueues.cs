using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    
    public class StackWithTwoQueues
    {
        private Queue<int> primaryQueue;
        private Queue<int> secondaryQueue;
        public StackWithTwoQueues()
        {
            this.primaryQueue = new Queue<int>();
            this.secondaryQueue = new Queue<int>();
        }

        public void push(int data)
        {

            if (isEmpty() == true)
            {
                this.primaryQueue.Enqueue(data);
            }
            if (this.secondaryQueue.Count != 0)
            {
                this.secondaryQueue.Enqueue(data);
            }
            else if (this.primaryQueue.Count !=0)
            {
                this.primaryQueue.Enqueue(data);
            }
        }

        public int pop()
        {
            int returnvalue = 0;
           if (isEmpty() == true)
            {
                return 0;
            }
           if(this.secondaryQueue.Count != 0)
            {
                while (this.secondaryQueue.Count != 1)
                {
                    int deQueued = this.secondaryQueue.Dequeue();
                    this.primaryQueue.Enqueue(deQueued);
                }

                 returnvalue = this.secondaryQueue.Dequeue();
            } else if(this.primaryQueue.Count !=0)
            {
                while (this.primaryQueue.Count != 1)
                {
                    int deQueued = this.primaryQueue.Dequeue();
                    this.secondaryQueue.Enqueue(deQueued);
                }

                returnvalue = this.primaryQueue.Dequeue();
            }

            return returnvalue;
        }

        public int peek()
        {
            int returnvalue = 0;
       
            if (isEmpty() == true)
            {
                return returnvalue;
            }
            if (this.secondaryQueue.Count != 0)
            {
                while (this.secondaryQueue.Count != 0)
                {
                    int deQueued = this.secondaryQueue.Dequeue();
                    if (this.secondaryQueue.Count == 1)
                    {
                        returnvalue = deQueued;
                    }
                    this.primaryQueue.Enqueue(deQueued);
                }
            }
            else if (this.primaryQueue.Count != 0)
            {
                while (this.primaryQueue.Count != 0)
                {
                    int deQueued = this.primaryQueue.Dequeue();
                    if (this.primaryQueue.Count == 1)
                    {
                        returnvalue = deQueued;
                    }
                    this.secondaryQueue.Enqueue(deQueued);
                }
            }
            return returnvalue;
        }

        public int size()
        {
            if (isEmpty() == true)
            {
                return 0;
            } else if (this.primaryQueue.Count != 0)
            {
                return this.primaryQueue.Count;
            }
            else
            {
                return this.secondaryQueue.Count;
            }
        }

        public bool isEmpty()
        {
            if(this.primaryQueue.Count==0 && this.secondaryQueue.Count == 0)
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

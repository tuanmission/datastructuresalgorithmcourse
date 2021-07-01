using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class QueueStack
    {
        private Stack<int> primaryStack;
        private Stack<int> secondaryStack;


        public QueueStack()
        {
            this.primaryStack = new Stack<int>();
            this.secondaryStack = new Stack<int>();
        }
        public int deQueue()
        {
            int returnVal = 0;
            if (this.primaryStack.Count != 0)
            {
                
                while (this.primaryStack.Count != 1)
                {
                    int poppedOff = this.primaryStack.Pop();
                    this.secondaryStack.Push(poppedOff);
                }

                returnVal = this.primaryStack.Pop();
            }
            else if(this.secondaryStack.Count!=0)
            {
                returnVal = this.secondaryStack.Pop();
                while (this.secondaryStack.Count != 0)
                {
                    int poppedOff = this.secondaryStack.Pop();
                    this.primaryStack.Push(poppedOff);
                }
            }
            
            return returnVal;
        }

        public void enQueue(int data)
        {
            if (this.secondaryStack.Count == 0)
            {
                this.primaryStack.Push(data);
            }
            else
            {
                while (this.secondaryStack.Count != 0)
                {
                    int poppedOff = this.secondaryStack.Pop();
                    this.primaryStack.Push(poppedOff);
                }
                this.primaryStack.Push(data);
            }
        }

        public int peek()
        {
            int returnVal = 0;
            if (this.secondaryStack.Count != 0)
            {
                returnVal = this.secondaryStack.Pop();
                this.primaryStack.Push(returnVal);
                while (this.secondaryStack.Count != 0)
                {
                    int PoppedOff = this.secondaryStack.Pop();
                    this.primaryStack.Push(PoppedOff);
                }
            }
            else
            {
                while (this.primaryStack.Count != 1)
                {
                    int PoppedOff = this.primaryStack.Pop();
                    this.secondaryStack.Push(PoppedOff);
                }
                returnVal = this.primaryStack.Pop();
                this.secondaryStack.Push(returnVal);
            }

            return returnVal;
        }

        public bool isEmpty()
        {
            if (this.secondaryStack.Count==0 && this.primaryStack.Count == 0)
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

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class PriorityQueuebyArray
    {
        private int count;
        private int length;
        private int[] array;
        public PriorityQueuebyArray()
        {
            this.count = 0;
            this.length = 5;
            this.array = new int[this.length];
        }

        private int[] expandArray(int newlength, int currentlength, int[] Currentarray)
        {
            int[] biggerarray = new int[newlength];
            for (int i = 0; i < currentlength; i++)
            {
                biggerarray[i] = Currentarray[i];
            }

            return biggerarray;
        }

        public void enQueue(int data)
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
                
                while(i>0 && data<this.array[i-1])
                {
                    
                    this.array[i] = this.array[i-1];
                    i = i - 1;
           
                }
                this.array[i] = data;

            }
            this.count++;
        }

        public int deQueue()
        {
            int returnval = this.array[0];
            this.array[0] = 0;
            this.count--;
            for (int i=0; i<count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            
            return returnval;
        }

        public void printArray()
        {
            for (int i = 0; i < count; i++)
            {
                int output = this.array[i];
                System.Console.WriteLine(output);
            }
        }
    }
}

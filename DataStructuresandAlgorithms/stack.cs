using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class stack
    {
        private int count;
        private int length;
        private int[] array;
        private int[] minarray;
        private int minCount;
        private int minlength;
        public stack()
        {
            this.count = 0;
            this.length = 2;
            this.minlength = 2;
            this.array = new int[this.length];
            this.minarray = new int[this.minlength];
            this.minCount = 0;
            this.minarray[this.minCount] = 0;
        }

        public void push(int data)
        {
            if (this.count == 0)
            {
                this.array[0] = data;
                this.minarray[0] = data;
                this.count++;
                this.minCount++;
            }
            else
            {
                this.count++;
                if (this.count > this.length)
                {
                    this.array = expandArray(this.count * 2, this.length, this.array);
                    this.length = this.count * 2;
                }
                if (this.minarray[this.minCount-1] > data)
                {
                    this.minCount++;
                    if (this.minCount > this.minlength)
                    {
                        this.minarray = expandArray(this.minCount * 2, this.minlength, this.minarray);
                        this.minlength = this.minCount * 2;
                    }

                    this.minarray[this.minCount-1] = data;
                    
                }

                this.array[this.count - 1] = data;
            }
            
            
        }

        public int pop()
        {
            int returndata = this.array[this.count - 1];
            this.array[this.count - 1] = 0;
            if (returndata== this.minarray[this.minCount - 1])
            {
                this.minarray[this.minCount - 1] = 0;
                this.minCount--;
            }
            this.count--;
            return returndata;
        }


        public int min()
        {
            return this.minarray[this.minCount - 1];
        }

        public int peek()
        {
            int returndata = this.array[this.count - 1];
            return returndata;
        }

        private int [] expandArray(int newlength, int currentlength, int [] Currentarray)
        {
            int[] biggerarray = new int[newlength];
            for (int i = 0; i <currentlength; i++)
            {
                biggerarray[i] = Currentarray[i];
            }
            
            return biggerarray;
        }

        public bool isEmpty()
        {
            if (this.count == 0)
            {
                return true;
            }

            return false;
        }

        public int [] returnint()
        {
            int[] returnarray = new int[this.count];
            int currentlength = this.count - 1;
            for (int i=0; i<this.count; i++)
            {

                returnarray[i] = this.array[currentlength - i];
            }
            return returnarray;
        }
    }
}

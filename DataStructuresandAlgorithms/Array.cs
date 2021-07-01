using System;
using System.Collections.Generic;
using System.Collections;

using System.Text;

namespace DataStructuresandAlgorithms
{
    public class Array
    {
        private int length;
        private int[] array;
        private int count;
        public Array(int length)
        {
            this.length = length;
            this.array = new int[this.length];
            this.count = 0;

        }

        public void removeAt(int index)
        {

           if (index <0 || index >= this.length)
            {
                throw new ArgumentException(string.Format("Index {0} is out of bounds", index));
            }

            this.array[index] = 0;
            for (int i= index; i<count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.count--;
        }


        public void Insert(int number)
        {
            this.count++;
            if (this.count > this.length)
            {
                expandArray(this.count*2);
            }
            this.array[this.count - 1] = number;
        }

        public void expandArray(int newlength)
        {
            int[] biggerarray = new int[newlength];
            for (int i=0; i<this.length; i++)
            {
                biggerarray[i] = this.array[i];
            }
            this.length = newlength;
            this.array = biggerarray;
        }

        public int indexOf(int number)
        {
            
            for(int i=0; i<count; i++)
            {
                if (this.array[i] == number)
                {
                    return i;
                }
            }
            return -1;
        }


        public void print()
        {
            for(int i=0; i<this.count; i++)
            {
                System.Console.WriteLine(this.array[i]);
            }
        }

        public int ArrayMax()
        {
            int max = this.array[0];
            for (int i=0; i< this.count; i++)
            {
                if (this.array[i] > max)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        public int [] ArrayIntersect(int [] outerarray)
        {
            int current = 0;
            List<int> intlist = new List<int>();
            for (int i=0; i<outerarray.Length; i++)
            {
                current = outerarray[i];
                for(int j=0; j<this.count; j++)
                {
                    if (this.array[j] == current)
                    {
                        intlist.Add(current);
                    }
                }
            }

            int[] returnarray = new int[intlist.Count];
            for(int i=0; i< returnarray.Length; i++)
            {
                returnarray[i] = intlist[i];
            }

            return returnarray;
        }

        public void ReverseArray()
        {
            
            int end = this.count - 1;
            int mid = (end / 2) + 1;
            for(int i=0; i< mid; i++)
            {
                
                int temp = this.array[i];
                this.array[i] = this.array[end];
                this.array[end] = temp;
                end--;
            }
        }

        public void insertAt(int item, int index)
        {
            if (index >= this.count)
            {
                throw new ArgumentException(string.Format("Index {0} is out of bounds", index));
            }

            this.count++;
            if (this.count > this.length)
            {
                expandArray(this.count * 2);
            }
            for(int i=this.count-1; i>=index; i--)
            {
                this.array[i + 1] = this.array[i];
            }

            this.array[index] = item;

        }
    }
}

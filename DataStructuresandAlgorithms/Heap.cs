using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class Heap
    {

        private int size;
        private int length;
        private int [] intarray;

        public Heap()
        {
            this.size = 0;
            this.length = 11;
            this.intarray = new int[this.length];
        }


        private void expandArray(int newlength)
        {
            int [] biggerarray = new int[newlength];

            for (int i =0; i <this.length; i++)
            {
                biggerarray[i] = this.intarray[i];
            }
            this.length = newlength;
            this.intarray = biggerarray;

        }

        public bool isMaxHeap(int [] arr)
        {
            for (int i= arr.Length-1; i>0; i--)
            {
                if(arr[i]> arr[parentIndex(i)])
                {
                    return false;
                }
            }

            return true;
        }

     


        public void insert(int value)
        {
            if (this.size==0)
            {
                this.intarray[0] = value;
                this.size++;
            }
            else
            {
                this.size++;
                if (this.size >= this.length)
                {
                    expandArray(this.length * 2);
                }
                int index = this.size - 1;
                int parentIndex = (index - 1) / 2;
                this.intarray[index] = value;
                if (value> this.intarray[parentIndex])
                {
                   this.intarray= bubbleup(this.intarray, index, value);
                }
            }
        }

        private int [] bubbleup(int[] arr, int index, int child)
        {
            int parentIndex = (index - 1) / 2;
            int parent = arr[parentIndex];
            while (index>=0 && child > parent)
            {
                if (child > parent)
                {
                    arr =swap(arr, index, parentIndex);
                }
                index = (index - 1) / 2;
                parentIndex = (index - 1) / 2;
                parent = arr[parentIndex];
            }
            return arr;
        }


        private int parentIndex(int index)
        {
            return (index - 1) / 2;
        }
        private int leftChildindex(int index)
        {
            return index * 2 + 1;
        }

        private int rightChildindex(int index)
        {
            return index * 2 + 2;
        }

        private int getChild(int [] arr, int childindex)
        {
            if (childindex >= this.length)
            {
                expandArray(this.length * 2);
            }
            return arr[childindex];
        }

        
        private void bubbleDown(int [] arr, int index, int parent)
        {
            int leftchildindex = leftChildindex(index);
            int rightchildindex = rightChildindex(index);
            int leftChild = getChild(this.intarray, leftchildindex);
            int rightChild = getChild(this.intarray, rightchildindex);

            while (parent<leftChild && parent<rightChild)
            {
                int swapindex = 0;
                if(rightChild >= leftChild)
                {
                    swapindex = rightchildindex;
                } else if (leftChild> rightChild)
                {
                    swapindex = leftchildindex;
                }

                this.intarray = swap(this.intarray, index, swapindex);


                index = swapindex;
                leftchildindex = leftChildindex(index);
                rightchildindex = rightChildindex(index);
                leftChild = getChild(this.intarray,leftchildindex);
                rightChild = getChild(this.intarray, rightchildindex);


            }
        }

        public int remove()
        {
            if (this.size == 0)
            {
                return 0;
            }
            int ret = this.intarray[0];
            this.intarray[0] =0;
            this.intarray[0] = this.intarray[this.size - 1];
            this.intarray[this.size - 1]=0;
            this.size = this.size - 1;
            bubbleDown(this.intarray, 0, this.intarray[0]);
            return ret;
        }

        public bool isEmpty()
        {
            if (this.size == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private  int [] swap(int [] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            return arr;
        }



    }


}

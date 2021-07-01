using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class PriorityQueueMinHeap
    {
        private int size;
        private int length;
        private Entry[] entryarray;

        public PriorityQueueMinHeap()
        {
            this.size = 0;
            this.length = 11;
            this.entryarray = new Entry [this.length];
        }


        private void expandArray(int newlength)
        {
            Entry[] biggerarray = new Entry[newlength];

            for (int i = 0; i < this.length; i++)
            {
                biggerarray[i] = this.entryarray[i];
            }
            this.length = newlength;
            this.entryarray = biggerarray;

        }





        public void insert(Entry value)
        {
            if (this.size == 0)
            {
                this.entryarray[0] = value;
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
                this.entryarray[index] = value;
                if (value.key < this.entryarray[parentIndex].key)
                {
                    this.entryarray = bubbleup(this.entryarray, index, value.key);
                }
            }
        }

        private Entry[] bubbleup(Entry[] arr, int index, int child)
        {
            int parentIndex = (index - 1) / 2;
            int parent = arr[parentIndex].key;
            while (index >= 0 && child < parent)
            {
                if (child < parent)
                {
                    arr = swap(arr, index, parentIndex);
                }
                index = (index - 1) / 2;
                parentIndex = (index - 1) / 2;
                parent = arr[parentIndex].key;
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

        private int getChild(Entry[] arr, int childindex)
        {
            if (childindex >= this.length)
            {
                expandArray(this.length * 2);
            }
            if (arr[childindex] == null)
            {
                return 0;
            }
            return arr[childindex].key;
        }

        

        private void bubbleDown(Entry[] arr, int index, int parent)
        {
            int leftchildindex = leftChildindex(index);
            int rightchildindex = rightChildindex(index);
            int leftChild = getChild(this.entryarray, leftchildindex);
            int rightChild = getChild(this.entryarray, rightchildindex);

            while (parent > leftChild && parent > rightChild)
            {
                int swapindex = 0;
                if (rightChild <= leftChild)
                {
                    swapindex = rightchildindex;
                }
                else if (leftChild < rightChild)
                {
                    swapindex = leftchildindex;
                }

                this.entryarray = swap(this.entryarray, index, swapindex);


                index = swapindex;
                leftchildindex = leftChildindex(index);
                rightchildindex = rightChildindex(index);
                leftChild = getChild(this.entryarray, leftchildindex);
                rightChild = getChild(this.entryarray, rightchildindex);


            }
        }

        public Entry remove()
        {
            if (this.size == 0)
            {
                return null;
            }
            Entry ret = this.entryarray[0];
            this.entryarray[0] = null;
            this.entryarray[0] = this.entryarray[this.size - 1];
            this.entryarray[this.size - 1] = null;
            this.size = this.size - 1;
            bubbleDown(this.entryarray, 0, this.entryarray[0].key);
            return ret;
        }

        public bool isEmpty()
        {
            if (this.size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Entry[] swap(Entry[] arr, int a, int b)
        {
            Entry temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            return arr;
        }
    }
}

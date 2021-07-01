using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class MaxHeapify
    {

        public void Heapify (int [] arr)
        {
            int lastparentindex = arr.Length / 2 - 1;
            for (int i = lastparentindex; i>=0; i--)
            {
                Heapify(arr, i);
            }
        }

        private void Heapify(int [] arr, int index)
        {
            int largerIndex = index;
            int parent = arr[index];
            

            int leftChildindex = index * 2 + 1;
            int righChildindex = index * 2 + 2;
            if(righChildindex<arr.Length && leftChildindex < arr.Length)
            {
                int leftchild = arr[leftChildindex];
                int rightchild = arr[righChildindex];
                if(parent < leftchild || parent <rightchild)
                {
                    if (rightchild>= leftchild)
                    {
                        largerIndex = righChildindex;
                    }
                    else
                    {
                        largerIndex = leftChildindex;
                    }
                    swap(arr, index, largerIndex);
                    Heapify(arr, largerIndex);
                    
                }
            }
            if (largerIndex == index)
            {
                return;
            }
        }


        private void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
            
        }
    }
}

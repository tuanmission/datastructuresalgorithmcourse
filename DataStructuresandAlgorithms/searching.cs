using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class searching
    {

        public int linearSearch(int[] array, int target)
        {
            for(int i=0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool binarysearchrecursive(int [] arr, int target)
        {
            return BinarySearchRecursive(arr, 0, arr.Length - 1, target);
        }
        private bool BinarySearchRecursive(int [] arr, int left, int right, int target)
        {
            if(right < left)
            {
                return false;
            }

            int middle = (left + right) / 2;
            if (target == arr[middle])
            {
                return true;
            }else if (target > arr[middle])
            {
                return BinarySearchRecursive(arr,middle + 1, right, target);
            }
            else
            {
                return BinarySearchRecursive(arr, left, middle-1, target);
            }
        }

        public bool Ternarysearchrecursive(int[] arr, int target)
        {
            return TernarySearchRecursive(arr, 0, arr.Length - 1, target);
        }
        private bool TernarySearchRecursive(int[] arr, int left, int right, int target)
        {
            if (right < left)
            {
                return false;
            }

            int partitionsize = (right-left) / 3;
            int mid1 = left + partitionsize;
            int mid2 = right - partitionsize;
            if (target == arr[mid1] || target==arr[mid2])
            {
                return true;
            }
            else if (target < arr[mid1])
            {
                return TernarySearchRecursive(arr, left, mid1-1, target);
            }
            else if (target>arr[mid1] && target<arr[mid2])
            {
                return TernarySearchRecursive(arr, mid1+1, mid2 - 1, target);
            }
            else
            {
                return TernarySearchRecursive(arr, mid2 + 1, right, target);
            }
        }

        public bool JumpSearch(int [] arr, int target)
        {
            int start = 0;
            int blocksize = arr.Length / arr.Length;
            while(start< arr.Length)
            {
                int end = start + blocksize;
                if (blocksize > arr.Length)
                {
                    end = arr.Length;
                }
                for(int i=start; i<end; i++)
                {
                    if (arr[i] == target)
                    {
                        return true;
                    }
                }

                start = start + blocksize;
            }

            return false;
        }



        public bool BinarySearchIterative(int [] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[middle] == target)
                {
                    return true;
                }

                if (target < array[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return false;
        }

        public bool exponentialSearch(int [] arr, int target)
        {
            int boundary = 1;
            while(boundary< arr.Length && target >arr[boundary])
            {
                boundary = boundary * 2;
            }

            int left = boundary / 2;
            int right = Math.Min(boundary, arr.Length - 1);
            return BinarySearchRecursive(arr, left, right, target);
        }
    }
}

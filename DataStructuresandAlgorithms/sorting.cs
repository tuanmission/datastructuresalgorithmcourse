using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class sorting
    {


        public void duparray()
        {
            int[] duparray = { 15, 17, 20, 22, 17, 23, 45, 67, 23, 17, 67 };
            for (int i = 0; i < duparray.Length; i++)
            {


                for (int j = i + 1; j < duparray.Length; j++)
                {

                    {
                        if (duparray[i] == duparray[j])
                        {
                            System.Console.WriteLine(duparray[j]);
                        }
                    }
                }
            }
        }


        public int [] mergeSort(int [] arr)
        {
            mergesort(arr, arr.Length);
            return arr;
        }

        private void mergesort(int[] arr, int length)
        {
            if (length < 2)
            {
                return;
            }

            int middle = length / 2;
            int[] left = new int[middle];
            int[] right = new int[length - middle];
            for(int i=0; i<middle; i++)
            {
                left[i] = arr[i];
            }

            for (int j=middle; j<length; j++)
            {
                right[j-middle] = arr[j];
            }
            mergesort(left, middle);
            mergesort(right, length - middle);
            merge(left, right,arr, middle, length - middle);
            
        }

        private void merge(int [] left, int [] right,int [] merged, int leftlength, int rightlength)
        {
           
            int j = 0;
            int n = 0;
            int i = 0;
            while(j <leftlength && n< rightlength)
            {
                if (left[j] <= right[n])
                {
                    merged[i] = left[j];
                    j++;
                    i++;
                } else
                {
                    merged[i] = right[n];
                    n++;
                    i++;
                }
            }

            while (j < leftlength)
            {
                merged[i] = left[j];
                j++;
                i++;
            }

            while (n< rightlength)
            {
                merged[i] = right[n];
                n++;
                i++;
            }
           
            
        }


        public int[] insertionsort(int[] arr, int arrlength)
        {
            for(int i=1; i<arrlength; i++)
            {
                int j = i-1;
                int current = arr[i];
                while(j>=0 && arr[j]>current)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j+1] = current;




            }

            return arr;
        }
        public int[] removeduparray(int[] arr, int arrlength)
        {

            bubblesort(arr, arrlength);
            if (arrlength == 0 || arrlength == 1)
            {
                return arr;
            }

            int[] temp = new int[arrlength];
            int j = 0;
            for (int i = 0; i < arrlength - 1; i++)
            {
                if (arr[i] != arr[i + 1])
                {
                    temp[j++] = arr[i];
                }
            }

            temp[j++] = arr[arrlength - 1];

            arr = new int[j];
            for (int i = 0; i < j; i++)
            {
                arr[i] = temp[i];
            }

            return arr;
        }

        public void lgsmlarray()
        {
            int[] lgsmarray = { 15, 17, 20, 22, 23, 45, 67, 23, 17, 67 };

            int smallest = lgsmarray[0];
            int largest = 0;
            for (int i = 0; i < lgsmarray.Length; i++)
            {
                if (lgsmarray[i] < smallest)
                {
                    smallest = lgsmarray[i];
                }
                else if (lgsmarray[i] > largest)
                {
                    largest = lgsmarray[i];
                }
            }

            System.Console.WriteLine("The largest element is " + largest + "");
            System.Console.WriteLine("The smallest element is " + smallest + "");
        }

        public int[] swap(int[] intarray, int i, int j)
        {
            int swap = intarray[i];
            int sw2 = intarray[j];
            intarray[i] = sw2;
            intarray[j] = swap;

            return intarray;

        }
        public void sumduparray()
        {
            int sum = 30;
            int[] duparray = { 13, 17, 20, 20, 10, 45, 5, 23, 25, 67 };
            for (int i = 0; i < duparray.Length; i++)
            {
                for (int j = i + 1; j < duparray.Length; j++)
                {
                    int sumres = duparray[i] + duparray[j];
                    if (sumres == sum)
                    {
                        Console.WriteLine("A pair that matches the sum of " + sum + " is " + duparray[i] + " +" + duparray[j] + "");
                    }
                }
            }
        }
        public void reversearray()
        {
            int[] intarray = { 13, 17, 20, 20, 10, 45, 5, 23, 25, 67 };


            for (int i = 0; i < intarray.Length / 2; i++)
            {
                int temp = intarray[i];
                intarray[i] = intarray[intarray.Length - 1 - i];
                intarray[intarray.Length - 1 - i] = temp;
            }

            for (int i = 0; i < intarray.Length; i++)
            {
                System.Console.WriteLine(intarray[i]);
            }
        }

        public int [] bucketSort(int[] arr, int nobuckets)
        {
            List<int>[] buckets = new List<int>[nobuckets];
            for(int b=0; b<3; b++)
            {
                buckets[b] = new List<int>();
            }
            for(int i=0; i<arr.Length; i++)
            {
                int current = arr[i];
                int bucketNumber = current / nobuckets;
                buckets[bucketNumber].Add(current);
            }

            int index = 0;
            for(int j=0; j<3; j++)
            {
                buckets[j].Sort();
                foreach(int n in buckets[j])
                {
                    arr[index] = n;
                    index = index + 1;
                }
            }

            return arr;

        }


        public int [] countingSort(int [] arr, int max)
        {
            int[] frequencyArray = new int[max + 1];
            for(int i=0; i < arr.Length; i++)
            {
                int currentvalue = arr[i];
                frequencyArray[currentvalue] = frequencyArray[currentvalue] + 1;
            }
            int arrindex = 0;
            for(int j=0; j<frequencyArray.Length; j++)
            {
                if (frequencyArray[j] > 0)
                {
                    int n = frequencyArray[j];
                    while (n > 0)
                    {
                        arr[arrindex] = j;
                        arrindex = arrindex + 1;
                        n = n - 1;
                    }
                }
            }

            return arr;
        }


        public void quicksort(int[] arr)
        {
            quickSort(arr, 0, arr.Length - 1);
        }
        private void quickSort(int [] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int boundary = partition(arr);
            quickSort(arr, start, boundary-1);
            quickSort(arr, boundary + 1,end);
        }

        private int partition(int [] arr)
        {
            int boundary = -1;
            int pivot = arr[arr.Length-1];
            for(int i=0; i<arr.Length; i++)
            {
               if (arr[i] <= pivot || i==arr.Length-1)
                {
                    boundary=boundary+1;
                    swap(arr, boundary, i);
                }
            }

            return boundary;

        }
        public void selectionsort(int[] array, int n)
        {
            int minindex = 0;

            for (int i = 0; i < n - 1; i++)
            {
                minindex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minindex])
                    {
                        minindex = j;
                    }
                }

                swap(array, i, minindex);
            }

            for (int i = 0; i < n - 1; i++)
            {
                System.Console.WriteLine(array[i]);
            }
        }
        public void bubblesort(int[] array, int n)
        {
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        swap(array, j, j + 1);
                    }
                }


            }





        }
    }
}


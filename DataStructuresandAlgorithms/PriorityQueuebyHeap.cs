using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class PriorityQueuebyHeap
    {
        private Heap hp;

        public PriorityQueuebyHeap()
        {
            this.hp = new Heap();
        }
        public void add(int item)
        {
            this.hp.insert(item);
        }

        public int getKthLargest(int k, int [] arr)
        {
            Heap hp = new Heap();
            for(int i=0; i<arr.Length; i++)
            {
                hp.insert(arr[i]);
            }
            int n = 1;
            
            
            while (n <= k)
            {
                int get = hp.remove();
                if (n == k)
                {
                    return get;
                }
                n = n + 1;
            }
            return 0;
        }

        public int remove()
        {
            return this.hp.remove();
        }
    }
}

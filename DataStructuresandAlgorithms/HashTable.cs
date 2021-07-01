using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class HashTable
    {

        private int count;
        private int length;
        private LinkedList<Entry>[] llarray;
        public HashTable()
        {
            this.count = 0;
            this.length = 6;
            this.llarray = new LinkedList<Entry>[this.length];
        }

        public void put(int key, string value)
        {
            Entry en = new Entry
            {
                key = key,
                value = value

            };
            if (this.count == 0)
            {
               
                LinkedList<Entry> ll = new LinkedList<Entry>();
                ll.AddFirst(en);
                this.llarray[this.count] = ll;
                this.count++;
            }
            else
            {
                bool ischained = false;
                for (int i = 0; i < this.count; i++)
                {
                    LinkedList<Entry> ll = this.llarray[i];
                    Entry head = ll.First.Value;
                    if (head.key == key)
                    {
                        ischained = true;
                        ll.AddLast(en);
                        this.llarray[i] = ll;
                    }
                }
                if (ischained == false)
                {
                    if (this.count >= this.length)
                    {
                       this.llarray= ExpandArray(this.length * 2, this.length, this.llarray);
                    }
                    LinkedList<Entry> ll = new LinkedList<Entry>();
                    ll.AddFirst(en);
                    this.llarray[this.count] = ll;
                    this.count++;
                }
            }
        }

        private LinkedList<Entry> [] ExpandArray(int newlength, int currentlength, LinkedList<Entry>[] Currentarray)
        {
            
                LinkedList<Entry>[] biggerarray = new LinkedList<Entry>[newlength];
                for (int i = 0; i < currentlength; i++)
                {
                    biggerarray[i] = Currentarray[i];
                }

                return biggerarray;
            
        }

        public LinkedList<Entry> get(int key)
        {
           
            for(int i=0; i < this.count; i++)
            {
                LinkedList<Entry> ll = this.llarray[i];
                Entry head = ll.First.Value;
                if (head.key == key)
                {
             
                    return this.llarray[i];
                }
            }

            return null;
        }

        public void remove(int key)
        {
            bool isFound = false;
            int findIndex = 0;
            if (this.count == 1)
            {
                this.llarray[0] = null;
            }
            else
            {
                int i = 0;
                while(i<this.count && isFound == false)
                {
                    LinkedList<Entry> ll = this.llarray[i];
                    Entry head = ll.First.Value;
                    if (head.key == key)
                    {

                        findIndex = i;
                        isFound = true;
                    }
                    i++;
                }
                    
                if (isFound == true)
                {
                    this.count--;
                    this.llarray[findIndex] = null;
                    for(int n = findIndex; i<this.count; i++)
                    {
                        this.llarray[n] = this.llarray[n + 1];
                    }
                }
                else
                {
                    Console.WriteLine("Unable to Remove Element");
                }
            }
        }


        private int hashfunc(int number)
        {
            return number % this.count;
        }
    }
}

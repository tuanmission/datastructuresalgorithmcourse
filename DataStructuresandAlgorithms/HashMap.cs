using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class HashMap
    {
        private int length;
        private Entry[] entArray;
        public HashMap()
        {
            this.length = 5;
            this.entArray = new Entry[this.length];
        }

        public void put(int key, string value)
        {
            Entry en = new Entry
            {
                key = key,
                value = value
            };
            int index = hash(key);
            if (this.entArray[index] == null)
            {
                this.entArray[index] = en;
            }
            else
            {
                bool inserted = false;
                int i = 1;
                while (inserted != true)
                {
                    index = (hash(key))%this.length + i;
                    if (index >= this.length)
                    {
                        ExpandArray(this.length * 2, this.length, entArray);
                        this.length = this.length * 2;
                    }
                    if (this.entArray[index] == null)
                    {
                        this.entArray[index] = en;
                        inserted = true;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }
        }
        public string get(int key)
        {
            
            for (int i=0; i < this.length; i++)
            {
                Entry curr = this.entArray[i];
                if (curr != null)
                {
                    if (curr.key == key)
                    {
                        return curr.value;
                    }
                }
            }
            return "";
        }

        public void remove(int key)
        {
            for (int i = 0; i < this.length; i++)
            {
                Entry curr = this.entArray[i];
                if (curr != null)
                {
                    if (curr.key == key)
                    {
                        this.entArray = null;
                    }
                }
            }
        }

        private int hash(int input)
        {
            return input % this.length;
        }

        private Entry[] ExpandArray(int newlength, int currentlength, Entry [] Currentarray)
        {

            Entry[] biggerarray = new Entry[newlength];
            for (int i = 0; i < currentlength; i++)
            {
                biggerarray[i] = Currentarray[i];
            }

            return biggerarray;

        }

        public int size()
        {
            int size = 0;
            foreach (Entry en in entArray)
            {
                if (en != null)
                {
                    size++;
                }
            }

            return size;
        }
    }
}

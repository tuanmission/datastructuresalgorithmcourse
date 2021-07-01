using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class DualStack
    {
        private int count1;
        private int count2;
        private int length;
        private int[] array;
        public DualStack()
        {
            this.count1 =0;
            this.count2 =3;
            this.length = 6;
            this.array = new int[this.length];
        }


        public void push1(int data)
        {
            if (isFull1() == true)
            {
                throw new StackOverflowException("Stack is full");
            }

            this.array[this.count1] = data;
            this.count1++;
        }

        public void push2(int data)
        {
            if (isFull2() == true)
            {
                throw new StackOverflowException("Stack is full");
            }

            this.array[this.count2] = data;
            this.count2++;
        }

        public int pop1()
        {
            if (this.count1 == 0)
            {
                return  -1;
            }
            this.count1--;

            int returnInt = this.array[this.count1];
            this.array[this.count1] = 0;
            return returnInt;
            
        }

        public int pop2()
        {

            if (this.count2 == 0)
            {
                return -1;
            }

            this.count2--;
            int returnValue = this.array[this.count2];
            this.array[this.count2] = 0;
            return returnValue;



        }

        public bool isFull1()
        {
            if (this.count1 >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isFull2()
        {
            if (this.count1 >= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool isEmpty1()
        {
            if (this.count1 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isEmpty2()
        {
            if (this.count1 == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void print1()
        {
            for(int i=this.count1-1; i>=0; i--)
            {
                Console.WriteLine(this.array[i]);
            }
        }

        public void print2()
        {
            for (int i = this.count2 - 1; i >= 3; i--)
            {
                Console.WriteLine(this.array[i]);
            }
        }
    }
}

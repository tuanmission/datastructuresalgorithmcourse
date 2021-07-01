using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class linkedlist
    {
        private Node head;
        private Node tail;
        
        public linkedlist()
        {
            this.head = null;
            this.tail = null;
        }

        public void addFirst(int data)
        {
            Node newNode = new Node(data, null);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.head;
                this.head = newNode;
            }
        }

        public void addLast(int data)
        {
            Node newNode = new Node(data, null);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            } else
            {
                this.tail.next = newNode;
                this.tail = newNode;
            }
        }

        public int deleteFirst()
        {
            if(this.head==null && this.tail == null)
            {
                throw new NullReferenceException("No Elements in the list");
            }


            int returndata = this.head.data;
            Node nextNode = this.head.next;
            this.head = null;
            this.head = nextNode;
            return returndata;
        }


        public int deleteLast()
        {
            if (this.head == null && this.tail == null)
            {
                throw new NullReferenceException("No Elements in the list");
            }
            else if (this.head == this.tail)
            {
                this.head = null;
                return 0;
            }


            Node currentNode = this.head;
            Node prevNode = null;
            while (currentNode.next != null)
            {
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
            int returnint = currentNode.data;
            prevNode.next = null;
            this.tail = null;
            this.tail = prevNode;
            return returnint;
        }

        public int getLast()
        {
            Node current = this.head;
            while (current.next != null)
            {
                current = current.next;
            }

            return current.data;
        }

        public int getFirst()
        {
            return this.head.data;
        }

        public bool contains(int data)
        {
            bool contains = false;
            
            if (this.head == null && this.tail == null)
            {
                throw new NullReferenceException("No Elements in the list");
            }
            else
            {
                Node currentnode = this.head;
                while (currentnode != null && contains!=true)
                {
                    if (currentnode.data == data)
                    {
                        contains = true;
                    }

                    currentnode = currentnode.next;
                }
            }

            return contains;
        }

        public int indexOf(int data)
        {
            int i = 0;
            
            if (this.head.data == data)
            {
                return i;
            }
            Node current = this.head;
            while (current != null)
            {
                if (current.data== data)
                {
                    return i;
                }
                current = current.next;
                i++;
            }

            return -1;
            
        }

        public int Size()
        {
            int size = 0;
            if (this.head.next == null)
            {
                return size+1;
            }
            Node currentnode = this.head;
            while (currentnode != null)
            {
                size++;
                currentnode = currentnode.next;
            }
            return size;
        }

        public void printList()
        {
            Node currentnode = this.head;
            while (currentnode != null)
            {
                System.Console.WriteLine(currentnode.data);
                currentnode = currentnode.next;
            }
        }

        public int [] toarray()
        {
            int[] newarray = new int[Size()];
            Node first = this.head;
            int i = 0;
            while (first != null)
            {
                newarray[i] = first.data;
                first = first.next;
                i = i + 1;
            }

            return newarray;
        }


        public void CreateLoop()
        {
            this.tail.next = this.head;
        }

        public void reverse()
        {

            Node current = this.head;
            Node prev = null;
            this.tail = this.head;
            while (current!= null)
            {
                Node next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                
                
    
            }

            this.head = prev;
            
            
        }

        public int getKthNodefromEnd(int kth)
        {
            Node first = this.head;
            Node second = this.head;
            int rtValue = -1;
            int i = 1;
            while (i < kth)
            {
                second = second.next;
                i = i + 1;
            }

            while (second != null)
            {
                if (second.next == null)
                {
                    rtValue = first.data;
                }

                second = second.next;
                first = first.next;
            }
            return rtValue;
        }

        public void MiddleofList()
        {
            Node slowptr = this.head;
            Node fastptr = this.head;
            Node prev = this.head;
            while (fastptr != null && fastptr != this.tail) 
            {
                fastptr = fastptr.next.next;
                prev = slowptr;
                slowptr = slowptr.next;
                if (fastptr == null)
                {
                    Console.WriteLine(prev.data);
                    Console.WriteLine(slowptr.data);
                } else if (fastptr == this.tail)
                {
                    Console.WriteLine(slowptr.data);
                }
                
            }
        }

        public bool isLoop()
        {
            bool isloop = false;
            Node slowptr = this.head;
            Node fastptr = this.head;
            while (isloop!=true && fastptr != null)
            {
                slowptr = slowptr.next;
                fastptr = fastptr.next.next;
                if (slowptr == fastptr)
                {
                    isloop = true;
                }
            }

            return isloop;
        }
    }
}

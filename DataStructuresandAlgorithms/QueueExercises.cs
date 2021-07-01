using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class QueueExercises
    {
        public QueueExercises()
        {

        }

        public Queue<int> reverse(Queue<int> input)
        {
            Stack<int> reverseStack = new Stack<int>();
            if (input.Count == 0 || input.Count==1)
            {
                return input;
            }
            while (input.Count != 0)
            {
                int n = input.Dequeue();
                reverseStack.Push(n);
            }

            while (reverseStack.Count != 0)
            {
                int n = reverseStack.Pop();
                input.Enqueue(n);
            }
            
            return input;



        }

        public Queue<int> reverseByK(Queue<int> input, int k)
        {
            Stack<int> reverseStack = new Stack<int>();
            Queue<int> output = new Queue<int>();
            int i = 0;
            while (i < k && input.Count!=0)
            {
                int deQuqueued = input.Dequeue();
                reverseStack.Push(deQuqueued);
                i++;
            }

            while (reverseStack.Count != 0)
            {
                int poppedOff = reverseStack.Pop();
                output.Enqueue(poppedOff);
            }

            while (input.Count != 0)
            {
                int deQuqueued = input.Dequeue();
                output.Enqueue(deQuqueued);
            }

            return output;


        }
    }
}

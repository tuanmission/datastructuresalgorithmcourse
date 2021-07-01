using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class TreeExercises
    {
        public TreeExercises()
        {

        }

        public int factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n *factorial(n-1);
        }
    }
}

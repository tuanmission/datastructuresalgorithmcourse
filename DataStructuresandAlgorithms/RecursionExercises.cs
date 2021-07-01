using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class RecursionExercises
    {

        public int Exponent(int num, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            return num * Exponent(num, power - 1);
        }

        public int GCD(int n1 , int n2)
        {
           if (n2 == 0)
            {
                return n1;
            }

            return GCD(n2, n1 % n2);
            
        }

        private bool isPrime(int num, int n)
        {
            if (n == 1)
            {
                return true;
            }
            else
            {
                if (num % n == 0)
                {
                    return false;
                }
            }

            return isPrime(num, n - 1);

            
        }

        public bool isPrime(int number)
        {
            bool ret = isPrime(number, number - 1);
            return ret;

        }

        public string reversestr(string str)
        {

            string output = "";
            output = reversestr(str, str.Length - 1, output);
            return output;
        }

        private string reversestr(string str, int n, string output)
        {
            if (n == 0)
            {
                output = string.Concat(output, str[n]);
                return output;
            }
            else
            {
                output = string.Concat(output, str[n]);
                return reversestr(str, n - 1, output);
            }

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class stackExcercises
    {

        public String reverseString(String input)
        {
            Stack<char> chStack = new Stack<char>();
            for(int i=0; i<input.Length; i++)
            {
                chStack.Push(input[i]);
            }

            StringBuilder bd = new StringBuilder();
            while (chStack.Count != 0)
            {
                bd.Append(chStack.Pop());
            }

            return bd.ToString();

        }

        public bool balancedExpression(String input)
        {
            bool balanced = false;
            Stack<char> charStack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[' || input[i] == '<')
                {
                    charStack.Push(input[i]);
                }

                if (input[i] == ')' || input[i] == '}' || input[i] == ']' || input[i] == '>')
                {
                    if (charStack.Count == 0)
                    {
                        return false;
                    }
                    else if(input[i]==']' && charStack.Pop()!='[' )
                    {
                        return false;
                    }
                    else if (input[i] == '}' && charStack.Pop() != '{')
                    {
                        return false;
                    }
                    else if (input[i] == ')' && charStack.Pop() != '(')
                    {
                        return false;
                    } 
                    else if (input[i] == '>' && charStack.Pop() != '<')
                    {
                        return false;
                    }
                }

            }
            balanced = charStack.Count == 0 ? balanced = true : balanced = false;
            return balanced;
        }
    }
}

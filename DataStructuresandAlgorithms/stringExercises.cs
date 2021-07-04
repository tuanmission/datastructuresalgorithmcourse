using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class stringExercises
    {

        public int noVowels(string input)
        {
            input = input.ToUpper();
            int noVowels = 0;
            for(int i=0; i<input.Length; i++)
            {
                if(input[i]=='A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U')
                {
                    noVowels = noVowels + 1;
                }
            }

            return noVowels;
        }

        public string reverseString(string input)
        {
            string output = "";
            for(int i=input.Length-1; i>=0; i--)
            {
                output = output + input[i];
            }

            return output;
        }

        public string removeDuplicates(string input)
        {
            string output = "";
            for(int i =0; i< input.Length; i++)
            {
               if(input[i]==' ')
               {
                    output = output + " ";
                }
                else
                {
                    if (output.Contains(input[i])==false)
                    {
                        output = output + input[i];
                    }
                }

            }

            return output;
        }
        
        public string sentenceReverse(string input)
        {
            Stack<string> st = new Stack<string>();
            string word = "";
            
            
            for(int i=0; i<input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    word = word + input[i];
                    if(i == input.Length - 1)
                    {
                        st.Push(word);
                    } else if (input[i+1]==' ')
                    {
                        st.Push(word);
                        word = " ";
                    }
                }
                
            }
            string output = "";

            foreach(string wd in st)
            {
                output = output + wd + " ";
            }

            output.Remove(output.Length - 1, 1);
            return output;
        }

        public bool isRotation(string str1,  string str2)
        {
            string combined = str1 + str2;
            return str1.Length == str2.Length && combined.Contains(str2);
        }

        public string capitalize(string input)
        {
            List<string> st = new List<string>();
            string word = "";


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    word = word + input[i];
                    if (i == input.Length - 1)
                    {
                        st.Add(word);
                    }
                    else if (input[i + 1] == ' ')
                    {
                        st.Add(word);
                        word = "";
                    }
                }

            }
            string output = "";

            foreach (string wd in st)
            {
                wd.Trim();
                wd.ToLower();
                
                char firstLetter = Char.ToUpper(wd[0]);
                string substring = wd.Substring(1, wd.Length - 1);
                string finalstring = firstLetter + substring;
                output = output + finalstring + " ";
            }

            output.Remove(output.Length - 1, 1);
            return output;
        }

        public bool anagramHisto(string first, string second)
        {

            first = first.ToLower();
            int[] frequencies = new int[26];
            for (int i = 0; i < first.Length; i++)
            {
                frequencies[first[i]-'a'] = frequencies[first[i] - 'a'] + 1;
            }

            for(int j=0; j<second.Length; j++)
            {
                int index = second[j] - 'a';
                if (frequencies[index] == 0)
                {
                    return false;
                }
                frequencies[index] = frequencies[index] - 1;
            }

            return true;
        }

        public bool palindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;
            while (left < right)
            {
                if(word[left]!= word[right])
                {
                    return false;
                }
                left++;
                right++;
            }

            return true;
        }
        
    }
}

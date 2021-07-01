using System;
using System.Collections.Generic;

using System.Text;

namespace DataStructuresandAlgorithms
{
    public class DictionaryExercises
    {

        public char FirstnonrepeatedChracter(string input)
        {
            Dictionary<char, int> strDict = addtoDict(input);
            char returnChar = 'A';
         foreach(KeyValuePair<char, int> pair in strDict)
            {
                if (pair.Value == 1)
                {
                    returnChar = pair.Key;
                    return returnChar;
                }
            }
            return returnChar;
        }

        public int mostFrequent(int [] input)
        {
            Dictionary<int, int> intdict = new Dictionary<int, int>();
            int mostfrequent = 0;
            int mostfreqval = 0;

            foreach (int n in input)
            {
                if (intdict.Count == 0)
                {
                    intdict.Add(n, 1);
                }
                else
                {
                    if (intdict.ContainsKey(n) == true)
                    {
                        intdict[n] = intdict[n] + 1;
                    }
                    else
                    {
                        intdict.Add(n, 1);
                    }
                }
            }

            bool initial = true;
            
            foreach (KeyValuePair<int ,int> p in intdict)
            {
                
                if (initial == true)
                {
                    mostfrequent = p.Key;
                    mostfreqval = p.Value;
                    initial = false;
                }
                else
                {
                    if(p.Value> mostfreqval)
                    {
                        mostfrequent = p.Key;
                        mostfreqval = p.Value;
                    }
                }
            }
            return mostfrequent;
        }

        public int countPairsWithDiff(int[] input, int k)
        {
            int kFreq = 0;
            int i = 0;
            while (i < input.Length-1)
            {
                int n = i+1;
                int currloc = input[i];
                while (n < input.Length)
                {
                    int diff = System.Math.Abs(currloc - input[n]);
                    if (diff== k)
                    {
                        kFreq++;
                    }
                    n++;
                }
                i++;
            }
            return kFreq;
        }

        public int [] twoSum(int [] input, int target)
        {

            int[] returnArr = new int[2];
            bool found = false;
            int ptr1 = 0;
            int ptr2 = 0;
            Dictionary<int, int> intdict = new Dictionary<int, int>();
            for (int j=0; j<input.Length; j++)
            {
                intdict.Add(input[j], j);
            }

            int i = 0;
            while(i< input.Length - 1 &&found!= true)
            {
                

                int n = i + 1;
                ptr1 = input[i];
                while (n < input.Length && found != true)
                {
                    int added = ptr1 + input[n];
                    if (added == target)
                    {
                        ptr2 = input[n];
                        found = true;
                    }
                    n++;
                }
                i++;
            }

            if (found == true)
            {
                returnArr[0] = intdict[ptr1];
                returnArr[1] = intdict[ptr2];

            }
            return returnArr;
        }



        public char FirstRepeatedCharacter(string input)
        {
            Dictionary<char, int> strDict = addtoDict(input);
            char returnChar = 'A';
            foreach (KeyValuePair<char, int> pair in strDict)
            {
                if (pair.Value > 1)
                {
                    returnChar = pair.Key;
                    return returnChar;
                }
            }
            return returnChar;
        }

        private Dictionary<char, int> addtoDict(string input)
        {
            Dictionary<char, int> strDict = new Dictionary<char, int>();
            input = input.Replace(" ", string.Empty);
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (strDict.Count == 0)
                {
                    strDict.Add(current, 1);
                }
                else
                {
                    if (strDict.ContainsKey(current) == false)
                    {
                        strDict.Add(current, 1);
                    }
                    else if (strDict.ContainsKey(current) == true)
                    {
                        strDict[current] = strDict[current] + 1;
                    }
                }
            }

            return strDict;
        }

        public int hash(string input)
        {
            int total = 0;
            foreach( char c in input)
            {
                total += c;
            }

            return total % 100;
        }
    }
}

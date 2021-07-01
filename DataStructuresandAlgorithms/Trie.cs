using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class Trie
    {

        private TrieNode head;
        private int noWords;
        public Trie()
        {

            this.head = new TrieNode();
            this.noWords = 0;
            this.head.endofWord = false;
        }
        public void insert(string input)
        {

            
            TrieNode currentNode = this.head;
            for (int i=0; i<input.Length; i++)
            {
                char currentchar = char.ToUpper(input[i]);
                
                if (currentNode.containsChild(currentchar)==false)
                {
                    currentNode.addChild(currentchar);
                }
                currentNode = currentNode.getNode(currentchar);
                
                
                
            }
            currentNode.endofWord = true;
        }

        public void remove(string word)
        {
            
            remove(this.head, word, 0);
        }

        private void remove(TrieNode root, string word, int index)
        {
            if (index == word.Length)
            {
                root.endofWord = false;
                return;
            }
            char current = char.ToUpper(word[index]);
            index = index + 1;
            TrieNode next = root.getNode(current);
            remove(next, word, index);
            var listchildren = next.getchildren();
            if (listchildren.Count == 0 & !next.endofWord)
            {
                root.removeChild(current);
            }
            
            
            
        }
        public void traversePreOrder()
        {
            traversePreOrder(this.head);
        }

        public string longestPrefix(string[] arr)
        {
            if (arr.Length == 1)
            {
                return arr[0].ToUpper();
            }
            for(int i=0; i<arr.Length; i++)
            {
                string word = arr[i].ToUpper();
                insert(word);
            }
           

            List<string> wordlist = new List<string>();
            longestprefix(wordlist, "", this.head);
            int initial = 0;
            string longest = "";
            foreach (string prefix in wordlist)
            {
                if (prefix.Length > initial)
                {
                    longest = prefix;
                    initial = prefix.Length;
                }
            }

            return longest;
        }

        private void longestprefix(List<string> prefixlist, string word, TrieNode Node)
        {
            word = word + Node.value;
            if (Node.endofWord == true)
            {
                if (Node.getchildren().Count > 0)
                {
                    prefixlist.Add(word);
                }
            }
            else if (Node.getchildren().Count > 1)
            {
                prefixlist.Add(word);
            }
            List<char> keyset = Node.getkeys();
            foreach (char c in keyset)
            {
                longestprefix(prefixlist, word, Node.getNode(c));
            }

        }

        public void traversePostOrder()
        {
            traversePostOrder(this.head);
        }

        private void traversePostOrder(TrieNode Node)
        {
            List<TrieNode> entryset = Node.getchildren();
            foreach (TrieNode n in entryset)
            {
                traversePostOrder(n);
            }
            Console.WriteLine(Node.value);
        }

        private void traversePreOrder(TrieNode Node)
        {
            Console.WriteLine(Node.value);
            List<char> keyset = Node.getkeys();
            foreach( char c in keyset)
            {
                traversePreOrder(Node.getNode(c));
            }

        }

        public int getNoWords()
        {
            this.noWords = 0;
            getNoWords(this.head);
            return this.noWords;

        }

        private void getNoWords(TrieNode node)
        {
           
           
            if (node.endofWord == true)
            {
                this.noWords = this.noWords + 1;
            }

            List<char> keyset = node.getkeys();
            foreach (char c in keyset)
            {
               TrieNode nd = node.getNode(c);
               getNoWords(nd);
            }

            

            
            
            

        }

        public List<string> autoComplete(string prefix)
        {
            List<string> wordlist = new List<string>();
            TrieNode branchNode = getLastChild(prefix);
            prefix = prefix.Remove(prefix.Length - 1);
            AutoComplete(branchNode, wordlist, prefix);
            return wordlist;
        }

        private TrieNode getLastChild(string prefix)
        {
            prefix = prefix.ToUpper();
            TrieNode current = this.head;
            for(int i=0; i<prefix.Length; i++)
            {
                current = current.getNode(prefix[i]);
                if (current == null)
                {
                    return null;
                }

            }
           

            return current;
            
                
        }

        

        private void AutoComplete(TrieNode node, List<string> wordList, string word)
        {
            word = word.ToUpper();
            word = word + node.value;
            if (node.endofWord == true)
            {
                wordList.Add(word);
            }
            if (node.getchildren().Count == 0)
            {
                return;
            }
            List<char> keyset = node.getkeys();
            foreach (char c in keyset)
            {
                AutoComplete(node.getNode(c), wordList, word);
            }

        }

        public bool containsRecursive(string word)
        {
            int index = 0;
            word = word.ToUpper();
            return containsRecursive(this.head, word, index);
        }

        private bool containsRecursive(TrieNode Node, string word, int index)
        {
            if(Node.getchildren().Count==0)
            {
                return Node.endofWord;
            } else if (Node.getchildren().Count>0 && index < word.Length)
            {
                TrieNode next = Node.getNode(word[index]);
                if (next != null )
                {
                    index = index + 1;
                    return containsRecursive(next, word, index);
                }
                else
                {
                    return false;
                }
            }
            return Node.endofWord;
           
        }

        public bool contains(string word)
        {
            TrieNode currentNode = this.head;
            for (int i=0; i< word.Length; i++)
            {
                char currentchar = char.ToUpper(word[i]);
                if (i == word.Length - 1)
                {
                    if (currentNode.containsChild(currentchar) == false)
                    {
                        return false;
                    }
                    else
                    {
                        currentNode = currentNode.getNode(currentchar);
                        return currentNode.endofWord;
                    }
                }

                if (currentNode.containsChild(currentchar) == false)
                {
                    return false;
                }
                currentNode = currentNode.getNode(currentchar);

            }
            return false;
        }

        private int getcharindex(char c)
        {
            return char.ToUpper(c) - 65;
        }
    }


}
        
    




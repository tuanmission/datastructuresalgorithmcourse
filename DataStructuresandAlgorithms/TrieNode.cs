using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class TrieNode
    {

        public char value { get; set; }

        public bool endofWord { get; set; }
        public Dictionary<char, TrieNode> NodeDict { get; set; }
        public TrieNode()
        {
            this.NodeDict = new Dictionary<char, TrieNode>();
            this.endofWord = false;
        }

        public bool containsChild(char c)
        {
            return this.NodeDict.ContainsKey(c);
        }

        public void addChild(char c)
        {
            TrieNode newnode = new TrieNode
            {
                value = c
            };
            newnode.endofWord = false;
            this.NodeDict.Add(c, newnode);
        }

        public void removeChild(char c)
        {
            this.NodeDict.Remove(c);
        }

        public TrieNode getNode(char c)
        {
            if (this.NodeDict.ContainsKey(c))
            {
                return this.NodeDict[c];
            }
            return null; 
        }

        public List<char> getkeys()
        {
           List <char> keylist = new List<char>(this.NodeDict.Keys);
           return keylist;
        }

        public List<TrieNode> getchildren()
        {
            List<TrieNode> children = new List<TrieNode>(this.NodeDict.Values);
            return children;
        }
    }
}

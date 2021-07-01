using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class TreeNode
    {
        public TreeNode leftNode { get; set; }
        public TreeNode rightNode { get; set; }
        public int Value { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
        }
    }
}

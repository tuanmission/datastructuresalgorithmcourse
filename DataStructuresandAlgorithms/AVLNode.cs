using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class AVLNode
    {

        public AVLNode leftNode { get; set; }

        public AVLNode rightNode { get; set; }

        public int value { get; set; }

        public int height { get; set; }

        public AVLNode(int value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "Value=" + this.value;
        }
    }
}

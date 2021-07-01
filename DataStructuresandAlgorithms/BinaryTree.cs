using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class BinaryTree
    {
        public TreeNode rootnode { get; set; }

        public BinaryTree()
        {
            this.rootnode = null;
        }
        public void insert(int data)
        {
            TreeNode tn = new TreeNode(data);
            if (this.rootnode == null)
            {
                this.rootnode = tn;
            }
            else
            {
                TreeNode curr = this.rootnode;
               
                while(true)
                {
                    if(data >= curr.Value)
                    {
                        if (curr.rightNode == null)
                        {
                            curr.rightNode = tn;
                            break;
                        }
                        else
                        {
                            curr = curr.rightNode;
                        }
                        
                    }
                    else if (data<curr.Value)
                    {
                        if (curr.leftNode == null)
                        {
                            curr.leftNode = tn;
                            break;
                        }
                        else
                        {
                            curr = curr.leftNode;
                        }
                    }
                }

              
            }
        }

        public bool find(int data)
        {
            
            TreeNode curr = this.rootnode;
            while(curr.leftNode!=null && curr.rightNode != null)
            {
                if (curr.Value == data)
                {
                    return true;
                }
                else
                {
                    if(data>= curr.Value)
                    {
                        curr = curr.rightNode;
                    }
                    else if(data<curr.Value)
                    {
                        curr = curr.leftNode;
                    }
                }
            }
            if (curr.Value == data)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int Height()
        {
            return Height(this.rootnode);
        }

        private int Height(TreeNode node)
        {
            if (node == null)
            {
                return -1;
            }
            if(node.leftNode==null && node.rightNode == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(Height(node.leftNode), Height(node.rightNode));
            }
        }

        private int getHeight(TreeNode node)
        {
            return 1 + Math.Max(Height(node.leftNode), Height(node.rightNode));
        }
        private void traversePreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            System.Console.WriteLine(root.Value);
            traversePreOrder(root.leftNode);
            traversePreOrder(root.rightNode);

        }
        private void traverseInOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            traverseInOrder(root.leftNode);
            System.Console.WriteLine(root.Value);
            
            traverseInOrder(root.rightNode);

        }
        private void traversePostOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            traverseInOrder(root.leftNode);
            traverseInOrder(root.rightNode);
            System.Console.WriteLine(root.Value);
        }

        public void traversePreOrder()
        {
            traversePreOrder(this.rootnode);
        }


        public void traverseInOrder()
        {
            traverseInOrder(this.rootnode);
        }
        public void traversePostOrder()
        {
            traversePostOrder(this.rootnode);
        }


        public int min()
        {
            return min(this.rootnode);
        }

        private int min(TreeNode root)
        {
            
            if (root.leftNode==null && root.rightNode== null)
            {
                return root.Value;
            }
            var left = min(root.leftNode);
            var right = min(root.rightNode);

            return Math.Min(Math.Min(left, right), root.Value);
        }


        public int max()
        {
            return max(this.rootnode);
        }

        private int max(TreeNode root)
        {

            if (root.leftNode == null && root.rightNode == null)
            {
                return root.Value;
            }
            var left = max(root.leftNode);
            var right = max(root.rightNode);

            return Math.Max(Math.Max(left, right), root.Value);
        }




        public int bstMin()
        {

            if (this.rootnode == null)
            {
                throw new InvalidOperationException("Empty Tree");
            }
            TreeNode current = this.rootnode;
            TreeNode last = current;
            while (current != null)
            {
                last = current;
                current = current.leftNode;
            }

            return last.Value;
        }

        public bool isequal(BinaryTree Compare)
        {
            return isequal(this.rootnode, Compare.rootnode);
        }

        private bool isequal(TreeNode thisTree, TreeNode compareTree)
        {
            if (thisTree == null && compareTree == null)
            {
                return true;
            }
            else if (thisTree!=null && compareTree!=null)
            {
                return thisTree.Value == compareTree.Value && isequal(thisTree.leftNode, compareTree.leftNode) && isequal(thisTree.rightNode, compareTree.rightNode);

            }
            else
            {
                return false;
            }
        }


        public void swapRoot()
        {
            TreeNode temp = this.rootnode.leftNode;
            this.rootnode.leftNode = this.rootnode.rightNode;
            this.rootnode.rightNode = temp;
        }
        public bool isBST()
        {
            return isBST(this.rootnode, int.MinValue, int.MaxValue);
        }
        private bool isBST(TreeNode node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            return node.Value >= min && node.Value <= max && isBST(node.leftNode, min, node.Value) && isBST(node.rightNode, node.Value, max);
        }

        public ArrayList nodesAtKDistance(int k)
        {
            ArrayList list = new ArrayList();
            nodesAtKDistance(this.rootnode, k,list);
            return list;
        }

        public bool isperfectBinary()
        {
            int heightofTree = Height();
            return isperfectBinary(this.rootnode, 0, heightofTree);

        }

        private bool isperfectBinary(TreeNode root, int currentDepth, int heightofTree)
        {
            
            if (heightofTree == 0)
            {
                return true;
            }else if (root.leftNode==null && root.rightNode == null && currentDepth==heightofTree)
            {
                return true;
            } else if (root.leftNode!=null && root.rightNode != null)
            {
                return isperfectBinary(root.leftNode, currentDepth + 1, heightofTree) && isperfectBinary(root.rightNode, currentDepth + 1, heightofTree);
            }
            else
            {
                return false;
            }
        }

        private void nodesAtKDistance(TreeNode Node, int k, ArrayList list)
        {
            if (k == 0)
            {
                list.Add(Node.Value);
                return;

               
               
            }

            if (Node == null)
            {
                return;
            }

            if (Node.rightNode == null && Node.leftNode == null)
            {
                list.Add(Node.Value);
                return;
            }

            nodesAtKDistance(Node.leftNode, k - 1,list);
            nodesAtKDistance(Node.rightNode, k - 1,list);


        }

        public int size()
        {
            return size(this.rootnode);
        }

        public int countLeaves()
        {
            return CountLeaves(this.rootnode);
        }
        
        private int size(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + size(root.leftNode) + size(root.rightNode);
        }
        

        private int CountLeaves(TreeNode root)
        {
            if (root.leftNode ==null && root.rightNode == null)
            {
                return 1;
            }

            return CountLeaves(root.leftNode) + CountLeaves(root.rightNode);
        }

       public bool aresibling(int data1, int data2)
        {
            return aresibling(this.rootnode, data1, data2);
        }

        private bool aresibling(TreeNode node, int data1, int data2)
        {
            if (node == null)
            {
                return false;
            }
            if (node.leftNode==null && node.leftNode == null)
            {
                return false;
            }
            else
            {
                if ((node.leftNode.Value==data1 && node.rightNode.Value==data2) || (node.leftNode.Value == data2 && node.rightNode.Value == data1))
                {
                    return true;
                }
            }

            return aresibling(node.leftNode,  data1,  data2) || aresibling(node.rightNode, data1, data2);
        }


        public bool getAncestors(int data, List<int> intlist)
        {
            return getAncestors(data, this.rootnode, intlist);
        }

        private bool getAncestors(int data, TreeNode node, List<int> intlist)
        {
            if (node == null)
            {
                return false;
            }
            else if (data == node.Value)
            {
                return true;
            }

            bool left = getAncestors(data, node.leftNode,intlist);
            bool right = getAncestors(data, node.rightNode, intlist);
            if (right == true || left == true)
            {
                intlist.Add(node.Value);
                return true;
            }

            return false;
          
        }

        public bool Find(int data)
        {
            return find(data, this.rootnode);
        }

        private bool find(int data, TreeNode node)
        {
            if (node == null)
            {
                return false;
            }
            if (data == node.Value)
            {
                return true;
            }

            return find(data, node.leftNode) || find(data, node.rightNode);
        }

        public void traverseLevelOrder()
        {
            for (int i =0; i<=Height(); i++)
            {
                ArrayList list = nodesAtKDistance(i);
                foreach (Object o in list)
                {
                    int outp = (int)o;
                    Console.WriteLine(outp); 
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresandAlgorithms
{
    public class AVLtree
    {

        private AVLNode root;

        public AVLtree()
        {
            this.root = null;
        }


        public void insert(int data)
        {

            this.root = insert(this.root, data);



        }


        private AVLNode insert(AVLNode node, int data)
        {
            if (node == null)
            {
                return new AVLNode(data);
            }

            if (data < node.value)
            {
                node.leftNode = insert(node.leftNode, data);
            }
            else
            {
                node.rightNode = insert(node.rightNode, data);
            }
            setHeight(node);

            Console.WriteLine("Height of this node is : " + node.height);
            node=balance(node);
            
            return node;
        }

        private void setHeight(AVLNode node)
        {
            node.height= Math.Max(height(node.leftNode), height(node.rightNode)) + 1;

        }

        public bool isBalanced()
        {
            return isBalanced(this.root);
        }


        private bool isBalanced(AVLNode node)
        {
            if (node == null)
            {
                return true;
            }
            return balanceFactor(node) >= -1 && balanceFactor(node) <= 1 && isBalanced(node.leftNode) && isBalanced(node.rightNode);
        }


        private AVLNode balance(AVLNode node)
        {
            if (leftHeavy(node))
            {
                if (balanceFactor(node.leftNode) < 0)
                {
                  node.leftNode=  rotateleft(node.leftNode);
                }

                node =rotateRight(node);

                return node;

            }
            else if (rightHeavy(node))
            {
                if (balanceFactor(node.rightNode) > 0)
                {
                  node.rightNode=  rotateRight(node.rightNode);
                }

                node = rotateleft(node);
                return node;

            }

            return node;
        }

        private AVLNode rotateleft(AVLNode rootNode)
        {
            AVLNode newNode = rootNode.rightNode;
            rootNode.rightNode = newNode.leftNode;
            newNode.leftNode = rootNode;
            setHeight(rootNode);
            setHeight(newNode);
            return newNode;
        }

        private AVLNode rotateRight(AVLNode rootNode)
        {
            AVLNode newNode = rootNode.leftNode;
            rootNode.leftNode = newNode.rightNode;
            newNode.rightNode = rootNode;
            setHeight(rootNode);
            setHeight(newNode);
            return newNode;
        }

        private int height(AVLNode node)
        {
            return (node == null) ? -1 : node.height;
        }

        private bool leftHeavy(AVLNode node)
        {
            return balanceFactor(node) > 1;
        }

        private bool rightHeavy(AVLNode node)
        {
            return balanceFactor(node) < -1;
        }

        private int balanceFactor(AVLNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return height(node.leftNode) - height(node.rightNode);
            }

        }
    }

}

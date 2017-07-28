﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions.DataStructures
{
    public class BinaryTree : ILCSolutions
    {
        public BinaryTree Root { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public int Value { get; set; }

        public BinaryTree()
        {

        }

        public BinaryTree(int val)
        {
            Value = val;
        }

        public static Random rnd = new Random();

        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            int n = 6;
            List<int> input = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int val = rnd.Next(1, 100);
                if (!input.Contains(val))
                    input.Add(val);
                else
                    i--;
            }

            BinaryTree BST = new BinaryTree();

            BST.CreateBinarySearchTree(input);

            Console.WriteLine("PreOrder");
            BST.PrintBinaryTreePreOrder(Root);
            Console.WriteLine();

            Console.WriteLine("PrintBinaryTreeInOrder");
            BST.PrintBinaryTreeInOrder(Root);
            Console.WriteLine();

            Console.WriteLine("PrintBinaryTreePostOrder");
            BST.PrintBinaryTreePostOrder(Root);
            Console.WriteLine();

            Console.WriteLine("PrintLeftBoundaryNode");
            BST.PrintLeftBoundaryNode(Root);
            Console.WriteLine();

            Console.WriteLine("PrintLeafNodesRec");
            BinaryTree.PrintLeafNodesRec(new List<int>() { 5, 3, 2, 4, 8, 7, 9 });

            Console.WriteLine("PrintLeafNodesRec");
            BinaryTree.PrintLeafNodesRec(new List<int>() { 5, 4, 82, 16, 62, 92 });

           
            bool validBST = false;
            Console.WriteLine("IsValidBST - BST");
            validBST = BST.IsValidBST(BST.Root);
            Console.WriteLine("IsValidBST: " + validBST);

            BinaryTree BT = new BinaryTree();
            Console.WriteLine("IsValidBST - BT");
            BT.CreateBinaryTree(input);
            validBST = BST.IsValidBST(BT.Root);
            Console.WriteLine("IsValidBST: " + validBST);

            int depth = FindMaxDepth(BST.Root);
            Console.WriteLine("Max depth is " + depth);

            depth = FindMinDepth(BST.Root);
            Console.WriteLine("Min depth is " + depth);

            Console.WriteLine();
        }


        /// <summary>
        /// Given a PreOrder BST, display leaf node w/o constructing the tree
        /// This method ONLY works for complete BST
        /// </summary>
        /// <param name="input"></param>
        [Obsolete]
        private static void PrintLeafNodes(List<int> arr)
        {
            if (arr == null || arr.Count == 0)
                return;

            int prev = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                if (prev < arr[i])
                {
                    Console.Write(prev + " ");
                }

                prev = arr[i];
            }

            // Always print last element
            Console.WriteLine(prev + " ");
        }

        /// <summary>
        /// Given a PreOrder BST, display leaf node w/o constructing the tree
        /// idea is that first node is the root, and we can use root to get left set and right set
        /// keep on dividing the array, until only 1 element left 
        /// </summary>
        /// <param name="arr"></param>
        private static void PrintLeafNodesRec(List<int> arr)
        {
            if (arr == null || arr.Count == 0)
                return;

            int prev = arr[0];

            if (arr.Count == 1)
            {
                Console.WriteLine(prev);
                return;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            for (int i = 1; i < arr.Count; i++)
            {
                if (prev < arr[i])
                    right.Add(arr[i]);
                else
                    left.Add(arr[i]);
            }
            PrintLeafNodesRec(left);
            PrintLeafNodesRec(right);
        }


        /// <summary>
        /// Print Binary Tree in increasing sorted order, In-Order
        /// </summary>
        /// <param name="node"></param>
        private void PrintBinaryTreePreOrder(BinaryTree node)
        {
            if (node == null)
                return;

            Console.Write(node.Value + " -> ");
            PrintBinaryTreePreOrder(node.Left);
            PrintBinaryTreePreOrder(node.Right);
        }

        /// <summary>
        /// Print binary tree in-order (bottom-up post-order trasversal)
        /// </summary>
        /// <param name="node"></param>
        private void PrintBinaryTreePostOrder(BinaryTree node)
        {
            if (node == null)
                return;

            PrintBinaryTreePostOrder(node.Left);
            PrintBinaryTreePostOrder(node.Right);
            Console.Write(node.Value + " -> ");
        }

        public void PrintBinaryTreeInOrder(BinaryTree node)
        {
            if (node == null)
                return;

            PrintBinaryTreeInOrder(node.Left);
            Console.Write(node.Value + " -> ");
            PrintBinaryTreeInOrder(node.Right);
        }


        /// <summary>
        /// Oly print the 
        /// </summary>
        /// <param name="node"></param>
        public void PrintLeftBoundaryNode(BinaryTree node)
        {
            if (node == null || (node.Left == null && node.Right == null))
                return;

            Console.Write(node.Value + "->");
            if(node.Left != null)
                PrintLeftBoundaryNode(node.Left);
            else if(node.Right != null)
                PrintLeftBoundaryNode(node.Right);    
        }

        /// <summary>
        /// This needs to be checked - we also need to check all subtree value is less or larger than the root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsValidBST(BinaryTree node)
        {
            // need to confirm the assumption
            if (node == null || (node.Left == null && node.Right == null))
                return false;

            return PreOrderValidation(node, null, null);
        }

        private bool PreOrderValidation(BinaryTree node, int? low, int? high)
        {
            if (node == null)
                return true;

            return (low == null || node.Value > low) && (high == null || node.Value < high)
                && PreOrderValidation(node.Left, low, node.Value)
                && PreOrderValidation(node.Right, node.Value, high);
        }

        public void CreateBinarySearchTree(List<int> inputs)
        {
            foreach(int val in inputs)
            {
                if(Root == null)
                {
                    Root = new BinaryTree(val);
                    Root.Left = null;
                    Root.Right = null;
                }
                else
                {
                    AddBSTNode(Root, val);
                }
            }
        }



        /// <summary>
        /// Create a  regular binary tree
        /// </summary>
        /// <param name="inputs"></param>
        public void CreateBinaryTree(List<int> inputs)
        {
            foreach(int val in inputs)
            {
                if (Root == null)
                {
                    Root = new BinaryTree(val);
                    Root.Left = null;
                    Root.Right = null;
                }
                else
                {
                    AddBTNode(Root, val);
                }
            }
        }

        /// <summary>
        /// ADD BT node 
        /// Current step is left node heavy...
        /// We need to track leaf node height to make it balanced
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        private void AddBTNode(BinaryTree root, int val)
        {
            if (root.Left == null)
            {
                root.Left = new BinaryTree(val);
            }
            else if (root.Right == null)
            {
                root.Right = new BinaryTree(val);
            }
            else
                //TODO: this step needs to be tweaked. 
                AddBTNode(root.Left, val);
        }

        /// <summary>
        /// Add BST node
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        public void AddBSTNode(BinaryTree root, int val)
        {
            BinaryTree newNode = new BinaryTree(val);

            if(root.Value > val)
            {
                if (root.Left == null)
                    root.Left = new BinaryTree(val);
                else
                    AddBSTNode(root.Left, val);
            }
            else
            {
                if (root.Right == null)
                    root.Right = new BinaryTree(val);
                else
                    AddBSTNode(root.Right, val);
            }
        }

        /// <summary>
        /// This returns number of nodes from Root to furtherest leaf
        /// If we want to return the edge, then we need ot minus 1
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int FindMaxDepth(BinaryTree node)
        {
            int depth = 0;

            if (node == null)
                return 0;

            int leftDepth = 0, rightDepth = 0;
            if (node.Left != null)
                leftDepth = FindMaxDepth(node.Left);
            if (node.Right != null)
                rightDepth = FindMaxDepth(node.Right);

            depth = (leftDepth >= rightDepth ? leftDepth : rightDepth) + 1;

            return depth;
        }


        public int FindMinDepth(BinaryTree node)
        {
            if (node == null)
                return 0;

            int depth = 1;

            //idea is to use a queue, FIFO to process
            Queue<BinaryTree> queue = new Queue<BinaryTree>();
            queue.Enqueue(node);

            BinaryTree rightMostNode = node;
            while(queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                if (currNode.Left == null && currNode.Right == null) break;
                if (currNode.Left != null)
                    queue.Enqueue(currNode.Left);
                if (currNode.Right != null)
                    queue.Enqueue(currNode.Right);
                if(rightMostNode == currNode)
                {
                    depth++;
                    rightMostNode = currNode.Right != null ? currNode.Right : currNode.Left;
                }
            }

            return depth;
        }



        /// <summary>
        /// Check if given tree is height balanced 
        /// idea: Top down approach
        ///       at each level check if the level difference less than 2 
        ///       if true, keep going down to next level, otherwise, return -1
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool ValidateBalancedBinaryTree(BinaryTree node)
        {
            return BalancedTreeDepth(node) != -1;
        }

        private int BalancedTreeDepth(BinaryTree node)
        {
            if (node == null) return 0;

            int leftDepth = BalancedTreeDepth(node.Left);
            if (leftDepth == -1) return -1;

            int rightDepth = BalancedTreeDepth(node.Right);
            if (rightDepth == -1) return -1;

            return Math.Abs(leftDepth - rightDepth) < 2 ? Math.Max(leftDepth, rightDepth) +1 : -1; 
        }


        /// <summary>
        /// Create a balanced Binary Search Tree given sorted array
        /// Divide and Conqure
        /// Time O(n), Space O(logN)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public BinaryTree CreateBalancedBST(List<int> input)
        {
            return CreateBalancedBST(input, 0, input.Count - 1);
        }

        private BinaryTree CreateBalancedBST(List<int> input, int start, int end)
        {
            if (start >= end) return null;

            int m = (start + end) / 2;

            BinaryTree node = new BinaryTree();
            node.Value = input[m];
            node.Left = CreateBalancedBST(input, start, m - 1);
            node.Right = CreateBalancedBST(input, m + 1, end);

            return node;
        }

        public void Remove(BinaryTree node)
        {
            throw new NotFiniteNumberException();
        }

        public void Insert(BinaryTree node)
        {
            throw new NotFiniteNumberException();
        }
    }
}

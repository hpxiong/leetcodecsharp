using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions.DataStructures
{
    public class BinaryTree
    {
        List<BinaryTreeNode> Nodes { get; set; }
        public BinaryTree(List<int> values)
        {
            if (Nodes == null)
                Nodes = new List<BinaryTreeNode>();

            int c = 0;
            BinaryTreeNode node = new BinaryTreeNode();
            foreach(int v in values)
            {
                node = new BinaryTreeNode();
                node.Value = v;

                if(Nodes.Count == 0)
                {
                    node.Parent = null;
                    node.Left = null;
                    node.Right = null;
                }
                else
                {
                    //node.Parent = 
                }

                Nodes.Add(node);
                
            }
            //Root = new BinaryTreeNode();
            //Root.Value = val;
            //Root.Parent = null;
        }

        public void Add(BinaryTreeNode node)
        {

        }

        public void Remove(BinaryTreeNode node)
        {

        }

        public void Insert(BinaryTreeNode node)
        {

        }
    }
}

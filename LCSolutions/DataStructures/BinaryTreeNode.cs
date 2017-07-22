using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions.DataStructures
{
    public class BinaryTreeNode
    {
        internal int Value { get; set; }
        internal BinaryTreeNode Left { get; set; }
        internal BinaryTreeNode Right { get; set; }
        internal BinaryTreeNode Parent { get; set; }
    }
}

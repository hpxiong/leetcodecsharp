using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class LinkedListDeepCopy : ILCSolutions
    {
        

        public void Test()
        {
            LinkedList<int> src = LinkedListHelper.BuildSortedLinkedList(10);

            LinkedListNode<int> curr = src.First;

            var node2 = LinkedListHelper.getNodeAt(src, 2);
            var node3 = LinkedListHelper.getNodeAt(src, 3);
            var node5 = LinkedListHelper.getNodeAt(src, 5);
            var node7 = LinkedListHelper.getNodeAt(src, 7);

            node2.Random(node3);
            node3.Random(node5);
            node5.Random(curr);


            LinkedList<int> copy = DeepCopyList(src);
        
        }

        private LinkedList<int> DeepCopyList(LinkedList<int> src)
        {
            throw new NotImplementedException();
        }
    }

    public static class RandomLinkedList
    {
        public static LinkedListNode<int> Random(this LinkedListNode<int> current, LinkedListNode<int> random)
        {
            return random;
        }

    }
}

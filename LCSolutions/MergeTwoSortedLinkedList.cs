using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class MergeTwoSortedLinkedList : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            LinkedList<int> list1 = new LinkedList<int>();
            list1.AddLast(5);
            list1.AddLast(6);
            list1.AddLast(7);
            list1.AddLast(9);
            list1.AddLast(13);
            printAllNodes(list1);

            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddLast(1);
            list2.AddLast(3);
            list2.AddLast(4);
            list2.AddLast(8);
            printAllNodes(list2);

            LinkedList<int> res = MergeList(list1, list2);
            printAllNodes(res);
            Console.WriteLine();
        }

        private  LinkedList<int> MergeList(LinkedList<int> list1, LinkedList<int> list2)
        {

            LinkedList<int> res = new LinkedList<int>();
            var cl = res.First;
            var l1 = list1.First;
            var l2 = list2.First;

            while (l1 != null || l2 != null)
            {
                if ((l1 != null && l2 != null && l1.Value < l2.Value) || (l1 != null && l2 == null))
                {
                    res.AddLast(l1.Value);
                    l1 = l1.Next;
                }
                else if ((l1 != null && l2 != null && l1.Value >= l2.Value) || (l1 == null && l2 != null))
                {
                    res.AddLast(l2.Value);
                    l2 = l2.Next;
                }

            }
            return res;
        }

        public  void printAllNodes(LinkedList<int> list)
        {
            var current = list.First;
            while (current != null)
            {
                Console.Write(current.Value);
                if (current.Next != null)
                    Console.Write("->");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}

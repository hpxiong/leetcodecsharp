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
            LinkedList<int> list1 = LinkedListHelper.BuildSortedLinkedList(8);
            LinkedListHelper.printAllNodes(list1);

            LinkedList<int> list2 = LinkedListHelper.BuildSortedLinkedList(5);
            LinkedListHelper.printAllNodes(list2);

            LinkedList<int> res = MergeList(list1, list2);
            LinkedListHelper.printAllNodes(res);
            Console.WriteLine();
        }

        public  LinkedList<int> MergeList(LinkedList<int> list1, LinkedList<int> list2, bool noduplicate=true)
        {

            LinkedList<int> res = new LinkedList<int>();

            //add a dummy node so that we dont need to check cl = null when run for the first time
            res.AddLast(0);
            var cl = res.First;

            var l1 = list1.First;
            var l2 = list2.First;

            while (l1 != null || l2 != null)
            {
                if ((l1 != null && l2 != null && l1.Value < l2.Value) 
                    || (l1 != null && l2 == null))
                {
                    if(noduplicate && cl.Value != l1.Value)
                        res.AddLast(l1.Value);
                    l1 = l1.Next;
                }
                else if ((l1 != null && l2 != null && l1.Value >= l2.Value) || (l1 == null && l2 != null))
                {
                    if (noduplicate && cl.Value != l2.Value)
                        res.AddLast(l2.Value);

                    l2 = l2.Next;
                }

                // Set cl to the last node in the final linkedlist so that we can check for duplicates
                cl = res.Last;
            }

            res.RemoveFirst();

            return res;
            

        }

    }
}

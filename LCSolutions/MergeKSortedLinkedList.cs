using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class MergeKSortedLinkedList : ILCSolutions
    {
        public void Test()
        {
            int n = 3;
            List<LinkedList<int>> lists = new List<LinkedList<int>>();

            int num = 1;
            for (int i=0; i < n; i++)
            {
                num = LinkedListHelper.rnd.Next(5, 10);
                var list = LinkedListHelper.BuildSortedLinkedList(num);
                lists.Add(list);
                LinkedListHelper.printAllNodes(list);
            }

            LinkedList<int> res = MergeKSortedLList(lists);
            LinkedListHelper.printAllNodes(res);
            Console.WriteLine();
        }

        private static MergeTwoSortedLinkedList sln = new MergeTwoSortedLinkedList();

        private LinkedList<int> MergeKSortedLList(List<LinkedList<int>> lists)
        {
            LinkedList<int> res = new LinkedList<int>();
            int c = 0;
            
            foreach (var list in lists)
            {
                if (c == 0)
                    res = list;
                else
                    // TODO: Existing code does not handle duplicates -- how to remove duplicates?
                    // 
                    res = sln.MergeList(list, res);
                c++;
            }
            return res;
        }

    }
}

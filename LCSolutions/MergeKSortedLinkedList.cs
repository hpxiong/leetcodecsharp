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
            int n = 100;
            List<LinkedList<int>> lists = new List<LinkedList<int>>();

            int num = 1;
            for (int i=0; i < n; i++)
            {
                num = LinkedListHelper.rnd.Next(5, 10);
                var list = LinkedListHelper.BuildSortedLinkedList(num);
                lists.Add(list);
                //LinkedListHelper.printAllNodes(list);
            }

            Console.WriteLine("Brutal Force ");
            Console.WriteLine("BGN: " + DateTime.Now);
            LinkedList<int> res = MergeKSortedLListBrutalForce(lists);
            LinkedListHelper.printAllNodes(res);
            Console.WriteLine("END: " + DateTime.Now);

            Console.WriteLine("Divide & Conque ");
            Console.WriteLine("BGN: " + DateTime.Now);
            MergeKSortedLListDivideConquer(lists, 0, lists.Count-1);
            LinkedListHelper.printAllNodes(res);
            Console.WriteLine("END: " + DateTime.Now);
            
            Console.WriteLine();
        }

        private static MergeTwoSortedLinkedList sln = new MergeTwoSortedLinkedList();


        /// <summary>
        /// Complexity: (n + 2n + 3n+ .. + nK) = n(k*(k+1)/2  -1) = nK^2
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        private LinkedList<int> MergeKSortedLListBrutalForce(List<LinkedList<int>> lists)
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


        /// <summary>
        /// Time: nK + nk/2 + nk/4.... -> O(nklogk)
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private LinkedList<int> MergeKSortedLListDivideConquer(List<LinkedList<int>> lists, int start, int end)
        {
            //// merge 2 list at the same time
            if (start == end)
                return lists[start];
            else if (start < end)
            {

                // !! Remeber this!!!

                int m = (start + end) / 2;

                var a = MergeKSortedLListDivideConquer(lists, start, m);
                var b = MergeKSortedLListDivideConquer(lists, m+1, end);
                return sln.MergeList(a, b);

            }
            else
                return null;
        }

    }
}

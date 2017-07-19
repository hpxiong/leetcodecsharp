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
            LinkedList<int> list1 = BuildSortedLinkedList(5); Thread.Sleep(1000);
            LinkedList<int> list2 = BuildSortedLinkedList(4); Thread.Sleep(1000);
            LinkedList<int> list3 = BuildSortedLinkedList(6); Thread.Sleep(1000);
            LinkedList<int> list14 = BuildSortedLinkedList(10); 

            Console.WriteLine();
        }

        private static Random rnd = new Random();
        private LinkedList<int> BuildSortedLinkedList(int v)
        {
            LinkedList<int> res = new LinkedList<int>();
            
            
            //int curr = rnd.Next(1, 10);

            int curr = 0;
            for(int i = 0; i < v; i++)
            {
                curr += rnd.Next(1, 3); 
                res.AddLast(curr);                
            }

            return res;
        }
    }
}

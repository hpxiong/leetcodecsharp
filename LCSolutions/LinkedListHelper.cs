using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public static class LinkedListHelper
    {
        public static Random rnd = new Random();
        public static LinkedList<int> BuildSortedLinkedList(int v)
        {
            LinkedList<int> res = new LinkedList<int>();
            int curr = 0;
            for (int i = 0; i < v; i++)
            {
                curr += rnd.Next(1, 30);
                res.AddLast(curr);
            }

            return res;
        }

        public static void printAllNodes(LinkedList<int> list)
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

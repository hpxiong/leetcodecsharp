using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class LinkedListAddition : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            int input1 = 1234;
            int input2 = 23958;

            LinkedList<int> list1 = StoreToLinkedList(input1); PrintList(list1);
            LinkedList<int> list2 = StoreToLinkedList(input2); PrintList(list2);
            LinkedList<int> res = AddList(list1, list2);
            PrintList(res);
            Console.ReadKey();
        }

        private LinkedList<int> AddList(LinkedList<int> list1, LinkedList<int> list2)
        {
            LinkedList<int> res = new LinkedList<int>();

            var l1 = list1.First;
            var l2 = list2.First;

            // handle carryover bit
            int carryover = 0;
            int val = 0;
            while(l1 != null || l2 != null)
            {
                if(l1 != null && l2 != null)
                {
                    val = l1.Value + l2.Value + carryover;
                    l1 = l1.Next;
                    l2 = l2.Next;                    
                }
                else if(l1 != null)
                {
                    val = l1.Value + carryover;
                    l1 = l1.Next;
                }
                else if(l2 != null)
                {
                    val = l2.Value + carryover;
                    l2 = l2.Next;
                }

                if (val >= 10)
                {
                    carryover = 1;
                    val = val - 10;
                }
                res.AddLast(val);
            }
            return res;
        }

        private LinkedList<int> StoreToLinkedList(int input)
        {
            int n = input;
            LinkedList<int> res = new LinkedList<int>();
            while(n/10 != 0)
            {
                res.AddFirst(n % 10);
                n /= 10;
            }
            if (n > 0)
                res.AddFirst(n);

            return res;
        }

        private void PrintList(LinkedList<int> res)
        {
            var curr = res.First;
            while(curr != null)
            {
                Console.Write(curr.Value); 
                if (curr.Next != null)
                    Console.Write("->");
                curr = curr.Next;
            }                
            Console.WriteLine();
        }
    }
}

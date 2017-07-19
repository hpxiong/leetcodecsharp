using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class RotateLinkedList : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            LinkedList<int> input = new LinkedList<int>();
            input.AddLast(1);
            input.AddLast(2);
            input.AddLast(3);
            input.AddLast(4);
            input.AddLast(5);
            PrintLinkedList(input);
            LinkedList<int> res = RotateList(input);
            PrintLinkedList(res);
            Console.WriteLine();

            input.AddLast(6);
            PrintLinkedList(input);
            res = RotateList(input);
            PrintLinkedList(res);
            Console.WriteLine();

            input.AddLast(7);
            PrintLinkedList(input);
            res = RotateList(input);
            PrintLinkedList(res);
            Console.WriteLine();

        }

        private void PrintLinkedList(LinkedList<int> res)
        {
            var curr = res.First;
            while(curr != null)
            {
                Console.Write(curr.Value);
                if(curr.Next != null)
                    Console.Write("->");

                curr = curr.Next;
            }
            Console.WriteLine();
        }

        public LinkedList<int> RotateList(LinkedList<int> list)
        {
            int count = 0;
            LinkedList<int> res = new LinkedList<int>();
            LinkedListNode<int> curr = list.First;
            int lastval = -1;
            while (curr != null)
            {
                if (count % 2 != 0)
                {
                    res.AddLast(curr.Value);
                    res.AddLast(lastval);
                }
                else
                {
                    lastval = curr.Value;
                }
                // move the iterator            
                curr = curr.Next;
                
                //handle the odd number case
                if (curr == null && count % 2 == 0)
                    res.AddLast(lastval);
                else
                    count++;                
            }
            return res;
        }
    }
}

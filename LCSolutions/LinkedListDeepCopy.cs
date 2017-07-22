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

            //TODO: LinkedListNode in C# is sealed, we cannot extend it with a Random node. Need to build a linked list and node class to take Random node
            

            var curr = (LinkedListNodeExt<int>) src.First;
            

            var node2 = (LinkedListNodeExt<int>) LinkedListHelper.getNodeAt(src, 2);
            var node3 = (LinkedListNodeExt<int>) LinkedListHelper.getNodeAt(src, 3);
            var node5 = (LinkedListNodeExt<int>) LinkedListHelper.getNodeAt(src, 5);
            var node7 = (LinkedListNodeExt<int>) LinkedListHelper.getNodeAt(src, 7);

            node2.AddRandom(node3);
            node3.AddRandom(node5);
            node5.AddRandom(curr);
            curr.AddRandom(node2);

            LinkedListHelper.printAllNodes(src);

            LinkedList<int> copy = DeepCopyList(src);

            LinkedListHelper.printAllNodes(copy);


        }

        private LinkedList<int> DeepCopyList(LinkedList<int> src)
        {
            // plan: 
            // pass 1: 
            //    1.1 copy all information in linked list except random points, 
            //    1.2 create a hashmap to store random point info
            // pass 2
            //    2.1 update the copy with haskmap random node info

            var curr = src.First;
            LinkedList<int> copy = new LinkedList<int>();
            // add a dummy head
            copy.AddFirst(0);

            // create a dictionary map
            Dictionary<int, LinkedListNode<int>> RandomPointers = new Dictionary<int, LinkedListNode<int>>();

            //counter
            int c = 0;


            // PASS 1
            while (curr != null)
            {
                //RandomPointers.Add(c, curr.Random);
                copy.AddLast(curr.Value);
                curr = curr.Next;
                c++;
            }

            // PASS 2
            curr = copy.First;
            c = 0;
            while(curr != null)
            {
                //curr.Random(RandomPointers[c].Value);
                curr = curr.Next;
            }

            return copy;
        }
    }

    //public static class RandomLinkedList
    //{
    //    public static LinkedListNode<int> Random(this LinkedListNode<int> current, LinkedListNode<int> random)
    //    {
    //        return random;
    //    }
    //}


    public class LinkedListNodeExt<T>
    {
        //
        // Summary:
        //     Gets the System.Collections.Generic.LinkedList`1 that the System.Collections.Generic.LinkedListNode`1
        //     belongs to.
        //
        // Returns:
        //     A reference to the System.Collections.Generic.LinkedList`1 that the System.Collections.Generic.LinkedListNode`1
        //     belongs to, or null if the System.Collections.Generic.LinkedListNode`1 is not
        //     linked.
        public LinkedList<T> List { get; set; }
        //
        // Summary:
        //     Gets the next node in the System.Collections.Generic.LinkedList`1.
        //
        // Returns:
        //     A reference to the next node in the System.Collections.Generic.LinkedList`1,
        //     or null if the current node is the last element (System.Collections.Generic.LinkedList`1.Last)
        //     of the System.Collections.Generic.LinkedList`1.
        public LinkedListNodeExt<T> Next { get; set; }
        //
        // Summary:
        //     Gets the previous node in the System.Collections.Generic.LinkedList`1.
        //
        // Returns:
        //     A reference to the previous node in the System.Collections.Generic.LinkedList`1,
        //     or null if the current node is the first element (System.Collections.Generic.LinkedList`1.First)
        //     of the System.Collections.Generic.LinkedList`1.
        public LinkedListNodeExt<T> Previous { get; set; }
        //
        // Summary:
        //     Gets the value contained in the node.
        //
        // Returns:
        //     The value contained in the node.
        public T Value { get; set; }

        public LinkedListNodeExt<T> Random { get; set; }

        public LinkedListNodeExt()
        {

        }
        public LinkedListNodeExt(T value)
        {
            Value = value;
        }
        public LinkedListNodeExt(LinkedListNode<T> source)
        {
            if(source != null)
            {
                Value = source.Value;
                List = source.List;
                Next = (LinkedListNodeExt<T>)source.Next;
                Previous = (LinkedListNodeExt<T>)source.Previous;
            }
        }

        public void AddRandom(LinkedListNodeExt<T> random)
        {
            Random = random;
        }

        public static explicit operator LinkedListNodeExt<T>(LinkedListNode<T> v)
        {
            LinkedListNodeExt<T> d = new LinkedListNodeExt<T>();
            if (v != null)
                 d = new LinkedListNodeExt<T>(v);
            
            return d;
        }
    }
}

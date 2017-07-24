using LCSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            ILCSolutions sln;

            //sln = new AnagramInString(); sln.Test();
            //sln = new BaseballScore();  sln.Test();
            //sln = new MergeLinkedList(); sln.Test();
            //sln = new LongestPalindromeString(); sln.Test();
            //sln = new Maze(); sln.Test();
            // sln = new MergeKSortedLinkedList(); sln.Test();

            //sln = new RotateLinkedList(); sln.Test();

            //sln = new LinkedListAddition();  sln.Test();

            //sln = new PlusOne(); sln.Test();
            //sln = new RotateArray(); sln.Test();

            //sln = new StringToInteger();

            //sln = new Subset();

            //sln = new TwoSum(); sln.Test();

            //sln = new TwoSumClass();

            // sln = new MergeKSortedLinkedList();
            // sln = new LinkedListDeepCopy();
            sln = new BinaryTree();


            sln.Test();

            Console.ReadKey();
        }
    }
}

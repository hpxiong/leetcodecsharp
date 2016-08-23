using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Tests
{
    [TestClass()]
    public class ThreeSumTests
    {
        [TestMethod()]
        public void ThreeSumBrutalForceTest()
        {
            ThreeSum handle = new ThreeSum();
            int[] input = new int[5];
            List<List<int>> expected = null;
            List<List<int>> actual = null;

            input = new int[5] { -5, 0, 1, 5, -2 };
            actual = handle.BrutalForce(input);
            expected = new List<List<int>>() { new List<int>() { -5, 0, 5 } };

            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));


            input = new int[5] { -5, 1, 1, 5, -2 };
            actual = handle.BrutalForce(input);
            expected = new List<List<int>>() { new List<int>() { -2, 1, 1 } };

            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));

            input = new int[6] { -5, 1, 1, 0, 5, -2 };
            actual = handle.BrutalForce(input);
            expected = new List<List<int>>()
            {
                new List<int>() { -5, 0, 5 },
                new List<int>() { -2, 1, 1 }
            };
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));
            CollectionAssert.AreEqual(expected[1], actual[1], String.Join(",", input));

            input = new int[6] { -1, 0, 1, 2, -1, -4 };
            actual = handle.BrutalForce(input);
            expected = new List<List<int>>()
            {
                new List<int>() { -1, -1, 2 },
                new List<int>() { -1, 0, 1 }

            };
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));
            CollectionAssert.AreEqual(expected[1], actual[1], String.Join(",", input));

            //[1,2,-2,-1]

            input = new int[4] { 1, 2, -2, -1 };
            actual = handle.BrutalForce(input);
            expected = new List<List<int>>()
            {
            };
            CollectionAssert.AreEqual(expected, actual, String.Join(",", input));


            //[0,-4,-1,-4,-2,-3,2]
            input = new int[7] { 0, -4, -1, -4, -2, -3, 2 };
            actual = handle.BrutalForce(input);
            expected = new List<List<int>>()
            {
                new List<int>() { -2, 0, 2 }
            };
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));
        }

        [TestMethod()]
        public void ThreeSumReduceTest()
        {
            ThreeSum handle = new ThreeSum();
            int[] input = new int[5];
            List<List<int>> expected = null;
            List<List<int>> actual = null;

            input = new int[5] { -5, 0, 1, 5, -2 };
            actual = handle.ThreeSumReduce(input);
            expected = new List<List<int>>() { new List<int>() { -5, 0, 5 } };

            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));


            input = new int[5] { -5, 1, 1, 5, -2 };
            actual = handle.ThreeSumReduce(input);
            expected = new List<List<int>>() { new List<int>() { -2, 1, 1 } };

            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));

            input = new int[6] { -5, 1, 1, 0, 5, -2 };
            actual = handle.ThreeSumReduce(input);
            expected = new List<List<int>>()
            {
                new List<int>() { -5, 0, 5 },
                new List<int>() { -2, 1, 1 }
            };
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));
            CollectionAssert.AreEqual(expected[1], actual[1], String.Join(",", input));

            input = new int[6] { -1, 0, 1, 2, -1, -4 };
            actual = handle.ThreeSumReduce(input);
            expected = new List<List<int>>()
            {
                new List<int>() { -1, -1, 2 },
                new List<int>() { -1, 0, 1 }

            };
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));
            CollectionAssert.AreEqual(expected[1], actual[1], String.Join(",", input));

            //[1,2,-2,-1]

            input = new int[4] { 1, 2, -2, -1 };
            actual = handle.ThreeSumReduce(input);
            expected = new List<List<int>>()
            {
            };
            CollectionAssert.AreEqual(expected, actual, String.Join(",", input));


            //[0,-4,-1,-4,-2,-3,2]
            input = new int[7] { 0, -4, -1, -4, -2, -3, 2 };
            actual = handle.ThreeSumReduce(input);
            expected = new List<List<int>>()
            {
                new List<int>() { -2, 0, 2 }
            };
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));


            input = new int[121] {0, 8, 2, -9, -14, 5, 2, -5, -5, -9, -1, 3, 1, -8, 0, -3, -12, 2, 11, 9, 13, -14, 2, -15, 4, 10, 9, 7, 14, -8, -2, -1, -15, -15, -2, 8, -3, 7, -12, 8, 6, 2, -12, -8, 1, -4, -3, 5, 13, -7, -1, 11, -13, 8, 4, 6, 3, -2, -2, 3, -2, 3, 9, -10, -4, -8, 14, 8, 7, 9, 1, -2, -3, 5, 5, 5, 8, 9, -5, 6, -12, 1, -5, 12, -6, 14, 3, 5, -11, 8, -7, 2, -12, 9, 8, -1, 9, -1, -7, 1, -7, 1, 14, -3, 13, -4, -12, 6, -9, -10, -10, -14, 7, 0, 13, 8, -9, 1, -2, -5, -14};
            actual = handle.ThreeSumReduce(input);
            expected = handle.BrutalForce(input);
            CollectionAssert.AreEqual(expected[0], actual[0], String.Join(",", input));
        }
    }
}
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
    public class CodeCollectionsClassTests
    {
        [TestMethod()]
        public void FindMedianSortedArraysTest()
        {
            FindMedianSortedArrays sl = new FindMedianSortedArrays();
            List<int> input1 = new List<int>();
            List<int> input3 = new List<int>();

            double actual;
            double expected;

            input1 = new List<int>() { 4 };
            input3 = new List<int>() { 2, 3, 5};
            expected = 3.5;
            actual = sl.FindMedianSortedArraysWrapper(input1.ToArray(), input3.ToArray());
            Assert.AreEqual(expected, actual);

            input1 = new List<int>() { 4, 6, 10, 12 };
            input3 = new List<int>() { 2, 3, 5 };
            expected = 5;
            actual = sl.FindMedianSortedArraysWrapper(input1.ToArray(), input3.ToArray());
            Assert.AreEqual(expected, actual);

            input1 = new List<int>() { 1 };
            input3 = new List<int>() { 2, 3, 4};
            expected = 2.5;
            actual = sl.FindMedianSortedArraysWrapper(input1.ToArray(), input3.ToArray());
            Assert.AreEqual(expected, actual);
        }
    }
}
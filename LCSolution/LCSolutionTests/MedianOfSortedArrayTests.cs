using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LCSolution.Tests
{
    [TestClass()]
    public class MedianOfSortedArrayTests
    {
        [TestMethod()]
        public void FindMedianSortedArraysTest()
        {
            MedianOfSortedArray sl = new MedianOfSortedArray();

            List<int> input1 = new List<int>() { 4, 5 };
            List<int> input2 = new List<int>() { 1, 2, 3 };

            double expected = 3;
            double actual = sl.FindMedianSortedArrays(input1.ToArray(), input2.ToArray());

            Assert.AreEqual(expected, actual);

            input1 = new List<int>() { 5, 10, 20 };
            input2 = new List<int>() { 1, 2, 3, 5, 6, 7 };

            expected = 5;
            actual = sl.FindMedianSortedArrays(input1.ToArray(), input2.ToArray());

            Assert.AreEqual(expected, actual);
        }
    }
}

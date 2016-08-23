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
    public class WaterContainerTests
    {
        [TestMethod()]
        public void MaxAreaTest()
        {
            WaterContainer handle = new WaterContainer();
            int[] input;
            int expected = 0;
            int actual = 0;

            //input = new int[2] { 1, 1 };
            //expected = 1;
            //actual = handle.MaxArea(input);
            //Assert.AreEqual(expected, actual, String.Join(",", input.Select(s=>s.ToString()).ToArray()));

            input = new int[12] { 4, 2, 10, 9, 8, 5, 7, 7, 5, 5, 5, 10 };
            expected = 90;
            actual = handle.MaxArea(input);
            Assert.AreEqual(expected, actual, String.Join(",", input.Select(s => s.ToString()).ToArray()));
        }
    }
}
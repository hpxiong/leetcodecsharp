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
    public class ReverseIntegerTests
    {
        [TestMethod()]
        public void ReverseIntTest()
        {
            ReverseInteger handle = new ReverseInteger();

            int x = 1234;

            int expected = 4321;
            int actual = handle.ReverseInt(x);
            Assert.AreEqual(expected, actual);

            x = -10;
            expected = -1;
            actual = handle.ReverseInt(x);

            x =        1534236469;
            // expected = 1056389759;
            expected = 10;
            actual = handle.ReverseInt(x);

            Assert.AreEqual(expected, actual, x);
        }
    }
}
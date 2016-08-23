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
    public class PalindromeIntegerTests
    {
        [TestMethod()]
        public void IsPalindromeIntegerTest()
        {
            PalindromeInteger handle = new PalindromeInteger();

            bool expected = false;
            int input = -1;
            bool actual = false;

            input = 1234321;
            expected = true;
            actual = handle.IsPalindromeInteger(input);
            Assert.AreEqual(expected, actual, input.ToString());


            input = 1001;
            expected = true;
            actual = handle.IsPalindromeInteger(input);
            Assert.AreEqual(expected, actual, input.ToString());
        }
    }
}
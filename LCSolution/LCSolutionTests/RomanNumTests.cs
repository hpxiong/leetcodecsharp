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
    public class RomanNumTests
    {
        [TestMethod()]
        public void IntToRomanTest()
        {
            RomanNum handle = new RomanNum();
            string expected = string.Empty;
            string actual = string.Empty;
            int input = -1;


            input = 1233;
            expected = "MCCXXXIII";
            actual = handle.IntToRoman(input);
            Assert.AreEqual(expected, actual, input.ToString());


            input = 3999;
            expected = "MMMCMXCIX";
            actual = handle.IntToRoman(input);
            Assert.AreEqual(expected, actual, input.ToString());
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            RomanNum handle = new RomanNum();
            int expected = -1;
            int actual = -1;
            string input = "";

            expected = 3999;
            input = "MMMCMXCIX";
            actual = handle.RomanToInt(input);
            Assert.AreEqual(expected, actual, input);


            expected = 1233;
            input = "MCCXXXIII";
            actual = handle.RomanToInt(input);
            Assert.AreEqual(expected, actual, input);
        }
    }
}
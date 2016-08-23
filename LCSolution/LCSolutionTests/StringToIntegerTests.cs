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
    public class StringToIntegerTests
    {
        [TestMethod()]
        public void MyAtoiTest()
        {
            string input = string.Empty;
            StringToInteger handle = new StringToInteger();
            int expected = -1;
            int actual =  -1;

            input = "";
            expected = 0;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "-12534";
            expected = -12534;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "55874454";
            expected = 55874454;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "234 12313 536 3";
            expected = 234;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "1234 ware";
            expected = 1234;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "555666555444445566544";
            expected = int.MaxValue;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "-0012aad123";
            expected = -12;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "-2147483648";
            expected = -2147483648;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "-2147483647";
            expected = -2147483647;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);

            input = "-2147483649";
            expected = -2147483648;
            actual = handle.MyAtoi(input);
            Assert.AreEqual(expected, actual, input);
        }
    }
}
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
    public class ZigZagTests
    {
        [TestMethod()]
        public void ZigZagConvertTest()
        {
            string input = string.Empty;
            int num = 4;
            string expected = string.Empty;
            string actual = string.Empty;
            ZigZag zz = new ZigZag();

            input = "mccibivvqovfzayjuamyvspmkciqbllqnnaryyoqmjxnmwwgykgtdxfnanfdaqvngyggwu";
            num = 50;

            //input = "abcdefghijklmn";
            //num = 4;

            expected = zz.ZigZagConvert(input, num);
            
            actual = zz.ZigZagConvert2(input, num);

            Assert.AreEqual(expected, actual);
        }
    }
}
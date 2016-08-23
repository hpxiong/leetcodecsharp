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
    public class LongestCommonPrefxTests
    {
        [TestMethod()]
        public void FindLCPrefixDPTest()
        {
            LongestCommonPrefx handle = new LongestCommonPrefx();
            string[] input = new string[3];
            string expected = string.Empty;
            string actual = string.Empty;

            input = new string[3] { "around", "array", "arrow" };
            actual = handle.FindLCPrefixDP(input);
            expected = "ar";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));


            input = new string[3] { "interspecies", "interstellar", "interstate" };
            actual = handle.FindLCPrefixDP(input);
            expected = "inters";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[2] { "throne", "throne" };
            actual = handle.FindLCPrefixDP(input);
            expected = "throne";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[2] { "throne", "dungeon" };
            actual = handle.FindLCPrefixDP(input);
            expected = "";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[1] { "cheese" };
            actual = handle.FindLCPrefixDP(input);
            expected = "cheese";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            
            input = new string[2] { "aca", "aba" };
            actual = handle.FindLCPrefixDP(input);
            expected = "a";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            
            input = new string[4] { "geeksforgeeks", "geeks", "geek", "geezer" };
            actual = handle.FindLCPrefixDP(input);
            expected = "gee";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[3] { "apple", "ape", "april" };
            actual = handle.FindLCPrefixDP(input);
            expected = "ap";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));


        }
        [TestMethod()]
        public void FindLCPrefixOneByOneTest()
        {
            LongestCommonPrefx handle = new LongestCommonPrefx();
            string[] input = new string[3];
            string expected = string.Empty;
            string actual = string.Empty;

            input = new string[3] { "array", "arrow", "around" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "ar";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));


            input = new string[3] { "interspecies", "interstellar", "interstate" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "inters";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[2] { "throne", "throne" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "throne";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[2] { "throne", "dungeon" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[1] { "cheese" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "cheese";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));


            input = new string[2] { "aca", "aba" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "a";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));


            input = new string[4] { "geeksforgeeks", "geeks", "geek", "geezer" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "gee";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));

            input = new string[3] { "apple", "ape", "april" };
            actual = handle.FindLCPrefixOneByOne(input);
            expected = "ap";
            Assert.AreEqual(expected, actual, String.Join(",", input.ToArray()));


        }
    }
}
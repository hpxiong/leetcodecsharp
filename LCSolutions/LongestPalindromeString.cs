using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class LongestPalindromeString : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            string input = "", res = "";

            input = "madamimadam";
            res = FindPalindrome(input);
            Console.WriteLine(input + " : " + res);

            input = "abababa";
            res = FindPalindrome(input);
            Console.WriteLine(input + " : " + res);

            input = "abcbabcbabcba";
            res = FindPalindrome(input);
            Console.WriteLine(input + " : " + res);

            input = "abacbacba";
            res = FindPalindrome(input);
            Console.WriteLine(input + " : " + res);

            Console.WriteLine();
        }


        private string FindPalindrome(string input)
        {
            if (input.Length < 1)
                return input;

            string res = "";

            int left = -1;
            int right = -1;
            string tmp = "";

            for (int i = 1; i < input.Length; i++)
            {
                left = i;
                right = i + 1;
                // case when palindrome string is even size, use space as mirror
                tmp = IsPalindrome(input, left, right);
                res = tmp.Length > res.Length ? tmp : res;

                // case when palindrome is odd length
                left = i - 1;
                tmp = IsPalindrome(input, left, right);
                res = tmp.Length > res.Length ? tmp : res;
            }

            return res;
        }

        private string IsPalindrome(string input, int left, int right)
        {
            string res = "";
            while (left >= 0 && right < input.Length && left < right)
            {
                if (input[left] == input[right])
                {
                    res = input.Substring(left, right - left + 1);
                    //Console.WriteLine(res);

                    left--;
                    right++;
                }
                else
                    return "";
            }
            return res;
        }

        //private string FindLongestPalindromeNaive(string input)
        //{
        //    string res = "";
        //    if (string.IsNullOrEmpty(input))
        //        return res;

        //    //naive method

        //    Console.WriteLine(new string('-', 20));
        //    Console.WriteLine(input);
        //    Console.WriteLine(new string('-', 20));

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        string palin = "";
        //        int leftId = -1;
        //        int rightId = -1;

        //        // check odd length case - element is the center
        //        leftId = i;
        //        rightId = i + 1;
        //        palin = FindPalindromeWithIndex(input, i, leftId, rightId);
        //        if (!string.IsNullOrEmpty(palin) && palin.Length > res.Length)
        //        {
        //            res = palin;
        //            Console.WriteLine(string.Format("{0} : {1} - {2} : {3}", input[i], input[leftId], input[rightId], palin));
        //        }

        //        // check even length case - space is the center
        //        leftId = i - 1;
        //        rightId = i + 1;
        //        palin = FindPalindromeWithIndex(input, i, leftId, rightId);
        //        if (!string.IsNullOrEmpty(palin) && palin.Length > res.Length)
        //        {
        //            res = palin;
        //            Console.WriteLine(string.Format("{0} : {1} - {2} : {3}", input[i], input[leftId], input[rightId], palin));
        //        }
        //    }

        //    Console.WriteLine(input + ": " + res);

        //    return res;
        //}

        //private string FindPalindromeWithIndex(string input, int i, int leftId, int rightId)
        //{
        //    string palin = input[i].ToString();
        //    while (leftId >= 0 && rightId < input.Length)
        //    {
        //        if (input[leftId] != input[rightId])
        //            break;
        //        else
        //        {
        //            palin = input[leftId] + palin + input[rightId];
        //            //Console.WriteLine(palin);
        //            leftId--;
        //            rightId++;
        //        }
        //    }

        //    return palin;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolution
{
    public class LongestSubstring
    {
        // Longest Substring Without Repeating Characters
        // Given a string, find the length of the longest substring without repeating characters.
        //Examples:
        //Given "abcabcbb", the answer is "abc", which the length is 3.
        //Given "bbbbb", the answer is "b", with the length of 1.
        //Given "pwwkew", the answer is "wke", with the length of 3. 
        //       Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;

            int n = s.Length;
            string maxString = string.Empty;
            string currString = string.Empty;
            Dictionary<char, int> map = new Dictionary<char, int>();

            int maxlen = 0;
            int j = 0;
            int prevId = -1; // track last repeating pos
            map.Add(s[0], 0);
            int currLen = 1;

            for (j = 1; j < n; j++)
            {
                prevId = map.ContainsKey(s[j]) ? map[s[j]] : -1;
                if (prevId == -1 || prevId < j - currLen) // not repeating or outside of current range
                {
                    currLen++;
                    currString += s[j];
                    maxlen = maxlen > currLen ? maxlen : currLen;
                    maxString = maxlen > currLen ? maxString : currString;
                }
                else
                {
                    currLen = j - prevId;
                    currString = s.Substring(prevId, j - prevId);
                }

                if (map.ContainsKey(s[j]))
                {
                    map[s[j]] = j;
                }
                else
                {
                    map.Add(s[j], j);
                }
            }

            //make sure nothing missed
            maxlen = maxlen > currLen ? maxlen : currLen;
            maxString = maxlen > currLen ? maxString : currString;

            return maxlen;
        }
    }
}

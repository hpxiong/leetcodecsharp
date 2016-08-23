using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class LongestCommonPrefx
    {
        public string LongestCommonPrefixFunc(string[] strs)
        {
            string res = string.Empty;
            if (strs.Length == 0) return res;

            strs.OrderBy(s => s.Length);

            res = FindLCPrefixDP(strs);

            return res;
        }

        /// <summary>
        /// use dynamic programming
        /// solve smaller array first then merge the result
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string FindLCPrefixDP(string[] strs)
        {
            if (strs.Length == 1) return strs[0];

            string res = string.Empty;
            // order array based on length
            int mid = strs.Length / 2;
            
            var strsLeft = strs.Take(mid);
            var strsRight = strs.Skip(mid).Take(strs.Length - mid);

            string lcp_left = FindLCPrefixDP(strsLeft.ToArray());
            string lcp_right = FindLCPrefixDP(strsRight.ToArray());

            int n = lcp_left.Length <= lcp_right.Length ? lcp_left.Length : lcp_right.Length;
            for(int i=0; i< n; i++)
            {
                if (lcp_left[i] == lcp_right[i])
                {
                    res += lcp_left[i].ToString();
                }
                else
                {
                    break;
                }
            }
            
            return res;
        }

        public string FindLCPrefixOneByOne(string[] strs)
        {
            if (strs.Length == 1) return strs[0];

            string res = string.Empty;
            int n = strs[0].Length;
            foreach(string str in strs)
            {
                n = n >= str.Length ? str.Length : n;
            }

            bool breall = false;
            for(int i = 0; i< n; i++)
            {
                char c = strs[0][i];
                for(int j =1; j < strs.Length; j++)
                {
                    if (c != strs[j][i]) { breall = true; break; }
                }
                if (breall)
                    break;
                else
                    res += c.ToString(); 
            }


            return res;
        }

    }
}

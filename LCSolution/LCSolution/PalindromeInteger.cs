using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class PalindromeInteger
    {
        public bool IsPalindromeInteger(int x)
        {
            if (x < 0) return false;

            return IsPalindromeFunc2(x);            
        }

        public bool IsPalindromeFunc(int x)
        {   
            string xstr = x.ToString();
            if (xstr[0] == '-' || xstr[0] == '+') xstr = xstr.Substring(1, xstr.Length - 1);
            bool res = true;
            for (int i = 0; i < xstr.Length; i++)
            {
                if (xstr[i] != xstr[xstr.Length - i - 1])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        public bool IsPalindromeFunc2(int x)
        {
            if (x < 0) return false;

            int src = x;
            bool res = true;
            // 1234 -> ()234
            // 1234 -> 123()
            int range = 1;
            //find out number of bits
            while(x / range >= 10)
            {
                range *= 10;
            }

            while (x != 0 )
            {
                int last = x % 10;
                int first = x / range;
                if (last != first) { res = false; break; }                

                // get ()234
                x = (x % range);
                //get ()23()
                x = x / 10;
                //update range, 2 digits removed
                range = range / 100;                 
            }

            return res;
        }

    }
}

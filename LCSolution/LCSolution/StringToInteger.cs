using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class StringToInteger
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            str = str.Trim();

            int res = 0;
            char sign = '+';
            if (str[0] == '+' || str[0] == '-')
            {   
                sign = str[0];
                str = str.Substring(1, str.Length - 1);
            }
            str = str.TrimStart('0');

            int temp = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (IsNumeric(str[i]) != -1)
                {
                    if(sign == '-')
                        res = res * 10 - IsNumeric(str[i]);
                    else
                        res = res * 10 + IsNumeric(str[i]);
                } else { break; }

                if (temp != res / 10)
                {
                    if (sign == '-')
                    {
                        res = int.MinValue;
                        break;
                    }
                    else
                    {
                        res = int.MaxValue;
                        break;
                    }
                }
                temp = res;
            }

            return res;
        }

        public int IsNumeric(char c)
        {
            switch (c)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default: return -1;
            }
        }
    }
}

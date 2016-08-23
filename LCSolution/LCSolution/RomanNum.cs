using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class RomanNum
    {
        //Given an integer, convert it to a roman numeral.
        //Input is guaranteed to be within the range from 1 to 3999.
        public string IntToRoman(int num)
        {
            if (num == 0) return "";

            string res = string.Empty;
           
            int[] map = new int[13] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};

            //1. find the highest decimal value v in map that is less than or equal to the decimal number x
            //   and its corresponding roman numeral n
            // 2. Write the roman numeral n that you found and subtract its value v from x, x = x  -v
            // 3. Repeat stages 1 and 2 until you get zero result of x.

            while (num != 0)
            {
                int v = findv(num, map);
                res += findRC(v);
                num -= v;
            }
            return res;
        }

        private int findv(int num, int[] map)
        {
            int v = -1;
            for(int i = 0; i<map.Length; i++)
            {
                if(num >= map[i])
                {
                    v = map[i];
                }
                else
                {
                    break;
                }
            }

            return v;
        }

        public string findRC(int i)
        {
            //1   I
            //4   IV
            //5   V
            //9   IX
            //10  X
            //40  XL
            //50  L
            //90  XC
            //100 C
            //400 CD
            //500 D
            //900 CM
            //1000    M

            string res = "";
            switch (i)
            {
                case 1: res = "I"; break;
                case 4: res = "IV"; break;
                case 5: res = "V"; break;
                case 9: res = "IX"; break;
                case 10: res = "X"; break;
                case 40: res = "XL"; break;
                case 50: res = "L"; break;
                case 90: res = "XC"; break;
                case 100: res = "C"; break;
                case 400: res = "CD"; break;
                case 500: res = "D"; break;
                case 900: res = "CM"; break;
                case 1000: res = "M"; break;
            }

            return res;
        }


        public int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;
            int[] map = new int[13] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

            //1. find the highest decimal value v in map that is less than or equal to the decimal number x
            //   and its corresponding roman numeral n
            // 2. Write the roman numeral n that you found and subtract its value v from x, x = x  +v
            // 3. Repeat stages 1 and 2 until you get zero result of x.

            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int v = 0;

                if ( (i <s.Length - 1)  && (
                    (s[i] == 'I' && (s[i + 1] == 'V' || s[i + 1] == 'X')) ||
                    (s[i] == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C')) ||
                    (s[i] == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                    ))
                {
                    v = findRCInt(s[i].ToString() + s[i + 1].ToString());
                    i++;
                }
                else 
                {
                    v = findRCInt(s[i].ToString());
                }
                res += v;
            }            
            return res;
        }

        public int findRCInt(string c)
        {
            //1   I
            //4   IV
            //5   V
            //9   IX
            //10  X
            //40  XL
            //50  L
            //90  XC
            //100 C
            //400 CD
            //500 D
            //900 CM
            //1000    M

            int res = -1;
            switch (c)
            {
                case "IV": res = 4; break;
                case "IX": res = 9; break;
                case "XL": res = 40; break;
                case "XC": res = 90; break;
                case "CD": res = 400; break;
                case "CM": res = 900; break;

                case "I": res = 1; break;
                case "V": res = 5; break;                
                case "X": res = 10; break;                
                case "L": res = 50; break;                
                case "C": res = 100; break;                
                case "D": res = 500; break;                
                case "M": res = 1000; break;
            }

            return res;
        }
    }
}

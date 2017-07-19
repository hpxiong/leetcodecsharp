using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class StringToInteger : ILCSolutions
    {        
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            string input = "-120924";
            int res = Atoi(input);

            Console.WriteLine(res);
            Console.WriteLine();
        }
        private static int minDiv10 = Int32.MaxValue / 10;

        /// <summary>
        /// Question to ask: how ot handle special characters between the digits...
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private  int Atoi(string input)
        {
            int sign = 1;
            int i = 0;
            int n = input.Length;

            //Remove anything strange in front
            while (i < n && (input[i] != '+' && input[i] != '-' &&
                !Char.IsLetterOrDigit(input[i]))) i++;
            if (input[i] == '+')
            {
                sign = 1;
                i++;
            }
            else if (input[i] == '-')
            {
                sign = -1;
                i++;
            }

            int num = 0;
            for (; i < n; i++)
            {
                if (Char.IsLetterOrDigit(input[i]))
                {
                    //!! we cannot convert Char to Int ... have to convert to string first.
                    int digit = Convert.ToInt32(input[i].ToString());

                    //Check for overflow!!!
                    if (num > minDiv10 || (num == minDiv10 && digit >= 8))
                        return sign > 0 ? Int32.MaxValue : Int32.MinValue;
                    else
                        num = num * 10 + digit;

                }
            }

            return num * sign;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class RotateArray : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            List<int> input = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            int n = 5;

            Console.WriteLine(string.Join(", ", input.ToArray()) + " - rotate " + n);

            Console.WriteLine("Double reverse");
            RotateArr(input, n);
            Console.WriteLine(string.Join(", ", input.ToArray()));


            input = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("Adhoc");
            RotateArrAdhoc(ref input, n);
            Console.WriteLine(string.Join(", ", input.ToArray()));
            Console.WriteLine();
        }

        /// <summary>
        /// separate array into 2 parts, reverse each and then reverse all
        /// Time: O(n) Space: O(1)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private void RotateArr(List<int> input, int n)
        {
            if (input == null || input.Count == 0 || n == 0)
                return;

            int start = 0;
            int end = input.Count - n - 1;
            // reverse the front
            reverse(input, start, end);
            //rever the back
            reverse(input, end + 1, input.Count - 1);
            //reverse all
            reverse(input, 0, input.Count - 1);
        }

        private void reverse(List<int> input, int start, int end)
        {
            int i = start;
            int j = end;
            while (i < j)
            {
                var a = input[i];
                input[i] = input[j];
                input[j] = a;
                i++;
                j--;
            }
        }

        /// <summary>
        /// Adhoc reverse add to tmp array
        /// Time: O(n) Space: O(n)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="n"></param>
        private void RotateArrAdhoc(ref List<int> input, int n)
        {
            if (input == null || input.Count == 0 || n == 0)
                return;

            List<int> tmp = new List<int>();
            //From the position that elements need to be moved to front
            for (int i = input.Count - n; i < input.Count; i++)
            {
                tmp.Add(input[i]);
            }
            // from the position that elements need to be moved to the back
            for (int i = 0; i < input.Count - n; i++)
            {
                tmp.Add(input[i]);
            }
            input = tmp;
        }
    }
}

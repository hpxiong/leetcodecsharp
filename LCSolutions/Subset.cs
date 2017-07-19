using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class Subset : ILCSolutions
    {

        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            List<int> input = new List<int>() { 1, 2, 3 };

            List<string> res = new List<string>();
            List<string> tempres = new List<string>();

            // list must be sorted if there are duplicates
            input.Sort();
            Backtrack(input, res, tempres, 0);
            foreach (var r in res)
                Console.WriteLine(r);

            Console.WriteLine();
        }

        private void Backtrack(List<int> input, List<string> result, List<string> tmpresult, int start)
        {
            if (tmpresult.Count > 0)
                result.Add(string.Join(",", tmpresult.ToArray()));

            for (int i = start; i < input.Count; i++)
            {
                //skip duplicates
                if (i - 1 >= start && input[i] == input[i - 1])
                    continue;

                tmpresult.Add(input[i].ToString());
                Backtrack(input, result, tmpresult, i + 1);
                tmpresult.RemoveAt(tmpresult.Count - 1);
            }
        }
    }
}

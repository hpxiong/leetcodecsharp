using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class TwoSumClass : ILCSolutions
    {

        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            TwoSumClass ts = new TwoSumClass();

            ts.Add(1);
            ts.Add(2);
            ts.Add(3);

            int n = 4;

            var res = ts.Find(n);
            Console.WriteLine(n + " - " + res);

            n = 5;
            res = ts.Find(n);
            Console.WriteLine(n + " - " + res);


            ts.Add(2);
            ts.Add(5);
            ts.Add(4);
            ts.Add(5);

            n = 10;
            res = ts.Find(n);
            Console.WriteLine(n + " - " + res);
            Console.WriteLine();
        }


        public TwoSumClass()
        {
            Map = new Dictionary<int, int>();
        }

        public Dictionary<int, int> Map { get; set; }


        /// <summary>
        /// Time O(1) Space O(n)
        /// </summary>
        /// <param name="n"></param>
        public void Add(int n)
        {
            if (!Map.ContainsKey(n))
                Map.Add(n, 1);
            else
                Map[n] = Map[n] + 1;
        }


        /// <summary>
        /// Time O(1) Space O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Find(int n)
        {
            if (Map.Count == 0)
                return -1;
            foreach (var j in Map)
            {
                int delta = n - j.Key;
                if (Map.ContainsKey(delta))
                {
                    if (delta == j.Key)
                    {
                        if (Map[delta] > 1)
                            return delta;
                    }
                    else
                        return delta;
                }

            }

            return -1;

        }
    }
}

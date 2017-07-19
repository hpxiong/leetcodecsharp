using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class TwoSum : ILCSolutions
    {

        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            List<int> inputArray = new List<int>() { 1, 2, 3, 5, 6, 7, 4 };
            int sum = 10;

            Console.WriteLine("TwoSumHashMap");
            var res = TwoSumHashMap(inputArray, sum);
            if (res != null)
                foreach (var r in res)
                    Console.WriteLine(r);
            else
                Console.WriteLine("Not found!");


            Console.WriteLine("TwoSumBinarySearch");
            res = TwoSumBinarySearch(inputArray, sum);
            if (res != null)
                foreach (var r in res)
                    Console.WriteLine(r);
            else
                Console.WriteLine("Not found!");


            Console.WriteLine("TwoSumSlidingWindow");
            res = TwoSumSlidingWindow(inputArray, sum);
            if (res != null)
                foreach (var r in res)
                    Console.WriteLine(r);
            else
                Console.WriteLine("Not found!");



            Console.WriteLine("Done");

            Console.WriteLine();
        }
        /// <summary>
        /// Time: O(n) Space O(1)
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private List<string> TwoSumSlidingWindow(List<int> inputArray, int sum)
        {
            if (inputArray.Count == 0)
                return null;

            //Array must be sorted
            inputArray.Sort();

            List<string> res = new List<string>();
            int left = 0;
            int right = inputArray.Count - 1;
            while (left < right)
            {
                if (inputArray[left] + inputArray[right] > sum)
                    right--;
                else if (inputArray[left] + inputArray[right] < sum)
                {
                    left++;
                    right = inputArray.Count - 1;
                }
                else
                {
                    res.Add(inputArray[left] + ", " + inputArray[right]);
                    left++;
                    right = inputArray.Count - 1;
                }
            }

            return res;
        }


        /// <summary>
        /// Time: O(nlogn) Space: O(1)
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private List<string> TwoSumBinarySearch(List<int> inputArray, int sum)
        {
            if (inputArray.Count == 0)
                return null;

            //Array must be sorted
            inputArray.Sort();

            List<string> res = new List<string>();
            for (int i = 0; i < inputArray.Count; i++)
            {
                int v = inputArray[i];
                int delta = sum - v;
                if (delta != v)
                {
                    int match = BinarySearch(inputArray, delta, i);
                    if (match != -1)
                        res.Add(v + ", " + inputArray[match]);
                }
            }

            return res;
        }

        private int BinarySearch(List<int> inputArray, int delta, int start)
        {
            int left = start;

            // index is important for calculating the mid
            int right = inputArray.Count();
            int mid = -1;
            int res = -1;

            while (left < right)
            {
                mid = left + (right - left) / 2;
                if (delta > inputArray[mid])
                    left = mid + 1;
                else if (delta < inputArray[mid])
                    // index does not need to  -1 ...??
                    right = mid;
                else
                    return mid;
            }
            return res;
        }

        /// <summary>
        /// implement the method based on hash map
        /// Time: O(1) Space: O(n)
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private List<string> TwoSumHashMap(List<int> inputArray, int sum)
        {
            if (inputArray.Count == 0)
                return null;

            Dictionary<int, int> map = new Dictionary<int, int>();
            //for (int i=0; i<inputArray.Count; i++)
            //{
            //    var val = inputArray[i];
            //    if (!map.ContainsKey(val))
            //        map.Add(val, i);
            //}

            List<string> res = new List<string>();
            for (int i = 0; i < inputArray.Count; i++)
            {
                var val = inputArray[i];
                var delta = sum - val;
                if (map.ContainsKey(delta) && delta != val)
                    res.Add(val + "," + delta);
                map.Add(val, i);
            }
            return res;
        }
    }
}

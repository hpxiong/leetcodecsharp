using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolution
{
    public class MedianOfSortedArray
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0)
            {
                return -1;
            }
            double res;
            int mid = -1;
            int rem = -1;
            if (nums1.Length == 0 && nums2.Length > 0 || nums2.Length == 0 && nums1.Length > 0)
            {
                var brr = nums1.Length == 0 ? nums2 : nums1;
                rem = -1;
                mid = Math.DivRem(brr.Length, 2, out rem);
                res = rem > 0 ? brr[mid] : (double)(brr[mid] + brr[mid - 1]) / 2;
                return res;
            }

            var arr = nums1.Length > nums2.Length ? nums1 : nums2;
            List<int> final = new List<int>();
            int last = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int a = i < nums1.Length ? nums1[i] : -1;
                int b = i < nums2.Length ? nums2[i] : -1;
                if (a < b)
                {
                    if (a != -1) ListAdd(final, a);
                    if (b != -1) ListAdd(final, b);
                    last = b != -1 ? b : a;
                }
                else
                {
                    if (b != -1) ListAdd(final, b);
                    if (a != -1) ListAdd(final, a);
                    last = a != -1 ? a : b;
                }
            }
            mid = Math.DivRem(final.Count, 2, out rem);
            res = rem > 0 ? final[mid] : (double)(final[mid] + final[mid - 1]) / 2;

            return res;
        }


        private void ListAdd(List<int> final, int a)
        {
            if (final.Count == 0 || final[final.Count - 1] < a)
            {
                final.Add(a);
            }
            else if (final.Count > 0 || final[final.Count - 1] > a)
            {
                final.Add(a); SwapLast(final);
            }
        }

        // swap last element
        private void SwapLast(List<int> final)
        {
            int n = final.Count;
            for (int i = n - 1; i > 0; i--)
            {
                if (final[i] < final[i - 1])
                {
                    int tmp = final[i];
                    final[i] = final[i - 1];
                    final[i - 1] = tmp;
                }
                else
                {
                    break;
                }
            }
        }

    }
}

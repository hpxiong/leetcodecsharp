using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class FindMedianSortedArrays
    {
        #region find media of two sorted array

        public double FindMedianSortedArraysWrapper(int[] nums1, int[] nums2)
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
                rem = brr.Length % 2;
                mid = brr.Length / 2;
                res = rem > 0 ? brr[mid] : (double)(brr[mid] + brr[mid - 1]) / 2;
                return res;
            }


            // List<int> final = SimpleMerge(nums1, nums2);
            List<int> final = LinearMerge(nums1, nums2);

            rem = final.Count % 2;
            mid = (int)final.Count / 2;
            res = rem > 0 ? final[mid] : (double)(final[mid] + final[mid - 1]) / 2;

            return res;
        }

        private List<int> LinearMerge(int[] arr1, int[] arr2)
        {   
            List<int> final = new List<int>();

            int i = 0;
            int j = 0;
            
            for (int k = 0; k < arr1.Length + arr2.Length; k++)
            {
                int curr = -1;

                if (i == arr1.Length)
                {
                    curr = arr2[j++];
                }else if(j == arr2.Length)
                {
                    curr = arr1[i++];
                }else if(arr1[i] <= arr2[j])
                {
                    curr = arr1[i++];
                }
                else
                {
                    curr  = arr2[j++];
                }
                final.Add(curr);
            }

            return final;
        }

        private List<int> LinearMerge2(int[] arr1, int[] arr2)
        {
            List<int> final = new List<int>();

            int i = 0;
            int j = 0;
            int k = 0;

            while(i<arr1.Length && j < arr2.Length)
            {
                int curr = arr1[i] <= arr2[j] ? arr1[i++] : arr2[j++];
                final.Add(curr);
                k++;
            }

            while (i < arr1.Length)
            {
                final.Add(arr1[i++]);
            }

            while (j < arr2.Length)
            {
                final.Add(arr2[j++]);
            }
            
            return final;
        }


        /// <summary>
        /// Simple way that merge the array fron i to j one by one
        /// O(n*m)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private List<int> SimpleMerge(int[] arr1, int[] arr2)
        {
            var arr = arr1.Length > arr2.Length ? arr1 : arr2;
            List<int> final = new List<int>();
            int last = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int a = i < arr1.Length ? arr1[i] : -1;
                int b = i < arr2.Length ? arr2[i] : -1;
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
            return final;
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
                    break; // stop when sorted order is met
                }
            }
        }

        #endregion
    }
}

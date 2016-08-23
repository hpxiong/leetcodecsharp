using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class WaterContainer
    {
        public int MaxArea(int[] height)
        {
            int N = height.Length;

            int mid = N / 2;
            int area = 0;

            int i = 0;
            int j = N - 1;
            int currHeight = 0;
            int currArea = 0;
            while (i < j)
            {
                currHeight = height[i] <= height[j] ? height[i] : height[j];
                currArea = currHeight * (j - i);
                area = area >= currArea ? area : currArea;
                //decide move left or move right pointer
                if (height[i] <= height[j]) { i++;}
                else { j--; }                
            }

            return area;
        }
    }
}

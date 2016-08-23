using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class ReverseInteger
    {
        public int ReverseInt(int x)
        {
            bool isnegative = x < 0;

            if (isnegative) x = x * -1;

            int y = 0;
            int ycopy = 0;

            while (x!=0)
            {
                ycopy = ycopy * 10 + (x % 10);
                // important! check overflow 
                if (y != ycopy / 10) { y = 0; break; } else { y = ycopy; }
                
                x = (int) x / 10;
            }
            if (isnegative) y = y * -1;

            return y;
        }
    }
}

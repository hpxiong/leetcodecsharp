using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class myarray
    {
        public int row { get; set; }
        public int col { get; set; }
        public char val { get; set; }
    }
    public class ZigZag
    {
        public string ZigZagConvert(string str, int numRows)
        {
            int numStaggerNodes = numRows - 2;
            int i = 0;
            List<myarray> arr = new List<myarray>();
            int row = 0;
            int col = 0;
            while (i < str.Length)
            {
                col = 0;
                for (int k = 0; k < numRows; k++)
                {
                    if (i < str.Length)
                    {
                        arr.Add(new myarray() { row = row, col = col, val = str[i] });
                        col++;
                        Debug.Write(str[i] + " ");
                        i++;
                    }
                    else { break; }
                }
                row++;
                Debug.WriteLine("");

                for (int y = 0; y < numStaggerNodes; y++)
                {
                    if (i < str.Length)
                    {
                        col = 0;
                        for (int k = numRows - 1; k >= 0; k--)
                        {
                            if (k == y + 1)
                            {
                                arr.Add(new myarray() { row = row, col = col, val = str[i] });
                                Debug.Write(str[i] + " ");
                                i++;
                            }
                            else
                            {
                                //arr.Add(new myarray() { row = row, col = col, val = ' ' });
                                Debug.Write("  ");
                            }
                            col++;
                        }
                        row++;
                        Debug.WriteLine("");
                    }
                    else { break; }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int q = 0; q < numRows; q++)
            {
                for (int p = 0; p < row; p++)
                {
                    var obj = arr.Where(s => s.row == p && s.col == q).FirstOrDefault();
                    if (obj != null) sb.Append(obj.val);
                }
            }
            string res = sb.ToString();
            return res;
        }


        public string ZigZagConvert2(string s, int numRows)
        {
            string res = string.Empty;

            if (s.Length == 0 || numRows < 2) return s;

            int numStaggerNodes = numRows - 2;
            char[] arr = new char[s.Length]; 
            int arrj = 0;           

            for (int r = 0; r < numRows; r++)
            {
                int p = r;
                if(r == 0 || r == numRows - 1)
                {
                    // first and last row, no stagger nodes
                    while (p < s.Length)
                    {
                        arr[arrj++] = s[p];
                        p += numRows + numStaggerNodes;
                    }
                }
                else
                {
                    int g = numRows + numStaggerNodes - r;
                    // middle rows with stagger nodes
                    while (p<s.Length || g < s.Length)
                    {
                        if (p < s.Length)
                        {                         
                            // pick normal nodes
                            arr[arrj++] = s[p];
                            p += numRows + numStaggerNodes;
                        }

                        if(g < s.Length)
                        {
                            // pick stagger nodes
                            arr[arrj++] = s[g];
                            g += numRows + numStaggerNodes;
                        }
                    }

                }
            }

            res = new string(arr);
            return res;
        }
    }
}

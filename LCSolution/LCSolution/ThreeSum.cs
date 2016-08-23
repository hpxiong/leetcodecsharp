using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class ThreeSum
    {
        public List<List<int>> ThreeSumFunc(int[] nums)
        {
            List<List<int>> res = new List<List<int>>();

            if (nums.Length == 0) return res;

            res = BrutalForce(nums);

            return res;
        }

        public List<List<int>> ThreeSumReduce(int[] nums)
        {
            List<List<int>> res = new List<List<int>>();
           
            Array.Sort(nums);

            Dictionary<int, List<int>> valMap = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> bb = null;
                if (valMap.TryGetValue(nums[i], out bb))
                {
                    valMap[nums[i]].Add(i);
                }
                else
                {
                    valMap[nums[i]] = new List<int>() { i };
                }
            }


            //List<string> strlist = new List<string>();
            Dictionary<string, int> strlist = new Dictionary<string, int>();
            for(int i=0; i< nums.Length; i++)
            {
                int twosum = 0 - nums[i];
                // reduce to twosum problem
                //for(int j = 0; (j < nums.Length - 1) && (j != i) ; j++)
                for (int j = i+1; (j < nums.Length - 1); j++)
                {
                    int rem = twosum - nums[j];
                    if (valMap.ContainsKey(rem))
                    {
                        foreach(var k in valMap[rem])
                        {
                            if(k!= i && k!= j)
                            {
                                string str = string.Empty;
                                List<int> sl = new List<int>();
                                if (k > j) {
                                    str = nums[i] + "," + nums[j] + "," + nums[k];
                                    sl = new List<int>() { nums[i], nums[j], nums[k] };
                                }
                                else if (k > i && k < j)
                                {
                                    str = nums[i] + "," + nums[k] + "," + nums[j];
                                    sl = new List<int>() { nums[i], nums[k], nums[j] };
                                }   
                                else if (k < i)
                                {
                                    str = nums[k] + "," + nums[i] + "," + nums[j];
                                    sl = new List<int>() { nums[k], nums[i], nums[j] };
                                }
                                    
                                if (!strlist.ContainsKey(str))
                                {
                                    strlist[str] = 1;
                                    res.Add(sl);
                                }
                            }
                        }
                    }
                }
            }

            
            return res;
        }

        public List<List<int>> BrutalForce(int[] nums)
        {
            List<List<int>> res = new List<List<int>>();

            Array.Sort(nums);

            Dictionary<int, List<int>> valMap = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> bb = null;
                if (valMap.TryGetValue(nums[i], out bb))
                {
                    valMap[nums[i]].Add(i);
                }
                else
                {
                    valMap[nums[i]] = new List<int>() { i };
                }
            }

            Dictionary<int, List<List<int>>> sumMap = new Dictionary<int, List<List<int>>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    int sum = 0 - (nums[i] + nums[j]);
                    List<List<int>> aa = null;
                    if (sumMap.TryGetValue(sum, out aa))
                    {
                        sumMap[sum].Add(new List<int>() { i, j });
                    }
                    else
                    {
                        sumMap[sum] = new List<List<int>>() { new List<int>() { i, j } };
                    }
                }
            }

            if (sumMap.Count > 0)
            {
                List<string> strRes = new List<string>();
                foreach (var mp in sumMap)
                {
                    if (valMap.ContainsKey(mp.Key))
                    {
                        foreach (var m in mp.Value)
                        {
                            foreach (var pos in valMap[mp.Key])
                            {
                                if (!m.Contains(pos))
                                {
                                    List<int> list = new List<int>();
                                    foreach (var p in m)
                                    {
                                        list.Add(nums[p]);
                                    }
                                    list.Add(nums[pos]);
                                    list.Sort();
                                    string str = String.Join(",", list);
                                    if (!strRes.Contains(str))
                                    {
                                        strRes.Add(str);
                                    }
                                }
                            }
                        }
                    }
                }

                if (strRes.Count > 0)
                {
                    foreach (string str in strRes)
                    {
                        res.Add(str.Split(',').Select(s => Convert.ToInt32(s)).ToList());
                    }
                }

            }

            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class point
    {
        public char key { get; set; }
        public List<int> positions { get; set; }
        //public int start { get; set; }
        //public int end { get; set; }
        //public int dist { get { return end - start;  } }

    }
    public class LongestPalindrome
    {
        public string LongestPalindromeWrapper(string s)
        {
            if (s.Length == 0 || s.Length == 1) return s;

            string maxstr = string.Empty;
            // maxstr = FindPalindrome1(s);
            maxstr = FindPalindrome3(s);

            return maxstr;
        }

        private string FindPalindrome2(string s)
        {
            string maxstr = string.Empty;

            Dictionary<char, string> cords = new Dictionary<char, string>();
            string curr = string.Empty;
            char maxchar = '$';
            int maxstartpos = -1;
            int maxendpos = -1;
            int maxlen = -1;

            List<int> pos = new List<int>();
            for (int j = 0; j < s.Length; j++)
            {
                string strval = string.Empty;
                if (cords.TryGetValue(s[j], out strval))
                {
                    if (cords[s[j]].IndexOf(';') != -1)
                    {
                        pos = cords[s[j]].Split(';').Select(g => Convert.ToInt32(g)).ToList();
                    }
                    else
                    {
                        pos = new List<int>() { Convert.ToInt32( cords[s[j]]) };
                    }
                    
                    int start = -1;
                    int end = j;

                    for (int k = 0; k < pos.Count; k++)
                    {
                        start = pos[k];
                        curr = s.Substring(start, end - start + 1);
                        if (curr.Length > maxlen)
                        {
                            if (IsPalindromeString(curr))
                            {
                                if (curr.Length >= maxstr.Length)
                                {
                                    maxstr = curr;
                                    maxchar = s[j];
                                    maxstartpos = start;
                                    maxendpos = end;
                                    maxlen = maxstr.Length;
                                }
                                break; // no need check further, the current one is the longest one
                            }
                        }
                    }

                    cords[s[j]] += ";" + j;
                }
                else { cords[s[j]] = j.ToString(); }
            }

            return maxstr;
        }

        private string FindPalindrome1(string s)
        {
            string maxstr = string.Empty;
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add(s[0], 0);
            string substr = string.Empty;
            int i = 1;
            for (i = 1; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map.Add(s[i], i);
                }
                else
                {
                    //TODO: recusive check to the begining of the repeat....
                    // need to expand front and end

                    // map has the key
                    // check if the substring is a palindrome
                    substr = s.Substring(map[s[i]], i - map[s[i]] + 1);
                    if (IsPalindromeString(substr))
                    {
                        maxstr = maxstr.Length >= substr.Length ? maxstr : substr;
                    }
                }
            }
            return maxstr;
        }

        public bool IsPalindromeString(string substr)
        {
            bool res = true;
            if (substr.Length < 2) return true;

            for(int i=0; i< substr.Length; i++)
            {
                if(substr[i] != substr[substr.Length - i - 1])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        private string FindPalindrome3(string s)
        {
            s = s.ToLower();
            string maxstr = string.Empty;
            Dictionary<char, string> cords = new Dictionary<char, string>();
            string curr = string.Empty;

            int maxlen = -1;

            string strval = string.Empty;
            for (int j = 0; j < s.Length; j++)
            {   
                if (cords.TryGetValue(s[j], out strval)) { cords[s[j]] += ";" + j;}
                else { cords[s[j]] = j.ToString(); }
            }

            if (cords.Count > 0)
            {
                List<int> pos = new List<int>();
                int start = -1;
                int end = -1;

                Dictionary<string, int> distMap = new Dictionary<string, int>();

                foreach (var cord in cords)
                {
                    if (cord.Value.IndexOf(";") != -1)
                    {
                        distMap = new Dictionary<string, int>();
                        pos = cord.Value.Split(';').Select(g => Convert.ToInt32(g)).ToList();

                        for (int k = 0; k < pos.Count; k++)
                        {
                            for (int l = pos.Count - 1; l > k; l--)
                            {
                                distMap.Add(pos[k] + "-" + pos[l], pos[l] - pos[k] + 1);
                            }
                        }

                        var distMapSorted = distMap.OrderByDescending(g => g.Value);
                        foreach (var h in distMapSorted)
                        {
                            if (h.Value > maxlen)
                            {
                                var co = h.Key.Split('-');
                                start = Convert.ToInt32(co[0]);
                                end = Convert.ToInt32(co[1]);
                                curr = s.Substring(start, end - start + 1);
                                if (IsPalindromeString(curr))
                                {
                                    if (curr.Length >= maxstr.Length)
                                    {
                                        maxstr = curr;
                                        maxlen = maxstr.Length;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            return maxstr;
        }
        private string FindPalindrome4(string s)
        {
            s = s.ToLower();
            string maxstr = string.Empty;
            int maxlen = -1;
            string curr = string.Empty;

            List<point> cords = new List<point>();
            Dictionary<char, List<int>> mycords = new Dictionary<char, List<int>>();
            for (int j = 0; j < s.Length; j++)
            {
                if (cords.Where(g => g.key == s[j]).Count() > 0)
                {
                    cords.Where(g => g.key == s[j]).FirstOrDefault().positions.Add(j);
                }
                else
                {
                    cords.Add(new point() { key = s[j], positions = new List<int>() { j } });
                }

                if (mycords.ContainsKey(s[j]))
                {
                    mycords[s[j]].Add(j);
                }
                else
                {
                    mycords.Add(s[j], new List<int>() { j });
                }
            }

            if (cords.Count > 0)
            {
                List<int> pos = new List<int>();
                int start = -1;
                int end = -1;

                Dictionary<string, int> distMap = new Dictionary<string, int>();

                foreach (var cord in mycords)
                {
                    if (cord.Value.Count > 1)
                    {
                        distMap = new Dictionary<string, int>();
                        //pos = cord.Value.Split(';').Select(g => Convert.ToInt32(g)).ToList();

                        for (int k = 0; k < pos.Count; k++)
                        {
                            for (int l = pos.Count - 1; l > k; l--)
                            {
                                distMap.Add(pos[k] + "-" + pos[l], pos[l] - pos[k] + 1);
                            }
                        }

                        var distMapSorted = distMap.OrderByDescending(g => g.Value);
                        foreach (var h in distMapSorted)
                        {
                            if (h.Value > maxlen)
                            {
                                var co = h.Key.Split('-');
                                start = Convert.ToInt32(co[0]);
                                end = Convert.ToInt32(co[1]);
                                curr = s.Substring(start, end - start + 1);
                                if (IsPalindromeString(curr))
                                {
                                    if (curr.Length >= maxstr.Length)
                                    {
                                        maxstr = curr;
                                        maxlen = maxstr.Length;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            return maxstr;
        }
    }
}

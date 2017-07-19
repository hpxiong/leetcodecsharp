using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class AnagramInString : ILCSolutions
    {
        
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            string baseString = "cbaebabacbadbbacccbba";
            string token = "abc";

            var results = FindAnagram(baseString, token);

            Console.WriteLine(string.Join(", ", results.ToArray()));
            Console.WriteLine();           
        }

        private List<int> FindAnagram(string baseString, string token)
        {
            if (string.IsNullOrEmpty(baseString) || string.IsNullOrEmpty(token))
                return null;

            List<string> res = new List<string>();
            bool findId = false;
            List<int> index = new List<int>();

            var tokenSort = token.ToArray().OrderBy(s => s.ToString());

            for (int i = 0; i < baseString.Length; i++)
            {
                findId = false;
                
                
                // !! handle when remaining of the string is less than the token
                // token is sorted so the matching is relatively easier
                if (tokenSort.Contains(baseString[i]) && (baseString.Length - 1 - i >= token.Length))
                {
                    var substring = baseString.Substring(i, token.Length).ToArray().OrderBy(s => s.ToString());
                    findId = tokenSort.SequenceEqual(substring);
                }

                if (findId)
                {
                    res.Add(baseString.Substring(i, token.Length));
                    index.Add(i);
                }
            }

#if DEBUG
            if (res.Count > 0)
                foreach (var r in res)
                    Console.WriteLine(r);
#endif
            return index;
        }
    }

}

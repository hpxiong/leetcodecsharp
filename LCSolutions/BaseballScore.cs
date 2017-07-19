using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class BaseballScore : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            string input = "5, -2, 4, z, x, 9, +, +";

            var scores = FindScore(input);

            Console.WriteLine(input + ": " + scores.Sum());
            Console.WriteLine(string.Join(", ", scores.ToArray()));
            Console.WriteLine();
        }

        private List<int> FindScore(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            var tokens = input.Split(',').Select(s => s.Trim());
            List<int> score = new List<int>();
            int d = -1;
            foreach (var token in tokens)
            {

                if (int.TryParse(token, out d))
                {
                    score.Add(d);
                }
                else if (token == "z")
                {
                    // remove last score
                    if (score.Count > 0)
                    {
                        score.RemoveAt(score.Count - 1);
                    }
                }
                else if (token == "x")
                {
                    //double last
                    if (score.Count > 0)
                        score.Add(score[score.Count - 1] * 2);
                }
                else if (token == "+")
                {
                    if (score.Count > 1)
                        score.Add(score[score.Count - 1] + score[score.Count - 2]);
                }
                else
                {
                    throw new ArgumentException("Bad token: " + token);
                }
            }

            return score;
        }
    }
}

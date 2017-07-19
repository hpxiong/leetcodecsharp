using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class PlusOne : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);

            Console.WriteLine("Add " + 1);
            List<int> inputs = new List<int>() { 3, 4, 9, 7, 2 };
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            ArrayPlusOne(inputs);
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            Console.WriteLine();

            inputs = new List<int>() { 3, 4, 9, 7, 9 };
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            ArrayPlusOne(inputs);
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            Console.WriteLine();

            inputs = new List<int>() { 9, 9, 9, 9, 9 };
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            ArrayPlusOne(inputs);
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            Console.WriteLine();


            int n = 2;
            Console.WriteLine("Add " + n);
            inputs = new List<int>() { 3, 4, 9, 7, 2 };
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            ArrayPlusN(inputs, n);
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            Console.WriteLine();

            inputs = new List<int>() { 3, 4, 9, 7, 9 };
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            ArrayPlusN(inputs, n);
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            Console.WriteLine();

            inputs = new List<int>() { 9, 8, 9, 8, 9 };
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            ArrayPlusN(inputs, n);
            Console.WriteLine(string.Join(",", inputs.ToArray()));
            Console.WriteLine();

        }

        private void ArrayPlusOne(List<int> inputs)
        {
            for (int i = inputs.Count - 1; i >= 0; i--)
            {
                if (inputs[i] < 9)
                {
                    // Return is the key here
                    // if element is less than 9, 
                    // then plus one we are done
                    inputs[i]++;
                    return;
                }
                else
                {
                    // any elements that is 9, it becomes 0
                    // then the up stream element will get to plus 1
                    inputs[i] = 0;
                }
            }

            // if code never hit return inside the for loop
            // we know all elements are 9
            // then we need to increase one more digit
            inputs.Insert(0, 1);
        }

        // plus N is much trickier...
        private void ArrayPlusN(List<int> inputs, int n)
        {
            // can't handle 
            if (n > 10)
                return;

            for (int i = inputs.Count - 1; i >= 0; i--)
            {
                // Check first element, sum less than 10
                if (i == inputs.Count - 1 && inputs[i] < (10 - n))
                {
                    // Return is the key here
                    // if element is less than 9, 
                    // then plus one we are done
                    inputs[i] += n;
                    return;
                }
                // check rest element sum less than 10
                else if (i < inputs.Count - 1 && inputs[i] < 9)
                {
                    inputs[i]++;
                    return;
                }
                else
                {
                    // if sum is > 10, decide value to update for 1st element and the rest

                    // any elements that is 9, it becomes 0
                    // then the up stream element will get to plus 1
                    if (i == inputs.Count - 1)
                        inputs[i] = 9 + n - 10;
                    else
                        inputs[i] = 0;
                }
            }

            // if code never hit return inside the for loop
            // we know all elements are 9
            // then we need to increase one more digit
            inputs.Insert(0, 1);
        }
    }
}

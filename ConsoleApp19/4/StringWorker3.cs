using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19._4
{
    internal class StringWorker3
    {
        static char FindFNRL(string input)
        {
            Dictionary<char, int> letterCount = new Dictionary<char, int>();
            foreach (char c in input.ToLower())
            {
                if (letterCount.ContainsKey(c))
                {
                    letterCount[c]++;
                }
                else
                {
                    letterCount[c] = 1;
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (letterCount[char.ToLower(input[i])] == 1)
                {
                    return input[i];
                }
            }
            return '\0'; 
        }
    }
}

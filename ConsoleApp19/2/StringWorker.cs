using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19._2
{
    public class StringWorker
    {
        public static void CountLetters(string input)
        {
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            foreach(char c in input)
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

            foreach (KeyValuePair<char, int> kvp in letterCount)
            {
                Console.WriteLine($"{kvp.Key}:{kvp.Value}");
            }
        }
    }
}

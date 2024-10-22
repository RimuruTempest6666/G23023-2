using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class StringWorker4
    {
        static string ToCamelCase(string input)
        {
            string[] words = input.ToLower().Split(' ');
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i]);
            }
            return String.Join("", words);
        }
    }
}

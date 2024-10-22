using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19._3
{
    internal class StringWorker2
    {
        static int FindOddOccurrence(int[] arr)
        {
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (countMap.ContainsKey(i))
                {
                    countMap[i]++;
                }
                else
                {
                    countMap[i] = 1;
                }
            }
            foreach (KeyValuePair<int, int> kvp in countMap)
            {
                if (kvp.Value % 2 != 0)
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }
}

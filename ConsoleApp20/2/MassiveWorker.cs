using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._2
{
    internal class MassiveWorker
    {
        public static int UniqueCount(int[] arr)
        {
            Dictionary<int, int> elementCount = new Dictionary<int, int>();

            foreach(int i in arr)
            {
                if (elementCount.ContainsKey(i))
                {
                    elementCount[i]++;
                }
                else
                {
                    elementCount[i] = 1;
                }
            }

            int[] uniqueElements = new int[elementCount.Keys.Count];
            elementCount.Keys.CopyTo(uniqueElements, 0);

            return uniqueElements.Length;
        }
    }
}

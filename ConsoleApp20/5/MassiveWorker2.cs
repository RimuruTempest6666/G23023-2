using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._5
{
    internal class MassiveWorker2
    {
        public static void Reverse(ref List<int> arr)
        {
            int i = 0;
            int j = arr.Count - 1;

            while(i < j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp; 
                i++; j--;
            }
        }
    }
}

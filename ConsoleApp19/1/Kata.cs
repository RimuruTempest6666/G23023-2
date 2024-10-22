using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19._1
{
    public static class Kata
    {
        public static void MoveZeroes(int[] arr)
        {
            int nonZeroIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[nonZeroIndex] = arr[i];
                    nonZeroIndex++;
                }
            }
            for (int i = nonZeroIndex; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            Console.WriteLine(string.Join(", ", arr));
        }

 



    }
}

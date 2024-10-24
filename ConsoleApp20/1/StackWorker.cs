using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._1
{
    internal class StackWorker
    {
        public static int[] RightFinder(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= arr[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    result[i] = stack.Peek();
                }
                else
                {
                    result[i] = -1;
                }

                stack.Push(arr[i]);
            }
            return result;
        }
    }
}

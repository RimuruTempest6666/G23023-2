using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._4
{
    internal class StackWorker2
    {
        static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char c2 = stack.Pop();
                    if ((c == ')' && c2 == '(') ||
                        (c == ']' && c2 == '[') ||
                        (c == '}' && c2 == '{'))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}

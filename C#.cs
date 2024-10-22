using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main()
        {
            string strr = Console.ReadLine()
            Char[] chars = strr.ToCharArray(0, str.Length);

            bool IsPalindrome = IsPalindrome(strr);

            static bool IsPalindrome(string str)
            {
                int left = 0;
                int right = str.Length - 1;

                while (left < right)
                {
                    if (str[left] != str[right])
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
            }

            Console.WriteLine(IsPalindrome);

        }
    
        
    }
}
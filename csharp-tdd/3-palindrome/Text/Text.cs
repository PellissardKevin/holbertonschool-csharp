using System;
using System.Text.RegularExpressions;

namespace Text
{
    public class Str
    {
        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            string cleanString = Regex.Replace(s.ToLower(), @"[^a-z0-9]", "");
            
            int left = 0;
            int right = cleanString.Length - 1;
            while (left < right)
            {
                if (cleanString[left] != cleanString[right])
                {
                    return false; // Not a palindrome
                }
                left++;
                right--;
            }
            return true;
        }
    }
}

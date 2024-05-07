using System;

namespace Text
{
    public class Str
    {
        public static int CamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int nbWord = 1;

            foreach (char c in s)
            {
                if (char.IsUpper(c))
                {
                    if (s.IndexOf(c) != 0)
                    {
                        nbWord++;
                    }
                }
            }

            return nbWord;
        }
    }
}

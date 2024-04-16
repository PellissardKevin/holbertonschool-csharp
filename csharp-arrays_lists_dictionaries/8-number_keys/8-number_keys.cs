using System;
using System.Collections.Generic;

class Dictionary
{
    public static int NumberOfKeys(Dictionary<string, string> myDict)
    {
        int i = 0;
        foreach (var item in myDict)
        {
            i++;
        }

        return i;
    }
}


using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        int save = 0;
        string name = null;

        foreach (var item in myList)
        {
            if (item.Value == "None" || item.Value > save)
            {
                save = item.Value;
                name = item.Key;
            }
        }

        return name;
    }
}


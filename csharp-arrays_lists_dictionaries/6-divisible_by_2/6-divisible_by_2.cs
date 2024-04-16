using System;
using System.Collections.Generic;

class List
{
    public static List<bool> DivisibleBy2(List<int> myList)
    {
        List<bool> newList = new List<bool>();
        foreach (int num in myList)
        {
            if (num % 2 == 0)
                newList.Add(true);
            else
                newList.Add(false);
        }

        return newList;
    }
}

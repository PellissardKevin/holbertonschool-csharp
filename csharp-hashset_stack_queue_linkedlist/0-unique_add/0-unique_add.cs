using System;
using System.Collections.Generic;


class List
{
    public static int Sum(List<int> myList)
    {
        int Sum = 0;
        var unique_items = new HashSet<int>(myList);
        foreach (int item in unique_items)
        {
            Sum += item;
        }

        return Sum;
    }
}


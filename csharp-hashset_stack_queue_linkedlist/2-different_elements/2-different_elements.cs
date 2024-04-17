using System;
using System.Collections.Generic;

class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        list1.Sort();
        list2.Sort();

        List<int> differentElements = new List<int>();

        int i = 0, j = 0;

        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] < list2[j])
            {
                differentElements.Add(list1[i]);
                i++;
            }
            else if (list1[i] > list2[j])
            {
                differentElements.Add(list2[i]);
                j++;
            }
            else
            {
                i++;
                j++;
            }
        }

        while (i < list1.Count)
        {
            differentElements.Add(list1[i]);
            i++;
        }

        while (j < list2.Count)
        {
            differentElements.Add(list2[j]);
            j++;
        }

        return differentElements;
    }
}

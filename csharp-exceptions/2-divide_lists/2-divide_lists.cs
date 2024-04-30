using System;
using System.Collections.Generic;

class List
{
    public static List<int> Divide(List<int> list1, List<int> list2, int listLength)
    {
        List<int> result = new List<int>();
        var i = 0;

        while (i < listLength)
        {
            try
            {
                result.Add(list1[i] / list2[i]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Out of range");
            }
            catch (DivideByZeroException)
            {
                result.Add(0);
                Console.WriteLine("Cannot divide by zero");
            }
            i++;
        }

        return result;
    }
}

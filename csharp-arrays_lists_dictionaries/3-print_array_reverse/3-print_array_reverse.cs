using System;

class Array
{
    public static void Reverse(int[] array)
    {
        if (array != null && array.Length != 0)
        {
            int[] result = new int[array.Length];
            for (int i = array.Length - 1, j = 0; i >= 0; i--, j++)
            {
                result[j] = array[i];
            }
            Console.WriteLine(string.Join(" ", result)); ;
        }
        else
            Console.WriteLine();

    }
}

using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 5; k++)
            {
                if (k == 4)
                {
                    Console.Write("0");
                }
                else if (i == 2 && k == 2)
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
            Console.WriteLine();
        }
    }
}

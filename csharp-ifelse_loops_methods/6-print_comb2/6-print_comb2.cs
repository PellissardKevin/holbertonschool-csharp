using System;

namespace _6_print_comb2
{
    class Program
    {
        static void Main(string[] args)
        {
            int printed = 0;
            for (int i = 0; i <= 8; i++)
                for (int j = i + 1; j <= 9; j++)
                {
                    if (printed > 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write($"{i}{j}");
                    printed++;
                }

                Console.WriteLine();
        }
    }
}

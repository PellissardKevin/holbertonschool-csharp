using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        int lastDigit = number % (10);

        Console.Write("The last digit of {0}", number);
        if (lastDigit > 5)
            Console.WriteLine(" is {0} and is greater than 5", lastDigit);
        else if (lastDigit < 6 && lastDigit != 0)
            Console.WriteLine(" is {0} and is less than 6 and not 0", lastDigit);
        else if (lastDigit == 0)
            Console.WriteLine(" is {0} and is 0", lastDigit);
    }
}

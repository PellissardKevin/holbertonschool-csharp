using System;

class Program
{
	static void Main(string[] args)
	{
		double percent = .7553;
		double currency = 98765.4321;
		Console.WriteLine($"Percent: {percent:P2}");

		Console.WriteLine($"Currency: {currency:C}");
	}
}

using System;

class Program
{
	static void Main(string[] args)
	{
		string str = "Holberton School";

		string repeatedStr = $"{str}{str}{str}";

		Console.WriteLine(repeatedStr);

		Console.WriteLine(str.Substring(0, Math.Min(str.Length, 9)));
	}
}

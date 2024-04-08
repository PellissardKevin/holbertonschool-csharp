using System;

class Program
{
	static void Main(string[] args)
	{
		string str = "Holberton School";
		
		string repeatedStr = string.Concat(Enumerable.Repeat(str, 3));
		Console.Write(repeatedStr);

		string firstNineChars = str.Substring(0, Math.Min(str.Length, 9));
		Console.WriteLine(firstNineChars);
	}
}

using System;

namespace Zadatak1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Unesite tekst koji treba napisati naopako:");
			string tekst = Console.ReadLine();

			while (string.IsNullOrEmpty(tekst) || tekst.Trim().Length == 0)
			{
				Console.WriteLine("Tekst ne može biti prazan, upišite nešto:");
				tekst = Console.ReadLine();
			}

			Console.WriteLine($"Tekst naopako: {tekst.ReverseText()}");

			Console.ReadKey();
		}
	}
}

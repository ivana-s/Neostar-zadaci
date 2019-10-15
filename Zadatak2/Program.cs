using System;
using System.Collections.Generic;

namespace Zadatak2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Unesite prirodne brojeve odvojene enterom. Ukoliko želite završiti s unosom unesite broj 0");

			List<uint> brojevi = new List<uint>();

			while (true)
			{
				Console.WriteLine("Unesite broj:");

				if (!uint.TryParse(Console.ReadLine(), out uint broj))
				{
					Console.WriteLine("Morate unijeti prirodan broj!");
					continue;
				}

				if (broj == 0)
				{
					break;
				}

				brojevi.Add(broj);
			}

			List<uint> djeljivi6 = Visekratnici.NadiVisekratnike(brojevi, 6);
			List<uint> djeljivi2 = Visekratnici.IzbaciVisekratnike(Visekratnici.NadiVisekratnike(brojevi, 2), 3);
			List<uint> djeljivi3 = Visekratnici.IzbaciVisekratnike(Visekratnici.NadiVisekratnike(brojevi, 3), 2);
			List<uint> ostali = Visekratnici.IzbaciVisekratnike(Visekratnici.IzbaciVisekratnike(brojevi, 2), 3);

			//program ne izbacuje duple brojeve, nego ih sve ispiše
			Console.WriteLine($"Uneseni brojevi:{string.Join(",", brojevi)}");
			Console.WriteLine($"Brojevi djeljivi s 2 i s 3: {string.Join(",", djeljivi6)}");
			Console.WriteLine($"Brojevi djeljivi s 2 (ali ne sa 3): {string.Join(",", djeljivi2)}");
			Console.WriteLine($"Brojevi djeljivi s 3 (ali ne sa 2): {string.Join(",", djeljivi3)}");
			Console.WriteLine($"Ostali brojevi: {string.Join(",", ostali)}");

			Console.ReadKey();
		}
	}
}

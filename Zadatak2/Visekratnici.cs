using System;
using System.Collections.Generic;

namespace Zadatak2
{
	class Visekratnici
	{
		public static List<uint> NadiVisekratnike(List<uint> brojevi, uint djelitelj)
		{
			return visekratnici(brojevi, djelitelj, (broj, djel) => broj % djel == 0);
		}

		public static List<uint> IzbaciVisekratnike(List<uint> brojevi, uint djelitelj)
		{
			return visekratnici(brojevi, djelitelj, (broj, djel) => broj % djel != 0);
		}

		private static List<uint> visekratnici(List<uint> brojevi, uint djelitelj, Func<uint, uint, bool> filterFunkcija)
		{
			if (djelitelj == 0)
			{
				throw new ArgumentException("Djelitelj ne može biti 0");
			}

			List<uint> rezultat = new List<uint>();

			foreach (uint broj in brojevi)
			{
				if (filterFunkcija(broj, djelitelj))
				{
					rezultat.Add(broj);
				}
			}

			return rezultat;
		}
	}
}

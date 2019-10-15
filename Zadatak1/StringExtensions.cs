using System;
using System.Linq;

namespace Zadatak1
{
	// ove metode neće ispravno okrenuti hrvatska slova koja se sastoje od 2 znaka: nj, lj, dž
	// metode treba doraditi i ako postoji potreba za podržavanjem posebnih znakova: \n, \r... i naglasaka
	static class StringExtensions
	{
		public static string ReverseTextLinq(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			return new string(text.Reverse().ToArray());
		}

		public static string ReverseText(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			var textArray = text.ToCharArray();
			Array.Reverse(textArray);
			return new string(textArray);
		}

		//bez korištenja postojeće Reverse() metode
		public static string ReverseTextManual(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			char[] textArray = text.ToCharArray();
			int length = textArray.Length;

			for (int i = 0; i < length / 2; i++)
			{
				textArray[i] ^= textArray[length - 1 - i];
				textArray[length - 1 - i] ^= textArray[i];
				textArray[i] ^= textArray[length - 1 - i];
			}

			return new string(textArray);
		}
	}
}

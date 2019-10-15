using System;
using System.Collections.Generic;
using System.Globalization;

namespace Zadatak3
{
	class Program
	{
		//nemam view dio pa sam sve pozive i prikaze ostavila u ovoj datoteci
		static void Main(string[] args)
		{
			Kontroler kontroler = new Kontroler();

			while (osnovniIzbornik(kontroler)) ;
		}

		public static bool osnovniIzbornik(Kontroler kontroler)
		{
			Console.WriteLine("\nOdaberite jednu od ponuđenih opcija:");
			Console.WriteLine("1. Popis svih učenika");
			Console.WriteLine("2. Unos učenika");
			Console.WriteLine("3. Odabir određenog učenika");
			Console.WriteLine("4. Izlaz iz programa\n");

			int brojOpcije = unosBroja();
			switch (brojOpcije)
			{
				case 1:
					IEnumerable<Ucenik> ucenici = kontroler.DohvatiUcenike();
					prikaziUcenike(ucenici);
					break;
				case 2:
					Ucenik ucenik = unosPodatakaUcenika();
					if (kontroler.KreirajUcenika(ucenik))
					{
						Console.WriteLine($"Učenik je uspješno kreiran.\n{ucenik}");
					}
					else
					{
						Console.WriteLine("Unos novog učenika neuspješan");
					}
					break;
				case 3:
					Console.WriteLine("Unesite šifru učenika ili 0 za povratak na glavni izbornik:");
					int sifraUcenika = unosBroja();
					while (pregledUcenikaIzbornik(sifraUcenika, kontroler)) ;
					break;
				case 4:
					Console.WriteLine("Gašenje programa");
					Console.ReadKey();
					return false;
				default:
					Console.WriteLine("Neispravan broj opcije");
					break;
			}
			return true;
		}

		public static bool pregledUcenikaIzbornik(int sifraUcenika, Kontroler kontroler)
		{
			if (sifraUcenika == 0)
			{
				return false;
			}

			Ucenik ucenik = kontroler.DohvatiUcenika(sifraUcenika);
			if (ucenik == null)
			{
				Console.WriteLine("Ne postoji učenik sa unesenom šifrom");
				return false;
			}
			Console.WriteLine(ucenik);

			Console.WriteLine("\nOdaberite jednu od ponuđenih opcija:");
			Console.WriteLine("1. Uređivanje");
			Console.WriteLine("2. Brisanje");
			Console.WriteLine("3. Povratak na glavni izbornik");

			int brojOpcije = unosBroja();

			switch (brojOpcije)
			{
				case 1:
					uredivanjeUcenikaIzbornik(sifraUcenika, kontroler);
					break;
				case 2:
					if (kontroler.ObrisiUcenika(sifraUcenika))
					{
						Console.WriteLine("Ucenik uspjesno obrisan.");
					}
					else
					{
						Console.WriteLine("Brisanje nije uspjelo.");
					}
					return false;
				case 3:
					return false;
				default:
					Console.WriteLine("Neispravan broj opcije.");
					break;
			}
			return true;
		}

		public static void uredivanjeUcenikaIzbornik(int sifraUcenika, Kontroler kontroler)
		{
			Ucenik ucenik = unosPodatakaUcenika(sifraUcenika);

			ucenik.PromjenaDatumaRodjenja += promjenaDatumaRodjenja;

			if (kontroler.UrediUcenika(ucenik))
			{
				Console.WriteLine($"Učenik uspješno promijenjen.");
			}
			else
			{
				Console.WriteLine("Izmjena učenika neuspješna");
			}

			ucenik.PromjenaDatumaRodjenja -= promjenaDatumaRodjenja;
		}

		private static void promjenaDatumaRodjenja(object sender, PromjenaDatumaRodjenjaArgs e)
		{
			Console.WriteLine($"Promijenili ste starost učenika, nova starost je {e.Starost}");
		}

		private static Ucenik unosPodatakaUcenika(int sifraUcenika = default)
		{
			Console.WriteLine("Molimo unesite potrebne podatke o učeniku:");

			Console.Write("Ime:");
			string ime = unosTeksta(50);

			Console.Write("Prezime:");
			string prezime = unosTeksta(50);

			Console.Write("Datum rodenja (dd.mm.gggg.):");
			DateTime datumRodjenja;
			while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy.", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out datumRodjenja))
			{
				Console.WriteLine("Datum mora biti u formatu \"dd.mm.gggg.\"");
			}

			Console.Write("Prosjek (0 ako nije ocjenjen):");
			double prosjek;
			while (true)
			{
				if (!double.TryParse(Console.ReadLine(), out prosjek))
				{
					Console.WriteLine("Prosjek mora biti decimalni broj");
					continue;
				}
				if (prosjek != 0 && (prosjek < 1 || prosjek > 5))
				{
					Console.WriteLine("Prosjek mora biti između 1 i 5");
					continue;
				}
				break;
			}

			return new Ucenik()
			{
				Id = sifraUcenika,
				Ime = ime,
				Prezime = prezime,
				DatumRodjenja = datumRodjenja,
				Prosjek = prosjek == default ? (double?)null : prosjek
			};
		}

		private static int unosBroja()
		{
			int broj;

			while (!int.TryParse(Console.ReadLine(), out broj))
			{
				Console.WriteLine("Neispravan unos, molimo unesite broj.");
			}

			return broj;
		}

		private static string unosTeksta(int maxDuzina)
		{
			string tekst;

			while (true)
			{
				tekst = Console.ReadLine();
				if (tekst.Length > maxDuzina)
				{
					Console.WriteLine($"Tekst ne može biti duži od {maxDuzina} znakova. Molimo unesite kraći tekst.");
					continue;
				}
				break;
			}

			return tekst;
		}

		private static void prikaziUcenike(IEnumerable<Ucenik> ucenici)
		{
			Console.WriteLine("Popis učenika:");
			foreach (Ucenik ucenik in ucenici)
			{
				Console.WriteLine(ucenik.ToShortString());
			}
		}
	}
}

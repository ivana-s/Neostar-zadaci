using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadatak3
{
	[Table("Ucenici")]
	public class Ucenik
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public string Ime { get; set; }

		[Required, MaxLength(50)]
		public string Prezime { get; set; }

		[Required]
		public DateTime DatumRodjenja { get; set; }

		[Range(1, 5)]
		public double? Prosjek { get; set; }

		public int Starost()
		{
			bool prosaoRodjendan = DateTime.Now.DayOfYear > DatumRodjenja.DayOfYear;

			return DateTime.Now.Year - DatumRodjenja.Year - (prosaoRodjendan ? 0 : 1);
		}

		public string ProsjekRijecima()
		{
			if (!Prosjek.HasValue)
			{
				return "Neocijenjen";
			}
			if (Prosjek < 1.5)
			{
				return "Nedovoljan";
			}
			else if (Prosjek < 2.5)
			{
				return "Dovoljan";
			}
			else if (Prosjek < 3.5)
			{
				return "Dobar";
			}
			else if (Prosjek < 4.5)
			{
				return "Vrlo dobar";
			}
			else
			{
				return "Odličan";
			}
		}

		public string ToShortString()
		{
			return $"Šifra: {Id}, ime: {Ime}, prezime: {Prezime}";
		}

		public override string ToString()
		{
			return $"{ToShortString()}, starost: {Starost()}, prosjek: {ProsjekRijecima()}";
		}

		public event EventHandler<PromjenaDatumaRodjenjaArgs> PromjenaDatumaRodjenja;

		public void NaPromjenuDatumaRodjenja(PromjenaDatumaRodjenjaArgs e)
		{
			PromjenaDatumaRodjenja?.Invoke(this, e);
		}
	}
}

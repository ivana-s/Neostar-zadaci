using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak3
{
	class UcenikRepozitorij : IUcenikRepozitorij
	{
		private readonly UcenikDbContext dbContext;
		private bool disposed = false;

		public UcenikRepozitorij()
		{
			dbContext = new UcenikDbContext();
		}

		public UcenikRepozitorij(UcenikDbContext db)
		{
			if (db == null)
			{
				throw new ArgumentNullException();
			}

			dbContext = db;
		}

		public IEnumerable<Ucenik> DohvatiUcenike()
		{
			return dbContext.Ucenici.ToList();
		}

		public Ucenik DohvatiUcenika(int idUcenika)
		{
			return dbContext.Ucenici.Find(idUcenika);
		}

		public void KreirajUcenika(Ucenik ucenik)
		{
			dbContext.Ucenici.Add(ucenik);
		}

		public void UrediUcenika(Ucenik ucenik)
		{
			Ucenik ucenikDb = DohvatiUcenika(ucenik.Id);

			if (ucenikDb.DatumRodjenja != ucenik.DatumRodjenja)
			{
				ucenik.NaPromjenuDatumaRodjenja(new PromjenaDatumaRodjenjaArgs(ucenik.Starost()));
			}

			ucenikDb.Ime = ucenik.Ime;
			ucenikDb.Prezime = ucenik.Prezime;
			ucenikDb.DatumRodjenja = ucenik.DatumRodjenja;
			ucenikDb.Prosjek = ucenik.Prosjek;
		}

		public void ObrisiUcenika(int idUcenika)
		{
			Ucenik ucenik = dbContext.Ucenici.Find(idUcenika);
			dbContext.Ucenici.Remove(ucenik);
		}

		public void Spremi()
		{
			dbContext.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					dbContext.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

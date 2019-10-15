using System.Collections.Generic;

namespace Zadatak3
{
	class Kontroler
	{
		private IUcenikRepozitorij ucenikRepozitorij;

		public Kontroler()
		{
			ucenikRepozitorij = new UcenikRepozitorij(new UcenikDbContext());
		}

		public Kontroler(IUcenikRepozitorij ucenikRepozitorij)
		{
			this.ucenikRepozitorij = ucenikRepozitorij;
		}

		public IEnumerable<Ucenik> DohvatiUcenike()
		{
			return ucenikRepozitorij.DohvatiUcenike();
		}

		public Ucenik DohvatiUcenika(int idUcenika)
		{
			return ucenikRepozitorij.DohvatiUcenika(idUcenika);
		}

		public bool KreirajUcenika(Ucenik ucenik)
		{
			try
			{
				ucenikRepozitorij.KreirajUcenika(ucenik);
				ucenikRepozitorij.Spremi();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool UrediUcenika(Ucenik ucenik)
		{
			try
			{
				ucenikRepozitorij.UrediUcenika(ucenik);
				ucenikRepozitorij.Spremi();
				return true;
			}
			catch
			{
				return false;
			}

		}

		public bool ObrisiUcenika(int idUcenika)
		{
			try
			{
				ucenikRepozitorij.ObrisiUcenika(idUcenika);
				ucenikRepozitorij.Spremi();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}

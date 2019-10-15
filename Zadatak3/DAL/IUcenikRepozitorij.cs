using System.Collections.Generic;

namespace Zadatak3
{
	public interface IUcenikRepozitorij
	{
		IEnumerable<Ucenik> DohvatiUcenike();

		Ucenik DohvatiUcenika(int idUcenika);

		void KreirajUcenika(Ucenik ucenik);

		void UrediUcenika(Ucenik ucenik);

		void ObrisiUcenika(int idUcenika);

		void Spremi();
	}
}

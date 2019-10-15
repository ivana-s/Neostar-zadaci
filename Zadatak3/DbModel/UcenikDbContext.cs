using System.Data.Entity;

namespace Zadatak3
{
	class UcenikDbContext : DbContext
	{
		public DbSet<Ucenik> Ucenici { get; set; }
	}
}

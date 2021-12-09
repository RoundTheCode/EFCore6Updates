using Microsoft.EntityFrameworkCore;
using RoundTheCode.EFCore.Entities;

namespace RoundTheCode.EFCore
{
    public class EfCoreDbContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();

        public DbSet<Team> Teams => Set<Team>();

        public EfCoreDbContext()
        {
        }

        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>()
			.ToTable(action =>
			{
				action.IsTemporal();
			});

			modelBuilder.Entity<Team>()
			.ToTable(action =>
			{
				action.IsTemporal();
			});
		}
	}
}

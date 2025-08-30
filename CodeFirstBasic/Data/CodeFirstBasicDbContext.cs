using Microsoft.EntityFrameworkCore;
using CodeFirstBasic.Models;

namespace CodeFirstBasic.Data
{
    public class PatikaFirstDbContext  : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // LocalDB kullandım
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CodeFirstBasicDb1;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Game>().ToTable("Games");
        }
    }
}

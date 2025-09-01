using Microsoft.EntityFrameworkCore;
using Survivor.Models;

namespace Survivor.Data
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Competitors> Competitors { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Competitors)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
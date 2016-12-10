using Lauderdale.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lauderdale.Repository.Context
{
    public class EntitiesContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7BQNVVE\SQLEXPRESS;initial catalog=Lauderdale;integrated security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);
        }
    }
}
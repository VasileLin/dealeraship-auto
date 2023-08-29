using DealershipAuto_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipAuto_Manager.Data
{

    //ApplicationDbContext - abstractizare asupra bazei de date
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(am => new { am.CarId, am.ClientId });
            base.OnModelCreating(modelBuilder);
        }

        //DbSet abstractizarea a tabelelor din baza de date
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; } 
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using World.Entities;
using World.Entities.Auth;

namespace World.DAL
{
    public class WoldDbContext : IdentityDbContext<AppUser>
    {
        public WoldDbContext(DbContextOptions<WoldDbContext> options) : base(options)
        {
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CapitalCity> CapitalCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Horse> Horses{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseModel(CompiledModels.SamuraiContextModel.Instance)
                .UseSqlServer("Data Source=localhost;Initial Catalog=SamuraiApp;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>
                 (bs => bs.HasOne<Battle>().WithMany(),
                  bs => bs.HasOne<Samurai>().WithMany())
                 .Property(bs => bs.DateJoined)
                 .HasDefaultValueSql("getdate()");

        }
    }
}

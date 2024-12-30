using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebHeroCreator.Models;

namespace WebHeroCreator.Contexts
{
    public class HeroBuilderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = heroes.db");
        }

        public DbSet<Clans> Clans { get; set; }
        public DbSet<PowerAttributes> powerAttributes { get; set; }

        public DbSet<HeroModel> Heroes { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie_Model.DAL
{
    public class PedalDbContext : DbContext
    {
        public DbSet<Residence> Residences { get; set; }
        public DbSet<Runner> Runners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pedal.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 1, Name = "Pedal", Description = "Pedal is een overkoepelende organisatie voor studentenresidenties." });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 2, Name = "Hesteria", Description = "Hesteria is studentenclub voor iedereen uit Heist en omstreken." });

        }
    }
}

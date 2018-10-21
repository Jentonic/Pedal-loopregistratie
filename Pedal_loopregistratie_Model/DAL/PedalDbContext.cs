using Microsoft.EntityFrameworkCore;
using Pedal_loopregistratie_Model.Models;
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
        public DbSet<Lap> Laps { get; set; }
        public DbSet<QueueRunner> QueueRunners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pedal.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 1, Name = "Pedal", Description = "Pedal is een overkoepelende organisatie voor studentenresidenties." });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 2, Name = "Hesteria", Description = "Hesteria is de studentenclub voor iedereen uit Heist en omstreken." });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 3, Name = "Heilige Geestcollege", Description = "" });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 4, Name = "Amerikaans College", Description = "" });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 5, Name = "Don Bosco", Description = "" });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 6, Name = "Regina Mundi", Description = "" });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 7, Name = "Copal", Description = "" });
            modelBuilder.Entity<Residence>().HasData(new Residence() { ResidenceId = 8, Name = "Cruysberghs", Description = "" });
        }

        public void DoMigrate()
        {
            this.Database.Migrate();

            var res = this.Residences.FirstOrDefault(x => x.Name == "Hesteria");
            var runner = new Runner()
            {
                RunnerId = 1,
                FirstName = "Jenne",
                LastName = "Baeten",
                Residence = res,
                ResidenceId = res.ResidenceId
            };
            if (this.Runners.Select(x => x).Where(x => x.RunnerId == 1).ToList().Count == 0)
            {
                this.Runners.Add(runner);
                this.SaveChanges();
            }
        }
    }
}

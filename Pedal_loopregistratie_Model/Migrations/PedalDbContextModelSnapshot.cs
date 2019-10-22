﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedal_loopregistratie_Model.DAL;

namespace Pedal_loopregistratie_Model.Migrations
{
    [DbContext(typeof(PedalDbContext))]
    partial class PedalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Pedal_loopregistratie_Model.Models.Lap", b =>
                {
                    b.Property<int>("LapId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AverageSpeedKmH");

                    b.Property<double>("AverageSpeedS");

                    b.Property<double>("Milliseconds");

                    b.Property<int>("RunnerId");

                    b.HasKey("LapId");

                    b.HasIndex("RunnerId");

                    b.ToTable("Laps");
                });

            modelBuilder.Entity("Pedal_loopregistratie_Model.Models.QueueRunner", b =>
                {
                    b.Property<int>("QueueRunnerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Position");

                    b.Property<int>("RunnerId");

                    b.HasKey("QueueRunnerId");

                    b.HasIndex("RunnerId");

                    b.ToTable("QueueRunners");
                });

            modelBuilder.Entity("Pedal_loopregistratie_Model.Residence", b =>
                {
                    b.Property<int>("ResidenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageString");

                    b.Property<string>("Name");

                    b.HasKey("ResidenceId");

                    b.ToTable("Residences");

                    b.HasData(
                        new { ResidenceId = 1, Description = "Pedal is een overkoepelende organisatie voor studentenresidenties.", Name = "Pedal" },
                        new { ResidenceId = 2, Description = "Hesteria is de studentenclub voor iedereen uit Heist en omstreken.", Name = "Hesteria" },
                        new { ResidenceId = 3, Description = "", Name = "Heilige Geestcollege" },
                        new { ResidenceId = 4, Description = "", Name = "Amerikaans College" },
                        new { ResidenceId = 5, Description = "", Name = "Don Bosco" },
                        new { ResidenceId = 6, Description = "", Name = "Regina Mundi" },
                        new { ResidenceId = 7, Description = "", Name = "Copal" },
                        new { ResidenceId = 8, Description = "", Name = "Cruysberghs" },
                        new { ResidenceId = 9, Description = "", Name = "Justus Lipsius" },
                        new { ResidenceId = 10, Description = "", Name = "Waterview" },
                        new { ResidenceId = 11, Description = "", Name = "Studax" }
                    );
                });

            modelBuilder.Entity("Pedal_loopregistratie_Model.Runner", b =>
                {
                    b.Property<int>("RunnerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("ResidenceId");

                    b.HasKey("RunnerId");

                    b.HasIndex("ResidenceId");

                    b.ToTable("Runners");
                });

            modelBuilder.Entity("Pedal_loopregistratie_Model.Models.Lap", b =>
                {
                    b.HasOne("Pedal_loopregistratie_Model.Runner", "Runner")
                        .WithMany("Laps")
                        .HasForeignKey("RunnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pedal_loopregistratie_Model.Models.QueueRunner", b =>
                {
                    b.HasOne("Pedal_loopregistratie_Model.Runner", "Runner")
                        .WithMany()
                        .HasForeignKey("RunnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pedal_loopregistratie_Model.Runner", b =>
                {
                    b.HasOne("Pedal_loopregistratie_Model.Residence", "Residence")
                        .WithMany("Runners")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

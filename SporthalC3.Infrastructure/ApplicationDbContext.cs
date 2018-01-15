using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SporthalC3;
using SporthalC3.Domain;
using SporthalC3.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SporthalC3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        [Required]
        public DbSet<SportsBuildingAdministrator> SportsBuildingAdministrators { get; set;}

        [Required]
        public DbSet<SportsBuilding> SportsBuilding { get; set; }

        [Required]
        public DbSet<SportsHall> SportsHall { get; set; }

        [Required]
        public DbSet<Reserve> Reserve { get; set; }

        [Required]
        public DbSet<Sport> Sport { get; set; }

        [Required]
        public DbSet<SportsHallSports> SportHallSports { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserve>()
                 .HasOne(x => x.SportsHall)
                 .WithMany(x => x.Reserve)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Sport>()
                .HasMany(p => p.SportsHallSports);

            modelBuilder.Entity<SportsHallSports>()
                .HasKey(bc => new { bc.SportsHallId, bc.SportsId });

            modelBuilder.Entity<SportsHallSports>()
                .HasOne(bc => bc.Sport)
                .WithMany(c => c.SportsHallSports)
                .HasForeignKey(bc => bc.SportsId);

            modelBuilder.Entity<SportsBuilding>()
                .HasOne(x => x.SportsBuildingAdministrator)
                .WithMany(x => x.SportBuildingList)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SportsHall>()
                .HasOne(x => x.SportsBuilding)
                .WithMany(x => x.SportsHallList)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

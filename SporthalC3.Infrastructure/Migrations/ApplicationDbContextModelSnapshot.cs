using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SporthalC3;

namespace SporthalC3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SporthalC3.Models.Reserve", b =>
                {
                    b.Property<int>("ReserveID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Email");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PhoneNumber");

                    b.Property<int?>("SportsHallID");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("ReserveID");

                    b.HasIndex("SportsHallID");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("SporthalC3.Models.Sport", b =>
                {
                    b.Property<int>("SportID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SportID");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("SporthalC3.Models.SportsBuilding", b =>
                {
                    b.Property<int>("SportsBuildingID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Canteen");

                    b.Property<string>("City");

                    b.Property<int>("HouseNumber");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<int?>("SportsBuildingAdministratorID");

                    b.Property<string>("Street");

                    b.HasKey("SportsBuildingID");

                    b.HasIndex("SportsBuildingAdministratorID");

                    b.ToTable("SportsBuilding");
                });

            modelBuilder.Entity("SporthalC3.Models.SportsBuildingAdministrator", b =>
                {
                    b.Property<int>("SportsBuildingAdministratorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("SportsBuildingAdministratorID");

                    b.ToTable("SportsBuildingAdministrators");
                });

            modelBuilder.Entity("SporthalC3.Models.SportsHall", b =>
                {
                    b.Property<int>("SportsHallID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CloseTime");

                    b.Property<double>("Length");

                    b.Property<int>("NumberOfDressingSpace");

                    b.Property<int>("NumberOfShowers");

                    b.Property<DateTime>("OpenTime");

                    b.Property<double>("Price");

                    b.Property<int?>("SportsBuildingID");

                    b.Property<double>("Width");

                    b.HasKey("SportsHallID");

                    b.HasIndex("SportsBuildingID");

                    b.ToTable("SportsHall");
                });

            modelBuilder.Entity("SporthalC3.Models.SportsHallSports", b =>
                {
                    b.Property<int>("SportsHallId");

                    b.Property<int>("SportsId");

                    b.HasKey("SportsHallId", "SportsId");

                    b.HasIndex("SportsId");

                    b.ToTable("SportHallSports");
                });

            modelBuilder.Entity("SporthalC3.Models.Reserve", b =>
                {
                    b.HasOne("SporthalC3.Models.SportsHall", "SportsHall")
                        .WithMany("Reserve")
                        .HasForeignKey("SportsHallID")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("SporthalC3.Models.SportsBuilding", b =>
                {
                    b.HasOne("SporthalC3.Models.SportsBuildingAdministrator", "SportsBuildingAdministrator")
                        .WithMany("SportBuildingList")
                        .HasForeignKey("SportsBuildingAdministratorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SporthalC3.Models.SportsHall", b =>
                {
                    b.HasOne("SporthalC3.Models.SportsBuilding", "SportsBuilding")
                        .WithMany("SportsHallList")
                        .HasForeignKey("SportsBuildingID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SporthalC3.Models.SportsHallSports", b =>
                {
                    b.HasOne("SporthalC3.Models.SportsHall", "SportsHall")
                        .WithMany("SportsHallSports")
                        .HasForeignKey("SportsHallId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SporthalC3.Models.Sport", "Sport")
                        .WithMany("SportsHallSports")
                        .HasForeignKey("SportsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

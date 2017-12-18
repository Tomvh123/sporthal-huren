using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SporthalC3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    SportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "SportsBuildingAdministrators",
                columns: table => new
                {
                    SportsBuildingAdministratorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsBuildingAdministrators", x => x.SportsBuildingAdministratorID);
                });

            migrationBuilder.CreateTable(
                name: "SportsBuilding",
                columns: table => new
                {
                    SportsBuildingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Canteen = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    SportsBuildingAdministratorID = table.Column<int>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsBuilding", x => x.SportsBuildingID);
                    table.ForeignKey(
                        name: "FK_SportsBuilding_SportsBuildingAdministrators_SportsBuildingAdministratorID",
                        column: x => x.SportsBuildingAdministratorID,
                        principalTable: "SportsBuildingAdministrators",
                        principalColumn: "SportsBuildingAdministratorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportsHall",
                columns: table => new
                {
                    SportsHallID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CloseTime = table.Column<DateTime>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    NumberOfDressingSpace = table.Column<int>(nullable: false),
                    NumberOfShowers = table.Column<int>(nullable: false),
                    OpenTime = table.Column<DateTime>(nullable: false),
                    SportsBuildingID = table.Column<int>(nullable: true),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsHall", x => x.SportsHallID);
                    table.ForeignKey(
                        name: "FK_SportsHall_SportsBuilding_SportsBuildingID",
                        column: x => x.SportsBuildingID,
                        principalTable: "SportsBuilding",
                        principalColumn: "SportsBuildingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    ReserveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    SportsHallID = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.ReserveID);
                    table.ForeignKey(
                        name: "FK_Reserve_SportsHall_SportsHallID",
                        column: x => x.SportsHallID,
                        principalTable: "SportsHall",
                        principalColumn: "SportsHallID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SportHallSports",
                columns: table => new
                {
                    SportsHallId = table.Column<int>(nullable: false),
                    SportsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportHallSports", x => new { x.SportsHallId, x.SportsId });
                    table.ForeignKey(
                        name: "FK_SportHallSports_SportsHall_SportsHallId",
                        column: x => x.SportsHallId,
                        principalTable: "SportsHall",
                        principalColumn: "SportsHallID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportHallSports_Sport_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sport",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_SportsHallID",
                table: "Reserve",
                column: "SportsHallID");

            migrationBuilder.CreateIndex(
                name: "IX_SportsBuilding_SportsBuildingAdministratorID",
                table: "SportsBuilding",
                column: "SportsBuildingAdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_SportsHall_SportsBuildingID",
                table: "SportsHall",
                column: "SportsBuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_SportHallSports_SportsId",
                table: "SportHallSports",
                column: "SportsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "SportHallSports");

            migrationBuilder.DropTable(
                name: "SportsHall");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "SportsBuilding");

            migrationBuilder.DropTable(
                name: "SportsBuildingAdministrators");
        }
    }
}

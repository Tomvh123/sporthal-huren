using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SporthalC3.Infrastructure.Migrations
{
    public partial class SportsReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportID",
                table: "Reserve",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_SportID",
                table: "Reserve",
                column: "SportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Sport_SportID",
                table: "Reserve",
                column: "SportID",
                principalTable: "Sport",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Sport_SportID",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_SportID",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "SportID",
                table: "Reserve");
        }
    }
}

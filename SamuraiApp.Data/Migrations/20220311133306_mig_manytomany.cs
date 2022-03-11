using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class mig_manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleSamurai",
                columns: table => new
                {
                    BattlesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SamuraisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleSamurai", x => new { x.BattlesId, x.SamuraisId });
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Battles_BattlesId",
                        column: x => x.BattlesId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Samurais_SamuraisId",
                        column: x => x.SamuraisId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleSamurai_SamuraisId",
                table: "BattleSamurai",
                column: "SamuraisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleSamurai");

            migrationBuilder.DropTable(
                name: "Battles");
        }
    }
}

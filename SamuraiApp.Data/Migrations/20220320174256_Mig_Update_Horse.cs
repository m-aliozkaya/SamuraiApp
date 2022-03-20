using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class Mig_Update_Horse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses",
                column: "SamuraiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_SamuraiId",
                table: "Horses",
                column: "SamuraiId");
        }
    }
}

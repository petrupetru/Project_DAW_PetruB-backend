using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_DAW_PetruB.Migrations
{
    public partial class prodlicense_1to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProducerId",
                table: "Licenses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ProducerId",
                table: "Licenses",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Producers_ProducerId",
                table: "Licenses",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Producers_ProducerId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_ProducerId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Licenses");
        }
    }
}

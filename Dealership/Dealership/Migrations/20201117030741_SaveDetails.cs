using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Migrations
{
    public partial class SaveDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailsJSON",
                table: "VehiclesFull",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsJSON",
                table: "VehiclesFull");
        }
    }
}

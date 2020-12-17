using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Migrations
{
    public partial class YearToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

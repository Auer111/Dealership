using Microsoft.EntityFrameworkCore.Migrations;

namespace Dealership.Migrations
{
    public partial class MakeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeFK = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Trims = table.Column<string>(nullable: true),
                    MakeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Model_Make_MakeID",
                        column: x => x.MakeID,
                        principalTable: "Make",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model_MakeID",
                table: "Model",
                column: "MakeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Make");
        }
    }
}

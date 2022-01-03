using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carCRBackend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarMake = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CarModel = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CarDate = table.Column<int>(type: "INTEGER", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}

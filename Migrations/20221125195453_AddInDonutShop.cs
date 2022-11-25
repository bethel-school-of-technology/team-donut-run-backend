using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rexfinderapi.Migrations
{
    /// <inheritdoc />
    public partial class AddInDonutShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonutShop",
                columns: table => new
                {
                    DonutShopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DonutShopName = table.Column<string>(type: "TEXT", nullable: false),
                    DonutShopAddress = table.Column<string>(type: "TEXT", nullable: true),
                    DonutShopWebsite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonutShop", x => x.DonutShopId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonutShop");
        }
    }
}

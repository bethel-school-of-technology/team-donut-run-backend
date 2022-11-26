using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rexfinderapi.Migrations
{
    /// <inheritdoc />
    public partial class OneMoreFieldForDonutShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonutShopImage",
                table: "DonutShop",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonutShopImage",
                table: "DonutShop");
        }
    }
}

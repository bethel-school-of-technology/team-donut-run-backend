using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rexfinderapi.Migrations
{
    /// <inheritdoc />
    public partial class AdjustingDonutShopAndAddingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonutShopImage",
                table: "DonutShop",
                newName: "DonutShopCityState");

            migrationBuilder.InsertData(
                table: "DonutShop",
                columns: new[] { "DonutShopId", "DonutShopAddress", "DonutShopCityState", "DonutShopName", "DonutShopWebsite" },
                values: new object[,]
                {
                    { 1, "1900 Eastland Ave Suite 101", "Nashville TN", "Five Daughters Bakery", "https://fivedaughtersbakery.com/" },
                    { 2, "1313 Shasta St", "Redding CA", "Heavenly Donuts", "https://www.heavenlydonut.com/" },
                    { 3, "6855 35th Ave NE ", "Seattle WA", "Top Pot Doughnuts", "https://www.toppotdoughnuts.com/" },
                    { 4, "1575 Broadway ", "Saugus MA", "Kanes Donuts", "https://www.kanesdonuts.com/" },
                    { 5, "3455 East Market St ", "York PA", "Maple Donuts", "https://www.mapledonuts.com/" },
                    { 6, "1311 Memorial Blvd ", "Murfreesboro TN", "Donut Country", "https://www.donutcountry.com/" },
                    { 7, "98 South Broadway Avenue ", "Denver CO", "Voodoo Doughnuts", "https://www.voodoodoughnut.com/" },
                    { 8, "10876 N 32nd St ", "Pheonix AZ", "BoSa Donuts", "https://bosadonutsaz.com/" },
                    { 9, "1998 N High ", "Columbus OH", "Buckeye Donuts", "https://buckeyedonuts.net/" },
                    { 10, "1710 Kenilworth Ave Suite 220 ", "Charlotte NC", "Duck Donuts", "https://www.duckdonuts.com/charlotte/" },
                    { 11, "175 S Fairfax Ave Unit D ", "Los Angeles CA", "Sidecar Doughnuts", "https://sidecardoughnuts.com/" },
                    { 12, "727 Manhattan Ave ", "Brooklyn NY", "Peter Pan Donut & Pastry Shop", "https://www.peterpandonuts.com/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 12);

            migrationBuilder.RenameColumn(
                name: "DonutShopCityState",
                table: "DonutShop",
                newName: "DonutShopImage");
        }
    }
}

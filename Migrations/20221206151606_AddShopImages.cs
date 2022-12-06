using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rexfinderapi.Migrations
{
    /// <inheritdoc />
    public partial class AddShopImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonutShopPhotoURL",
                table: "DonutShop",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 1,
                column: "DonutShopPhotoURL",
                value: "https://cdn.shopify.com/s/files/1/0015/8338/2600/files/FDB_Mar2_AmberUlmer-030_480x480.JPG?v=1535141819");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 2,
                column: "DonutShopPhotoURL",
                value: "https://images.squarespace-cdn.com/content/v1/5ae2002d9d5abb364c849f56/1525803588583-DVZJCKEO4ZAXUKN1S2FC/store-shasta-st-redding-ca-heavenly-donuts.jpg?format=1000w");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 3,
                column: "DonutShopPhotoURL",
                value: "https://cdn.shopify.com/s/files/1/1349/1039/files/featured-covid_858x_9254b94f-b880-4faa-820f-ce14e9bee403_1716x.jpg?v=1613784268");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 4,
                column: "DonutShopPhotoURL",
                value: "https://www.kanesdonuts.com/site/img/locations/kanes-legacy.jpg");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 5,
                column: "DonutShopPhotoURL",
                value: "https://www.mapledonuts.com/uploads/4532913028_b1c7972559_z.jpg");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 6,
                column: "DonutShopPhotoURL",
                value: "https://cdn.websites.hibu.com/5b9a48150fc94472bd49727cc22ee066/dms3rep/multi/Gallery-11.jpg");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 7,
                column: "DonutShopPhotoURL",
                value: "https://www.voodoodoughnut.com/wp-content/uploads/2022/11/Broadway_B.jpg");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 8,
                column: "DonutShopPhotoURL",
                value: "https://bosadonutsaz.com/wp-content/uploads/2019/05/Logo-1.png");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 9,
                column: "DonutShopPhotoURL",
                value: "https://images.squarespace-cdn.com/content/v1/5b328a679f8770158d2015fd/19b6a6af-8d28-4860-b610-f0ea80dd2c29/NEW+WEBSITE+HEADER+IMAGE_JPG.jpg?format=2500w");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 10,
                column: "DonutShopPhotoURL",
                value: "https://d2nmqj11l1ij0u.cloudfront.net//images/holiday%202022/website-holiday1.jpg");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 11,
                column: "DonutShopPhotoURL",
                value: "https://sidecarmigrate.wpenginepowered.com/wp-content/uploads/2020/08/Hero-4.jpg");

            migrationBuilder.UpdateData(
                table: "DonutShop",
                keyColumn: "DonutShopId",
                keyValue: 12,
                column: "DonutShopPhotoURL",
                value: "https://images.squarespace-cdn.com/content/v1/5fb40e02d2777464bb473010/1609262636242-NAMDR65IQFCYCMX8QBOG/peter_pan_bakery_greenpoint_brooklyn_ext.jpg?format=1500w");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonutShopPhotoURL",
                table: "DonutShop");
        }
    }
}

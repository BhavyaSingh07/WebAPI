using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatafordiffandreg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a821b42-497c-4375-b368-aadc825141e7"), "Hard" },
                    { new Guid("d84b719a-e6e3-4eec-8003-50a954c86188"), "Medium" },
                    { new Guid("e9563ff0-d73d-4470-a25a-a5c1f0d4a2cd"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("235b54a5-d6e8-4693-ab4b-f178995b0016"), "STL", "SouthLand", "https://www.newzealand.com/assets/Tourism-NZ/Southland/img-1536309346-4874-7451-B315794E-ED00-E5F3-899FFD38B13A4799__aWxvdmVrZWxseQo_FocalPointCropWzM1MiwxMDI0LDQ5LDYyLDc1LCJqcGciLDY1LDIuNV0.jpg" },
                    { new Guid("67dfa371-fe56-4eea-bb4d-308bfb8b7803"), "NSN", "Nelson", null },
                    { new Guid("6c861a39-f5ee-43e1-a105-c290aae8361c"), "NTL", "Northland", "https://www.newzealand.com/assets/Tourism-NZ/Northland-Bay-of-Islands/1000011333__aWxvdmVrZWxseQo_FocalPointCropWzM1MiwxMDI0LDMyLDYzLDc1LCJqcGciLDY1LDIuNV0.jpg" },
                    { new Guid("8e9c527f-2f2e-4c77-bdea-76dcd2dd95ca"), "BOP", "Bay of Plenty", null },
                    { new Guid("9fedf87f-41c3-4646-8a91-b5200a8a33e4"), "ACK", "Auckland", "https://imgix.theurbanlist.com/content/article/Rangitoto-Todd-Eyre.-ATEED_RMH_005-(1).jpg" },
                    { new Guid("b950f1f4-db81-4824-bc58-94b8139b7795"), "WGL", "Wellington", "https://www.neverendingvoyage.com/wp-content/uploads/2022/11/main-wellington-walks-skyline.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2a821b42-497c-4375-b368-aadc825141e7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d84b719a-e6e3-4eec-8003-50a954c86188"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e9563ff0-d73d-4470-a25a-a5c1f0d4a2cd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("235b54a5-d6e8-4693-ab4b-f178995b0016"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("67dfa371-fe56-4eea-bb4d-308bfb8b7803"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6c861a39-f5ee-43e1-a105-c290aae8361c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8e9c527f-2f2e-4c77-bdea-76dcd2dd95ca"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9fedf87f-41c3-4646-8a91-b5200a8a33e4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b950f1f4-db81-4824-bc58-94b8139b7795"));
        }
    }
}

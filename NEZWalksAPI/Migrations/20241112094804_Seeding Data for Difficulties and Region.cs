using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NEZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("63f368c1-ff89-4f0a-88f6-f538ba89c229"), "Medium" },
                    { new Guid("710fa13d-40e7-4694-8816-22944a1e4bd1"), "Hard" },
                    { new Guid("df0d7d14-d835-46e8-9c54-76670ef57cef"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3a9f591c-7c9e-457c-87aa-766b8665b98c"), "Auk", "AuckLand", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgQt4gkKebi36jCQ6Bi1bVWYRybLEs-Vm2AA&s" },
                    { new Guid("96e1007c-f6b5-43b2-bbd5-4f6cd679a107"), "06", "Gjilan", "https://kallxo.com/wp-content/uploads/2020/11/GJILANI-DRON-1-720x405.png" },
                    { new Guid("d9fc392b-218a-4842-b6a5-1118af631336"), "01", "Prishtina", "https://www.albinfo.at/wp-content/uploads/2021/07/210644935_4230753403630675_6342664394500292046_n.jpg" },
                    { new Guid("f97e90b4-6303-4da1-96f8-f2c850cbed97"), "02", "Mitrovice", "https://i0.wp.com/mytravelation.com/wp-content/uploads/2023/12/Mitrovica-Kosovo.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("63f368c1-ff89-4f0a-88f6-f538ba89c229"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("710fa13d-40e7-4694-8816-22944a1e4bd1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("df0d7d14-d835-46e8-9c54-76670ef57cef"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3a9f591c-7c9e-457c-87aa-766b8665b98c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("96e1007c-f6b5-43b2-bbd5-4f6cd679a107"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d9fc392b-218a-4842-b6a5-1118af631336"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f97e90b4-6303-4da1-96f8-f2c850cbed97"));
        }
    }
}

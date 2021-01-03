using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXiecheng.API.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPercent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("e3d6bcda-1e7c-451d-86f9-3768ebacbe36"), new DateTime(2021, 1, 3, 9, 1, 38, 238, DateTimeKind.Utc).AddTicks(6800), null, "shuoming", null, null, null, null, 0m, "zheshititle", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("e3d6bcda-1e7c-451d-86f9-3768ebacbe36"));
        }
    }
}

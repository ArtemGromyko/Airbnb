using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HasInternet = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Address", "HasInternet", "Price" },
                values: new object[] { new Guid("601ec7d3-b5c9-43c8-8adb-63fdc67bb1bd"), "10014, Perry Street, New York", true, 100m });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Address", "HasInternet", "Price" },
                values: new object[] { new Guid("75518431-3035-4a5d-8f91-d8a6e8f8af47"), "10019, West 53rd Street, New York", true, 80m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

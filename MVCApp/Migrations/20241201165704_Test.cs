using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("01b72cdf-b484-4e82-819f-c75ad385f6db"));

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("47df07d8-09ec-42f5-a76f-2faad680d059"));

            migrationBuilder.InsertData(
                table: "IdentityRole<Guid>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("fc13c27b-093a-414b-9238-e9bc08370cfc"), null, "User", "USER" },
                    { new Guid("fda632fe-fb2f-4345-9d5d-49b64e9044c0"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("fc13c27b-093a-414b-9238-e9bc08370cfc"));

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("fda632fe-fb2f-4345-9d5d-49b64e9044c0"));

            migrationBuilder.InsertData(
                table: "IdentityRole<Guid>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01b72cdf-b484-4e82-819f-c75ad385f6db"), null, "Admin", "ADMIN" },
                    { new Guid("47df07d8-09ec-42f5-a76f-2faad680d059"), null, "User", "USER" }
                });
        }
    }
}

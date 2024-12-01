using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("c5d6a3b3-d897-42c3-bcfe-1165628c69d7"), null, "User", "USER" },
                    { new Guid("f07b7e61-ee42-42a9-a464-0551f29e46ca"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("c5d6a3b3-d897-42c3-bcfe-1165628c69d7"));

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("f07b7e61-ee42-42a9-a464-0551f29e46ca"));

            migrationBuilder.InsertData(
                table: "IdentityRole<Guid>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("fc13c27b-093a-414b-9238-e9bc08370cfc"), null, "User", "USER" },
                    { new Guid("fda632fe-fb2f-4345-9d5d-49b64e9044c0"), null, "Admin", "ADMIN" }
                });
        }
    }
}

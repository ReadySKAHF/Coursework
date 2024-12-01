using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class RepairConfigFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs");

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("4cc33924-7d41-4f6d-9e52-f7492cb0dadb"));

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("83177a0d-10b7-46e3-ab4a-fa9377e6544a"));

            migrationBuilder.InsertData(
                table: "IdentityRole<Guid>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01b72cdf-b484-4e82-819f-c75ad385f6db"), null, "Admin", "ADMIN" },
                    { new Guid("47df07d8-09ec-42f5-a76f-2faad680d059"), null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs",
                column: "StatusId",
                principalTable: "CarsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs");

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
                    { new Guid("4cc33924-7d41-4f6d-9e52-f7492cb0dadb"), null, "User", "USER" },
                    { new Guid("83177a0d-10b7-46e3-ab4a-fa9377e6544a"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs",
                column: "StatusId",
                principalTable: "CarsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

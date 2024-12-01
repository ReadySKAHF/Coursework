using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentRepairMechanicFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Mechanics_MechanicId",
                table: "Repairs");

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("68c39a66-14dc-4f53-ac6d-bc7dc66a3215"));

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("e12d8c9b-1919-4c21-8724-8349245644a6"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Mechanics_MechanicId",
                table: "Repairs",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Mechanics_MechanicId",
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
                    { new Guid("68c39a66-14dc-4f53-ac6d-bc7dc66a3215"), null, "Admin", "ADMIN" },
                    { new Guid("e12d8c9b-1919-4c21-8724-8349245644a6"), null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs",
                column: "StatusId",
                principalTable: "CarsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Mechanics_MechanicId",
                table: "Repairs",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

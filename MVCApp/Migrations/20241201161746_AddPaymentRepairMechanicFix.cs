using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentRepairMechanicFix : Migration
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
                keyValue: new Guid("6a93944f-465c-4a1c-ba6c-3a0c2c102b6a"));

            migrationBuilder.DeleteData(
                table: "IdentityRole<Guid>",
                keyColumn: "Id",
                keyValue: new Guid("a6ce952a-841b-4204-8d48-15fc2eaa5700"));

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
                    { new Guid("6a93944f-465c-4a1c-ba6c-3a0c2c102b6a"), null, "User", "USER" },
                    { new Guid("a6ce952a-841b-4204-8d48-15fc2eaa5700"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_CarsStatuses_StatusId",
                table: "Repairs",
                column: "StatusId",
                principalTable: "CarsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Mechanics_MechanicId",
                table: "Repairs",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

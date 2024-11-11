using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IndkobsOrdre",
                columns: new[] { "Id", "kundeNummer", "leverandorNummer", "ordreDato", "ordreDetaljer", "ordreNummer", "referenceDetaljer" },
                values: new object[,]
                {
                    { 3, "1", "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "2", null },
                    { 4, "1", "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "2", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

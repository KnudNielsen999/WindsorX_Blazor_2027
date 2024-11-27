using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaggrundsDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 1,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 10, 56, 19, 262, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 10, 56, 19, 262, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 10, 56, 19, 262, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 10, 56, 19, 262, DateTimeKind.Local).AddTicks(4693));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 1,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 9, 53, 36, 67, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 9, 53, 36, 67, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 9, 53, 36, 67, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ordreDato",
                value: new DateTime(2024, 11, 27, 9, 53, 36, 67, DateTimeKind.Local).AddTicks(7277));
        }
    }
}

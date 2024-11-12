using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaggrundsDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class demo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaktioner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProduktNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProduktAntal = table.Column<double>(type: "float", nullable: true),
                    TransaktionsDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransaktionsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdreNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrugerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaktioner", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 1,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 10, 31, 17, 68, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 10, 31, 17, 68, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 10, 31, 17, 68, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 10, 31, 17, 68, DateTimeKind.Local).AddTicks(2093));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaktioner");

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 1,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 9, 41, 26, 45, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 9, 41, 26, 45, DateTimeKind.Local).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 9, 41, 26, 45, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "IndkobsOrdre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ordreDato",
                value: new DateTime(2024, 11, 12, 9, 41, 26, 45, DateTimeKind.Local).AddTicks(6692));
        }
    }
}

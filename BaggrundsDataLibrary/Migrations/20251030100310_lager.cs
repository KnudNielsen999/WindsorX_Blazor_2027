using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaggrundsDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class lager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndkobsOrdre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordreNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kundeNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ordreDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ordreDetaljer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referenceDetaljer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    leverandorNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndkobsOrdre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LagerData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vareNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vareTekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vareMaengde = table.Column<double>(type: "float", nullable: true),
                    enheder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kostPris = table.Column<double>(type: "float", nullable: true),
                    maxLager = table.Column<double>(type: "float", nullable: true),
                    minLager = table.Column<double>(type: "float", nullable: true),
                    salgsPris = table.Column<double>(type: "float", nullable: true),
                    location1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    oprDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sidsteLagerBevDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sidsteBestillingsDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bestiltAntal = table.Column<double>(type: "float", nullable: true),
                    lagerOptaltDato = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LagerData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leverandorer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leverandorNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firmanavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    byNavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefonNummer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefonNummer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kontaktPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kontaktOplysninger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverandorer", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "OrdreLinjer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leverandørNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vareNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vareTekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ordreAntal = table.Column<double>(type: "float", nullable: true),
                    enheder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kostPris = table.Column<double>(type: "float", nullable: true),
                    IndkobModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdreLinjer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                        column: x => x.IndkobModelId,
                        principalTable: "IndkobsOrdre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IndkobsOrdre",
                columns: new[] { "Id", "kundeNummer", "leverandorNummer", "open", "ordreDato", "ordreDetaljer", "ordreNummer", "referenceDetaljer" },
                values: new object[,]
                {
                    { 1, "1", "1", true, new DateTime(2025, 10, 30, 11, 3, 8, 137, DateTimeKind.Local).AddTicks(3595), null, "1", null },
                    { 2, "1", "1", true, new DateTime(2025, 10, 30, 11, 3, 8, 137, DateTimeKind.Local).AddTicks(3636), null, "1", null },
                    { 3, "1", "1", true, new DateTime(2025, 10, 30, 11, 3, 8, 137, DateTimeKind.Local).AddTicks(3639), null, "2", null },
                    { 4, "1", "1", true, new DateTime(2025, 10, 30, 11, 3, 8, 137, DateTimeKind.Local).AddTicks(3641), null, "2", null }
                });

            migrationBuilder.InsertData(
                table: "LagerData",
                columns: new[] { "Id", "bestiltAntal", "enheder", "kostPris", "lagerOptaltDato", "location1", "location2", "maxLager", "minLager", "oprDato", "salgsPris", "sidsteBestillingsDato", "sidsteLagerBevDato", "vareMaengde", "vareNummer", "vareTekst" },
                values: new object[,]
                {
                    { 3, 0.0, "stk", 2500.0, null, null, null, 1.0, 0.0, null, null, null, null, 1.0, "2", "Motor" },
                    { 4, 0.0, "mtr", 150.0, null, null, null, 5.0, 1.0, null, null, null, null, 5.0, "4", "gevind" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdreLinjer_IndkobModelId",
                table: "OrdreLinjer",
                column: "IndkobModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LagerData");

            migrationBuilder.DropTable(
                name: "Leverandorer");

            migrationBuilder.DropTable(
                name: "OrdreLinjer");

            migrationBuilder.DropTable(
                name: "Transaktioner");

            migrationBuilder.DropTable(
                name: "IndkobsOrdre");
        }
    }
}

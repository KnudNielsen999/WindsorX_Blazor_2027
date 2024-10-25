using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    sidsteBesstillingsDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bestiltAntal = table.Column<double>(type: "float", nullable: true),
                    lagerOptaltDato = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LagerData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LagerData");
        }
    }
}

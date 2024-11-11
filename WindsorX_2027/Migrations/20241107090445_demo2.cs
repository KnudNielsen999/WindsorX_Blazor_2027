using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LagerData",
                columns: new[] { "Id", "bestiltAntal", "enheder", "kostPris", "lagerOptaltDato", "location1", "location2", "maxLager", "minLager", "oprDato", "salgsPris", "sidsteBesstillingsDato", "sidsteLagerBevDato", "vareMaengde", "vareNummer", "vareTekst" },
                values: new object[,]
                {
                    { 3, null, "stk", 2500.0, null, null, null, 1.0, 0.0, null, null, null, null, 1.0, "2", "Motor" },
                    { 4, null, "mtr", 150.0, null, null, null, 5.0, 1.0, null, null, null, null, 5.0, "4", "gevind" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LagerData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LagerData",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

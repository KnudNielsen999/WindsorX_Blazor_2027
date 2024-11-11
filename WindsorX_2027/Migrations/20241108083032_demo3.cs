using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ordrenummer",
                table: "OrdreLinjer",
                newName: "ordreNummerId");

            migrationBuilder.RenameColumn(
                name: "ordreNummer",
                table: "IndkobsOrdre",
                newName: "ordreNummerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ordreNummerId",
                table: "OrdreLinjer",
                newName: "ordrenummer");

            migrationBuilder.RenameColumn(
                name: "ordreNummerId",
                table: "IndkobsOrdre",
                newName: "ordreNummer");
        }
    }
}

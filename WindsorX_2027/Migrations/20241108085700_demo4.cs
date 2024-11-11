using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ordreNummerId",
                table: "OrdreLinjer");

            migrationBuilder.RenameColumn(
                name: "ordreNummerId",
                table: "IndkobsOrdre",
                newName: "ordreNummer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ordreNummer",
                table: "IndkobsOrdre",
                newName: "ordreNummerId");

            migrationBuilder.AddColumn<string>(
                name: "ordreNummerId",
                table: "OrdreLinjer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

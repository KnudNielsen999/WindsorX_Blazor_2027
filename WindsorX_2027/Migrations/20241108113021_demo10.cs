using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer",
                column: "IndkobModelId",
                principalTable: "IndkobsOrdre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer",
                column: "IndkobModelId",
                principalTable: "IndkobsOrdre",
                principalColumn: "Id");
        }
    }
}

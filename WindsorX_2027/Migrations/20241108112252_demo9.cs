using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindsorX_2027.Migrations
{
    /// <inheritdoc />
    public partial class demo9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer");

            migrationBuilder.AlterColumn<int>(
                name: "IndkobModelId",
                table: "OrdreLinjer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer",
                column: "IndkobModelId",
                principalTable: "IndkobsOrdre",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer");

            migrationBuilder.AlterColumn<int>(
                name: "IndkobModelId",
                table: "OrdreLinjer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdreLinjer_IndkobsOrdre_IndkobModelId",
                table: "OrdreLinjer",
                column: "IndkobModelId",
                principalTable: "IndkobsOrdre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

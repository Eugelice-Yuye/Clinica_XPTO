using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sexta_tentativa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utentes_Utilizadores_UtilizadorId",
                table: "Utentes");

            migrationBuilder.AlterColumn<int>(
                name: "UtilizadorId",
                table: "Utentes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Utentes_Utilizadores_UtilizadorId",
                table: "Utentes",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utentes_Utilizadores_UtilizadorId",
                table: "Utentes");

            migrationBuilder.AlterColumn<int>(
                name: "UtilizadorId",
                table: "Utentes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utentes_Utilizadores_UtilizadorId",
                table: "Utentes",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

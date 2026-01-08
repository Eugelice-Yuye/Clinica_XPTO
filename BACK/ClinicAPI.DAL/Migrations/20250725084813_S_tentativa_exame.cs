using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class S_tentativa_exame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Utilizadores_UtilizadorId",
                table: "Profissionais");

            migrationBuilder.AlterColumn<int>(
                name: "UtilizadorId",
                table: "Profissionais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Utilizadores_UtilizadorId",
                table: "Profissionais",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Utilizadores_UtilizadorId",
                table: "Profissionais");

            migrationBuilder.AlterColumn<int>(
                name: "UtilizadorId",
                table: "Profissionais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Utilizadores_UtilizadorId",
                table: "Profissionais",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class P_tentativa_exame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Profissionais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_UtilizadorId",
                table: "Profissionais",
                column: "UtilizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Utilizadores_UtilizadorId",
                table: "Profissionais",
                column: "UtilizadorId",
                principalTable: "Utilizadores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Utilizadores_UtilizadorId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_UtilizadorId",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Profissionais");
        }
    }
}

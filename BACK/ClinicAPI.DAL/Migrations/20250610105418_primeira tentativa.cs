using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class primeiratentativa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubsistemasSaude",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsistemasSaude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposServicosClinicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EExame = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposServicosClinicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUtilizador = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utentes_Utilizadores_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoMarcacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    DataInicioPreferencial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimPreferencial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioPreferencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotasAdicionais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoMarcacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoMarcacoes_Utentes_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActosClinicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoMarcacaoId = table.Column<int>(type: "int", nullable: false),
                    TipoServicoClinicoId = table.Column<int>(type: "int", nullable: false),
                    SubsistemaSaudeId = table.Column<int>(type: "int", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    DataAgendada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRealizada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActosClinicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActosClinicos_PedidoMarcacoes_PedidoMarcacaoId",
                        column: x => x.PedidoMarcacaoId,
                        principalTable: "PedidoMarcacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActosClinicos_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActosClinicos_SubsistemasSaude_SubsistemaSaudeId",
                        column: x => x.SubsistemaSaudeId,
                        principalTable: "SubsistemasSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActosClinicos_TiposServicosClinicos_TipoServicoClinicoId",
                        column: x => x.TipoServicoClinicoId,
                        principalTable: "TiposServicosClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActosClinicos_PedidoMarcacaoId",
                table: "ActosClinicos",
                column: "PedidoMarcacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActosClinicos_ProfissionalId",
                table: "ActosClinicos",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ActosClinicos_SubsistemaSaudeId",
                table: "ActosClinicos",
                column: "SubsistemaSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActosClinicos_TipoServicoClinicoId",
                table: "ActosClinicos",
                column: "TipoServicoClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoMarcacoes_UtenteId",
                table: "PedidoMarcacoes",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Utentes_UtilizadorId",
                table: "Utentes",
                column: "UtilizadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActosClinicos");

            migrationBuilder.DropTable(
                name: "PedidoMarcacoes");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "SubsistemasSaude");

            migrationBuilder.DropTable(
                name: "TiposServicosClinicos");

            migrationBuilder.DropTable(
                name: "Utentes");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}

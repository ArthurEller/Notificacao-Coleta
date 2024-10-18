using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificacaoColetaApi.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coleta",
                columns: table => new
                {
                    ColetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataColeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoResiduos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleta", x => x.ColetaId);
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    NotificacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColetaId = table.Column<int>(type: "int", nullable: true),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.NotificacaoId);
                    table.ForeignKey(
                        name: "FK_Notificacao_Coleta_ColetaId",
                        column: x => x.ColetaId,
                        principalTable: "Coleta",
                        principalColumn: "ColetaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_ColetaId",
                table: "Notificacao",
                column: "ColetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Coleta");
        }
    }
}

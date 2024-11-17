using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infra.Migrations
{
    /// <inheritdoc />
    public partial class create_consultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgendamentoId = table.Column<long>(type: "bigint", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DuracaoMinutos = table.Column<int>(type: "int", nullable: false),
                    TipoConsulta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_AgendamentoDoacoes_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "AgendamentoDoacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_AgendamentoId",
                table: "Consulta",
                column: "AgendamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");
        }
    }
}

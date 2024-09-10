using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infra.Migrations
{
    /// <inheritdoc />
    public partial class agendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoSanguineo",
                table: "EstoqueSangue",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoIdentificacao",
                table: "EstoqueSangue",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AgendamentoDoacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DoadorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoDoacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentoDoacoes_Doadores_DoadorId",
                        column: x => x.DoadorId,
                        principalTable: "Doadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoDoacoes_DoadorId",
                table: "AgendamentoDoacoes",
                column: "DoadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoDoacoes");

            migrationBuilder.AlterColumn<string>(
                name: "TipoSanguineo",
                table: "EstoqueSangue",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoIdentificacao",
                table: "EstoqueSangue",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}

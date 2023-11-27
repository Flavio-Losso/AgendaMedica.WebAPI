using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMedica.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class firstrun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAtividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipodeAtividade = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAtividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBMedico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimaAtividadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtividadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAtividade_TBMedico",
                        column: x => x.AtividadeId,
                        principalTable: "TBAtividade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBMedico_TBAtividade_UltimaAtividadeId",
                        column: x => x.UltimaAtividadeId,
                        principalTable: "TBAtividade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAtividade_MedicoId",
                table: "TBAtividade",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBMedico_AtividadeId",
                table: "TBMedico",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TBMedico_UltimaAtividadeId",
                table: "TBMedico",
                column: "UltimaAtividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAtividade_TBMedico_MedicoId",
                table: "TBAtividade",
                column: "MedicoId",
                principalTable: "TBMedico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAtividade_TBMedico_MedicoId",
                table: "TBAtividade");

            migrationBuilder.DropTable(
                name: "TBMedico");

            migrationBuilder.DropTable(
                name: "TBAtividade");
        }
    }
}

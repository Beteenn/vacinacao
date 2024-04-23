using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCardenetaVacina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardenetaVacina",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardenetaVacina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardenetaVacina_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacinaCardenetaVacina",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardenetaId = table.Column<long>(type: "bigint", nullable: false),
                    VacinaId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacinaCardenetaVacina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacinaCardenetaVacina_CardenetaVacina_CardenetaId",
                        column: x => x.CardenetaId,
                        principalTable: "CardenetaVacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacinaCardenetaVacina_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardenetaVacina_PessoaId",
                table: "CardenetaVacina",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacinaCardenetaVacina_CardenetaId",
                table: "VacinaCardenetaVacina",
                column: "CardenetaId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaCardenetaVacina_VacinaId",
                table: "VacinaCardenetaVacina",
                column: "VacinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacinaCardenetaVacina");

            migrationBuilder.DropTable(
                name: "CardenetaVacina");
        }
    }
}

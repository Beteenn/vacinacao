using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixAjustarelacionamentovacinas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoseVacinaCardeneta");

            migrationBuilder.DropTable(
                name: "VacinaCardenetaVacina");

            migrationBuilder.CreateTable(
                name: "Vacinacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardenetaId = table.Column<long>(type: "bigint", nullable: false),
                    VacinaId = table.Column<long>(type: "bigint", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroDose = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacinacao_CardenetaVacina_CardenetaId",
                        column: x => x.CardenetaId,
                        principalTable: "CardenetaVacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacinacao_Vacina_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacinacao_CardenetaId",
                table: "Vacinacao",
                column: "CardenetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacinacao_VacinaId",
                table: "Vacinacao",
                column: "VacinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacinacao");

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

            migrationBuilder.CreateTable(
                name: "DoseVacinaCardeneta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardenetaVacinaId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroDose = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoseVacinaCardeneta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoseVacinaCardeneta_VacinaCardenetaVacina_CardenetaVacinaId",
                        column: x => x.CardenetaVacinaId,
                        principalTable: "VacinaCardenetaVacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoseVacinaCardeneta_CardenetaVacinaId",
                table: "DoseVacinaCardeneta",
                column: "CardenetaVacinaId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaCardenetaVacina_CardenetaId",
                table: "VacinaCardenetaVacina",
                column: "CardenetaId");

            migrationBuilder.CreateIndex(
                name: "IX_VacinaCardenetaVacina_VacinaId",
                table: "VacinaCardenetaVacina",
                column: "VacinaId");
        }
    }
}

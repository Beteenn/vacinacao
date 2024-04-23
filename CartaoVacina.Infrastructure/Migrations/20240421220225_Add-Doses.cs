using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDoses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoseVacinaCardeneta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardenetaVacinaId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroDose = table.Column<int>(type: "int", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoseVacinaCardeneta");
        }
    }
}

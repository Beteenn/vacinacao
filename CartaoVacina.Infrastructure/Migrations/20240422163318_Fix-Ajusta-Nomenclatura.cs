using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixAjustaNomenclatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinacao_CardenetaVacina_CardenetaId",
                table: "Vacinacao");

            migrationBuilder.DropTable(
                name: "CardenetaVacina");

            migrationBuilder.RenameColumn(
                name: "CardenetaId",
                table: "Vacinacao",
                newName: "CadernetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacinacao_CardenetaId",
                table: "Vacinacao",
                newName: "IX_Vacinacao_CadernetaId");

            migrationBuilder.CreateTable(
                name: "CadernetaVacina",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadernetaVacina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CadernetaVacina_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadernetaVacina_PessoaId",
                table: "CadernetaVacina",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinacao_CadernetaVacina_CadernetaId",
                table: "Vacinacao",
                column: "CadernetaId",
                principalTable: "CadernetaVacina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinacao_CadernetaVacina_CadernetaId",
                table: "Vacinacao");

            migrationBuilder.DropTable(
                name: "CadernetaVacina");

            migrationBuilder.RenameColumn(
                name: "CadernetaId",
                table: "Vacinacao",
                newName: "CardenetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vacinacao_CadernetaId",
                table: "Vacinacao",
                newName: "IX_Vacinacao_CardenetaId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CardenetaVacina_PessoaId",
                table: "CardenetaVacina",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinacao_CardenetaVacina_CardenetaId",
                table: "Vacinacao",
                column: "CardenetaId",
                principalTable: "CardenetaVacina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

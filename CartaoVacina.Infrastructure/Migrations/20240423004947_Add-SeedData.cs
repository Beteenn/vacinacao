using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vacina",
                columns: ["Nome", "QuantidadeDoses", "QuantidadeReforcos"],
                values: new object[,] { { "BCG", 1, 1 }, { "Hepatite B", 3, 1 }, { "Triplice Acelular", 3, 2 } });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: ["Nome"],
                values: new object[,]{ { "João" }, { "Maria" } });

            migrationBuilder.InsertData(
                table: "CadernetaVacina",
                columns: ["PessoaId"],
                values: new object[,] { { 1 }, { 2 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

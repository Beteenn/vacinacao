using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoDoseVacinacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDose",
                table: "Vacinacao",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDose",
                table: "Vacinacao");
        }
    }
}

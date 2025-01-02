using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contatos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTelefoneMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Contatos");

            migrationBuilder.AddColumn<string>(
                name: "Ddd",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ddd",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Contatos");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Contatos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}

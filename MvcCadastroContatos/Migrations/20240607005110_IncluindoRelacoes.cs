using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class IncluindoRelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_usuarioId",
                table: "Contatos",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_usuarioId",
                table: "Contatos",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_usuarioId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_usuarioId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Contatos");
        }
    }
}

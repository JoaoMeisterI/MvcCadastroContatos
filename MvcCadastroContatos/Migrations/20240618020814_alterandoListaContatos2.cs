using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class alterandoListaContatos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioModelId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_UsuarioModelId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "Contatos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Contatos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_UsuarioModelId",
                table: "Contatos",
                column: "UsuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioModelId",
                table: "Contatos",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

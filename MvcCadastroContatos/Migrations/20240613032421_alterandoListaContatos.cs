using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class alterandoListaContatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_usuarioId",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Contatos",
                newName: "UsuarioModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_usuarioId",
                table: "Contatos",
                newName: "IX_Contatos_UsuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioModelId",
                table: "Contatos",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioModelId",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "UsuarioModelId",
                table: "Contatos",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_UsuarioModelId",
                table: "Contatos",
                newName: "IX_Contatos_usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_usuarioId",
                table: "Contatos",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

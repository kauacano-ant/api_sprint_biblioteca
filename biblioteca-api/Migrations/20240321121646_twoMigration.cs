using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_api.Migrations
{
    /// <inheritdoc />
    public partial class twoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_LivroId1",
                table: "Emprestimo");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Usuarios_UsuarioId1",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_LivroId1",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_UsuarioId1",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "LivroId1",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Emprestimo");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LivroId",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LivroId",
                table: "Emprestimo",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_UsuarioId",
                table: "Emprestimo",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_LivroId",
                table: "Emprestimo",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Usuarios_UsuarioId",
                table: "Emprestimo",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_LivroId",
                table: "Emprestimo");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Usuarios_UsuarioId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_LivroId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_UsuarioId",
                table: "Emprestimo");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Emprestimo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "Emprestimo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LivroId1",
                table: "Emprestimo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Emprestimo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LivroId1",
                table: "Emprestimo",
                column: "LivroId1");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_UsuarioId1",
                table: "Emprestimo",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_LivroId1",
                table: "Emprestimo",
                column: "LivroId1",
                principalTable: "Livro",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Usuarios_UsuarioId1",
                table: "Emprestimo",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

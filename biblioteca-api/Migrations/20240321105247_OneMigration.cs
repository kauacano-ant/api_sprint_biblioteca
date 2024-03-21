using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_api.Migrations
{
    /// <inheritdoc />
    public partial class OneMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AnoFundacao = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AnoPublicacao = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    ISBN = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EditoraModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Editora_EditoraModelId",
                        column: x => x.EditoraModelId,
                        principalTable: "Editora",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pontuacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataAvaliacao = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmprestimo = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    DataDevolucao = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    LivroId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId1 = table.Column<int>(type: "int", nullable: true),
                    LivroId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_LivroId1",
                        column: x => x.LivroId1,
                        principalTable: "Livro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emprestimo_Usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataReserva = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_LivroId",
                table: "Avaliacao",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_UsuarioId",
                table: "Avaliacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LivroId1",
                table: "Emprestimo",
                column: "LivroId1");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_UsuarioId1",
                table: "Emprestimo",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EditoraModelId",
                table: "Livro",
                column: "EditoraModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_LivroId",
                table: "Reserva",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UsuarioId",
                table: "Reserva",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Editora");
        }
    }
}

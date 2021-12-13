using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Data.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoas",
                columns: table => new
                {
                    idPessoa = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoas", x => x.idPessoa);
                });

            migrationBuilder.CreateTable(
                name: "contas",
                columns: table => new
                {
                    idConta = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPessoa = table.Column<long>(type: "bigint", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    limiteSaqueDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    flagAtivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    tipoConta = table.Column<int>(type: "int", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contas", x => x.idConta);
                    table.ForeignKey(
                        name: "FK_contas_pessoas_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "pessoas",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    idLogin = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPessoa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.idLogin);
                    table.ForeignKey(
                        name: "FK_logins_pessoas_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "pessoas",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transacoes",
                columns: table => new
                {
                    idTransacao = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idConta = table.Column<long>(type: "bigint", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dataTransacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacoes", x => x.idTransacao);
                    table.ForeignKey(
                        name: "FK_transacoes_contas_idConta",
                        column: x => x.idConta,
                        principalTable: "contas",
                        principalColumn: "idConta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contas_idPessoa",
                table: "contas",
                column: "idPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_logins_idPessoa",
                table: "logins",
                column: "idPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transacoes_idConta",
                table: "transacoes",
                column: "idConta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "transacoes");

            migrationBuilder.DropTable(
                name: "contas");

            migrationBuilder.DropTable(
                name: "pessoas");
        }
    }
}

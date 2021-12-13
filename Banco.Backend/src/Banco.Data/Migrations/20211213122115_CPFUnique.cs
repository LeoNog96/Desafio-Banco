using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Data.Migrations
{
    public partial class CPFUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "pessoas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoas_cpf",
                table: "pessoas",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pessoas_cpf",
                table: "pessoas");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "pessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

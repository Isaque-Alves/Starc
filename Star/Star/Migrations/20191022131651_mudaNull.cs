using Microsoft.EntityFrameworkCore.Migrations;

namespace Star.Migrations
{
    public partial class mudaNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Cadastros_CadastroId",
                table: "Componentes");

            migrationBuilder.AlterColumn<int>(
                name: "CadastroId",
                table: "Componentes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Cadastros_CadastroId",
                table: "Componentes",
                column: "CadastroId",
                principalTable: "Cadastros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Cadastros_CadastroId",
                table: "Componentes");

            migrationBuilder.AlterColumn<int>(
                name: "CadastroId",
                table: "Componentes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Cadastros_CadastroId",
                table: "Componentes",
                column: "CadastroId",
                principalTable: "Cadastros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

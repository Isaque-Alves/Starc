using Microsoft.EntityFrameworkCore.Migrations;

namespace Star.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponenteGrupos_Componentes_ComponenteId",
                table: "ComponenteGrupos");

            migrationBuilder.DropColumn(
                name: "TipoComponenteId",
                table: "ComponenteGrupos");

            migrationBuilder.AlterColumn<int>(
                name: "ComponenteId",
                table: "ComponenteGrupos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponenteGrupos_Componentes_ComponenteId",
                table: "ComponenteGrupos",
                column: "ComponenteId",
                principalTable: "Componentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponenteGrupos_Componentes_ComponenteId",
                table: "ComponenteGrupos");

            migrationBuilder.AlterColumn<int>(
                name: "ComponenteId",
                table: "ComponenteGrupos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoComponenteId",
                table: "ComponenteGrupos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponenteGrupos_Componentes_ComponenteId",
                table: "ComponenteGrupos",
                column: "ComponenteId",
                principalTable: "Componentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

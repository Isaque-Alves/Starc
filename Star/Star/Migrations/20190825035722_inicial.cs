using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Star.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    HorarioInicial = table.Column<DateTime>(nullable: false),
                    HorarioFinal = table.Column<DateTime>(nullable: false),
                    Segunda = table.Column<bool>(nullable: false),
                    Terca = table.Column<bool>(nullable: false),
                    Quarta = table.Column<bool>(nullable: false),
                    Quinta = table.Column<bool>(nullable: false),
                    Sexta = table.Column<bool>(nullable: false),
                    Sabado = table.Column<bool>(nullable: false),
                    Domingo = table.Column<bool>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoComponentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComponentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CadastroId = table.Column<int>(nullable: false),
                    TipoComponenteId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componentes_Cadastros_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componentes_TipoComponentes_TipoComponenteId",
                        column: x => x.TipoComponenteId,
                        principalTable: "TipoComponentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CadastroId = table.Column<int>(nullable: false),
                    TipoUsuarioId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cadastros_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteGrupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrupoId = table.Column<int>(nullable: false),
                    TipoComponenteId = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteGrupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponenteGrupos_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponenteGrupos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteGrupos_ComponenteId",
                table: "ComponenteGrupos",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteGrupos_GrupoId",
                table: "ComponenteGrupos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_CadastroId",
                table: "Componentes",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_TipoComponenteId",
                table: "Componentes",
                column: "TipoComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_ComponenteId",
                table: "Registros",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_UsuarioId",
                table: "Registros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CadastroId",
                table: "Usuarios",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteGrupos");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoComponentes");

            migrationBuilder.DropTable(
                name: "Cadastros");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}

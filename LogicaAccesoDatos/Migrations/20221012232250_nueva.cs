using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    FechaIncio = table.Column<DateTime>(nullable: false),
                    FechaFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    FaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    CodigoISOAlfa3 = table.Column<string>(nullable: false),
                    Pbi = table.Column<double>(nullable: false),
                    Poblacion = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paises_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Selecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    CantidadApostadores = table.Column<int>(nullable: false),
                    IdGrupo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selecciones_Grupos_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selecciones_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoUnoId = table.Column<int>(nullable: false),
                    EquipoDosId = table.Column<int>(nullable: true),
                    EquipDosId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<int>(nullable: false),
                    CantidadGolesEquipoUno = table.Column<int>(nullable: false),
                    CantidadGolesEquipoDos = table.Column<int>(nullable: false),
                    PuntajeEquipoUno = table.Column<int>(nullable: false),
                    PuntajeEquipoDos = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_Selecciones_EquipoDosId",
                        column: x => x.EquipoDosId,
                        principalTable: "Selecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Selecciones_EquipoUnoId",
                        column: x => x.EquipoUnoId,
                        principalTable: "Selecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(maxLength: 25, nullable: false),
                    SeleccionId = table.Column<int>(nullable: false),
                    PartidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Selecciones_SeleccionId",
                        column: x => x.SeleccionId,
                        principalTable: "Selecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_FaseId",
                table: "Grupos",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_RegionId",
                table: "Paises",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoDosId",
                table: "Partidos",
                column: "EquipoDosId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoUnoId",
                table: "Partidos",
                column: "EquipoUnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_GrupoId",
                table: "Partidos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_IdGrupo",
                table: "Selecciones",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_PaisId",
                table: "Selecciones",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_PartidoId",
                table: "Tarjetas",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_SeleccionId",
                table: "Tarjetas",
                column: "SeleccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Selecciones");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "Regiones");
        }
    }
}

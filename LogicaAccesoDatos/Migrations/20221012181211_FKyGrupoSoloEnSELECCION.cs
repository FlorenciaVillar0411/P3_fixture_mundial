using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class FKyGrupoSoloEnSELECCION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Fases_FaseId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Selecciones_Grupos_GrupoId",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Selecciones_GrupoId",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_FaseId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Selecciones");

            migrationBuilder.DropColumn(
                name: "FaseId",
                table: "Partidos");

            migrationBuilder.AddColumn<int>(
                name: "IdGrupo",
                table: "Selecciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipoDos",
                table: "Partidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipoUno",
                table: "Partidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FaseId",
                table: "Grupos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Grupos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_IdGrupo",
                table: "Selecciones",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_FaseId",
                table: "Grupos",
                column: "FaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Fases_FaseId",
                table: "Grupos",
                column: "FaseId",
                principalTable: "Fases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selecciones_Grupos_IdGrupo",
                table: "Selecciones",
                column: "IdGrupo",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Fases_FaseId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Selecciones_Grupos_IdGrupo",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Selecciones_IdGrupo",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_FaseId",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "IdGrupo",
                table: "Selecciones");

            migrationBuilder.DropColumn(
                name: "IdEquipoDos",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IdEquipoUno",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "FaseId",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Grupos");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Selecciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FaseId",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_GrupoId",
                table: "Selecciones",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_FaseId",
                table: "Partidos",
                column: "FaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Fases_FaseId",
                table: "Partidos",
                column: "FaseId",
                principalTable: "Fases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Selecciones_Grupos_GrupoId",
                table: "Selecciones",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

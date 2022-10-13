using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class sacarpartidegrup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Grupos_GrupoId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_GrupoId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Partidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_GrupoId",
                table: "Partidos",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Grupos_GrupoId",
                table: "Partidos",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

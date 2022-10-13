using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_EquipoUnoId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "EquipoUnoId",
                table: "Partidos");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_IdEquipoDos",
                table: "Partidos",
                column: "IdEquipoDos");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_IdEquipoUno",
                table: "Partidos",
                column: "IdEquipoUno");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_IdEquipoDos",
                table: "Partidos",
                column: "IdEquipoDos",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_IdEquipoUno",
                table: "Partidos",
                column: "IdEquipoUno",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_IdEquipoDos",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_IdEquipoUno",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_IdEquipoDos",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_IdEquipoUno",
                table: "Partidos");

            migrationBuilder.AddColumn<int>(
                name: "EquipoDosId",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipoUnoId",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoDosId",
                table: "Partidos",
                column: "EquipoDosId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoUnoId",
                table: "Partidos",
                column: "EquipoUnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos",
                column: "EquipoDosId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos",
                column: "EquipoUnoId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

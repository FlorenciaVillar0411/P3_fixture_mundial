using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class fks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IdEquipoDos",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IdEquipoUno",
                table: "Partidos");

            migrationBuilder.AddColumn<int>(
                name: "Seleccion",
                table: "Partidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Seleccion",
                table: "Partidos",
                column: "Seleccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_Seleccion",
                table: "Partidos",
                column: "Seleccion",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_Seleccion",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_Seleccion",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Seleccion",
                table: "Partidos");

            migrationBuilder.AddColumn<int>(
                name: "EquipoDosId",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipoDos",
                table: "Partidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipoUno",
                table: "Partidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoDosId",
                table: "Partidos",
                column: "EquipoDosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos",
                column: "EquipoDosId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

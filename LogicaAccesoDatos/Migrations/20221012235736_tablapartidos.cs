using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class tablapartidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoUnoId",
                table: "Partidos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoDosId",
                table: "Partidos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoUnoId",
                table: "Partidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipoDosId",
                table: "Partidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos",
                column: "EquipoDosId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos",
                column: "EquipoUnoId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

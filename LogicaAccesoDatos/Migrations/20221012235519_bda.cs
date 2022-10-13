using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class bda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_Seleccion",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Partidos_PartidoId",
                table: "Tarjetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Selecciones_SeleccionId",
                table: "Tarjetas");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_Seleccion",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Seleccion",
                table: "Partidos");

            migrationBuilder.AlterColumn<int>(
                name: "SeleccionId",
                table: "Tarjetas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartidoId",
                table: "Tarjetas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipoUnoId",
                table: "Partidos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipoDosId",
                table: "Partidos",
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos",
                column: "EquipoUnoId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Partidos_PartidoId",
                table: "Tarjetas",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Selecciones_SeleccionId",
                table: "Tarjetas",
                column: "SeleccionId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Partidos_PartidoId",
                table: "Tarjetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Selecciones_SeleccionId",
                table: "Tarjetas");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_EquipoDosId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "EquipoDosId",
                table: "Partidos");

            migrationBuilder.AlterColumn<int>(
                name: "SeleccionId",
                table: "Tarjetas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PartidoId",
                table: "Tarjetas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EquipoUnoId",
                table: "Partidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Seleccion",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Seleccion",
                table: "Partidos",
                column: "Seleccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_EquipoUnoId",
                table: "Partidos",
                column: "EquipoUnoId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Selecciones_Seleccion",
                table: "Partidos",
                column: "Seleccion",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Partidos_PartidoId",
                table: "Tarjetas",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Selecciones_SeleccionId",
                table: "Tarjetas",
                column: "SeleccionId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Partidos_PartidoId",
                table: "Tarjetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Selecciones_SeleccionId",
                table: "Tarjetas");

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
                name: "FK_Tarjetas_Partidos_PartidoId",
                table: "Tarjetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Selecciones_SeleccionId",
                table: "Tarjetas");

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

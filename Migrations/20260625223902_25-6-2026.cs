using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Facturacion_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class _2562026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Usuarios_UsuarioIdUsuario",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Facturas_FacturaIdFactura",
                table: "Pagos");

            migrationBuilder.AlterColumn<int>(
                name: "FacturaIdFactura",
                table: "Pagos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Facturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Usuarios_UsuarioIdUsuario",
                table: "Facturas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Facturas_FacturaIdFactura",
                table: "Pagos",
                column: "FacturaIdFactura",
                principalTable: "Facturas",
                principalColumn: "IdFactura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Usuarios_UsuarioIdUsuario",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Facturas_FacturaIdFactura",
                table: "Pagos");

            migrationBuilder.AlterColumn<int>(
                name: "FacturaIdFactura",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Usuarios_UsuarioIdUsuario",
                table: "Facturas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Facturas_FacturaIdFactura",
                table: "Pagos",
                column: "FacturaIdFactura",
                principalTable: "Facturas",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

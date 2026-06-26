using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Facturacion_Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesNuevos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Servicios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

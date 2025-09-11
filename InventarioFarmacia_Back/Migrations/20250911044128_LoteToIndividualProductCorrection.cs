using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class LoteToIndividualProductCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Productos_Id_Producto",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_Id_Categoria",
                table: "Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Productos_Id_Producto",
                table: "Lotes",
                column: "Id_Producto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_Id_Categoria",
                table: "Productos",
                column: "Id_Categoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Productos_Id_Producto",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_Id_Categoria",
                table: "Productos");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Productos_Id_Producto",
                table: "Lotes",
                column: "Id_Producto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_Id_Categoria",
                table: "Productos",
                column: "Id_Categoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

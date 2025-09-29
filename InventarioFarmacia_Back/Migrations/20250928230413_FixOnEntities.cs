using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class FixOnEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Individuales_Productos_Id_Producto",
                table: "Productos_Individuales");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Individuales_Id_Producto",
                table: "Productos_Individuales");

            migrationBuilder.DropColumn(
                name: "Id_Producto",
                table: "Productos_Individuales");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Productos_Individuales",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Lotes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_ProductoId",
                table: "Productos_Individuales",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_InventarioId",
                table: "Lotes",
                column: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Inventarios_InventarioId",
                table: "Lotes",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Individuales_Productos_ProductoId",
                table: "Productos_Individuales",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Inventarios_InventarioId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Individuales_Productos_ProductoId",
                table: "Productos_Individuales");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Individuales_ProductoId",
                table: "Productos_Individuales");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_InventarioId",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Productos_Individuales");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Lotes");

            migrationBuilder.AddColumn<int>(
                name: "Id_Producto",
                table: "Productos_Individuales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Id_Producto",
                table: "Productos_Individuales",
                column: "Id_Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Individuales_Productos_Id_Producto",
                table: "Productos_Individuales",
                column: "Id_Producto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

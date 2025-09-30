using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class LoteToInventoryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Id_LastOrdenCompra",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Lotes");

            migrationBuilder.CreateTable(
                name: "InventarioLote",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    LotesDeProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioLote", x => new { x.InventarioId, x.LotesDeProductoId });
                    table.ForeignKey(
                        name: "FK_InventarioLote_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioLote_Lotes_LotesDeProductoId",
                        column: x => x.LotesDeProductoId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventarioLote_LotesDeProductoId",
                table: "InventarioLote",
                column: "LotesDeProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioLote");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Productos_Individuales",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_LastOrdenCompra",
                table: "Lotes",
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
    }
}

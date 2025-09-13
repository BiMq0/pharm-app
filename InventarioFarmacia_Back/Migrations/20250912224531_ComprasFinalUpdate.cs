using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class ComprasFinalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Compras");

            migrationBuilder.AddColumn<int>(
                name: "Id_OrdenCompra",
                table: "Productos_Individuales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_LastOrdenCompra",
                table: "Lotes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrdenCompraLote",
                columns: table => new
                {
                    LotesInvolucradosId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdenesCompraId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompraLote", x => new { x.LotesInvolucradosId, x.OrdenesCompraId });
                    table.ForeignKey(
                        name: "FK_OrdenCompraLote_Lotes_LotesInvolucradosId",
                        column: x => x.LotesInvolucradosId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenCompraLote_Orden_Compras_OrdenesCompraId",
                        column: x => x.OrdenesCompraId,
                        principalTable: "Orden_Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Id_OrdenCompra",
                table: "Productos_Individuales",
                column: "Id_OrdenCompra");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraLote_OrdenesCompraId",
                table: "OrdenCompraLote",
                column: "OrdenesCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Individuales_Orden_Compras_Id_OrdenCompra",
                table: "Productos_Individuales",
                column: "Id_OrdenCompra",
                principalTable: "Orden_Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Individuales_Orden_Compras_Id_OrdenCompra",
                table: "Productos_Individuales");

            migrationBuilder.DropTable(
                name: "OrdenCompraLote");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Individuales_Id_OrdenCompra",
                table: "Productos_Individuales");

            migrationBuilder.DropColumn(
                name: "Id_OrdenCompra",
                table: "Productos_Individuales");

            migrationBuilder.DropColumn(
                name: "Id_LastOrdenCompra",
                table: "Lotes");

            migrationBuilder.CreateTable(
                name: "Detalle_Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_OrdenDeCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_ProductoIndividual = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_Compras_Orden_Compras_Id_OrdenDeCompra",
                        column: x => x.Id_OrdenDeCompra,
                        principalTable: "Orden_Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Compras_Productos_Individuales_Id_ProductoIndividual",
                        column: x => x.Id_ProductoIndividual,
                        principalTable: "Productos_Individuales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Id_OrdenDeCompra",
                table: "Detalle_Compras",
                column: "Id_OrdenDeCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Id_ProductoIndividual",
                table: "Detalle_Compras",
                column: "Id_ProductoIndividual",
                unique: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class NtoMRelationInLotesToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioLote_Inventarios_InventarioId",
                table: "InventarioLote");

            migrationBuilder.RenameColumn(
                name: "InventarioId",
                table: "InventarioLote",
                newName: "InventariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioLote_Inventarios_InventariosId",
                table: "InventarioLote",
                column: "InventariosId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioLote_Inventarios_InventariosId",
                table: "InventarioLote");

            migrationBuilder.RenameColumn(
                name: "InventariosId",
                table: "InventarioLote",
                newName: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioLote_Inventarios_InventarioId",
                table: "InventarioLote",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

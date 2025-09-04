using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class ShopDTOSModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Individuales_Lotes_Nro_Lote",
                table: "Productos_Individuales");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Individuales_Nro_Lote",
                table: "Productos_Individuales");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Lotes_Nro_Lote",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Fecha_Vencimiento",
                table: "Productos_Individuales");

            migrationBuilder.DropColumn(
                name: "Nro_Lote",
                table: "Productos_Individuales");

            migrationBuilder.AddColumn<int>(
                name: "Id_Lote",
                table: "Productos_Individuales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Fecha_Vencimiento",
                table: "Lotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Id_Producto",
                table: "Lotes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Nro_Lote",
                table: "Productos_Individuales",
                column: "Id_Lote");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_Id_Producto",
                table: "Lotes",
                column: "Id_Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Productos_Id_Producto",
                table: "Lotes",
                column: "Id_Producto",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Individuales_Lotes_Id_Lote",
                table: "Productos_Individuales",
                column: "Id_Lote",
                principalTable: "Lotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Productos_Id_Producto",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Individuales_Lotes_Id_Lote",
                table: "Productos_Individuales");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Individuales_Nro_Lote",
                table: "Productos_Individuales");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_Id_Producto",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Id_Lote",
                table: "Productos_Individuales");

            migrationBuilder.DropColumn(
                name: "Fecha_Vencimiento",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Id_Producto",
                table: "Lotes");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Fecha_Vencimiento",
                table: "Productos_Individuales",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Nro_Lote",
                table: "Productos_Individuales",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Lotes_Nro_Lote",
                table: "Lotes",
                column: "Nro_Lote");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Nro_Lote",
                table: "Productos_Individuales",
                column: "Nro_Lote");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Individuales_Lotes_Nro_Lote",
                table: "Productos_Individuales",
                column: "Nro_Lote",
                principalTable: "Lotes",
                principalColumn: "Nro_Lote",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

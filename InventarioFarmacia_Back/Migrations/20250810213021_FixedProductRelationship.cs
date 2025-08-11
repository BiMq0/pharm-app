using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioFarmacia_Back.Migrations
{
    /// <inheritdoc />
    public partial class FixedProductRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Ruta_Imagen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Total_Productos = table.Column<int>(type: "INTEGER", nullable: false),
                    Ultima_Actualizacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nro_Lote = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.UniqueConstraint("AK_Lotes_Nro_Lote", x => x.Nro_Lote);
                });

            migrationBuilder.CreateTable(
                name: "Orden_Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha_Pedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fecha_Recibo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Categoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre_Clinico = table.Column<string>(type: "TEXT", nullable: true),
                    Ruta_Imagen = table.Column<string>(type: "TEXT", nullable: true),
                    Precio_Unitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precio_Caja = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bitacora_Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Inventario = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Usuario = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo_Accion = table.Column<string>(type: "TEXT", nullable: true),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha_Actualizacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora_Inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bitacora_Inventarios_Inventarios_Id_Inventario",
                        column: x => x.Id_Inventario,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bitacora_Inventarios_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bitacora_Inventarios_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Usuario = table.Column<int>(type: "INTEGER", nullable: true),
                    Fecha_Venta = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Cantidad_Productos = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo_Total = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Bitacora_Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Producto = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Usuario = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha_Cambio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Campo_Modificado = table.Column<string>(type: "TEXT", nullable: true),
                    Valor_Anterior = table.Column<string>(type: "TEXT", nullable: true),
                    Valor_Nuevo = table.Column<string>(type: "TEXT", nullable: true),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bitacora_Productos_Productos_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bitacora_Productos_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Productos_Individuales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Producto = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Inventario = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha_Vencimiento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Nro_Lote = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos_Individuales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Individuales_Inventarios_Id_Inventario",
                        column: x => x.Id_Inventario,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Individuales_Lotes_Nro_Lote",
                        column: x => x.Nro_Lote,
                        principalTable: "Lotes",
                        principalColumn: "Nro_Lote",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Productos_Individuales_Productos_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Venta = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Producto = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Descuento = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_Ventas_Productos_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Ventas_Ventas_Id_Venta",
                        column: x => x.Id_Venta,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Bitacora_Inventarios_Id_Inventario",
                table: "Bitacora_Inventarios",
                column: "Id_Inventario");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Inventarios_Id_Usuario",
                table: "Bitacora_Inventarios",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Inventarios_InventarioId",
                table: "Bitacora_Inventarios",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Productos_Id_Producto",
                table: "Bitacora_Productos",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Productos_Id_Usuario",
                table: "Bitacora_Productos",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Id_OrdenDeCompra",
                table: "Detalle_Compras",
                column: "Id_OrdenDeCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Id_ProductoIndividual",
                table: "Detalle_Compras",
                column: "Id_ProductoIndividual",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Ventas_Id_Producto",
                table: "Detalle_Ventas",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Ventas_Id_Venta",
                table: "Detalle_Ventas",
                column: "Id_Venta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Id_Categoria",
                table: "Productos",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Id_Inventario",
                table: "Productos_Individuales",
                column: "Id_Inventario");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Id_Producto",
                table: "Productos_Individuales",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Individuales_Nro_Lote",
                table: "Productos_Individuales",
                column: "Nro_Lote");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Id_Usuario",
                table: "Ventas",
                column: "Id_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora_Inventarios");

            migrationBuilder.DropTable(
                name: "Bitacora_Productos");

            migrationBuilder.DropTable(
                name: "Detalle_Compras");

            migrationBuilder.DropTable(
                name: "Detalle_Ventas");

            migrationBuilder.DropTable(
                name: "Orden_Compras");

            migrationBuilder.DropTable(
                name: "Productos_Individuales");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}

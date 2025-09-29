using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;
namespace InventarioFarmacia_Domain.Models;

public class Lote
{
    public int Id { get; set; }
    public int Id_Producto { get; set; }
    public DateOnly Fecha_Vencimiento { get; set; }
    public string Nro_Lote { get; set; } = null!;
    public ICollection<Producto_Individual>? ProductosIndividuales { get; set; }
    public Producto Producto { get; set; } = null!;
    public ICollection<Orden_Compra>? OrdenesCompra { get; set; }

    [NotMapped]
    public int CantidadProductos => ProductosIndividuales?.Count ?? 0;

    [NotMapped]
    public int CantidadProductosDisponibles => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? 0;

    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosDisponibles =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? Enumerable.Empty<Producto_Individual>();

    [NotMapped]
    public int CantidadProductosPorVencer => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.POR_VENCER) ?? 0;

    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosPorVencer =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.POR_VENCER) ?? Enumerable.Empty<Producto_Individual>();

    [NotMapped]
    public int CantidadProductosVendidos => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO) ?? 0;

    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosVendidos =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO) ?? Enumerable.Empty<Producto_Individual>();

    [NotMapped]
    public int CantidadProductosVencidos => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.VENCIDO) ?? 0;
    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosVencidos =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.VENCIDO) ?? Enumerable.Empty<Producto_Individual>();

    [NotMapped]
    public int CantidadProductosPendientes => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.PENDIENTE) ?? 0;
    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosPendientes =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.PENDIENTE) ?? Enumerable.Empty<Producto_Individual>();
}

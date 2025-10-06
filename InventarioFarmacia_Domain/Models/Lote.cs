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
    public ICollection<Inventario>? Inventarios { get; set; }

    [NotMapped]
    public int CantidadProductos => ProductosIndividuales?.Count ?? 0;

    [NotMapped]
    public int CantidadProductosDisponibles => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? 0;
    [NotMapped]
    public int CantidadProductosVendidos => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO) ?? 0;
    [NotMapped]
    public int CantidadProductosPendientes => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.PENDIENTE) ?? 0;


    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosPendientes =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.PENDIENTE) ?? Enumerable.Empty<Producto_Individual>();
    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosDisponibles =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? Enumerable.Empty<Producto_Individual>();
    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosVendidos =>
        ProductosIndividuales?.Where(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO) ?? Enumerable.Empty<Producto_Individual>();
    [NotMapped]
    public Estados_LoteProductos Estado => ProductosIndividuales == null || ProductosIndividuales.Count == 0 ? Estados_LoteProductos.NO_DISPONIBLE :
        Fecha_Vencimiento < DateOnly.FromDateTime(DateTime.Now) ? Estados_LoteProductos.VENCIDO :
        Fecha_Vencimiento <= DateOnly.FromDateTime(DateTime.Now.AddDays(30)) ? Estados_LoteProductos.POR_VENCER :
        Estados_LoteProductos.DISPONIBLE;


    // Propiedades como metodos
    public int CantidadProductosDisponiblesEnInventario(int idInventario) => ProductosIndividuales
        ?.Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE && pi.Id_Inventario == idInventario) ?? 0;
}

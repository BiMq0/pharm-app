using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Inventario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public DateTime Ultima_Actualizacion { get; set; }

    public ICollection<Producto_Individual>? ProductosIndividuales { get; set; }
    public ICollection<Bitacora_Inventario>? BitacoraInventarios { get; set; }

    [NotMapped]
    public int CantidadProductos => ProductosIndividuales?.Count ?? 0;

    [NotMapped]
    public int CantidadTiposProducto => ProductosIndividuales?.Select(p => p.Producto).Distinct().Count() ?? 0;

    [NotMapped]
    public int CantidadProductosDisponibles => ProductosIndividuales
        ?.Count(p => p.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? 0;

    [NotMapped]
    public int CantidadProductosVendidos => ProductosIndividuales
        ?.Count(p => p.Estado == Estados_ProductosIndividuales.VENDIDO) ?? 0;

    [NotMapped]
    public int CantidadProductosPorVencer => ProductosIndividuales
        ?.Count(p => p.Estado == Estados_ProductosIndividuales.POR_VENCER) ?? 0;

    [NotMapped]
    public int CantidadProductosVencidos => ProductosIndividuales
        ?.Count(p => p.Estado == Estados_ProductosIndividuales.VENCIDO) ?? 0;
}

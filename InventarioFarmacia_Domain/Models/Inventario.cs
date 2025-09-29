using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Inventario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public DateTime Ultima_Actualizacion { get; set; }

    public ICollection<Lote>? LotesDeProducto { get; set; }
    public ICollection<Bitacora_Inventario>? BitacoraInventarios { get; set; }

    [NotMapped]
    public int CantidadProductos => LotesDeProducto?.Sum(l => l.CantidadProductos) ?? 0;

    [NotMapped]
    public int CantidadProductosDisponibles => LotesDeProducto
        ?.Sum(l => l.ProductosIndividuales?.Count(p => p.Estado == Estados_ProductosIndividuales.DISPONIBLE)) ?? 0;

    [NotMapped]
    public int CantidadProductosVendidos => LotesDeProducto
        ?.Sum(l => l.ProductosIndividuales?.Count(p => p.Estado == Estados_ProductosIndividuales.VENDIDO)) ?? 0;

    [NotMapped]
    public int CantidadProductosPorVencer => LotesDeProducto
        ?.Sum(l => l.ProductosIndividuales?.Count(p => p.Estado == Estados_ProductosIndividuales.POR_VENCER)) ?? 0;

    [NotMapped]
    public int CantidadProductosVencidos => LotesDeProducto
        ?.Sum(l => l.ProductosIndividuales?.Count(p => p.Estado == Estados_ProductosIndividuales.VENCIDO)) ?? 0;
}

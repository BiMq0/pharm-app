using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;
namespace InventarioFarmacia_Domain.Models;

public class Producto
{
    public int Id { get; set; }
    public int Id_Categoria { get; set; }
    public string? Nombre { get; set; }
    public string? Nombre_Clinico { get; set; }
    public string? Ruta_Imagen { get; set; }
    public int Existencias_Por_Caja { get; set; }
    public decimal Precio_Unitario { get; set; }
    public decimal Precio_Caja { get; set; }
    public bool Tiene_Subunidades { get; set; }
    public int? Unidades_Por_Existencia { get; set; }
    public int Total_Existencias_Por_Caja => Tiene_Subunidades ? Existencias_Por_Caja * (Unidades_Por_Existencia ?? 1) : Existencias_Por_Caja;
    public Categoria Categoria { get; set; } = null!;
    public ICollection<Bitacora_Producto> BitacoraProductos { get; set; } = new List<Bitacora_Producto>();
    public ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    [NotMapped]
    public int StockDisponible => Lotes.Where(l => l.Estado != Estados_LoteProductos.VENCIDO && l.Estado != Estados_LoteProductos.NO_DISPONIBLE)
        .Sum(l => l.ProductosIndividuales?.Count(pi => pi.Estado != Estados_ProductosIndividuales.VENDIDO) ?? 0);

    [NotMapped]
    public int StockVendido => Lotes.Sum(l => l.CantidadProductosVendidos);

    [NotMapped]
    public int StockVencido => Lotes.Where(l => l.Estado == Estados_LoteProductos.VENCIDO)
        .Sum(l => l.ProductosIndividuales?.Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? 0);

    [NotMapped]
    public int StockPorVencer => Lotes.Where(l => l.Estado == Estados_LoteProductos.POR_VENCER)
        .Sum(l => l.ProductosIndividuales?.Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE) ?? 0);

    [NotMapped]
    public bool TieneStockBajo => StockDisponible < 20;
}

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
    public int StockDisponible => Lotes.Sum(l => l.ProductosIndividuales!.Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE));

    [NotMapped]
    public int StockVendido => Lotes.Sum(l => l.ProductosIndividuales!.Count(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO));

    [NotMapped]
    public int StockVencido => Lotes.Sum(l => l.ProductosIndividuales!.Count(pi => pi.Estado == Estados_ProductosIndividuales.VENCIDO));

    [NotMapped]
    public int StockPorVencer => Lotes.Sum(l => l.ProductosIndividuales!.Count(pi => pi.Estado == Estados_ProductosIndividuales.POR_VENCER));

    [NotMapped]
    public bool TieneStockBajo => StockDisponible < 20;
}

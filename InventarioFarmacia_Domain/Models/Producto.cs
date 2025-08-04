using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;
namespace InventarioFarmacia_Domain.Models;

public class Producto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Nombre_Clinico { get; set; }
    public string? Ruta_Imagen { get; set; }
    public decimal Precio_Unitario { get; set; }
    public decimal Precio_Caja { get; set; }

    public ICollection<Producto_Individual> ProductosIndividuales { get; set; } = new List<Producto_Individual>();
    public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    public ICollection<Bitacora_Producto> BitacoraProductos { get; set; } = new List<Bitacora_Producto>();


    [NotMapped]
    public int StockDisponible => ProductosIndividuales
        .Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE);

    [NotMapped]
    public int StockVendido => ProductosIndividuales
        .Count(pi => pi.Estado == Estados_ProductosIndividuales.VENDIDO);

    [NotMapped]
    public int StockVencido => ProductosIndividuales
        .Count(pi => pi.Estado == Estados_ProductosIndividuales.VENCIDO);

    [NotMapped]
    public int StockPorVencer => ProductosIndividuales
        .Count(pi => pi.Estado == Estados_ProductosIndividuales.POR_VENCER);

    [NotMapped]
    public bool TieneStockBajo => StockDisponible < 20;
}

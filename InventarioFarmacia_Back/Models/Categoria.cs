using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioFarmacia_Back;

public class Categoria
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();


    [NotMapped]
    public int CantidadProductos => Productos.Count;

    [NotMapped]
    public int ProductosDisponibles => Productos.Sum(p => p.StockDisponible);
}

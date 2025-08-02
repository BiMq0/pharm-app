using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioFarmacia_Back;

public class Lote
{
    public int Id { get; set; }
    public string? Nro_Lote { get; set; }
    public ICollection<Producto_Individual> ProductosIndividuales { get; set; } = new List<Producto_Individual>();

    [NotMapped]
    public int CantidadProductos => ProductosIndividuales.Count;

    [NotMapped]
    public int CantidadProductosDisponibles => ProductosIndividuales
        .Count(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE);

    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosDisponibles =>
        ProductosIndividuales.Where(pi => pi.Estado == Estados_ProductosIndividuales.DISPONIBLE);

    [NotMapped]
    public IEnumerable<Producto_Individual> ProductosVencidos =>
        ProductosIndividuales.Where(pi => pi.Estado == Estados_ProductosIndividuales.VENCIDO);
}

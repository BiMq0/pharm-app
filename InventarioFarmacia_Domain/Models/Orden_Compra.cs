namespace InventarioFarmacia_Domain.Models;

using InventarioFarmacia_Domain.Constants;
public class Orden_Compra
{
    public int Id { get; set; }
    public DateOnly Fecha_Pedido { get; set; }
    public DateOnly Fecha_Recibo { get; set; }
    public Estados_OrdenDeCompra Estado { get; set; }

    public ICollection<Lote> Lotes { get; set; } = null!;

    public int Cantidad_Tipos_Producto => Lotes.GroupBy(l => l.Id_Producto).Count();
    public int Cantidad_Productos => Lotes.Sum(l => l.CantidadProductos);
    public decimal Costo_Total => Lotes.Sum(l => l.Producto.Precio_Unitario * l.CantidadProductos);

}

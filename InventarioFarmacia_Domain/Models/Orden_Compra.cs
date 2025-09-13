namespace InventarioFarmacia_Domain.Models;

using InventarioFarmacia_Domain.Constants;
public class Orden_Compra
{
    public int Id { get; set; }
    public DateOnly Fecha_Pedido { get; set; }
    public DateOnly Fecha_Recibo { get; set; }
    public Estados_OrdenDeCompra Estado { get; set; } = Estados_OrdenDeCompra.PENDIENTE;

    public ICollection<Lote>? LotesInvolucrados { get; set; } = null!;

    public int Cantidad_Tipos_Producto => LotesInvolucrados?.GroupBy(l => l.Id_Producto).Count() ?? 0;
    public int Cantidad_Productos => LotesInvolucrados?.Sum(l => l.CantidadProductos) ?? 0;
    public decimal Costo_Total => LotesInvolucrados?.Sum(l => l.Producto.Precio_Unitario * l.CantidadProductos) ?? 0;

}

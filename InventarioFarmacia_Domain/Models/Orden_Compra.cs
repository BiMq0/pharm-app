namespace InventarioFarmacia_Domain.Models;

using InventarioFarmacia_Domain.Constants;
public class Orden_Compra
{
    public int Id { get; set; }
    public DateOnly Fecha_Pedido { get; set; }
    public DateOnly Fecha_Recibo { get; set; }
    public Estados_OrdenDeCompra Estado { get; set; } = Estados_OrdenDeCompra.PENDIENTE;

    public ICollection<Lote>? LotesInvolucrados { get; set; } = new List<Lote>();

    public int Cantidad_Tipos_Producto =>
    LotesInvolucrados != null && LotesInvolucrados.Count > 0
        ? LotesInvolucrados.Where(l => l != null).GroupBy(l => l.Id_Producto).Count()
        : 0;

    public int Cantidad_Productos =>
        LotesInvolucrados != null && LotesInvolucrados.Count > 0
            ? LotesInvolucrados.Where(l => l != null).Sum(l => l.ProductosPendientes.Where(pi => pi.Id_OrdenCompra == l.Id_LastOrdenCompra).Count())
            : 0;

    public decimal Costo_Total =>
        LotesInvolucrados != null && LotesInvolucrados.Count > 0
            ? LotesInvolucrados.Where(l => l?.Producto != null)
                .Sum(l => l.Producto.Precio_Unitario * l.ProductosPendientes.Where(pi => pi.Id_OrdenCompra == l.Id_LastOrdenCompra).Count())
            : 0;

}

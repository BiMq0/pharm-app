namespace InventarioFarmacia_Domain.Models;

using InventarioFarmacia_Domain.Constants;
public class Orden_Compra
{
    public int Id { get; set; }
    public DateTime Fecha_Pedido { get; set; }
    public DateTime Fecha_Recibo { get; set; }
    public Estados_OrdenDeCompra Estado { get; set; }


    public ICollection<Detalle_Compra> DetalleCompras { get; set; } = new List<Detalle_Compra>();

    public int Cantidad_Productos => DetalleCompras.Count();
    public decimal Costo_Total => DetalleCompras.Sum(d => d.Precio);

}

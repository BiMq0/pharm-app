namespace InventarioFarmacia_Domain.Models;

public class Detalle_Venta
{
    public int Id { get; set; }
    public int Id_Venta { get; set; }
    public int Id_Producto { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Venta Venta { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
    public decimal Total_Final => Precio * Cantidad;
}

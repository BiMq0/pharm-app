using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioFarmacia_Back;

public class Venta
{
    public int Id { get; set; }
    public int? Id_Usuario { get; set; }
    public DateOnly Fecha_Venta { get; set; }
    public int Cantidad_Productos { get; set; }
    public decimal Costo_Total { get; set; }

    public Usuario? Usuario { get; set; }
    public ICollection<Detalle_Venta> DetalleVentas { get; set; } = new List<Detalle_Venta>();

    [NotMapped]
    public decimal TotalCalculado => DetalleVentas.Sum(dv => dv.Total_Final);

    [NotMapped]
    public int CantidadProductosCalculada => DetalleVentas.Sum(dv => dv.Cantidad);
}

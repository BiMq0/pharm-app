using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioFarmacia_Domain.Models;

public class Detalle_Compra
{
    public int Id { get; set; }
    public int Id_OrdenDeCompra { get; set; }
    public int Id_ProductoIndividual { get; set; }
    public decimal Precio { get; set; }

    public Producto_Individual ProductoIndividual { get; set; } = null!;
    public Orden_Compra OrdenCompra { get; set; } = null!;
}

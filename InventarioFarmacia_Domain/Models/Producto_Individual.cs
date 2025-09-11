using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Producto_Individual
{
    public int Id { get; set; }
    public int Id_Producto { get; set; }
    public int Id_Inventario { get; set; }
    public int Id_Lote { get; set; }
    public Estados_ProductosIndividuales Estado { get; set; } = Estados_ProductosIndividuales.DISPONIBLE;


    public Producto Producto { get; set; } = null!;
    public Lote Lote { get; set; } = null!;
    public Inventario Inventario { get; set; } = null!;
    public Detalle_Compra DetalleCompras { get; set; } = null!;
}

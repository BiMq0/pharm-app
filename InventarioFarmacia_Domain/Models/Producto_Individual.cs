using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Producto_Individual
{
    public int Id { get; set; }
    public int Id_Inventario { get; set; }
    public int Id_Lote { get; set; }
    public int Id_OrdenCompra { get; set; }
    public Estados_ProductosIndividuales Estado { get; set; } = Estados_ProductosIndividuales.PENDIENTE;
}

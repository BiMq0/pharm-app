using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Inventario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int Total_Productos { get; set; }
    public DateTime Ultima_Actualizacion { get; set; }

    public ICollection<Producto_Individual> ProductosIndividuales { get; set; } = new List<Producto_Individual>();
    public ICollection<Bitacora_Inventario> BitacoraInventarios { get; set; } = new List<Bitacora_Inventario>();

    [NotMapped]
    public int CantidadProductosDisponibles => ProductosIndividuales
        .Count(p => p.Estado == Estados_ProductosIndividuales.DISPONIBLE);

    [NotMapped]
    public int CantidadProductosVendidos => ProductosIndividuales
        .Count(p => p.Estado == Estados_ProductosIndividuales.VENDIDO);

    [NotMapped]
    public int CantidadProductosVencidos => ProductosIndividuales
        .Count(p => p.Estado == Estados_ProductosIndividuales.VENCIDO);
}

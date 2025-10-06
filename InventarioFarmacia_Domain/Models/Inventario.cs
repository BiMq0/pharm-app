using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Inventario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public DateTime Ultima_Actualizacion { get; set; }
    public ICollection<Lote>? LotesDeProducto { get; set; }
    public ICollection<Bitacora_Inventario>? BitacoraInventarios { get; set; }

    [NotMapped]
    public int CantidadProductosDisponibles => LotesDeProducto?.Where(l => l.Estado != Estados_LoteProductos.NO_DISPONIBLE)
        .Sum(l => l.ProductosIndividuales?.Count(pi => pi.Estado != Estados_ProductosIndividuales.VENDIDO && pi.Estado != Estados_ProductosIndividuales.PENDIENTE && pi.Id_Inventario == Id) ?? 0) ?? 0;
}

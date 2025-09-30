using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Shared.DTOs.Inventarios
{
    public class InventarioGeneralDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Ultima_Actualizacion { get; set; }
        public List<LoteSimpleToInventoryDTO>? Lotes { get; set; }
        public int CantidadProductos { get; set; }
        public int CantidadProductosDisponibles { get; set; }
        public int CantidadProductosPorVencer { get; set; }
        public int CantidadProductosVencidos { get; set; }

        public InventarioGeneralDTO(Inventario inventario)
        {
            Id = inventario.Id;
            Nombre = inventario.Nombre;
            Ultima_Actualizacion = inventario.Ultima_Actualizacion;
            Lotes = inventario.LotesDeProducto!.Select(l => new LoteSimpleToInventoryDTO(l, inventario.Id)).ToList();
            CantidadProductos = inventario.CantidadProductos;
            CantidadProductosDisponibles = inventario.CantidadProductosDisponibles;
            CantidadProductosPorVencer = inventario.CantidadProductosPorVencer;
            CantidadProductosVencidos = inventario.CantidadProductosVencidos;
        }
        public InventarioGeneralDTO()
        {

        }
    }
}

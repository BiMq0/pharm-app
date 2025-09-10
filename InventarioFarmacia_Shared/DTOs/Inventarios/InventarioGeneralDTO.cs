using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Inventarios
{
    public class InventarioGeneralDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Ultima_Actualizacion { get; set; }
        public int CantidadProductos { get; set; }
        public int CantidadTiposProducto { get; set; }
        public int CantidadProductosDisponibles { get; set; }
        public int CantidadProductosPorVencer { get; set; }
        public int CantidadProductosVencidos { get; set; }
        public InventarioGeneralDTO(Inventario inventario)
        {
            Id = inventario.Id;
            Nombre = inventario.Nombre;
            Ultima_Actualizacion = inventario.Ultima_Actualizacion;
            CantidadProductos = inventario.CantidadProductos;
            CantidadTiposProducto = inventario.CantidadTiposProducto;
            CantidadProductosDisponibles = inventario.CantidadProductosDisponibles;
            CantidadProductosPorVencer = inventario.CantidadProductosPorVencer;
            CantidadProductosVencidos = inventario.CantidadProductosVencidos;
        }
    }
}

using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Shared.DTOs.Inventarios
{
    public class InventarioGeneralDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<LoteSimpleToInventoryDTO>? Lotes { get; set; }
        public int CantidadProductosDisponibles { get; set; }
        public List<ProductoInfoToInventoryDTO>? Productos { get; set; }

        public InventarioGeneralDTO(Inventario inventario)
        {
            Id = inventario.Id;
            Nombre = inventario.Nombre;
            Lotes = inventario.LotesDeProducto!.Select(l => new LoteSimpleToInventoryDTO(l, inventario.Id)).ToList();
            CantidadProductosDisponibles = inventario.CantidadProductosDisponibles;
            Productos = Lotes!.GroupBy(l => l.Id_Producto).Select(l => l.First().Producto!).ToList();
        }
        public InventarioGeneralDTO()
        {

        }
    }
}

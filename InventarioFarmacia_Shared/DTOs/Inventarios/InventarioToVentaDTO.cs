using InventarioFarmacia_Shared.DTOs.Lotes;
using InventarioFarmacia_Shared.DTOs.Products;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Inventarios
{
    public class InventarioToVentaDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public List<LoteToVentaInventoryDTO>? Lotes { get; set; }
        public List<ProductoToVentaInventoryDTO>? Productos { get; set; }

        public InventarioToVentaDTO(Inventario inventario)
        {
            Id = inventario.Id;
            Nombre = inventario.Nombre;
            Lotes = inventario.LotesDeProducto!.Select(l => new LoteToVentaInventoryDTO(l, inventario.Id)).ToList();
            Productos = Lotes!.GroupBy(l => l.Id_Producto).Select(l => l.First().Producto!).ToList();
            Productos!.ForEach(p =>
            {
                p.Stock_Disponible = Lotes!.Where(l => l.Id_Producto == p.Id).Sum(l => l.CantidadProductosDisponibles);
            });
        }
        public InventarioToVentaDTO()
        {

        }
    }
}
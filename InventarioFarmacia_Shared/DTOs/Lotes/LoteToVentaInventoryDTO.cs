using System.Text.Json.Serialization;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToVentaInventoryDTO
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public string? Nro_Lote { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public int CantidadProductosDisponibles { get; set; }
        [JsonIgnore]
        public ProductoToVentaInventoryDTO? Producto { get; set; }

        public LoteToVentaInventoryDTO()
        {

        }

        public LoteToVentaInventoryDTO(Lote lote, int inventarioId)
        {
            Id = lote.Id;
            Id_Producto = lote.Id_Producto;
            Nro_Lote = lote.Nro_Lote;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            CantidadProductosDisponibles = lote.CantidadProductosDisponiblesEnInventario(inventarioId);
            Producto = new ProductoToVentaInventoryDTO(lote.Producto!);
        }
    }
}
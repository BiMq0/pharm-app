using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IDetalle_VentaService
{
    Task<IEnumerable<Detalle_Venta>> ObtenerDetallesVentaAsync();
    Task<IEnumerable<Detalle_Venta>> ObtenerDetallesPorVentaAsync(int ventaId);
    Task<Detalle_Venta> ObtenerDetallePorIdAsync(int id);
    Task<bool> CrearDetalleVentaAsync(Detalle_Venta detalleVenta);
    Task<bool> ActualizarDetalleVentaAsync(Detalle_Venta detalleVenta);
    Task<bool> EliminarDetalleVentaAsync(int id);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<DetalleVentaDTO>> ObtenerDetallesVentaDTOAsync();
    // Task<bool> CrearDetalleVentaAsync(DetalleVentaNuevoDTO detalle);
}

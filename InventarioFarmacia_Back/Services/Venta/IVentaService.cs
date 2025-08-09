using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IVentaService
{
    Task<IEnumerable<Venta>> ObtenerVentasAsync();
    Task<IEnumerable<Venta>> ObtenerVentasPorUsuarioAsync(int userId);
    Task<IEnumerable<Venta>> ObtenerVentasPorFechasAsync(DateOnly fechaInicio, DateOnly fechaFin);
    Task<Venta> ObtenerVentaPorIdAsync(int id);
    Task<bool> CrearVentaAsync(Venta venta);
    Task<bool> ActualizarVentaAsync(Venta venta);
    Task<bool> EliminarVentaAsync(int id);
    Task<decimal> CalcularTotalVentaAsync(int ventaId);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<VentaDTO>> ObtenerVentasDTOAsync();
    // Task<VentaDTO> ObtenerVentaDTOPorIdAsync(int id);
    // Task<bool> CrearVentaAsync(VentaNuevaDTO venta);
}

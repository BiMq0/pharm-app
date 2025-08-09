using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class Detalle_VentaService : IDetalle_VentaService
{
    private readonly IDetalle_VentaRepository _detalleVentaRepository;

    public Detalle_VentaService(IDetalle_VentaRepository detalleVentaRepository)
    {
        _detalleVentaRepository = detalleVentaRepository;
    }

    public async Task<IEnumerable<Detalle_Venta>> ObtenerDetallesVentaAsync()
    {
        return await _detalleVentaRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Detalle_Venta>> ObtenerDetallesPorVentaAsync(int ventaId)
    {
        return await _detalleVentaRepository.GetByVentaIdAsync(ventaId);
    }

    public async Task<Detalle_Venta> ObtenerDetallePorIdAsync(int id)
    {
        return await _detalleVentaRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearDetalleVentaAsync(Detalle_Venta detalleVenta)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la venta existe
        // TODO: Verificar disponibilidad del producto
        return await _detalleVentaRepository.AddAsync(detalleVenta);
    }

    public async Task<bool> ActualizarDetalleVentaAsync(Detalle_Venta detalleVenta)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el detalle existe
        return await _detalleVentaRepository.UpdateAsync(detalleVenta);
    }

    public async Task<bool> EliminarDetalleVentaAsync(int id)
    {
        // TODO: Verificar que el detalle existe
        return await _detalleVentaRepository.DeleteAsync(id);
    }
}

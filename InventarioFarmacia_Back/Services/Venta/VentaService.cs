using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IDetalle_VentaRepository _detalleVentaRepository;

    public VentaService(IVentaRepository ventaRepository, IDetalle_VentaRepository detalleVentaRepository)
    {
        _ventaRepository = ventaRepository;
        _detalleVentaRepository = detalleVentaRepository;
    }

    public async Task<IEnumerable<Venta>> ObtenerVentasAsync()
    {
        return await _ventaRepository.GetAllVentasAsync();
    }

    public async Task<IEnumerable<Venta>> ObtenerVentasPorUsuarioAsync(int userId)
    {
        return await _ventaRepository.GetVentasByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Venta>> ObtenerVentasPorFechasAsync(DateOnly fechaInicio, DateOnly fechaFin)
    {
        return await _ventaRepository.GetVentasByDatesAsync(fechaInicio, fechaFin);
    }

    public async Task<Venta> ObtenerVentaPorIdAsync(int id)
    {
        return await _ventaRepository.GetVentaByIdAsync(id);
    }

    public async Task<bool> CrearVentaAsync(Venta venta)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar disponibilidad de productos
        // TODO: Actualizar inventario
        return await _ventaRepository.AddVentaAsync(venta);
    }

    public async Task<bool> ActualizarVentaAsync(Venta venta)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la venta exists
        return await _ventaRepository.UpdateVentaAsync(venta);
    }

    public async Task<bool> EliminarVentaAsync(int id)
    {
        // TODO: Verificar que la venta exists
        // TODO: Restaurar inventario si es necesario
        return await _ventaRepository.DeleteVentaAsync(id);
    }

    public async Task<decimal> CalcularTotalVentaAsync(int ventaId)
    {
        // TODO: Implementar cálculo del total usando detalles de venta
        var detalles = await _detalleVentaRepository.GetByVentaIdAsync(ventaId);
        // TODO: Verificar propiedades correctas del modelo Detalle_Venta
        // return detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
        return 0; // Placeholder hasta definir las propiedades del modelo
    }
}

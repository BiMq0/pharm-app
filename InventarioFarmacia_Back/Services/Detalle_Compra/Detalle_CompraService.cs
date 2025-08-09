using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class Detalle_CompraService : IDetalle_CompraService
{
    private readonly IDetalle_CompraRepository _detalleCompraRepository;

    public Detalle_CompraService(IDetalle_CompraRepository detalleCompraRepository)
    {
        _detalleCompraRepository = detalleCompraRepository;
    }

    public async Task<IEnumerable<Detalle_Compra>> ObtenerDetallesCompraAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _detalleCompraRepository.GetAllAsync();
        }
        return await _detalleCompraRepository.GetAllAsync(filtro);
    }

    public async Task<IEnumerable<Detalle_Compra>> ObtenerDetallesPorCompraAsync(int compraId)
    {
        return await _detalleCompraRepository.GetByCompraIdAsync(compraId);
    }

    public async Task<Detalle_Compra> ObtenerDetallePorIdAsync(int id)
    {
        return await _detalleCompraRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearDetalleCompraAsync(Detalle_Compra detalleCompra)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la orden de compra exists
        // TODO: Verificar que el producto exists
        return await _detalleCompraRepository.AddAsync(detalleCompra);
    }

    public async Task<bool> ActualizarDetalleCompraAsync(Detalle_Compra detalleCompra)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el detalle exists
        return await _detalleCompraRepository.UpdateAsync(detalleCompra);
    }

    public async Task<bool> EliminarDetalleCompraAsync(int id)
    {
        // TODO: Verificar que el detalle exists
        return await _detalleCompraRepository.DeleteAsync(id);
    }
}

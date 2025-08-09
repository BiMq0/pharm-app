using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class Orden_CompraService : IOrden_CompraService
{
    private readonly IOrden_CompraRepository _ordenCompraRepository;
    private readonly IDetalle_CompraRepository _detalleCompraRepository;

    public Orden_CompraService(IOrden_CompraRepository ordenCompraRepository, IDetalle_CompraRepository detalleCompraRepository)
    {
        _ordenCompraRepository = ordenCompraRepository;
        _detalleCompraRepository = detalleCompraRepository;
    }

    public async Task<IEnumerable<Orden_Compra>> ObtenerOrdenesCompraAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _ordenCompraRepository.GetAllAsync();
        }
        return await _ordenCompraRepository.GetAllAsync(filtro);
    }

    public async Task<Orden_Compra> ObtenerOrdenCompraPorIdAsync(int id)
    {
        return await _ordenCompraRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearOrdenCompraAsync(Orden_Compra ordenCompra)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar datos del proveedor
        return await _ordenCompraRepository.AddAsync(ordenCompra);
    }

    public async Task<bool> ActualizarOrdenCompraAsync(Orden_Compra ordenCompra)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la orden existe
        return await _ordenCompraRepository.UpdateAsync(ordenCompra);
    }

    public async Task<bool> EliminarOrdenCompraAsync(int id)
    {
        // TODO: Verificar que la orden existe
        // TODO: Verificar que no esté procesada
        return await _ordenCompraRepository.DeleteAsync(id);
    }

    public async Task<bool> ProcesarOrdenCompraAsync(int ordenId)
    {
        // TODO: Implementar lógica de procesamiento
        // TODO: Actualizar inventario con los productos recibidos
        // TODO: Cambiar estado de la orden
        var orden = await _ordenCompraRepository.GetByIdAsync(ordenId);
        if (orden == null) return false;

        // Lógica de procesamiento aquí
        return true;
    }
}

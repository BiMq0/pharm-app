using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Back;

public class Producto_IndividualService : IProducto_IndividualService
{
    private readonly IProducto_IndividualRepository _productoIndividualRepository;

    public Producto_IndividualService(IProducto_IndividualRepository productoIndividualRepository)
    {
        _productoIndividualRepository = productoIndividualRepository;
    }

    public async Task<IEnumerable<Producto_Individual>> ObtenerProductosIndividualesAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _productoIndividualRepository.GetAllAsync();
        }
        return await _productoIndividualRepository.GetAllAsync(filtro);
    }

    public async Task<IEnumerable<Producto_Individual>> ObtenerProductosPorProductoAsync(int productId)
    {
        return await _productoIndividualRepository.GetAllByProductIdAsync(productId);
    }

    public async Task<IEnumerable<Producto_Individual>> ObtenerProductosPorEstadoAsync(Estados_ProductosIndividuales estado)
    {
        return await _productoIndividualRepository.GetAllProductByStateAsync(estado);
    }

    public async Task<IEnumerable<Producto_Individual>> ObtenerProductosProximosAVencerAsync()
    {
        return await _productoIndividualRepository.GetAllProductsAboutToExpire();
    }

    public async Task<Producto_Individual> ObtenerProductoIndividualPorIdAsync(int id)
    {
        return await _productoIndividualRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearProductoIndividualAsync(List<Producto_Individual> productosIndividuales)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el producto exists
        // TODO: Verificar que el lote exists
        return await _productoIndividualRepository.AddAsync(productosIndividuales);
    }

    public async Task<bool> ActualizarProductoIndividualAsync(Producto_Individual productoIndividual)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el producto individual exists
        return await _productoIndividualRepository.UpdateAsync(productoIndividual);
    }

    public async Task<bool> ActualizarEstadosPorFechaVencimientoAsync()
    {
        return await _productoIndividualRepository.UpdateStatesByExpirationDateAsync();
    }

    public async Task<bool> MarcarComoVendidoAsync(int productId)
    {
        return await _productoIndividualRepository.MarkAsSold(productId);
    }

    public async Task<bool> MarcarComoVencidoAsync(int productId)
    {
        return await _productoIndividualRepository.MarkAsExpired(productId);
    }

    public async Task<bool> MarcarComoProximoAVencerAsync(int productId)
    {
        return await _productoIndividualRepository.MarkAsAboutToExpire(productId);
    }
}

using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Shared.DTOs.Products.Individual;

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

    public async Task<IEnumerable<ProductoIndividualToLoteDTO>> ObtenerProductosPorLoteAsync(int loteId)
    {
        var productos = await _productoIndividualRepository.GetAllByLoteIdAsync(loteId);
        return productos.Select(p => new ProductoIndividualToLoteDTO(p));
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

    public async Task<bool> CrearProductoIndividualAsync(List<ProductoIndividualToNewCompraDTO> productosIndividuales)
    {
        var newProductos = productosIndividuales.Select(p => new Producto_Individual
        {
            Id_Producto = p.Id_Producto,
            Id_Lote = p.Id_Lote,
            Id_Inventario = p.Id_Inventario,
            Estado = p.Estado
        }).ToList();
        return await _productoIndividualRepository.AddAsync(newProductos);
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

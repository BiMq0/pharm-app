using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Shared.DTOs.Products.Individual;

namespace InventarioFarmacia_Back;

public interface IProducto_IndividualService
{
    Task<IEnumerable<Producto_Individual>> ObtenerProductosIndividualesAsync(string filtro = "");
    Task<IEnumerable<ProductoIndividualToLoteDTO>> ObtenerProductosPorLoteAsync(int loteId);
    Task<IEnumerable<Producto_Individual>> ObtenerProductosPorEstadoAsync(Estados_ProductosIndividuales estado);
    Task<IEnumerable<Producto_Individual>> ObtenerProductosProximosAVencerAsync();
    Task<Producto_Individual> ObtenerProductoIndividualPorIdAsync(int id);
    Task<bool> CrearProductoIndividualAsync(List<ProductoIndividualToNewCompraDTO> productoIndividuales);
    Task<bool> ActualizarProductoIndividualAsync(Producto_Individual productoIndividual);
    Task<bool> ActualizarEstadosPorFechaVencimientoAsync();
    Task<bool> MarcarComoVendidoAsync(int productId);
    Task<bool> MarcarComoVencidoAsync(int productId);
    Task<bool> MarcarComoProximoAVencerAsync(int productId);
}

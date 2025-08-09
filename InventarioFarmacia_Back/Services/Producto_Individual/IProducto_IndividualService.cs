using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IProducto_IndividualService
{
    Task<IEnumerable<Producto_Individual>> ObtenerProductosIndividualesAsync(string filtro = "");
    Task<IEnumerable<Producto_Individual>> ObtenerProductosPorProductoAsync(int productId);
    Task<IEnumerable<Producto_Individual>> ObtenerProductosPorEstadoAsync(Estados_ProductosIndividuales estado);
    Task<IEnumerable<Producto_Individual>> ObtenerProductosProximosAVencerAsync();
    Task<Producto_Individual> ObtenerProductoIndividualPorIdAsync(int id);
    Task<bool> CrearProductoIndividualAsync(Producto_Individual productoIndividual);
    Task<bool> ActualizarProductoIndividualAsync(Producto_Individual productoIndividual);
    Task<bool> ActualizarEstadosPorFechaVencimientoAsync();
    Task<bool> MarcarComoVendidoAsync(int productId);
    Task<bool> MarcarComoVencidoAsync(int productId);
    Task<bool> MarcarComoProximoAVencerAsync(int productId);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<ProductoIndividualDTO>> ObtenerProductosIndividualesDTOAsync(string filtro = "");
    // Task<ProductoIndividualDTO> ObtenerProductoIndividualDTOPorIdAsync(int id);
}

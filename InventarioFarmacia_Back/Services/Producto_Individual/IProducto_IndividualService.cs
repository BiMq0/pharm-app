using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Back;

public interface IProducto_IndividualService
{
    Task<IEnumerable<Producto_Individual>> ObtenerProductosIndividualesAsync(string filtro = "");
    Task<IEnumerable<Producto_Individual>> ObtenerProductosPorEstadoAsync(Estados_ProductosIndividuales estado);
    Task<Producto_Individual> ObtenerProductoIndividualPorIdAsync(int id);
    Task<bool> CrearProductoIndividualAsync(int cantidad, int idLote, int idOrdenCompra, int idInventario = 2);
    Task<bool> ActualizarProductoIndividualAsync(Producto_Individual productoIndividual);
    Task<bool> MarcarComoVendidoAsync(int productId);
    Task<bool> MarcarComoVencidoAsync(int productId);
    Task<bool> MarcarComoProximoAVencerAsync(int productId);
}

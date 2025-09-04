using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Front.Services.Products;

public interface IProductoService
{
    Task<IEnumerable<ProductoInfoCardDTO>> GetProductosAsync(string filtro = "");
    Task<ProductoDetalladoDTO> GetProductoPorIdAsync(int id);
    Task<ProductoEdicionDTO> GetProductoPorIdForEditAsync(int id);
    Task<IEnumerable<ProductoToNewCompraDTO>> GetProductosForOrdenAsync();
    Task<bool> CrearProducto(ProductoNuevoDTO producto);
    Task<bool> EditarProducto(ProductoEdicionDTO producto);
    Task<bool> EliminarProducto(int id);
}

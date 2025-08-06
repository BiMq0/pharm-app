using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IProductoService
{
    Task<IEnumerable<ProductoInfoCardDTO>> ObtenerProductosAsync(string filtro = "");
    Task<ProductoDetalladoDTO> ObtenerProductoPorIdAsync(int id);
    Task<bool> CrearProductoAsync(ProductoNuevoDTO producto);
}

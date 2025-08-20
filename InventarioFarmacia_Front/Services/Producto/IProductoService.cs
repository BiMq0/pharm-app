using InventarioFarmacia_Shared.DTOs.Products;
using InventarioFarmacia_Shared.DTOs.Categorias;

namespace InventarioFarmacia_Front.Services.Products;

public interface IProductoService
{
    Task<IEnumerable<ProductoInfoCardDTO>> GetProductosAsync(string filtro = "");
}

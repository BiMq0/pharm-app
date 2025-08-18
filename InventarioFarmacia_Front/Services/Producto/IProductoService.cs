using InventarioFarmacia_Shared.DTOs.Products;
namespace InventarioFarmacia_Front.Services.Products;

public interface IProductoService
{
    Task<List<ProductoInfoCardDTO>> GetProductosAsync(string filtro = "");
}

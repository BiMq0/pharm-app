using InventarioFarmacia_Shared;
namespace InventarioFarmacia_Front.Services;

public interface IProductoService
{
    Task<List<ProductoInfoCardDTO>> GetProductosAsync(string filtro = "");
}

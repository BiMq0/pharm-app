
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Back;

public interface IProducto_IndividualRepository
{
    Task<IEnumerable<Producto_Individual>> GetAllAsync();
    Task<IEnumerable<Producto_Individual>> GetAllAsync(string filtro);
    Task<IEnumerable<Producto_Individual>> GetAllByProductIdAsync(int productId);
    Task<IEnumerable<Producto_Individual>> GetAllProductByStateAsync(Estados_ProductosIndividuales estado);
    Task<IEnumerable<Producto_Individual>> GetAllProductsAboutToExpire();
    Task<Producto_Individual> GetByIdAsync(int id);
    Task<bool> AddAsync(List<Producto_Individual> productosIndividuales);
    Task<bool> UpdateAsync(Producto_Individual productoIndividual);
    Task<bool> UpdateStatesByExpirationDateAsync();
    Task<bool> MarkAsSold(int productId);
    Task<bool> MarkAsExpired(int productId);
    Task<bool> MarkAsAboutToExpire(int productId);
    Task<bool> DeleteAsync(int id);
}

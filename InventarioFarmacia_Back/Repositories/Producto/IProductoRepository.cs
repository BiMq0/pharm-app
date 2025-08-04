
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<IEnumerable<Producto>> GetAllAsync(string filtro);
    Task<Producto> GetByIdAsync(int id);
    Task<bool> AddAsync(Producto producto);
    Task<bool> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(int id);

}

using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public interface IInventarioRepository
{
    Task<IEnumerable<Inventario>> GetAllInventariosAsync();
    Task<Inventario> GetInventarioByIdAsync(int id);
    Task<bool> AddInventarioAsync(Inventario inventario);
    Task<bool> UpdateInventarioAsync(Inventario inventario);
    Task<bool> DeleteInventarioAsync(int id);
}

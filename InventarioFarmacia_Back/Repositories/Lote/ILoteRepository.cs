using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public interface ILoteRepository
{
    Task<IEnumerable<Lote>> GetAllLotesAsync();
    Task<IEnumerable<Lote>> GetAllForProductoAsync(int idProducto);
    Task<Lote> GetLoteByIdAsync(int id);
    Task<bool> AddLoteAsync(Lote lote);
    Task<bool> UpdateLoteAsync(Lote lote);
    Task<bool> DeleteLoteAsync(int id);
}

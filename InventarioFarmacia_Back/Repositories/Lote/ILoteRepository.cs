namespace InventarioFarmacia_Back;

public interface ILoteRepository
{
    Task<IEnumerable<Lote>> GetAllLotesAsync();
    Task<IEnumerable<Lote>> GetAllByNroLoteAsync(string nroLote);
    Task<Lote> GetLoteByIdAsync(int id);
    Task<bool> AddLoteAsync(Lote lote);
    Task<bool> UpdateLoteAsync(Lote lote);
    Task<bool> DeleteLoteAsync(int id);
}

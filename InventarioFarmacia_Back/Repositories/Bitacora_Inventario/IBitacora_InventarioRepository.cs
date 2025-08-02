namespace InventarioFarmacia_Back;

public interface IBitacora_InventarioRepository
{
    Task<IEnumerable<Bitacora_Inventario>> GetAllAsync();
    Task<IEnumerable<Bitacora_Inventario>> GetAllAsync(string filtro);
    Task<Bitacora_Inventario> GetByIdAsync(int id);
    Task<bool> AddAsync(Bitacora_Inventario bitacora);
    Task<bool> UpdateAsync(Bitacora_Inventario bitacora);
    Task<bool> DeleteAsync(int id);
}

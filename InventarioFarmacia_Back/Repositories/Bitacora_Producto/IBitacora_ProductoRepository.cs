namespace InventarioFarmacia_Back;

public interface IBitacora_ProductoRepository
{
    Task<IEnumerable<Bitacora_Producto>> GetAllAsync();
    Task<IEnumerable<Bitacora_Producto>> GetAllAsync(string filtro);
    Task<Bitacora_Producto> GetByIdAsync(int id);
    Task<bool> AddAsync(Bitacora_Producto bitacora);
    Task<bool> UpdateAsync(Bitacora_Producto bitacora);
    Task<bool> DeleteAsync(int id);
}

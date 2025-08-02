namespace InventarioFarmacia_Back;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<IEnumerable<Categoria>> GetAllAsync(string filtro);
    Task<Categoria> GetByIdAsync(int id);
    Task<bool> AddAsync(Categoria categoria);
    Task<bool> UpdateAsync(Categoria categoria);
    Task<bool> DeleteAsync(int id);
}

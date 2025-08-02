using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly PharmDBContext _dbContext;

    public CategoriaRepository(PharmDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _dbContext.Categorias
            .Include(c => c.CantidadProductos)
            .Include(c => c.Productos)
            .AsNoTracking().ToListAsync();
    }
    public async Task<IEnumerable<Categoria>> GetAllAsync(string filtro)
    {
        return await _dbContext.Categorias.Where(c => c.Id.ToString().Contains(filtro) ||
                                                    c.Nombre.Contains(filtro)
                                                )
                                        .Include(c => c.CantidadProductos)
                                        .Include(c => c.Productos)
                                        .AsNoTracking().ToListAsync();
    }
    public async Task<Categoria> GetByIdAsync(int id)
    {
        return await _dbContext.Categorias
            .Include(c => c.Productos)
            .Include(c => c.CantidadProductos)
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException($"No se encontro la categoria por id {id}");
    }
    public async Task<bool> AddAsync(Categoria categoria)
    {
        await _dbContext.Categorias.AddAsync(categoria);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }
    public async Task<bool> UpdateAsync(Categoria categoria)
    {
        _dbContext.Categorias.Update(categoria);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var categoria = _dbContext.Categorias.Find(id);
        if (categoria != null)
        {
            _dbContext.Remove(categoria);
            var resultado = await _dbContext.SaveChangesAsync();
            return resultado > 0;
        }
        else
        {
            throw new KeyNotFoundException($"No se encontro la categoria por id {id}");
        }
    }
}

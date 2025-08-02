using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class Bitacora_InventarioRepository : IBitacora_InventarioRepository
{
    private readonly PharmDBContext _dbContext;

    public Bitacora_InventarioRepository(PharmDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Bitacora_Inventario>> GetAllAsync()
    {
        return await _dbContext.Bitacora_Inventarios.AsNoTracking().ToListAsync();
    }
    public async Task<IEnumerable<Bitacora_Inventario>> GetAllAsync(string filtro)
    {
        return await _dbContext.Bitacora_Inventarios
            .Where(b =>
                b.Id.ToString().Contains(filtro) ||
                b.Id_Usuario.ToString().Contains(filtro) ||
                b.Id_Inventario.ToString().Contains(filtro) ||
                b.Fecha_Actualizacion.ToString().Contains(filtro) ||
                b.Tipo_Accion.ToString().Contains(filtro) ||
                b.Motivo.Contains(filtro))
                .AsNoTracking().ToListAsync();
    }
    public async Task<Bitacora_Inventario> GetByIdAsync(int id)
    {
        return await _dbContext.Bitacora_Inventarios.FindAsync(id) ?? throw new KeyNotFoundException($"Bitacora_Inventario con id {id} no encontrado.");
    }
    public async Task<bool> AddAsync(Bitacora_Inventario bitacora)
    {
        await _dbContext.Bitacora_Inventarios.AddAsync(bitacora);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }
    public async Task<bool> UpdateAsync(Bitacora_Inventario bitacora)
    {
        _dbContext.Bitacora_Inventarios.Update(bitacora);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var bitacora = await _dbContext.Bitacora_Inventarios.FindAsync(id);
        if (bitacora != null)
        {
            _dbContext.Bitacora_Inventarios.Remove(bitacora);
            var resultado = await _dbContext.SaveChangesAsync();
            return resultado > 0;
        }
        else
        {
            throw new KeyNotFoundException($"Bitacora_Inventario con id {id} no encontrado.");
        }
    }
}

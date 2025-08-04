using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class Bitacora_ProductoRepository : IBitacora_ProductoRepository
{
    private readonly PharmDBContext _dbContext;

    public Bitacora_ProductoRepository(PharmDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Bitacora_Producto>> GetAllAsync()
    {
        return await _dbContext.Bitacora_Productos.AsNoTracking().ToListAsync();
    }
    public async Task<IEnumerable<Bitacora_Producto>> GetAllAsync(string filtro)
    {
        return await _dbContext.Bitacora_Productos
            .Where(b =>
                b.Id.ToString().Contains(filtro) ||
                b.Id_Usuario.ToString().Contains(filtro) ||
                b.Id_Producto.ToString().Contains(filtro) ||
                b.Campo_Modificado.ToString().Contains(filtro) ||
                b.Valor_Anterior.ToString().Contains(filtro) ||
                b.Valor_Nuevo.ToString().Contains(filtro) ||
                b.Fecha_Cambio.ToString().Contains(filtro) ||
                b.Motivo.Contains(filtro)).AsNoTracking().ToListAsync();
    }
    public async Task<Bitacora_Producto> GetByIdAsync(int id)
    {
        return await _dbContext.Bitacora_Productos.FindAsync(id) ?? throw new KeyNotFoundException($"Bitacora_Producto con id {id} no encontrado.");
    }
    public async Task<bool> AddAsync(Bitacora_Producto bitacora)
    {
        await _dbContext.Bitacora_Productos.AddAsync(bitacora);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }
    public async Task<bool> UpdateAsync(Bitacora_Producto bitacora)
    {
        _dbContext.Bitacora_Productos.Update(bitacora);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var bitacora = await _dbContext.Bitacora_Productos.FindAsync(id);
        if (bitacora != null)
        {
            _dbContext.Bitacora_Productos.Remove(bitacora);
            var resultado = await _dbContext.SaveChangesAsync();

            return resultado > 0;
        }
        else
        {
            throw new KeyNotFoundException($"Bitacora_Producto con id {id} no encontrado.");
        }
    }
}

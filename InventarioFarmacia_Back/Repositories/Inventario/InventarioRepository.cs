using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;
namespace InventarioFarmacia_Back;

public class InventarioRepository : IInventarioRepository
{
    private readonly PharmDBContext _context;

    public InventarioRepository(PharmDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Inventario>> GetAllInventariosAsync()
    {
        return await _context.Inventarios
            .Include(i => i.LotesDeProducto)
                .ThenInclude(lp => lp.Producto)
            .Include(i => i.BitacoraInventarios)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Inventario> GetInventarioByIdAsync(int id)
    {
        return await _context.Inventarios
            .Include(i => i.LotesDeProducto)
                .ThenInclude(lp => lp.Producto)
            .Include(i => i.BitacoraInventarios)
            .FirstOrDefaultAsync(i => i.Id == id)
            ?? throw new KeyNotFoundException($"Inventario con id {id} no encontrado.");
    }

    public async Task<bool> AddInventarioAsync(Inventario inventario)
    {
        await _context.Inventarios.AddAsync(inventario);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateInventarioAsync(Inventario inventario)
    {
        _context.Inventarios.Update(inventario);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteInventarioAsync(int id)
    {
        var inventario = await GetInventarioByIdAsync(id);
        if (inventario == null) throw new KeyNotFoundException($"Inventario con id {id} no encontrado.");
        _context.Inventarios.Remove(inventario);
        return await _context.SaveChangesAsync() > 0;
    }
}

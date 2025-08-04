using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class LoteRepository : ILoteRepository
{
    private readonly PharmDBContext _context;

    public LoteRepository(PharmDBContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Lote>> GetAllLotesAsync()
    {
        return await _context.Lotes
            .Include(l => l.ProductosIndividuales)
                .ThenInclude(pi => pi.Producto)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Lote>> GetAllByNroLoteAsync(string nroLote)
    {
        return await _context.Lotes
            .Include(l => l.ProductosIndividuales)
            .ThenInclude(pi => pi.Producto)
            .Where(l => l.Nro_Lote == nroLote)
            .ToListAsync();
    }

    public async Task<Lote> GetLoteByIdAsync(int id)
    {
        return await _context.Lotes
            .Include(l => l.ProductosIndividuales)     // ← Unidades en el lote
                .ThenInclude(pi => pi.Producto)        // ← Información del producto
                    .ThenInclude(p => p.Categorias)    // ← Categorías del producto
            .FirstOrDefaultAsync(l => l.Id == id)
            ?? throw new KeyNotFoundException($"Lote con id {id} no encontrado.");
    }

    public async Task<bool> AddLoteAsync(Lote lote)
    {
        await _context.Lotes.AddAsync(lote);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateLoteAsync(Lote lote)
    {
        _context.Lotes.Update(lote);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteLoteAsync(int id)
    {
        var lote = await GetLoteByIdAsync(id);
        if (lote == null) throw new KeyNotFoundException($"Lote con id {id} no encontrado.");

        _context.Lotes.Remove(lote);
        return await _context.SaveChangesAsync() > 0;
    }
}

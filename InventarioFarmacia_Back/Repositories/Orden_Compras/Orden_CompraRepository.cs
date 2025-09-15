using InventarioFarmacia_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class Orden_CompraRepository : IOrden_CompraRepository
{
    private readonly PharmDBContext _dbContext;

    public Orden_CompraRepository(PharmDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Orden_Compra>> GetAllAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _dbContext.Orden_Compras
                                .Include(o => o.LotesInvolucrados!)
                                .ThenInclude(l => l.ProductosIndividuales)
                                .ToListAsync();
        }
        return await _dbContext.Orden_Compras
                                .Include(o => o.LotesInvolucrados!)
                                .ThenInclude(l => l.ProductosIndividuales)
                                .ToListAsync();
    }

    public async Task<Orden_Compra> GetByIdAsync(int id)
    {
        return await _dbContext.Orden_Compras.Include(o => o.LotesInvolucrados!)
                                            .ThenInclude(l => l.Producto)
                                            .ThenInclude(l => l.ProductosIndividuales)
                                            .FirstOrDefaultAsync(o => o.Id == id) ?? throw new KeyNotFoundException("Orden de compra no encontrada");
    }

    public async Task<Orden_Compra> AddAsync(Orden_Compra ordenCompra)
    {
        var ordenCompraNueva = await _dbContext.Orden_Compras.AddAsync(ordenCompra);
        await _dbContext.SaveChangesAsync();
        return ordenCompraNueva.Entity;
    }

    public async Task<bool> UpdateAsync(Orden_Compra ordenCompra)
    {
        _dbContext.Orden_Compras.Update(ordenCompra);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ordenCompra = await GetByIdAsync(id);
        if (ordenCompra == null) return false;

        _dbContext.Orden_Compras.Remove(ordenCompra);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}

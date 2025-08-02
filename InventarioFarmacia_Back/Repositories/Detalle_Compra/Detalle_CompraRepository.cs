using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class Detalle_CompraRepository : IDetalle_CompraRepository
{
    private readonly PharmDBContext _dbContext;

    public Detalle_CompraRepository(PharmDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Detalle_Compra>> GetAllAsync()
    {
        return await _dbContext.Detalle_Compras
                    .Include(dc => dc.OrdenCompra)
                    .Include(dc => dc.ProductoIndividual)
                    .AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Detalle_Compra>> GetAllAsync(string filtro)
    {
        return await _dbContext.Detalle_Compras
            .Where(d =>
                d.Id.ToString().Contains(filtro) ||
                d.Id_OrdenDeCompra.ToString().Contains(filtro) ||
                d.Id_ProductoIndividual.ToString().Contains(filtro) ||
                d.Precio.ToString().Contains(filtro))
                .Include(dc => dc.OrdenCompra)
                .Include(dc => dc.ProductoIndividual)
                .AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Detalle_Compra>> GetByCompraIdAsync(int compraId)
    {
        return await _dbContext.Detalle_Compras
            .Where(dc => dc.Id_OrdenDeCompra == compraId)
            .Include(dc => dc.OrdenCompra)
            .Include(dc => dc.ProductoIndividual)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Detalle_Compra> GetByIdAsync(int id)
    {
        return await _dbContext.Detalle_Compras
            .Include(dc => dc.OrdenCompra)
            .Include(dc => dc.ProductoIndividual)
            .FirstOrDefaultAsync(dv => dv.Id == id) ?? throw new KeyNotFoundException($"Detalle_Compra con id {id} no encontrado.");
    }

    public async Task<bool> AddAsync(Detalle_Compra detalle_Compra)
    {
        await _dbContext.Detalle_Compras.AddAsync(detalle_Compra);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }

    public async Task<bool> UpdateAsync(Detalle_Compra detalle_Compra)
    {
        _dbContext.Detalle_Compras.Update(detalle_Compra);
        var resultado = await _dbContext.SaveChangesAsync();
        return resultado > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var detalle_Compra = await _dbContext.Detalle_Compras.FindAsync(id);
        if (detalle_Compra != null)
        {
            _dbContext.Detalle_Compras.Remove(detalle_Compra);
            var resultado = await _dbContext.SaveChangesAsync();
            return resultado > 0;
        }
        else
        {
            throw new KeyNotFoundException($"Detalle_Compra con id {id} no encontrado.");
        }
    }
}

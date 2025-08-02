using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class Orden_CompraRepository : IOrden_CompraRepository
{
    private readonly PharmDBContext _context;

    public Orden_CompraRepository(PharmDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Orden_Compra>> GetAllAsync()
    {
        return await _context.Orden_Compras.Include(o => o.DetalleCompras).AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Orden_Compra>> GetAllAsync(string filtro)
    {
        return await _context.Orden_Compras
            .Where(o => o.Id.ToString().Contains(filtro) ||
                        o.Fecha_Pedido.ToString().Contains(filtro) ||
                        o.Fecha_Recibo.ToString().Contains(filtro) ||
                        o.Cantidad_Productos.ToString().Contains(filtro) ||
                        o.Costo_Total.ToString().Contains(filtro) ||
                        o.Estado.ToString().Contains(filtro)).Include(o => o.DetalleCompras)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Orden_Compra> GetByIdAsync(int id)
    {
        return await _context.Orden_Compras.Include(o => o.DetalleCompras).FirstOrDefaultAsync(o => o.Id == id) ?? throw new KeyNotFoundException($"Orden de compra con ID {id} no encontrada.");
    }

    public async Task<bool> AddAsync(Orden_Compra ordenCompra)
    {
        _context.Orden_Compras.Add(ordenCompra);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Orden_Compra ordenCompra)
    {
        _context.Orden_Compras.Update(ordenCompra);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ordenCompra = await GetByIdAsync(id);
        if (ordenCompra == null) throw new KeyNotFoundException($"Orden de compra con ID {id} no encontrada.");

        _context.Orden_Compras.Remove(ordenCompra);
        return await _context.SaveChangesAsync() > 0;
    }
}

using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class VentaRepository : IVentaRepository
{
    private readonly PharmDBContext _context;

    public VentaRepository(PharmDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Venta>> GetAllVentasAsync()
    {
        return await _context.Ventas
            .Include(v => v.Usuario)              // ← Quién hizo la venta
            .Include(v => v.DetalleVentas)        // ← Qué se vendió
                .ThenInclude(dv => dv.Producto) // ← Unidades específicas vendidas
                    .ThenInclude(pi => pi.ProductosIndividuales)       // ← Información del producto
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Venta>> GetVentasByUserIdAsync(int userId)
    {
        return await _context.Ventas
            .Include(v => v.Usuario)
            .Include(v => v.DetalleVentas)
                .ThenInclude(dv => dv.Producto)
                    .ThenInclude(pi => pi.ProductosIndividuales)
            .Where(v => v.Id_Usuario == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Venta>> GetVentasByDatesAsync(DateOnly startDate, DateOnly endDate)
    {
        return await _context.Ventas
            .Include(v => v.Usuario)
            .Include(v => v.DetalleVentas)
                .ThenInclude(dv => dv.Producto)
                    .ThenInclude(pi => pi.ProductosIndividuales)
            .Where(v => v.Fecha_Venta >= startDate && v.Fecha_Venta <= endDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Venta> GetVentaByIdAsync(int id)
    {
        return await _context.Ventas.FindAsync(id) ?? throw new KeyNotFoundException($"Venta con id {id} no encontrada.");
    }

    public async Task<bool> AddVentaAsync(Venta venta)
    {
        await _context.Ventas.AddAsync(venta);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateVentaAsync(Venta venta)
    {
        _context.Ventas.Update(venta);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteVentaAsync(int id)
    {
        var venta = await GetVentaByIdAsync(id);
        if (venta == null) return false;

        _context.Ventas.Remove(venta);
        return await _context.SaveChangesAsync() > 0;
    }
}

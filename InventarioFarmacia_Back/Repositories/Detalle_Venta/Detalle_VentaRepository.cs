using Microsoft.EntityFrameworkCore;

namespace InventarioFarmacia_Back;

public class Detalle_VentaRepository : IDetalle_VentaRepository
{
    private readonly PharmDBContext _context;

    public Detalle_VentaRepository(PharmDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Detalle_Venta>> GetAllAsync()
    {
        return await _context.Detalle_Ventas
            .Include(dv => dv.Venta)
            .Include(dv => dv.Producto).AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Detalle_Venta>> GetAllAsync(string filtro)
    {
        return await _context.Detalle_Ventas
            .Where(dv => dv.Id.ToString().Contains(filtro) ||
                         dv.Id_Venta.ToString().Contains(filtro) ||
                         dv.Id_Producto.ToString().Contains(filtro) ||
                         dv.Precio.ToString().Contains(filtro) ||
                         dv.Cantidad.ToString().Contains(filtro) ||
                         dv.Descuento.ToString().Contains(filtro) ||
                         dv.Total_Final.ToString().Contains(filtro))
            .Include(dv => dv.Venta)
            .Include(dv => dv.Producto)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Detalle_Venta>> GetByVentaIdAsync(int ventaId)
    {
        return await _context.Detalle_Ventas
            .Where(dv => dv.Id_Venta == ventaId)
            .Include(dv => dv.Venta)
            .Include(dv => dv.Producto)
            .ToListAsync();
    }

    public async Task<Detalle_Venta> GetByIdAsync(int id)
    {
        return await _context.Detalle_Ventas.FindAsync(id) ?? throw new KeyNotFoundException($"Detalle_Venta con Id {id} no encontrado.");
    }

    public async Task<bool> AddAsync(Detalle_Venta detalleVenta)
    {
        await _context.Detalle_Ventas.AddAsync(detalleVenta);
        var resultado = await _context.SaveChangesAsync();
        return resultado > 0;
    }

    public async Task<bool> UpdateAsync(Detalle_Venta detalleVenta)
    {
        _context.Detalle_Ventas.Update(detalleVenta);
        var resultado = await _context.SaveChangesAsync();
        return resultado > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var detalleVenta = await GetByIdAsync(id);
        if (detalleVenta != null)
        {
            _context.Detalle_Ventas.Remove(detalleVenta);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }
        else throw new KeyNotFoundException($"Detalle_Venta con Id {id} no encontrado.");
    }
}

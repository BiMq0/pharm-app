using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class ProductoRepository : IProductoRepository
{
    private readonly PharmDBContext _context;

    public ProductoRepository(PharmDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Lotes)
                .ThenInclude(p => p.ProductosIndividuales)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto>> GetAllForOrderAsync()
    {
        return await _context.Productos
            .Include(p => p.Lotes)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<IEnumerable<Producto>> GetAllAsync(string filtro)
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Lotes)
                .ThenInclude(p => p.ProductosIndividuales)
            .Where(p => p.Id.ToString().Contains(filtro)
                || (p.Nombre != null && p.Nombre.Contains(filtro))
                || (p.Nombre_Clinico != null && p.Nombre_Clinico.Contains(filtro))
                || p.Precio_Unitario.ToString().Contains(filtro)
                || p.Precio_Caja.ToString().Contains(filtro))
                .AsNoTracking()
                .ToListAsync();
    }

    public async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Lotes)
                .ThenInclude(p => p.ProductosIndividuales)
            .Include(p => p.BitacoraProductos)
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException($"Producto con id {id} no encontrado.");
    }

    public async Task<bool> AddAsync(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Producto producto)
    {
        _context.Productos.Update(producto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await GetByIdAsync(id);
        if (producto == null) throw new KeyNotFoundException($"Producto con id {id} no encontrado.");

        _context.Productos.Remove(producto);
        return await _context.SaveChangesAsync() > 0;
    }
}

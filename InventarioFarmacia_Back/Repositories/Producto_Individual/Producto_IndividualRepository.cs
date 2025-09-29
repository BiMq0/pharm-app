using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Back;

public class Producto_IndividualRepository : IProducto_IndividualRepository
{
    private readonly PharmDBContext _context;

    public Producto_IndividualRepository(PharmDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto_Individual>> GetAllAsync()
    {
        return await _context.Productos_Individuales
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto_Individual>> GetAllAsync(string filtro)
    {
        return await _context.Productos_Individuales
            .Where(p => p.Id.ToString().Contains(filtro)
                || p.Estado.ToString().Contains(filtro))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto_Individual>> GetAllByLoteIdAsync(int loteId)
    {
        return await _context.Productos_Individuales
            .Where(p => p.Id_Lote == loteId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto_Individual>> GetAllProductByStateAsync(Estados_ProductosIndividuales estado)
    {
        return await _context.Productos_Individuales
            .Where(p => p.Estado == estado)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Producto_Individual>> GetAllProductsAboutToExpire()
    {
        return await _context.Productos_Individuales
            .Where(p => p.Estado != Estados_ProductosIndividuales.VENDIDO)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Producto_Individual> GetByIdAsync(int id)
    {
        return await _context.Productos_Individuales
            .FirstOrDefaultAsync(pi => pi.Id == id)
            ?? throw new KeyNotFoundException($"Producto Individual con id {id} no encontrado.");
    }

    public async Task<bool> AddAsync(List<Producto_Individual> productosIndividuales)
    {
        await _context.Productos_Individuales.AddRangeAsync(productosIndividuales);
        return await _context.SaveChangesAsync() == productosIndividuales.Count;
    }

    public async Task<bool> UpdateAsync(Producto_Individual productoIndividual)
    {
        _context.Productos_Individuales.Update(productoIndividual);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> MarkAsSold(int productId)
    {
        var producto = await GetByIdAsync(productId);
        if (producto == null) return false;

        producto.Estado = Estados_ProductosIndividuales.VENDIDO;
        _context.Productos_Individuales.Update(producto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> MarkAsExpired(int productId)
    {
        var producto = await GetByIdAsync(productId);
        if (producto == null) return false;

        producto.Estado = Estados_ProductosIndividuales.VENCIDO;
        _context.Productos_Individuales.Update(producto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> MarkAsAboutToExpire(int productId)
    {
        var producto = await GetByIdAsync(productId);
        if (producto == null) return false;

        producto.Estado = Estados_ProductosIndividuales.POR_VENCER;
        _context.Productos_Individuales.Update(producto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await GetByIdAsync(id);
        if (producto == null) return false;

        _context.Productos_Individuales.Remove(producto);
        return await _context.SaveChangesAsync() > 0;
    }
}


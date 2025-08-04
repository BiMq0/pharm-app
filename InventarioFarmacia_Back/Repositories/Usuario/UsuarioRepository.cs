using Microsoft.EntityFrameworkCore;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly PharmDBContext _context;
    public UsuarioRepository(PharmDBContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
    {
        return await _context.Usuarios
            .Include(u => u.Ventas)                    // ← Ventas realizadas por el usuario
                .ThenInclude(v => v.DetalleVentas)     // ← Detalles de cada venta
            .Include(u => u.BitacoraInventarios)       // ← Movimientos de inventario que hizo
            .Include(u => u.BitacoraProductos)         // ← Cambios en productos que hizo
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<IEnumerable<Usuario>> GetAllUsuariosByNameAsync(string nombre)
    {
        return await _context.Usuarios
            .Include(u => u.Ventas)
            .Include(u => u.BitacoraInventarios)
            .Include(u => u.BitacoraProductos)
            .Where(u => u.Nombre != null && u.Nombre.Contains(nombre))
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.Ventas)                    // ← Historial de ventas
                .ThenInclude(v => v.DetalleVentas)     // ← Qué vendió específicamente
            .Include(u => u.BitacoraInventarios)       // ← Movimientos de inventario
            .Include(u => u.BitacoraProductos)         // ← Cambios en productos
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new KeyNotFoundException($"Usuario con id {id} no encontrado.");
    }
    public async Task<bool> AddUsuarioAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        var usuario = await GetUsuarioByIdAsync(id);
        _context.Usuarios.Remove(usuario);
        return await _context.SaveChangesAsync() > 0;
    }
}

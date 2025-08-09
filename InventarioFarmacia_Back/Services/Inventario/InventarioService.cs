using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _inventarioRepository;

    public InventarioService(IInventarioRepository inventarioRepository)
    {
        _inventarioRepository = inventarioRepository;
    }

    public async Task<IEnumerable<Inventario>> ObtenerInventariosAsync()
    {
        return await _inventarioRepository.GetAllInventariosAsync();
    }

    public async Task<Inventario> ObtenerInventarioPorIdAsync(int id)
    {
        return await _inventarioRepository.GetInventarioByIdAsync(id);
    }

    public async Task<bool> CrearInventarioAsync(Inventario inventario)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el producto existe
        return await _inventarioRepository.AddInventarioAsync(inventario);
    }

    public async Task<bool> ActualizarInventarioAsync(Inventario inventario)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el inventario existe
        return await _inventarioRepository.UpdateInventarioAsync(inventario);
    }

    public async Task<bool> EliminarInventarioAsync(int id)
    {
        // TODO: Verificar que el inventario existe
        // TODO: Verificar que no tenga movimientos pendientes
        return await _inventarioRepository.DeleteInventarioAsync(id);
    }

    public async Task<bool> ActualizarStockAsync(int inventarioId, int cantidad)
    {
        var inventario = await _inventarioRepository.GetInventarioByIdAsync(inventarioId);
        if (inventario == null) return false;

        // TODO: Implementar lógica de actualización de stock
        // inventario.Stock += cantidad;
        return await _inventarioRepository.UpdateInventarioAsync(inventario);
    }
}

using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Inventarios;

namespace InventarioFarmacia_Back;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _inventarioRepository;

    public InventarioService(IInventarioRepository inventarioRepository)
    {
        _inventarioRepository = inventarioRepository;
    }

    public async Task<IEnumerable<InventarioGeneralDTO>> ObtenerInventariosAsync()
    {
        var inventarios = await _inventarioRepository.GetAllInventariosAsync();
        return inventarios.Select(i => new InventarioGeneralDTO(i));
    }

    public async Task<InventarioGeneralDTO> ObtenerInventarioPorIdAsync(int id)
    {
        var inventario = await _inventarioRepository.GetInventarioByIdAsync(id);
        return inventario is not null ? new InventarioGeneralDTO(inventario) : null;
    }

    public async Task<bool> CrearInventarioAsync(InventarioNuevoDTO inventario)
    {
        var nuevoInventario = new Inventario
        {
            Nombre = inventario.Nombre,
        };
        return await _inventarioRepository.AddInventarioAsync(nuevoInventario);
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

using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IInventarioService
{
    Task<IEnumerable<Inventario>> ObtenerInventariosAsync();
    Task<Inventario> ObtenerInventarioPorIdAsync(int id);
    Task<bool> CrearInventarioAsync(Inventario inventario);
    Task<bool> ActualizarInventarioAsync(Inventario inventario);
    Task<bool> EliminarInventarioAsync(int id);
    Task<bool> ActualizarStockAsync(int inventarioId, int cantidad);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<InventarioDTO>> ObtenerInventariosDTOAsync();
    // Task<InventarioDTO> ObtenerInventarioDTOPorIdAsync(int id);
}

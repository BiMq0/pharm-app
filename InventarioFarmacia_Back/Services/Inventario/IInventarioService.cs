using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Inventarios;
namespace InventarioFarmacia_Back;

public interface IInventarioService
{
    Task<IEnumerable<InventarioGeneralDTO>> ObtenerInventariosAsync();
    Task<InventarioGeneralDTO> ObtenerInventarioPorIdAsync(int id);
    Task<bool> CrearInventarioAsync(InventarioNuevoDTO inventario);
    Task<bool> ActualizarInventarioAsync(Inventario inventario);
    Task<bool> EliminarInventarioAsync(int id);
    Task<bool> ActualizarStockAsync(int inventarioId, int cantidad);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<InventarioDTO>> ObtenerInventariosDTOAsync();
    // Task<InventarioDTO> ObtenerInventarioDTOPorIdAsync(int id);
}

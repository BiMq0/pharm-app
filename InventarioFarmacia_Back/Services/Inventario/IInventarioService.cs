using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Inventarios;
namespace InventarioFarmacia_Back;

public interface IInventarioService
{
    Task<IEnumerable<InventarioToListDTO>> ObtenerInventariosAsync();
    //Task<InventarioGeneralDTO> ObtenerInventarioPorIdAsync(int id);
    Task<Inventario> ObtenerInventarioPorIdAsync(int id);
    Task<bool> CrearInventarioAsync(InventarioNuevoDTO inventario);
    Task<bool> ActualizarInventarioAsync(Inventario inventario);
    Task<bool> EliminarInventarioAsync(int id);
    Task<bool> ActualizarStockAsync(List<Lote> lotes, int idInventario = 2);
}

using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Inventarios;
using InventarioFarmacia_Shared.DTOs.Lotes;
namespace InventarioFarmacia_Back;

public interface IInventarioService
{
    Task<IEnumerable<InventarioToListDTO>> ObtenerInventariosAsync();
    Task<InventarioGeneralDTO> ObtenerInventarioPorIdAsync(int id);
    Task<InventarioToVentaDTO> ObtenerInventarioParaVentaAsync(int id);
    Task<bool> CrearInventarioAsync(InventarioNuevoDTO inventario);
    Task<bool> EliminarInventarioAsync(int id);
    Task<bool> ActualizarStockAsync(List<Lote> lotes, int idInventario = 2);
}

using InventarioFarmacia_Shared.DTOs.Inventarios;


namespace InventarioFarmacia_Front.Services.Inventarios;

public interface IInventarioService
{
    Task<IEnumerable<InventarioToListDTO>> ObtenerTodosLosInventarios();
    Task<InventarioGeneralDTO> ObtenerInventarioGeneralAsync(int id);
}

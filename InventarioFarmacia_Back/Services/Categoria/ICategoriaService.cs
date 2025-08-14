using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Categorias;

namespace InventarioFarmacia_Back;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaInfoCardDTO>> ObtenerCategoriasAsync(string filtro = "");
    Task<CategoriaAllInfoDTO> ObtenerCategoriaPorIdAsync(int id);
    Task<bool> CrearCategoriaAsync(CategoriaNuevaDTO categoria);
    Task<bool> ActualizarCategoriaAsync(CategoriaNuevaDTO categoria);
    Task<bool> EliminarCategoriaAsync(int id);
}

using InventarioFarmacia_Shared.DTOs.Categorias;

namespace InventarioFarmacia_Front.Services.Categories;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaInfoCardDTO>> GetCategoriasAsync(string filtro = "");
    Task<CategoriaAllInfoDTO> GetCategoriaByIdAsync(int id);
    Task<CategoriaEdicionDTO> GetCategoriaByIdForEditAsync(int id);
    Task<bool> CreateCategoriaAsync(CategoriaNuevoDTO categoria);
    Task<bool> UpdateCategoriaAsync(CategoriaEdicionDTO categoria);
    Task<bool> DeleteCategoriaAsync(int id);
}

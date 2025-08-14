using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Front.Services.Categoria;

public interface ICategoriaService
{
    Task<List<CategoriaInfoCardDTO>> GetCategoriasAsync(string filtro = "");
    Task<CategoriaInfoCardDTO> GetCategoriaByIdAsync(int id);
    Task<CategoriaInfoCardDTO> CreateCategoriaAsync(CategoriaInfoCardDTO categoria);
    Task<CategoriaInfoCardDTO> UpdateCategoriaAsync(CategoriaInfoCardDTO categoria);
    Task<bool> DeleteCategoriaAsync(int id);
}

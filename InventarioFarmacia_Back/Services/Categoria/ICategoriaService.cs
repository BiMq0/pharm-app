using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> ObtenerCategoriasAsync(string filtro = "");
    Task<Categoria> ObtenerCategoriaPorIdAsync(int id);
    Task<bool> CrearCategoriaAsync(Categoria categoria);
    Task<bool> ActualizarCategoriaAsync(Categoria categoria);
    Task<bool> EliminarCategoriaAsync(int id);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<CategoriaDTO>> ObtenerCategoriasDTOAsync(string filtro = "");
    // Task<CategoriaDTO> ObtenerCategoriaDTOPorIdAsync(int id);
    // Task<bool> CrearCategoriaAsync(CategoriaNuevaDTO categoria);
}

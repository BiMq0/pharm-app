using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<IEnumerable<Categoria>> ObtenerCategoriasAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _categoriaRepository.GetAllAsync();
        }
        return await _categoriaRepository.GetAllAsync(filtro);
    }

    public async Task<Categoria> ObtenerCategoriaPorIdAsync(int id)
    {
        return await _categoriaRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearCategoriaAsync(Categoria categoria)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que no exista una categoría con el mismo nombre
        return await _categoriaRepository.AddAsync(categoria);
    }

    public async Task<bool> ActualizarCategoriaAsync(Categoria categoria)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la categoría existe
        return await _categoriaRepository.UpdateAsync(categoria);
    }

    public async Task<bool> EliminarCategoriaAsync(int id)
    {
        // TODO: Verificar que la categoría existe
        // TODO: Verificar que no tenga productos asociados
        return await _categoriaRepository.DeleteAsync(id);
    }
}

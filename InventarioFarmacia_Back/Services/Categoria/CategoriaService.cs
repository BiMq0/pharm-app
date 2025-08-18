using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Categorias;
namespace InventarioFarmacia_Back;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<IEnumerable<CategoriaInfoCardDTO>> ObtenerCategoriasAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return (await _categoriaRepository.GetAllAsync()).Select(c => new CategoriaInfoCardDTO(c));
        }
        return (await _categoriaRepository.GetAllAsync(filtro)).Select(c => new CategoriaInfoCardDTO(c));
    }

    public async Task<CategoriaAllInfoDTO> ObtenerCategoriaPorIdAsync(int id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria == null) return null!;
        return new CategoriaAllInfoDTO(categoria);
    }

    public async Task<bool> CrearCategoriaAsync(CategoriaNuevoDTO categoria)
    {
        var nuevaCategoria = new Categoria
        {
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion,
            Icono = categoria.Icono
        };
        return await _categoriaRepository.AddAsync(nuevaCategoria);
    }

    public async Task<bool> ActualizarCategoriaAsync(CategoriaEdicionDTO categoria)
    {
        var categoriaExistente = await _categoriaRepository.GetByIdAsync(categoria.Id);
        if (categoriaExistente == null) return false;

        categoriaExistente.Nombre = categoria.Nombre ?? categoriaExistente.Nombre;
        categoriaExistente.Descripcion = categoria.Descripcion ?? categoriaExistente.Descripcion;
        categoriaExistente.Icono = categoria.Icono ?? categoriaExistente.Icono;

        return await _categoriaRepository.UpdateAsync(categoriaExistente);
    }

    public async Task<bool> EliminarCategoriaAsync(int id)
    {
        return await _categoriaRepository.DeleteAsync(id);
    }
}

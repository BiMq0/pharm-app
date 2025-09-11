using InventarioFarmacia_Shared.DTOs.Products;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository, ICategoriaRepository categoriaRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<IEnumerable<ProductoInfoCardDTO>> ObtenerProductosAsync(string filtro = "")
    {
        if (filtro != "")
        {
            var productos = await _productoRepository.GetAllAsync(filtro);
            return productos.Select(p => new ProductoInfoCardDTO(p));
        }
        else
        {
            var productos = await _productoRepository.GetAllAsync();
            return productos.Select(p => new ProductoInfoCardDTO(p));
        }
    }

    public async Task<ProductoDetalladoDTO> ObtenerProductoPorIdAsync(int id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        return new ProductoDetalladoDTO(producto);
    }

    public async Task<bool> CrearProductoAsync(ProductoNuevoDTO productoDto)
    {
        var producto = new Producto
        {
            Id_Categoria = productoDto.Id_Categoria,
            Nombre = productoDto.Nombre,
            Nombre_Clinico = productoDto.Nombre_Clinico,
            Ruta_Imagen = productoDto.Ruta_Imagen,
            Precio_Unitario = productoDto.Precio_Unitario,
            Precio_Caja = productoDto.Precio_Caja,
            Existencias_Por_Caja = productoDto.Existencias_Por_Caja,
            Tiene_Subunidades = productoDto.Tiene_Subunidades,
            Unidades_Por_Existencia = productoDto.Unidades_Por_Existencia,
            Categoria = null!
        };

        return await _productoRepository.AddAsync(producto);
    }

    public async Task<bool> ActualizarProductoAsync(ProductoEdicionDTO productoEdicionDTO)
    {
        var productoExistente = await _productoRepository.GetByIdAsync(productoEdicionDTO.Id);
        if (productoExistente == null) return false;
        productoExistente.Id_Categoria = productoEdicionDTO.Id_Categoria;
        productoExistente.Nombre = productoEdicionDTO.Nombre ?? productoExistente.Nombre;
        productoExistente.Nombre_Clinico = productoEdicionDTO.Nombre_Clinico ?? productoExistente.Nombre_Clinico;
        productoExistente.Ruta_Imagen = productoEdicionDTO.Ruta_Imagen ?? productoExistente.Ruta_Imagen;
        productoExistente.Precio_Unitario = productoEdicionDTO.Precio_Unitario;
        productoExistente.Precio_Caja = productoEdicionDTO.Precio_Caja;
        productoExistente.Existencias_Por_Caja = productoEdicionDTO.Existencias_Por_Caja;
        productoExistente.Tiene_Subunidades = productoEdicionDTO.Tiene_Subunidades;
        productoExistente.Unidades_Por_Existencia = productoEdicionDTO.Unidades_Por_Existencia;

        return await _productoRepository.UpdateAsync(productoExistente);
    }

    public async Task<bool> EliminarProductoAsync(int id)
    {
        var productoExistente = await _productoRepository.GetByIdAsync(id);
        if (productoExistente == null) return false;

        return await _productoRepository.DeleteAsync(productoExistente.Id);
    }

    public async Task<IEnumerable<ProductoToNewCompraDTO>> ObtenerProductosParaCompraAsync()
    {
        var productos = await _productoRepository.GetAllForOrderAsync();
        return productos.Select(p => new ProductoToNewCompraDTO(p));
    }
}

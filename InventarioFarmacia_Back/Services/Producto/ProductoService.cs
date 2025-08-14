using InventarioFarmacia_Shared;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
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
            Nombre = productoDto.Nombre,
            Nombre_Clinico = productoDto.Nombre_Clinico,
            Ruta_Imagen = productoDto.Ruta_Imagen,
            Precio_Unitario = productoDto.Precio_Unitario,
            Precio_Caja = productoDto.Precio_Caja,
            Existencias_Por_Caja = productoDto.Existencias_Por_Caja,
            Tiene_Subunidades = productoDto.Tiene_Subunidades,
            Unidades_Por_Existencia = productoDto.Unidades_Por_Existencia,
            Categoria = productoDto.Categoria
        };

        return await _productoRepository.AddAsync(producto);
    }
}

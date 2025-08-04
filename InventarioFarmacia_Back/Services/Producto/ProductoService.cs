using InventarioFarmacia_Shared;

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

    public async Task<ProductoAllInfoDTO> ObtenerProductoPorIdAsync(int id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        return new ProductoAllInfoDTO(producto);
    }
}

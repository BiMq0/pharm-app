using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Back;

public class Producto_IndividualService : IProducto_IndividualService
{
    private readonly IProducto_IndividualRepository _productoIndividualRepository;

    public Producto_IndividualService(IProducto_IndividualRepository productoIndividualRepository)
    {
        _productoIndividualRepository = productoIndividualRepository;
    }

    public async Task<IEnumerable<Producto_Individual>> ObtenerProductosIndividualesAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _productoIndividualRepository.GetAllAsync();
        }
        return await _productoIndividualRepository.GetAllAsync(filtro);
    }

    public async Task<IEnumerable<Producto_Individual>> ObtenerProductosPorEstadoAsync(Estados_ProductosIndividuales estado)
    {
        return await _productoIndividualRepository.GetAllProductByStateAsync(estado);
    }

    public async Task<Producto_Individual> ObtenerProductoIndividualPorIdAsync(int id)
    {
        return await _productoIndividualRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearProductoIndividualAsync(int cantidad, int idLote, int idOrdenCompra, int idInventario = 2)
    {
        var productosIndividuales = new List<Producto_Individual>();
        for (int i = 0; i < cantidad; i++)
        {
            productosIndividuales.Add(new Producto_Individual
            {
                Id_Inventario = idInventario,
                Id_Lote = idLote,
                Id_OrdenCompra = idOrdenCompra,
            });
        }
        return await _productoIndividualRepository.AddAsync(productosIndividuales);
    }

    public async Task<bool> ActualizarEstadoProductosPorLoteAsync(IEnumerable<Producto_Individual> productos, Estados_ProductosIndividuales nuevoEstado)
    {
        var contador = 0;
        foreach (var producto in productos)
        {
            producto.Estado = nuevoEstado;
            if (await _productoIndividualRepository.UpdateAsync(producto))
            {
                contador++;
            }
        }
        return contador == productos.Count();
    }
    public async Task<bool> EliminarProductosPorOrdenCanceladaAsync(IEnumerable<Producto_Individual> productos)
    {
        var contador = 0;
        foreach (var producto in productos)
        {
            await _productoIndividualRepository.DeleteAsync(producto.Id);
        }
        return contador == productos.Count();
    }
    public async Task<bool> ActualizarInventarioAsync(Producto_Individual producto)
    {
        var resultado = await _productoIndividualRepository.UpdateAsync(producto);
        return resultado;
    }
}

using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;
using InventarioFarmacia_Shared.DTOs.Products.Individual;

namespace InventarioFarmacia_Back;

public class LoteService : ILoteService
{
    private readonly ILoteRepository _loteRepository;
    private readonly IProducto_IndividualService _productoService;

    private const int DIAS_ALERTA_VENCIMIENTO = 30;

    public LoteService(ILoteRepository loteRepository, IProducto_IndividualService productoService)
    {
        _loteRepository = loteRepository;
        _productoService = productoService;
    }

    public async Task<IEnumerable<Lote>> ObtenerLotesAsync()
    {
        return await _loteRepository.GetAllLotesAsync();
    }

    public async Task<IEnumerable<LoteToProductoDetalladoDTO>> ObtenerLotesPorIdProductoAsync(int idProducto)
    {
        var lotes = await _loteRepository.GetAllForProductoAsync(idProducto);
        return lotes.Select(lote => new LoteToProductoDetalladoDTO(lote));
    }

    public async Task<IEnumerable<LoteToNewCompraDTO>> ObtenerLotesPorIdProductoParaCompraAsync(int idProducto)
    {
        var lotes = await _loteRepository.GetAllForProductoAsync(idProducto);
        return lotes.Select(lote => new LoteToNewCompraDTO(lote));
    }

    public async Task<Lote> ObtenerLotePorIdAsync(int id)
    {
        return await _loteRepository.GetLoteByIdAsync(id);
    }

    public async Task<LoteToNewCompraDTO> CrearLoteAsync(LoteNuevoDTO lote, int idInventario = 2)
    {

        if (lote.Fecha_Vencimiento <= DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException("La fecha de vencimiento debe ser futura");

        if (string.IsNullOrWhiteSpace(lote.Nro_Lote)) throw new ArgumentException("El número de lote es requerido");

        var nuevoLote = new Lote
        {
            Id_Producto = lote.Id_Producto,
            Fecha_Vencimiento = lote.Fecha_Vencimiento,
            Nro_Lote = lote.Nro_Lote,
        };
        var loteCreado = await _loteRepository.AddLoteAsync(nuevoLote);
        return new LoteToNewCompraDTO(loteCreado);
    }


    public async Task<bool> ActualizarLoteAsync(LoteToNewCompraDTO lote, int cantidadProductos, int idLastOrdenCompra)
    {
        var loteExistente = await _loteRepository.GetLoteByIdAsync(lote.Id);
        if (loteExistente == null) return false;

        int diferenciaToCreate = cantidadProductos - loteExistente.CantidadProductos;
        var resultado = await CrearProductosIndividuales(loteExistente.Id_Producto, loteExistente.Id, diferenciaToCreate, 2, idLastOrdenCompra);

        if (!resultado) return false;
        else return await _loteRepository.UpdateLoteAsync(loteExistente);
    }
    private Task<bool> CrearProductosIndividuales(int idProducto, int idLote, int cantidad, int idInventario, int idLastOrdenCompra)
    {
        var productos = new List<ProductoIndividualToNewCompraDTO>();

        for (int i = 0; i < cantidad; i++)
        {
            productos.Add(new ProductoIndividualToNewCompraDTO
            {
                Id_Producto = idProducto,
                Id_Lote = idLote,
                Id_Inventario = idInventario,
                Id_OrdenCompra = idLastOrdenCompra
            });
        }
        var resultado = _productoService.CrearProductoIndividualAsync(productos);

        return resultado;
    }

    public async Task<bool> EliminarLoteAsync(int id)
    {
        var loteExistente = await _loteRepository.GetLoteByIdAsync(id);
        if (loteExistente == null) return false;

        if (loteExistente.ProductosIndividuales?.Any() == true)
        {
            throw new InvalidOperationException("No se puede eliminar un lote que tiene productos asociados.");
        }

        return await _loteRepository.DeleteLoteAsync(id);
    }

    public async Task<IEnumerable<Lote>> ObtenerLotesProximosAVencerAsync(int dias = DIAS_ALERTA_VENCIMIENTO)
    {
        var lotes = await _loteRepository.GetAllLotesAsync();
        var fechaLimite = DateOnly.FromDateTime(DateTime.Now.AddDays(dias));

        return lotes.Where(l => l.Fecha_Vencimiento <= fechaLimite && l.Fecha_Vencimiento >= DateOnly.FromDateTime(DateTime.Now));
    }
}

using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back;

public class LoteService : ILoteService
{
    private readonly ILoteRepository _loteRepository;
    private readonly IProducto_IndividualService _productoService;
    private readonly IInventarioService _inventarioService;

    private const int DIAS_ALERTA_VENCIMIENTO = 30;

    public LoteService(ILoteRepository loteRepository, IProducto_IndividualService productoService, IInventarioService inventarioService)
    {
        _loteRepository = loteRepository;
        _productoService = productoService;
        _inventarioService = inventarioService;
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

    public async Task<LoteToNewCompraDTO> CrearLoteAsync(LoteNuevoDTO lote)
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


    public async Task<bool> ActualizarLoteAsync(LoteToNewCompraDTO lote)
    {
        var loteExistente = await _loteRepository.GetLoteByIdAsync(lote.Id);
        if (loteExistente == null) return false;

        return await _loteRepository.UpdateLoteAsync(loteExistente);
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

    public async Task<bool> RealizarTransferenciaDeInventario(List<LoteToTransferProductsDTO> lotesToTransfer, int idInventarioDestino)
    {
        var lstLotes = new List<Lote>();
        foreach (var loteTransfer in lotesToTransfer)
        {
            var lote = await _loteRepository.GetLoteByIdAsync(loteTransfer.Id);
            if (lote == null)
            {
                continue;
            }
            lstLotes.Add(lote);

            foreach (var loteToTransfer in lotesToTransfer)
            {
                for (int i = 0; i < loteToTransfer.CantidadATransferir; i++)
                {
                    var productoIndividual = lote.ProductosIndividuales?.ToList()[i];
                    if (productoIndividual != null)
                    {
                        productoIndividual.Id_Inventario = idInventarioDestino;
                        await _productoService.ActualizarInventarioAsync(productoIndividual);
                    }
                }
            }
        }
        return await _inventarioService.ActualizarStockAsync(lstLotes, idInventarioDestino);
    }
}

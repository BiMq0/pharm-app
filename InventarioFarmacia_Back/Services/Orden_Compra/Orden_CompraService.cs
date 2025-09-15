using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Compras;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back;

public class Orden_CompraService : IOrden_CompraService
{
    private readonly IOrden_CompraRepository _ordenCompraRepository;
    private readonly ILoteService _loteService;

    public Orden_CompraService(IOrden_CompraRepository ordenCompraRepository, ILoteService loteService)
    {
        _ordenCompraRepository = ordenCompraRepository;
        _loteService = loteService;
    }

    public async Task<IEnumerable<CompraRegistroDTO>> ObtenerOrdenesCompraAsync(string filtro = "")
    {
        var ordenesDeCompra = await _ordenCompraRepository.GetAllAsync();
        if (string.IsNullOrEmpty(filtro))
        {
            return ordenesDeCompra.Select(oc => new CompraRegistroDTO(oc));
        }
        return ordenesDeCompra.Select(oc => new CompraRegistroDTO(oc));
    }

    public async Task<Orden_Compra> ObtenerOrdenCompraPorIdAsync(int id)
    {
        return await _ordenCompraRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearOrdenCompraAsync(ComprasNuevaDTO ordenCompra)
    {

        var nuevaCompra = new Orden_Compra
        {
            Fecha_Pedido = ordenCompra.Fecha_Pedido,
            Fecha_Recibo = ordenCompra.Fecha_Recibo,
        };

        var nuevaCompraCreada = await _ordenCompraRepository.AddAsync(nuevaCompra);

        nuevaCompraCreada.LotesInvolucrados = await Task.WhenAll(ordenCompra.LotesInvolucrados.Select(async loteDto =>
            {
                var lote = await _loteService.ObtenerLotePorIdAsync(loteDto.Id);
                lote.Id_LastOrdenCompra = nuevaCompraCreada.Id;
                await _loteService.ActualizarLoteAsync(new LoteToNewCompraDTO(lote));
                return lote;
            }
        ));

        return await ActualizarOrdenCompraAsync(nuevaCompraCreada);
    }

    public async Task<bool> ActualizarOrdenCompraAsync(Orden_Compra ordenCompra)
    {
        var ordenExistente = await _ordenCompraRepository.GetByIdAsync(ordenCompra.Id);
        if (ordenExistente == null) return false;

        ordenExistente.Fecha_Pedido = ordenCompra.Fecha_Pedido;
        ordenExistente.Fecha_Recibo = ordenCompra.Fecha_Recibo;

        var lotesActualizados = new List<Lote>();
        foreach (var lote in ordenCompra.LotesInvolucrados ?? Enumerable.Empty<Lote>())
        {
            await _loteService.ActualizarLoteAsync(new LoteToNewCompraDTO(lote));
            var trackedLote = await _loteService.ObtenerLotePorIdAsync(lote.Id);
            if (trackedLote != null)
                lotesActualizados.Add(trackedLote);
        }
        ordenExistente.LotesInvolucrados = lotesActualizados;

        return await _ordenCompraRepository.UpdateAsync(ordenExistente);
    }
    public async Task<bool> ProcesarOrdenCompraRecibidaAsync(int ordenId)
    {
        // TODO: Implementar lógica de procesamiento
        // TODO: Actualizar inventario con los productos recibidos
        // TODO: Cambiar estado de la orden
        var orden = await _ordenCompraRepository.GetByIdAsync(ordenId);
        if (orden == null) return false;

        // Lógica de procesamiento aquí
        return true;
    }

    public async Task<bool> ProcesarOrdenCompraCanceladaAsync(int id)
    {
        // TODO: Verificar que la orden existe
        // TODO: Verificar que no esté procesada
        return await _ordenCompraRepository.DeleteAsync(id);
    }
}

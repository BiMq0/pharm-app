using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Compras;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back;

public class Orden_CompraService : IOrden_CompraService
{
    private readonly IOrden_CompraRepository _ordenCompraRepository;
    private readonly ILoteService _loteService;
    private readonly IProducto_IndividualService _productoIndividualService;

    public Orden_CompraService(IOrden_CompraRepository ordenCompraRepository, ILoteService loteService, IProducto_IndividualService productoIndividualService)
    {
        _ordenCompraRepository = ordenCompraRepository;
        _loteService = loteService;
        _productoIndividualService = productoIndividualService;
    }

    public async Task<IEnumerable<CompraRegistroDTO>> ObtenerOrdenesCompraAsync(string filtro = "")
    {
        var ordenesFiltradas = string.IsNullOrEmpty(filtro)
            ? await _ordenCompraRepository.GetAllAsync()
            : (await _ordenCompraRepository.GetAllAsync()).Where(oc => oc.Estado.ToString().Contains(filtro, StringComparison.OrdinalIgnoreCase));

        return ordenesFiltradas.Select(oc => new CompraRegistroDTO(oc));

    }

    public async Task<CompraDetalladaDTO> ObtenerOrdenCompraPorIdAsync(int id)
    {
        var ordenCompra = await _ordenCompraRepository.GetByIdAsync(id);
        return ordenCompra != null ? new CompraDetalladaDTO(ordenCompra) : throw new KeyNotFoundException("Orden de compra no encontrada");
    }

    public async Task<bool> CrearOrdenCompraAsync(ComprasNuevaDTO ordenCompra)
    {
        var lotesToAdd = await Task.WhenAll(ordenCompra.LotesInvolucrados.Select(async loteDto =>
        {
            var lote = await _loteService.ObtenerLotePorIdAsync(loteDto.Id);
            if (lote == null) throw new Exception("Error al recuperar el lote.");
            return lote;
        }).ToList());

        var nuevaCompra = new Orden_Compra
        {
            Fecha_Pedido = ordenCompra.Fecha_Pedido,
            Fecha_Recibo = ordenCompra.Fecha_Recibo,
            LotesInvolucrados = lotesToAdd
        };

        var nuevaCompraCreada = await _ordenCompraRepository.AddAsync(nuevaCompra);

        foreach (var lote in ordenCompra.LotesInvolucrados)
        {
            await _productoIndividualService.CrearProductoIndividualAsync(lote.CantidadProductosPedidos, lote.Id, nuevaCompraCreada.Id, 2);
        }
        return nuevaCompraCreada != null;
    }

    public async Task<bool> ActualizarOrdenCompraAsync(Orden_Compra ordenCompra)
    {
        var ordenExistente = await _ordenCompraRepository.GetByIdAsync(ordenCompra.Id);
        if (ordenExistente == null) return false;

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

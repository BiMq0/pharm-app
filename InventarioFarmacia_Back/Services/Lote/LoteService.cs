using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back;

public class LoteService : ILoteService
{
    private readonly ILoteRepository _loteRepository;
    private readonly IProducto_IndividualRepository _productoIndividualRepository;

    public LoteService(ILoteRepository loteRepository, IProducto_IndividualRepository productoIndividualRepository)
    {
        _loteRepository = loteRepository;
        _productoIndividualRepository = productoIndividualRepository;
    }

    public async Task<IEnumerable<Lote>> ObtenerLotesAsync()
    {
        return await _loteRepository.GetAllLotesAsync();
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

    public async Task<bool> CrearLoteAsync(LoteNuevoDTO lote)
    {
        var nuevoLote = new Lote
        {
            Id_Producto = lote.Id_Producto,
            Fecha_Vencimiento = lote.Fecha_Vencimiento,
            Nro_Lote = lote.Nro_Lote,
        };
        var loteCreado = await _loteRepository.AddLoteAsync(nuevoLote);

        var lstProductosIndividuales = new List<Producto_Individual>();

        for (int i = 0; i < lote.Cantidad_Productos; i++)
        {
            lstProductosIndividuales.Add(new Producto_Individual
            {
                Id_Producto = lote.Id_Producto,
                Id_Lote = loteCreado.Id,
                Id_Inventario = 2,
                Estado = Estados_ProductosIndividuales.DISPONIBLE
            });
        }

        return loteCreado != null && await _productoIndividualRepository.AddAsync(lstProductosIndividuales);
    }

    public async Task<bool> ActualizarLoteAsync(LoteToNewCompraDTO lote)
    {
        var loteExistente = await _loteRepository.GetLoteByIdAsync(lote.Id);
        if (loteExistente == null) return false;

        var lstProductosIndividuales = new List<Producto_Individual>();
        for (int i = 0; i < lote.Cantidad_Productos; i++)
        {
            lstProductosIndividuales.Add(new Producto_Individual
            {
                Id_Producto = lote.Id_Producto,
                Id_Lote = loteExistente.Id,
                Id_Inventario = 2,
                Estado = Estados_ProductosIndividuales.DISPONIBLE
            });
        }

        loteExistente.Fecha_Vencimiento = lote.Fecha_Vencimiento;
        loteExistente.Nro_Lote = lote.Nro_Lote;
        lstProductosIndividuales.ForEach(pi => loteExistente.ProductosIndividuales?.Add(pi));

        return await _loteRepository.UpdateLoteAsync(loteExistente);
    }

    public async Task<bool> EliminarLoteAsync(int id)
    {
        // TODO: Verificar que el lote exists
        // TODO: Verificar que no tenga productos asociados
        return await _loteRepository.DeleteLoteAsync(id);
    }

    public async Task<IEnumerable<Lote>> ObtenerLotesProximosAVencerAsync(int dias = 30)
    {
        var lotes = await _loteRepository.GetAllLotesAsync();
        var fechaLimite = DateOnly.FromDateTime(DateTime.Now.AddDays(dias));

        return lotes.Where(l => l.Fecha_Vencimiento <= fechaLimite);
        //return lotes; 
    }
}

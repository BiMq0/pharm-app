using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back;

public interface ILoteService
{
    Task<IEnumerable<Lote>> ObtenerLotesAsync();
    Task<IEnumerable<LoteToProductoDetalladoDTO>> ObtenerLotesPorIdProductoAsync(int idProducto);
    Task<IEnumerable<LoteToNewCompraDTO>> ObtenerLotesPorIdProductoParaCompraAsync(int idProducto);
    Task<Lote> ObtenerLotePorIdAsync(int id);
    Task<LoteToNewCompraDTO> CrearLoteAsync(LoteNuevoDTO lote);
    Task<bool> ActualizarLoteAsync(LoteToNewCompraDTO lote);
    Task<bool> EliminarLoteAsync(int id);
    Task<IEnumerable<Lote>> ObtenerLotesProximosAVencerAsync(int dias = 30);
}

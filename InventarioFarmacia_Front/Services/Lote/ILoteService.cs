using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Front.Services.Lotes;

public interface ILoteService
{
    Task<IEnumerable<LoteToNewCompraDTO>> GetLotesAsync(string filtro = "");
    Task<LoteToNewCompraDTO?> GetLotePorIdAsync(int id);
    Task<IEnumerable<LoteToNewCompraDTO>> GetLotesPorProductoAsync(int productoId);
    Task<bool> CrearLoteAsync(LoteNuevoDTO lote);
    Task<bool> ActualizarLoteAsync(LoteToNewCompraDTO lote);
    Task<bool> EliminarLoteAsync(int id);
    Task<bool> ActualizarStockLoteAsync(int loteId, int nuevaCantidad);
    Task<bool> VerificarDisponibilidadAsync(int loteId, int cantidadRequerida);
}

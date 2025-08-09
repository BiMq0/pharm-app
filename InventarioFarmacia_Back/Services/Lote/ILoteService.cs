using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface ILoteService
{
    Task<IEnumerable<Lote>> ObtenerLotesAsync();
    Task<IEnumerable<Lote>> ObtenerLotesPorNumeroAsync(string nroLote);
    Task<Lote> ObtenerLotePorIdAsync(int id);
    Task<bool> CrearLoteAsync(Lote lote);
    Task<bool> ActualizarLoteAsync(Lote lote);
    Task<bool> EliminarLoteAsync(int id);
    Task<IEnumerable<Lote>> ObtenerLotesProximosAVencerAsync(int dias = 30);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<LoteDTO>> ObtenerLotesDTOAsync();
    // Task<LoteDTO> ObtenerLoteDTOPorIdAsync(int id);
}

using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class LoteService : ILoteService
{
    private readonly ILoteRepository _loteRepository;

    public LoteService(ILoteRepository loteRepository)
    {
        _loteRepository = loteRepository;
    }

    public async Task<IEnumerable<Lote>> ObtenerLotesAsync()
    {
        return await _loteRepository.GetAllLotesAsync();
    }

    public async Task<IEnumerable<Lote>> ObtenerLotesPorNumeroAsync(string nroLote)
    {
        return await _loteRepository.GetAllByNroLoteAsync(nroLote);
    }

    public async Task<Lote> ObtenerLotePorIdAsync(int id)
    {
        return await _loteRepository.GetLoteByIdAsync(id);
    }

    public async Task<bool> CrearLoteAsync(Lote lote)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que no exista un lote con el mismo número
        // TODO: Validar fecha de vencimiento
        return await _loteRepository.AddLoteAsync(lote);
    }

    public async Task<bool> ActualizarLoteAsync(Lote lote)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el lote existe
        return await _loteRepository.UpdateLoteAsync(lote);
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
        var fechaLimite = DateTime.Now.AddDays(dias);

        // TODO: Implementar filtro por fecha de vencimiento en el repositorio
        // TODO: Verificar propiedades correctas del modelo Lote
        // return lotes.Where(l => l.FechaVencimiento <= fechaLimite);
        return lotes; // Placeholder hasta definir las propiedades del modelo
    }
}

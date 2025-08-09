using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class Bitacoria_InventarioService : IBitacoria_InventarioService
{
    private readonly IBitacora_InventarioRepository _bitacoraInventarioRepository;

    public Bitacoria_InventarioService(IBitacora_InventarioRepository bitacoraInventarioRepository)
    {
        _bitacoraInventarioRepository = bitacoraInventarioRepository;
    }

    public async Task<IEnumerable<Bitacora_Inventario>> ObtenerBitacorasInventarioAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _bitacoraInventarioRepository.GetAllAsync();
        }
        return await _bitacoraInventarioRepository.GetAllAsync(filtro);
    }

    public async Task<Bitacora_Inventario> ObtenerBitacoraPorIdAsync(int id)
    {
        return await _bitacoraInventarioRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearBitacoraInventarioAsync(Bitacora_Inventario bitacora)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el inventario exists
        return await _bitacoraInventarioRepository.AddAsync(bitacora);
    }

    public async Task<bool> ActualizarBitacoraInventarioAsync(Bitacora_Inventario bitacora)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la bitácora exists
        return await _bitacoraInventarioRepository.UpdateAsync(bitacora);
    }

    public async Task<bool> EliminarBitacoraInventarioAsync(int id)
    {
        // TODO: Verificar que la bitácora exists
        return await _bitacoraInventarioRepository.DeleteAsync(id);
    }

    public async Task<bool> RegistrarMovimientoInventarioAsync(int inventarioId, string tipoMovimiento, int cantidad, string observaciones = "")
    {
        var bitacora = new Bitacora_Inventario
        {
            // TODO: Asignar propiedades según el modelo
            // InventarioId = inventarioId,
            // TipoMovimiento = tipoMovimiento,
            // Cantidad = cantidad,
            // Observaciones = observaciones,
            // Fecha = DateTime.Now
        };

        return await _bitacoraInventarioRepository.AddAsync(bitacora);
    }
}

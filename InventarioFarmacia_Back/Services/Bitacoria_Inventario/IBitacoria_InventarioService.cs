using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IBitacoria_InventarioService
{
    Task<IEnumerable<Bitacora_Inventario>> ObtenerBitacorasInventarioAsync(string filtro = "");
    Task<Bitacora_Inventario> ObtenerBitacoraPorIdAsync(int id);
    Task<bool> CrearBitacoraInventarioAsync(Bitacora_Inventario bitacora);
    Task<bool> ActualizarBitacoraInventarioAsync(Bitacora_Inventario bitacora);
    Task<bool> EliminarBitacoraInventarioAsync(int id);
    Task<bool> RegistrarMovimientoInventarioAsync(int inventarioId, string tipoMovimiento, int cantidad, string observaciones = "");
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<BitacoraInventarioDTO>> ObtenerBitacorasInventarioDTOAsync(string filtro = "");
    // Task<BitacoraInventarioDTO> ObtenerBitacoraDTOPorIdAsync(int id);
}

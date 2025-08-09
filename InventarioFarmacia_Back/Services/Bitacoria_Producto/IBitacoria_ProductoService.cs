using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IBitacoria_ProductoService
{
    Task<IEnumerable<Bitacora_Producto>> ObtenerBitacorasProductoAsync(string filtro = "");
    Task<Bitacora_Producto> ObtenerBitacoraPorIdAsync(int id);
    Task<bool> CrearBitacoraProductoAsync(Bitacora_Producto bitacora);
    Task<bool> ActualizarBitacoraProductoAsync(Bitacora_Producto bitacora);
    Task<bool> EliminarBitacoraProductoAsync(int id);
    Task<bool> RegistrarCambioProductoAsync(int productoId, string tipoOperacion, string observaciones = "");
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<BitacoraProductoDTO>> ObtenerBitacorasProductoDTOAsync(string filtro = "");
    // Task<BitacoraProductoDTO> ObtenerBitacoraDTOPorIdAsync(int id);
}

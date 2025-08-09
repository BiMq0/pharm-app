using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IDetalle_CompraService
{
    Task<IEnumerable<Detalle_Compra>> ObtenerDetallesCompraAsync(string filtro = "");
    Task<IEnumerable<Detalle_Compra>> ObtenerDetallesPorCompraAsync(int compraId);
    Task<Detalle_Compra> ObtenerDetallePorIdAsync(int id);
    Task<bool> CrearDetalleCompraAsync(Detalle_Compra detalleCompra);
    Task<bool> ActualizarDetalleCompraAsync(Detalle_Compra detalleCompra);
    Task<bool> EliminarDetalleCompraAsync(int id);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<DetalleCompraDTO>> ObtenerDetallesCompraDTOAsync(string filtro = "");
    // Task<bool> CrearDetalleCompraAsync(DetalleCompraNuevoDTO detalle);
}

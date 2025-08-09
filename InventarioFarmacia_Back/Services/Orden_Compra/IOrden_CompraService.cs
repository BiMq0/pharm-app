using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IOrden_CompraService
{
    Task<IEnumerable<Orden_Compra>> ObtenerOrdenesCompraAsync(string filtro = "");
    Task<Orden_Compra> ObtenerOrdenCompraPorIdAsync(int id);
    Task<bool> CrearOrdenCompraAsync(Orden_Compra ordenCompra);
    Task<bool> ActualizarOrdenCompraAsync(Orden_Compra ordenCompra);
    Task<bool> EliminarOrdenCompraAsync(int id);
    Task<bool> ProcesarOrdenCompraAsync(int ordenId);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<OrdenCompraDTO>> ObtenerOrdenesCompraDTOAsync(string filtro = "");
    // Task<OrdenCompraDTO> ObtenerOrdenCompraDTOPorIdAsync(int id);
    // Task<bool> CrearOrdenCompraAsync(OrdenCompraNuevaDTO orden);
}

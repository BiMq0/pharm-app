using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Compras;
namespace InventarioFarmacia_Back;

public interface IOrden_CompraService
{
    Task<IEnumerable<Orden_Compra>> ObtenerOrdenesCompraAsync(string filtro = "");
    Task<Orden_Compra> ObtenerOrdenCompraPorIdAsync(int id);
    Task<ComprasNuevaDTO> CrearOrdenCompraAsync(ComprasNuevaDTO ordenCompra);
    Task<bool> ActualizarOrdenCompraAsync(Orden_Compra ordenCompra);
    Task<bool> EliminarOrdenCompraAsync(int id);
}

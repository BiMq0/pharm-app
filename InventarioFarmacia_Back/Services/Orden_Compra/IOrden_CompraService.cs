using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Compras;
namespace InventarioFarmacia_Back;

public interface IOrden_CompraService
{
    Task<IEnumerable<CompraRegistroDTO>> ObtenerOrdenesCompraAsync(string filtro = "");
    Task<CompraDetalladaDTO> ObtenerOrdenCompraPorIdAsync(int id);
    Task<bool> CrearOrdenCompraAsync(ComprasNuevaDTO ordenCompra);
    Task<bool> ActualizarOrdenCompraAsync(Orden_Compra ordenCompra);
    Task<bool> ProcesarOrdenCompraRecibidaAsync(int ordenId);
    Task<bool> ProcesarOrdenCompraCanceladaAsync(int ordenId);
}

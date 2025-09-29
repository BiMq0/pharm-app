using InventarioFarmacia_Shared.DTOs.Compras;

namespace InventarioFarmacia_Front.Services.Compras
{

    public interface ICompraService
    {
        Task<IEnumerable<CompraRegistroDTO>> GetAllCompras();
        Task<CompraDetalladaDTO?> GetCompraById(int id);
        Task<bool> CreateOrdenCompra(ComprasNuevaDTO ordenCompra);
        Task<bool> ActualizarOrdenCompra(int idOrdenCompra, int codigoOperacion);
    }

}
using InventarioFarmacia_Shared.DTOs.Compras;

namespace InventarioFarmacia_Front.Services.Compras
{

    public interface ICompraService
    {
        Task<IEnumerable<CompraRegistroDTO>> GetAllCompras();
        Task<bool> CreateOrdenCompra(ComprasNuevaDTO ordenCompra);
    }

}
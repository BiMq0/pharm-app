namespace InventarioFarmacia_Back;

using InventarioFarmacia_Domain.Models;

public interface IOrden_CompraRepository
{
    Task<IEnumerable<Orden_Compra>> GetAllAsync(string filtro = "");
    Task<Orden_Compra> GetByIdAsync(int id);
    Task<Orden_Compra> AddAsync(Orden_Compra ordenCompra);
    Task<bool> UpdateAsync(Orden_Compra ordenCompra);
    Task<bool> DeleteAsync(int id);
}

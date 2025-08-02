namespace InventarioFarmacia_Back;

public interface IOrden_CompraRepository
{
    Task<IEnumerable<Orden_Compra>> GetAllAsync();
    Task<IEnumerable<Orden_Compra>> GetAllAsync(string filtro);
    Task<Orden_Compra> GetByIdAsync(int id);
    Task<bool> AddAsync(Orden_Compra ordenCompra);
    Task<bool> UpdateAsync(Orden_Compra ordenCompra);
    Task<bool> DeleteAsync(int id);
}

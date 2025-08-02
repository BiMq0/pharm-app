namespace InventarioFarmacia_Back;

public interface IDetalle_CompraRepository
{
    Task<IEnumerable<Detalle_Compra>> GetAllAsync();
    Task<IEnumerable<Detalle_Compra>> GetAllAsync(string filtro);
    Task<IEnumerable<Detalle_Compra>> GetByCompraIdAsync(int compraId);
    Task<Detalle_Compra> GetByIdAsync(int id);
    Task<bool> AddAsync(Detalle_Compra detalle_Compra);
    Task<bool> UpdateAsync(Detalle_Compra detalle_Compra);
    Task<bool> DeleteAsync(int id);
}

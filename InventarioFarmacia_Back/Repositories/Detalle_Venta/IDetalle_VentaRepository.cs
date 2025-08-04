using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public interface IDetalle_VentaRepository
{
    Task<IEnumerable<Detalle_Venta>> GetAllAsync();
    Task<IEnumerable<Detalle_Venta>> GetAllAsync(string filtro);
    Task<IEnumerable<Detalle_Venta>> GetByVentaIdAsync(int ventaId);
    Task<Detalle_Venta> GetByIdAsync(int id);
    Task<bool> AddAsync(Detalle_Venta detalleVenta);
    Task<bool> UpdateAsync(Detalle_Venta detalleVenta);
    Task<bool> DeleteAsync(int id);
}

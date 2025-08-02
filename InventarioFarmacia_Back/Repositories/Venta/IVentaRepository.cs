namespace InventarioFarmacia_Back;

public interface IVentaRepository
{
    Task<IEnumerable<Venta>> GetAllVentasAsync();
    Task<IEnumerable<Venta>> GetVentasByUserIdAsync(int userId);
    Task<IEnumerable<Venta>> GetVentasByDatesAsync(DateOnly startDate, DateOnly endDate);
    Task<Venta> GetVentaByIdAsync(int id);
    Task<bool> AddVentaAsync(Venta venta);
    Task<bool> UpdateVentaAsync(Venta venta);
    Task<bool> DeleteVentaAsync(int id);
}

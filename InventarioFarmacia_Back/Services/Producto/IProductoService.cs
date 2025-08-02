namespace InventarioFarmacia_Back;

public interface IProductoService
{
    Task<IEnumerable<Producto>> GetAllAsync();
}

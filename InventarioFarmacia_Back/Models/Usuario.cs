namespace InventarioFarmacia_Back;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Password { get; set; }

    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    public ICollection<Bitacora_Inventario> BitacoraInventarios { get; set; } = new List<Bitacora_Inventario>();
    public ICollection<Bitacora_Producto> BitacoraProductos { get; set; } = new List<Bitacora_Producto>();
}

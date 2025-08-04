namespace InventarioFarmacia_Domain.Models;

public class Bitacora_Inventario
{
    public int Id { get; set; }
    public int Id_Inventario { get; set; }
    public int Id_Usuario { get; set; }
    public string? Tipo_Accion { get; set; }
    public string? Motivo { get; set; }
    public DateTime Fecha_Actualizacion { get; set; }


    public Inventario Inventario { get; set; } = new Inventario();
}

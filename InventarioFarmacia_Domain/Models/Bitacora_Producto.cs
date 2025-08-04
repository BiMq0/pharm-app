namespace InventarioFarmacia_Domain.Models;

public class Bitacora_Producto
{
    public int Id { get; set; }
    public int Id_Producto { get; set; }
    public int Id_Usuario { get; set; }
    public DateTime Fecha_Cambio { get; set; }
    public string? Campo_Modificado { get; set; }
    public string? Valor_Anterior { get; set; }
    public string? Valor_Nuevo { get; set; }
    public string? Motivo { get; set; }
}

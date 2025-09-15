namespace InventarioFarmacia_Domain.Constants;

public enum Estados_OrdenDeCompra
{
    PENDIENTE,
    RECIBIDO,
    CANCELADO
}

public static class Colores_EstadosCompra
{
    public const string RECIBIDO = "#109aafff";
    public const string PENDIENTE = "#ffc107";
    public const string CANCELADO = "#dc3545";
}
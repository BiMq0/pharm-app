namespace InventarioFarmacia_Domain.Constants;

public enum Estados_ProductosIndividuales
{
    DISPONIBLE,
    VENDIDO,
    PENDIENTE,
    ORDEN_CANCELADA
}

public static class Colores_ProductosIndividuales
{
    public const string DISPONIBLE = "#28a745";
    public const string VENDIDO = "#109aafff";
    public const string PENDIENTE = "#6c757d";
    public const string ORDEN_CANCELADA = "#dc3545";
}
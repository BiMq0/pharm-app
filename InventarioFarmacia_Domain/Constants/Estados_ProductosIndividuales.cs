namespace InventarioFarmacia_Domain.Constants;

public enum Estados_ProductosIndividuales
{
    DISPONIBLE,
    VENDIDO,
    POR_VENCER,
    VENCIDO
}

public static class Colores_ProductosIndividuales
{
    public const string DISPONIBLE = "#28a745";
    public const string VENDIDO = "#109aafff";
    public const string POR_VENCER = "#ffc107";
    public const string VENCIDO = "#dc3545";

}
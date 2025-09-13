using System.ComponentModel.DataAnnotations.Schema;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Domain.Models;

public class Producto_Individual
{
    public int Id { get; set; }
    public int Id_Producto { get; set; }
    public int Id_Inventario { get; set; }
    public int Id_Lote { get; set; }
    public int Id_OrdenCompra { get; set; }
    public Estados_ProductosIndividuales Estado
    {
        get
        {
            if (OrdenCompra != null)
            {
                if (OrdenCompra.Estado == Estados_OrdenDeCompra.PENDIENTE) return Estados_ProductosIndividuales.PENDIENTE;
                else if (OrdenCompra.Estado == Estados_OrdenDeCompra.RECIBIDO)
                {
                    if (Lote.Fecha_Vencimiento.AddDays(30) > DateOnly.FromDateTime(DateTime.Now)) return Estados_ProductosIndividuales.DISPONIBLE;
                    else if (Lote.Fecha_Vencimiento > DateOnly.FromDateTime(DateTime.Now)) return Estados_ProductosIndividuales.POR_VENCER;
                    else return Estados_ProductosIndividuales.VENCIDO;
                }
                else return Estados_ProductosIndividuales.ORDEN_CANCELADA;
            }
            else return Estados_ProductosIndividuales.PENDIENTE;
        }
        set { }
    }

    public Producto Producto { get; set; } = null!;
    public Lote Lote { get; set; } = null!;
    public Inventario Inventario { get; set; } = null!;
    public Orden_Compra OrdenCompra { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Shared.DTOs.Compras
{
    public class ComprasNuevaDTO
    {
        public DateOnly Fecha_Pedido { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly Fecha_Recibo { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public Estados_OrdenDeCompra Estado { get; set; }

        public ICollection<Detalle_Compra>? DetalleCompras { get; set; }

        public int Cantidad_Tipos_Producto => DetalleCompras?.GroupBy(d => d.ProductoIndividual.Id_Producto).Count() ?? 0;
        public int Cantidad_Productos => DetalleCompras?.Count() ?? 0;
        public decimal Costo_Total => DetalleCompras?.Sum(d => d.Precio) ?? 0;

        public ComprasNuevaDTO()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.DTOs.Detalle_Ventas
{
    public class DetalleVentaNuevoDTO
    {
        public int Id_Venta { get; set; }
        public int Id_Producto { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Cantidad { get; set; }
        public DetalleVentaNuevoDTO()
        {

        }
    }
}
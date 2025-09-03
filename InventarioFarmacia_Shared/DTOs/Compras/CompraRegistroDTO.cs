using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Shared.DTOs.Compras
{
    public class CompraRegistroDTO
    {
        public int Id { get; set; }
        public Estados_OrdenDeCompra Estado { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Recibo { get; set; }
        public int Cantidad_Productos { get; }
        public decimal Costo_Total { get; }

        public CompraRegistroDTO(Orden_Compra ordenCompra)
        {
            Id = ordenCompra.Id;
            Estado = ordenCompra.Estado;
            Fecha_Pedido = ordenCompra.Fecha_Pedido;
            Fecha_Recibo = ordenCompra.Fecha_Recibo;
            Cantidad_Productos = ordenCompra.Cantidad_Productos;
            Costo_Total = ordenCompra.Costo_Total;
        }
    }
}
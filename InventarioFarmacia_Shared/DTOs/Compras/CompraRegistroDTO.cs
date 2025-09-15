using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Shared.DTOs.Compras
{
    public class CompraRegistroDTO
    {
        public int Id { get; set; }
        public Estados_OrdenDeCompra Estado { get; set; }
        public DateOnly Fecha_Pedido { get; set; }
        public DateOnly Fecha_Recibo { get; set; }
        public int Cantidad_Productos { get; }
        public decimal Costo_Total { get; }
        public IEnumerable<LoteToCompraRegistroDTO> LotesInvolucrados { get; set; } = new List<LoteToCompraRegistroDTO>();

        public CompraRegistroDTO(Orden_Compra ordenCompra)
        {
            Id = ordenCompra.Id;
            Estado = ordenCompra.Estado;
            Fecha_Pedido = ordenCompra.Fecha_Pedido;
            Fecha_Recibo = ordenCompra.Fecha_Recibo;
            Cantidad_Productos = ordenCompra.Cantidad_Productos;
            Costo_Total = ordenCompra.Costo_Total;
            LotesInvolucrados = ordenCompra.LotesInvolucrados!.Select(lote => new LoteToCompraRegistroDTO(lote)).ToList();
        }
    }
}
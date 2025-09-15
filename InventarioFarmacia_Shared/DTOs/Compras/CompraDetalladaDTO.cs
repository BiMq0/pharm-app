using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Shared.DTOs.Compras
{
    public class CompraDetalladaDTO
    {
        public int Id { get; set; }
        public DateOnly Fecha_Pedido { get; set; }
        public DateOnly Fecha_Recibo { get; set; }
        public Estados_OrdenDeCompra Estado { get; set; }
        public ICollection<LoteToCompraDetalladaDTO>? LotesInvolucrados { get; set; }

        // Analisar esta vaina jaklsdjgl;kasjbvunapbguisd
        public int Cantidad_Tipos_Producto { get; }
        public int Cantidad_Productos { get; }
        public decimal Costo_Total { get; }
        public CompraDetalladaDTO(Orden_Compra ordenCompra)
        {
            Id = ordenCompra.Id;
            Fecha_Pedido = ordenCompra.Fecha_Pedido;
            Fecha_Recibo = ordenCompra.Fecha_Recibo;
            Estado = ordenCompra.Estado;
            LotesInvolucrados = ordenCompra.LotesInvolucrados?.Select(lote => new LoteToCompraDetalladaDTO(lote)).ToList();

            Cantidad_Tipos_Producto = ordenCompra.LotesInvolucrados?.GroupBy(l => l.Id_Producto).Count() ?? 0;

            Cantidad_Productos = ordenCompra.LotesInvolucrados?.Sum(l => l.CantidadProductosPendientes) ?? 0;

            Costo_Total = LotesInvolucrados!.Sum(l => l.Costo_Total);
        }
        public CompraDetalladaDTO()
        {

        }
    }
}
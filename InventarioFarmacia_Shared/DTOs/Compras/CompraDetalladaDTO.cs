using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Lotes;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Shared.DTOs.Compras
{
    public class CompraDetalladaDTO
    {
        public int Id { get; set; }
        public DateOnly Fecha_Pedido { get; set; }
        public DateOnly Fecha_Recibo { get; set; }
        public Estados_OrdenDeCompra Estado { get; set; }
        public int CantidadTiposProductos { get; set; }
        public int CantidadTotalProductos { get; set; }
        public decimal CostoTotal { get; set; }
        public List<LoteToCompraDetalladaDTO> Lotes { get; set; }
        public List<ProductoInfoToCompraDetalladaDTO> Productos { get; set; }
        public CompraDetalladaDTO(Orden_Compra ordenCompra)
        {
            Id = ordenCompra.Id;
            Fecha_Pedido = ordenCompra.Fecha_Pedido;
            Fecha_Recibo = ordenCompra.Fecha_Recibo;
            Estado = ordenCompra.Estado;
            CantidadTiposProductos = ordenCompra.Cantidad_Tipos_Producto;
            CantidadTotalProductos = ordenCompra.Cantidad_Productos;
            CostoTotal = ordenCompra.Costo_Total;
            Lotes = ordenCompra.LotesInvolucrados!.Select(lote => new LoteToCompraDetalladaDTO(lote, Id)).ToList();
            Productos = Lotes.GroupBy(lote => lote.Producto).Select(g => g.First().Producto!).ToList();
        }
        public CompraDetalladaDTO()
        {

        }
    }
}
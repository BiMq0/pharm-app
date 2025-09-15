using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products.Individual;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToCompraDetalladaDTO
    {
        public int Id { get; set; }
        public int Id_LastOrdenCompra { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public string Nro_Lote { get; set; } = null!;
        public int CantidadProductosPendientes { get; set; }
        public ICollection<ProductoIndividualToNewCompraDTO>? ProductosPendientes { get; set; }

        public decimal Costo_Total { get; set; }
        public LoteToCompraDetalladaDTO(Lote lote)
        {
            Id = lote.Id;
            Id_LastOrdenCompra = (int)lote.Id_LastOrdenCompra!;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            Nro_Lote = lote.Nro_Lote!;
            CantidadProductosPendientes = lote.CantidadProductosPendientes;
            ProductosPendientes = lote.ProductosPendientes.Where(p => p.Id_OrdenCompra == Id_LastOrdenCompra).Select(p => new ProductoIndividualToNewCompraDTO(p)).ToList();
            Costo_Total = lote.Producto.Precio_Unitario * CantidadProductosPendientes;
        }

        public LoteToCompraDetalladaDTO()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Shared.DTOs.Lotes;
namespace InventarioFarmacia_Shared.DTOs.Compras
{
    public class ComprasNuevaDTO
    {
        public DateOnly Fecha_Pedido { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly Fecha_Recibo { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public Estados_OrdenDeCompra Estado { get; set; } = Estados_OrdenDeCompra.PENDIENTE;
        public ICollection<LoteToNewCompraDTO> LotesInvolucrados { get; set; }

        public ComprasNuevaDTO()
        {

        }
    }
}
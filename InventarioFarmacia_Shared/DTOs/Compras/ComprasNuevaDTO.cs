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
        public ICollection<LoteToCompraRegistroDTO> LotesInvolucrados { get; set; } = new List<LoteToCompraRegistroDTO>();

        public ComprasNuevaDTO()
        {

        }
    }
}
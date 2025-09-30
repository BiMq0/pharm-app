using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToCompraRegistroDTO
    {
        public int Id { get; set; }
        public string? Nro_Lote { get; set; }
        public int CantidadProductosPedidos { get; set; }

        public LoteToCompraRegistroDTO()
        {

        }

        public LoteToCompraRegistroDTO(Lote lote, int compraId)
        {
            Id = lote.Id;
            Nro_Lote = lote.Nro_Lote;
            CantidadProductosPedidos = lote.ProductosIndividuales!.Where(pi => pi.Id_OrdenCompra == compraId).Count();
        }
    }
}
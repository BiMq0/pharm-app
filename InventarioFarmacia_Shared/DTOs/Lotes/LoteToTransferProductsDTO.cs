using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToTransferProductsDTO
    {
        public int Id { get; set; }
        public int CantidadATransferir { get; set; }

        public LoteToTransferProductsDTO()
        {

        }
    }
}
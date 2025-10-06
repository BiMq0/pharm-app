using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Ventas
{
    public class VentaNuevaDTO
    {

        public DateTime Fecha_Venta { get; set; }

        public VentaNuevaDTO()
        {
        }
    }
}